using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;
using System.Diagnostics;

namespace Polakken
{
    class DbHandler
    {
        private string thismodule = "DbHandler";

        //Status koder for tilkobling og oppretting til/av databasen
        private enum dbStatus : int { NEW = 0, EXISTING, SUCCESS, ERROR }

        //Navn til databasen
        private static readonly string fileName = "Database_v-1.sdf";
        //passord for å koble til databasen, og koblingsvariabel. 
        private static readonly string password = "fg8qaw890d89DS8";
        private string ConnectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", fileName, password);
        private SqlCeConnection _connection;

        //database tables & collums
        public static readonly string TB_READINGS = "Readings";
        public static readonly string TB_READINGS_DATE = "Date";
        public static readonly string TB_READINGS_DEGREE = "Degree";
        public static readonly string TB_READINGS_STATUS = "Status";

        //e-post tabell
        public static readonly string TB_EMAIL = "Email";
        public static readonly string TB_EMAIL_NUMBER = "ID";
        public static readonly string TB_EMAIL_ADRESS = "Adress";

        /**
         * Konstruktør for database håndtering, sjekker/oppretter eller kobler til databasen.  
         */
        public DbHandler()
        {
            Logger.Info("Starter konstruksjon", thismodule);
            //initialiserer databasen, henter ut status/resultat-kode
            int init_db_status = initDb();

            //if (init_db_status == (int)dbStatus.NEW)
            //{
            //    Debug.WriteLine("-- CONSTRUCTOR: Ny database, kjører CreateDummyValues()");
            //    gjør ingenting med dette foreløpig. 

            //    lager eksempel verdier for testing, fjern dette før release
            //    CreateDummyValues();
            //}
            //else if (init_db_status == (int)dbStatus.EXISTING)
            //{

            //}
            //Debug.WriteLine("-- CONSTRUCTOR: Starter debugging test");
            //DebugginTestTwo();
        }
        
        public void OpenDb()
        {
            if (_connection == null)
                _connection = new SqlCeConnection(ConnectionString);

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }
        public void CloseDb()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        /**
         * PUBLIC METHODS: Her kan det lages flere metoder som polakken skal utnytte.
         */
        
        public int DelReadings(DateTime fraDato, DateTime tilDato) //Sletter oppføringer i temp-databasen fra-til dato
        {
            string sql = string.Format("delete from {0} where {1} < '{2}' and {1} > '{3}'", TB_READINGS, TB_READINGS_DATE, tilDato, fraDato);
            return executeSql_NonQuery(sql);
        }

        public int DelReading(DateTime datetime) // Sletter en oppføring i databasen for temperaturer
        {
            string sql = string.Format("delete from {0} where {1} = {2}", TB_READINGS, TB_READINGS_DATE, datetime);
            return executeSql_NonQuery(sql);
        }

        public int DelEmail(int idnr) // Sletter en oppføring i databasen for e-post
        {
            string sql = string.Format("delete from {0} where {1} = {2}", TB_EMAIL, TB_EMAIL_ADRESS, idnr);
            return executeSql_NonQuery(sql);
        }

        public SqlCeDataReader GetLastReading() //henter siste måling fra temp-databasen
        {
            string sql = string.Format("select {0}, {1}, {2} from {3} " +
            "where {0} = (select max({0}) form {3} as b)",
            TB_READINGS_DATE,
            TB_READINGS_DEGREE,
            TB_READINGS_STATUS,
            TB_READINGS);
            return executeSql_Reader(sql);
        }

        public SqlCeDataReader GetReadingToDate(DateTime dateTime) //henter ut en selektert oppføring i tempdatabasen
        {
            string sql = string.Format("select * from {0} where {1} = '{2}'", TB_READINGS, TB_READINGS_DATE, dateTime);
            return executeSql_Reader(sql);
        }

        public SqlCeDataReader GetEmails()
        {
            string sql = string.Format("select * from {0}", TB_EMAIL); //Henter alt som ligger i email tabellen. 
            return executeSql_Reader(sql);
        }

        public SqlCeDataReader GetReadings()
        {
            string sql = string.Format("select * from {0}", TB_READINGS); //Henter alt som ligger i readings tabellen. 
            return executeSql_Reader(sql);
        }


        //public int SetReading(DateTime time, int C, Boolean status) //Sender parameterne videre

        
        public int SetReading(DateTime time, int C, Boolean status)

        {
            return executeSql_NonQuery(time, C, status);
        }

        public int AddEmail(string email) //legger til epost i epostdatabasen
        {
            return executeSql_NonQuery_Email(email);
        }

        /**
         * END PUBLIC METHODS!
         */

