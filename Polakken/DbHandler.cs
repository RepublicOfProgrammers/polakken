using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;

namespace Polakken
{
    class DbHandler : IDisposable
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

        //database tabeller og kolonner
        public static readonly string TB_READINGS = "Readings";
        public static readonly string TB_READINGS_DATE = "Date";
        public static readonly string TB_READINGS_DEGREE = "Degree";
        public static readonly string TB_READINGS_STATUS = "Status";

        //e-post tabell
        public static readonly string TB_EMAIL = "Email";
        public static readonly string TB_EMAIL_NUMBER = "ID";
        public static readonly string TB_EMAIL_ADRESS = "Adress";


        /// <summary>
        /// Kaster DbHandleren i søppla, for å frigjøre ressurser
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Automatisk dekonstruktør som blir kaldt når DbHandler ikke brukes lengre. 
        /// </summary>
        ~DbHandler()
        {
            Dispose(false);
        }

        /// <summary>
        /// NB! Denne metoden blir kun kjørt fra Dispose() og ~DbHandler().
        /// Egenmodifisert dispose metoden som sletter alle ressurser som det ikke er behov for lengre dersom:
        /// </summary>
        /// <param name="freeManagedObjectsAlso">== true: sletter både ubrukte og brukte ressurser det ikke lengre er behov for.
        /// ==false: sletter kun ubrukte ressurser.</param>
        protected void Dispose(Boolean freeManagedObjectsAlso)
        {
            //Frigjør uhåndterte ressurser 
            if (freeManagedObjectsAlso)
            {
                if (this._connection != null)
                {
                    this._connection.Dispose();
                    this._connection = null;
                }
            }
        }

        /// <summary>
        /// Konstruktør for database håndtering, sjekker/oppretter eller kobler til databasen. 
        /// </summary>
        public DbHandler()
        {
            Logger.Info("Starter konstruksjon", thismodule);
            //initialiserer databasen, henter ut status/resultat-kode
            int init_db_status = initDb();

            if (init_db_status == (int)dbStatus.NEW)
            {
                //Her kan det sendes en messagebox til bruker om at programmet har startet for første gang og database er opprettet.
            }
            else if (init_db_status == (int)dbStatus.EXISTING)
            {
                //her kan det sendes en melding til bruker om at siste innlogging var sånn og sånn f.eks.
            }
        }

