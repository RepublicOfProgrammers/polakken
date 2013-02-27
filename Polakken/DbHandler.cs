using System;
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
        
        private string ConnectionString { get; set; }

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

            }
            else if (init_db_status == (int)dbStatus.EXISTING) 
            {
            
            }
        }

        //TODO: Her kan det lages flere metoder som polakken skal utnytte.

        private int initDb()
        {
            //Navn til databasen
            string fileName = "Database.sdf";
            //passord for å koble til databasen
            string password = "fg8qaw890d89DS8";

            //sjekker om databasen allerede eksisterer
            if (File.Exists(fileName))
            {
                return (int)dbStatus.EXISTING;
            }
            else 
            {
                //Dersom den ikke eksisterer opprettes databasen. 
                ConnectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", fileName, password);
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
            //Kobler til databasen
            SqlCeConnection cn = new SqlCeConnection(ConnectionString);
            
            if (cn.State==ConnectionState.Closed)
            {
                //Åpner databasen dersom den ikke er åpen. 
                cn.Open();
            }
 
            SqlCeCommand cmd;
 
            //SQL koden som skal kjøres for oppretting av tabellene i databasen. 
            string sql = "create table " + TB_READINGS + " (" + TB_READINGS_DATE + " datetime not null, " + TB_READINGS_DEGREE + " integer, " + TB_READINGS_STATUS + " bit )"; 
            //Kjører SQL koden.
            cmd = new SqlCeCommand(sql, cn);

            //Default verdi som skal returneres, vil alltid være success dersom ingen errors fanges opp i try catch. 
            int returnValue = (int)dbStatus.SUCCESS;
 
            try
            {
                cmd.ExecuteNonQuery();
                //lblResults.Text = "Table Created.";
            }
            catch (SqlCeException sqlexception)
            {
                //TODO: skrive sqlexception koden til log

                //returnerer error status som brukes for å si ifra til bruker at noe feil har skjedd.
                returnValue = (int)dbStatus.ERROR;
            } 
            catch (Exception ex)
            {
                //TODO: skrive ex koden til log

                returnValue = (int)dbStatus.ERROR;
            }
            finally
            {
                //Lukker databasen og tilkoblingen.
                cn.Close();
            }
            return returnValue;
        }
    }
}