﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace Polakken
{
    class DbHandler
    {
        //Status koder for tilkobling og oppretting til/av databasen
        private enum dbStatus :int { NEW = 0, EXISTING, SUCCESS, ERROR }
        
        //Navn til databasen
        private static string fileName = "Database.sdf";
        //passord for å koble til databasen, og koblingsvariabel. 
        private static string password = "fg8qaw890d89DS8";
        private string ConnectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", fileName, password);
        private SqlCeConnection _connection;
  
        //database tables & collums
        public static readonly int DB_VERSION = 1;
        public static readonly string TB_READINGS = "Readings";
        public static readonly string TB_READINGS_DATE = "Date";
        public static readonly string TB_READINGS_DEGREE = "Degree";
        public static readonly string TB_READINGS_STATUS = "Status";

        /**
         * Konstruktør for database håndtering, sjekker/oppretter eller kobler til databasen.  
         */
        public DbHandler()
        {
            //initialiserer databasen, henter ut status/resultat-kode
            int init_db_status = initDb();

            if (init_db_status == (int)dbStatus.NEW)
            {
                //gjør ingenting med dette foreløpig. 
            }
            else if (init_db_status == (int)dbStatus.EXISTING) 
            {
            
            }
        }

        private void OpenDb()
        {
            if (_connection == null)
                _connection = new SqlCeConnection(ConnectionString);

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }
        private void CloseDb() 
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        /**
         * PUBLIC METHODS: Her kan det lages flere metoder som polakken skal utnytte.
         */

        //public SqlCeResultSet getRowToDate(int dateTime)
        //{
        //    SqlCeResultSet result_set;
        //    return result_set;
        //}

        public SqlCeDataReader getAllRows() 
        {
            string sql = "select * from " + TB_READINGS; //Henter alt som ligger i readings tabellen. 
            return executeSql_Reader(sql);
        }
        
        /**
         * metoder som skal lages:
         * SetReading
         * GetReading
         * EditReading
         * DelReading
         * DelReadings 
        */

        public int SetReading(int C, int status) 
        {
            string sql = "sql kode";
            return executeSql_NonQuery(sql);
        }

        /**
         * END PUBLIC METHODS!
         */
        private SqlCeDataReader executeSql_Reader(string sql)
        {
            this.OpenDb();
            SqlCeCommand cmd = new SqlCeCommand(sql, _connection);
            SqlCeDataReader data_reader = null;
            try { data_reader = cmd.ExecuteReader(); }
            catch(SqlCeException){}
            catch(Exception){}
            finally{
                this.CloseDb();
            }
            return data_reader;
        }
        private int executeSql_NonQuery(string sql) 
        {
            //kobler til databasen og åpner den
            this.OpenDb();

            //Henter inn sql koden fra metode argumentet sql, og lager en sqlcommand sammen med koblingen til databasen.
            SqlCeCommand cmd = new SqlCeCommand(sql, _connection);

            //variabel som inneholder antall rader som blir påvirket av kommandoen
            int affectedRows = 0;

            //prøver å kjøre kommandoen. fanger opp errorer, men gjør ingenting med dem foreløpig. 
            try { affectedRows = cmd.ExecuteNonQuery(); }
            catch (SqlCeException){}
            catch (Exception){}
            finally
            {
                this.CloseDb();
            }
            return affectedRows;
        }

        private int initDb()
        {
            //sjekker om databasen allerede eksisterer
            if (File.Exists(fileName))
            {
                return (int)dbStatus.EXISTING;
            }
            else 
            {
                //Dersom den ikke eksisterer opprettes databasen. 
                SqlCeEngine en = new SqlCeEngine(ConnectionString);
                en.CreateDatabase();

                //lager tabeller i databasen vi nettop opprettet.
                int cT = createTables();
                if (cT != (int)dbStatus.SUCCESS) //bruker != success slik at dbstatus kan kodes med flere forskjellige error koder senere. 
                { 
                    //TODO: gi melding til bruker om at noe gikk galt - se log. 
                }
                return (int)dbStatus.NEW;
            }

        }

        private int createTables() {           
            //SQL koden som skal kjøres for oppretting av tabellene i databasen. 
            string sql = "create table " + TB_READINGS + " (" + TB_READINGS_DATE + " datetime not null, " + TB_READINGS_DEGREE + " integer, " + TB_READINGS_STATUS + " bit )"; 
            
            //Kjører SQL koden. Integeren i inneholder antall rader påvirket av kommandoen, dersom denne er 0 har noe feil skjedd. 
            int i = executeSql_NonQuery(sql);
            
            if (i != 0) 
                return (int)dbStatus.SUCCESS;
            else
                return (int)dbStatus.ERROR;
        }
    }
}