        /// <summary>
        /// Åpner databasen og initialiserer koblingen. Databasen er nå klar for jobb, og er opptatt for alle andre instanser/sammenhenger
        /// </summary>
        public void OpenDb()
        {
            if (_connection == null)
                _connection = new SqlCeConnection(ConnectionString);

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        /// <summary>
        /// Lukker databasen og koblingen. Nå kan andre også bruke databasen igjen. 
        /// </summary>
        public void CloseDb()
        {
            //dersom databasen ikke er åpen vil ikke denne metoden gjøre noe. 
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        /**
         * PUBLIC METHODS: Her kan det lages flere metoder som polakken skal utnytte.
         */

        /// <summary>
        /// Sletter oppføringer i temp-databasen fra-til dato.
        /// </summary>
        /// <returns>
        /// Returnerer antall rader påvirket (altså 0 = noe skjedde feil, 1 = en rad har blitt slettet, 2+ = flere rader har blitt slettet
        /// </returns>
        public int DelReadings(string fraDato, string tilDato)
        {
            string sql = string.Format("delete from {0} where {1} >= '{2}' and {1} <= '{3}'", TB_READINGS, TB_READINGS_DATE, fraDato, tilDato);
            return executeSql_NonQuery(sql);
        }

        /// <summary>
        /// Sletter en oppføring i databasen for temperaturer.
        /// </summary>
        /// <returns>
        /// Returnerer antall rader påvirket (altså 0 = noe skjedde feil, 1 = en rad har blitt slettet, 2+ = flere rader har blitt slettet
        /// </returns>
        public int DelReading(DateTime datetime)
        {
            string sql = string.Format("delete from {0} where {1} = {2}", TB_READINGS, TB_READINGS_DATE, datetime);
            return executeSql_NonQuery(sql);
        }

        /// <summary>
        /// Sletter en oppføring i databasen for e-post.
        /// </summary>
        /// <returns>
        /// Returnerer antall rader påvirket (altså 0 = noe skjedde feil, 1 = en rad har blitt slettet, 2+ = flere rader har blitt slettet
        /// </returns>
        public int DelEmail(int idnr)
        {
            string sql = string.Format("delete from {0} where {1} = {2}", TB_EMAIL, TB_EMAIL_NUMBER, idnr);
            return executeSql_NonQuery(sql);
        }

        /// <summary>
        /// henter siste måling fra temp-databasen.
        /// </summary>
        /// <returns>
        /// Returnerer et SqlCeDataReader-objekt som kan loopes igjennom.
        /// </returns>
        public SqlCeDataReader GetLastReading()
        {
            string sql = string.Format("select {0}, {1}, {2} from {3} " +
            "where {0} = (select max({0}) form {3} as b)",
            TB_READINGS_DATE,
            TB_READINGS_DEGREE,
            TB_READINGS_STATUS,
            TB_READINGS);
            return executeSql_Reader(sql);
        }

        /// <summary>
        /// henter ut en selektert oppføring i tempdatabasen
        /// </summary>
        /// <returns>
        /// Returnerer et SqlCeDataReader-objekt som kan loopes igjennom.
        /// </returns>
        public SqlCeDataReader GetReadingToDate(DateTime dateTime)
        {
            string sql = string.Format("select * from {0} where {1} = '{2}'", TB_READINGS, TB_READINGS_DATE, dateTime);
            return executeSql_Reader(sql);
        }

        /// <summary>
        /// Henter alt som ligger i email tabellen. 
        /// </summary>
        /// <returns>
        /// Returnerer et SqlCeDataReader-objekt som kan loopes igjennom.
        /// </returns>
        public SqlCeDataReader GetEmails()
        {
            string sql = string.Format("select * from {0}", TB_EMAIL);
            return executeSql_Reader(sql);
        }

        /// <summary>
        /// Henter alt som ligger i readings tabellen. 
        /// </summary>
        /// <returns>
        /// Returnerer et SqlCeDataReader-objekt som kan loopes igjennom.
        /// </returns>
        public SqlCeDataReader GetReadings()
        {
            string sql = string.Format("select * from {0}", TB_READINGS);
            return executeSql_Reader(sql);
        }


        //public int SetReading(DateTime time, int C, Boolean status) //Sender parameterne videre

        /// <summary>
        /// Oppretter en ny avlesing i databasen.
        /// </summary>
        /// <param name="time">ISO-8601 formatert slik: yy.MM.ddThh:mm:ss</param>
        /// <param name="C">Temperatur i Celcius (ganget med 100. Del på 100 og tolk som double ved uthenting).</param>
        /// <param name="status">Varmeovn på = true, av = false</param>
        /// <returns>Returnerer 0 eller 1. Dersom linjen er opprettet vil metoden returnere 1. </returns>
        public int SetReading(DateTime time, int C, Boolean status)
        {
            return executeSql_NonQuery(time, C, status);
        }

        /// <summary>
        /// legger til epost i epostdatabasen 
        /// </summary>
        /// <param name="email">Email som en string</param>
        /// <returns>Returnerer 0 eller 1. Dersom linjen er opprettet vil metoden returnere 1. </returns>
        public int AddEmail(string email)
        {
            return executeSql_NonQuery_Email(email);
        }

        /**
         * END PUBLIC METHODS!
         */

        ///<summary>
        /// MERK: Denne metoden trenger at dbhandler objektet åpnes før kjøring, og lukkes etterpå, ved .OpenDb() og .CloseDb()
        ///</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")] //sql stringen kommer aldri fra bruker-input
        private SqlCeDataReader executeSql_Reader(string sql)
        {
            SqlCeCommand cmd = new SqlCeCommand(sql, _connection);
            SqlCeDataReader data_reader = null;
            try
            {
                data_reader = cmd.ExecuteReader();
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
                cmd.Dispose();
            }
            return data_reader;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")] //sql stringen kommer aldri fra bruker-input
        private int executeSql_NonQuery(string sql)
        {
            //kobler til databasen og åpner den
            this.OpenDb();

            //Henter inn sql koden fra metode argumentet sql, og lager en sqlcommand sammen med koblingen til databasen.
            SqlCeCommand cmd = new SqlCeCommand(sql, _connection);

            //variabel som inneholder antall rader som blir påvirket av kommandoen
            int affectedRows = 0;

            //prøver å kjøre kommandoen. fanger opp errorer, men gjør ingenting med dem foreløpig. 
            try
            {
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (SqlCeException ssceE)
            {
                //Sender error til log tekst filen.
                Logger.Error(ssceE, thismodule);
            }
            catch (Exception e)
            {
                //Sender error til log tekst filen.
                Logger.Error(e, thismodule);
            }
            finally
            {
                //Lukker databasen.
                cmd.Dispose();
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
            SqlCeCommand cmd = new SqlCeCommand(sql, _connection);

            //variabel som inneholder antall rader som blir påvirket av kommandoen
            int affectedRows = 0;

            //prøver å kjøre kommandoen. fanger opp errorer. 
            try
            {
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
                cmd.Dispose();
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
            SqlCeCommand cmd = new SqlCeCommand(sql, _connection);

            //variabel som inneholder antall rader som blir påvirket av kommandoen
            int affectedRows = 0;

            //prøver å kjøre kommandoen. fanger opp errorer. 
            try
            {
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
                cmd.Dispose();
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

                return (int)dbStatus.EXISTING;
            }
            else
            {
                Logger.Info("Oppretter ny database...", thismodule);
                //Dersom den ikke eksisterer opprettes databasen. 
                SqlCeEngine en = new SqlCeEngine(ConnectionString);
                try
                {
                    en.CreateDatabase();
                }
                catch (Exception) { }
                finally 
                {
                    en.Dispose();
                }

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
            {
                Logger.Info("Laget tabeller suksessfult", thismodule);
                return (int)dbStatus.SUCCESS;
            }
            else
            {
                Logger.Info("Klarte ikke lage tabeller, finnes det en error over meg?", thismodule);
                return (int)dbStatus.ERROR;
            }
        }
    }
}