        ///<summary>
        /// MERK: Denne metoden trenger at dbhandler objektet åpnes før kjøring, og lukkes etterpå, ved .OpenDb() og .CloseDb()
        ///</summary>
        private SqlCeDataReader executeSql_Reader(string sql)
        {
            //this.OpenDb();
            SqlCeCommand cmd = new SqlCeCommand(sql, _connection);
            SqlCeDataReader data_reader = null;
            try { data_reader = cmd.ExecuteReader(); }
            catch (SqlCeException ssceE)
            {
                Logger.Error(ssceE, thismodule);
            }
            catch (Exception e)
            {
                Logger.Error(e, thismodule);
            }
            finally
            {
                //this.CloseDb();
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
            catch (SqlCeException ssceE)
            {
                Logger.Error(ssceE, thismodule);
            }
            catch (Exception e)
            {
                Logger.Error(e, thismodule);
            }
            finally
            {
                this.CloseDb();
            }
            return affectedRows;
        }

        private int executeSql_NonQuery(DateTime time, int C, Boolean status)
        {
            // sql-spørringen
            string sql = "insert into " + TB_READINGS + "(" + TB_READINGS_DATE + ", " + TB_READINGS_DEGREE + ", " + TB_READINGS_STATUS + ") values(@date, @value, @status)";
            
            //kobler til databasen og åpner den
            this.OpenDb();

            //Henter inn sql koden fra metode argumentet sql, og lager en sqlcommand sammen med koblingen til databasen.
            SqlCeCommand cmd;

            //variabel som inneholder antall rader som blir påvirket av kommandoen
            int affectedRows = 0;

            //prøver å kjøre kommandoen. fanger opp errorer, men gjør ingenting med dem foreløpig. 
            try
            {
                cmd = new SqlCeCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@date", time);
                cmd.Parameters.AddWithValue("@value", C);
                cmd.Parameters.AddWithValue("@status", status);
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (SqlCeException ssceE)
            {
                Logger.Error(ssceE, thismodule);
            }
            catch (Exception e)
            {
                Logger.Error(e, thismodule);
            }
            finally
            {
                this.CloseDb();
            }
            return affectedRows;
        }

        private int executeSql_NonQuery_Email(string email)
        {
            // sql-spørringen
            string sql = "insert into " + TB_EMAIL + "(" + TB_EMAIL_ADRESS + ") values(@email)";

            //kobler til databasen og åpner den
            this.OpenDb();

            //Henter inn sql koden fra metode argumentet sql, og lager en sqlcommand sammen med koblingen til databasen.
            SqlCeCommand cmd;

            //variabel som inneholder antall rader som blir påvirket av kommandoen
            int affectedRows = 0;

            //prøver å kjøre kommandoen. fanger opp errorer, men gjør ingenting med dem foreløpig. 
            try
            {
                cmd = new SqlCeCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@email", email);
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (SqlCeException ssceE)
            {
                Logger.Error(ssceE, thismodule);
            }
            catch (Exception e)
            {
                Logger.Error(e, thismodule);
            }
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
                Logger.Info("Fant eksisterende database", thismodule);
 
                ///TODO: Mens vi tester/utvikler skal følgende 2 linjer være stående:
                //File.Delete(fileName);
                //return initDb();

                return (int)dbStatus.EXISTING;
            }
            else
            {
                Logger.Info("Oppretter ny database...", thismodule);
                //Dersom den ikke eksisterer opprettes databasen. 
                SqlCeEngine en = new SqlCeEngine(ConnectionString);
                en.CreateDatabase();

                //lager tabeller i databasen vi nettop opprettet.
                int cT = createTables();
                if (cT != (int)dbStatus.SUCCESS) //bruker != success slik at dbstatus kan kodes med flere forskjellige error koder senere. 
                {
                    //TODO: gi melding til bruker om at noe gikk galt - se log. 
                }
                Logger.Info("...Success", thismodule);
                return (int)dbStatus.NEW;
            }
        }

        private int createTables()
        {
            //SQL koden som skal kjøres for oppretting av tabellene i databasene. 
            string sql = "create table " + TB_READINGS + " (" + TB_READINGS_DATE + " datetime not null, " + TB_READINGS_DEGREE + " integer not null, " + TB_READINGS_STATUS + " bit not null)";
            string sql1 = "create table " + TB_EMAIL + " (" + TB_EMAIL_NUMBER + " int identity (1,1) primary key, " + TB_EMAIL_ADRESS + " nvarchar(80) not null unique)";

            //Kjører SQL koden. Integeren i og j inneholder antall rader påvirket av kommandoen, dersom en av disse er 0 har noe feil skjedd. 
            int i = executeSql_NonQuery(sql);
            int j = executeSql_NonQuery(sql1);

            if (i != 0 && j != 0)
                return (int)dbStatus.SUCCESS;
            else
                return (int)dbStatus.ERROR;

        }
    }
}