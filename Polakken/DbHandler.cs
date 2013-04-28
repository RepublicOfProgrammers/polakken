using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Polakken
{
    /// <summary>
    ///     Mange kommentarer er utelatt, men Logger bruk forklarer mye det samme.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    //Unødvendig, disposer sqlceConnection i dekonstruktør.
    internal class DbHandler
    {
        //Navn til databasen
        private const string FileName = "Database_v-1.sdf";
        //passord for å koble til databasen, og koblingsvariabel. 
        private const string Password = "fg8qaw890d89DS8";
        private const string Thismodule = "DbHandler";

        //database tabeller og kolonner
        public static readonly string TbReadings = "Readings";
        public static readonly string TbReadingsDate = "Date";
        public static readonly string TbReadingsDegree = "Degree";
        public static readonly string TbReadingsStatus = "Status";

        //e-post tabell
        public static readonly string TbEmail = "Email";
        public static readonly string TbEmailNumber = "ID";
        public static readonly string TbEmailAdress = "Adress";

        private readonly string _connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", FileName,
                                                                  Password);

        private SqlCeConnection _connection;

        /// <summary>
        ///     Konstruktør for database håndtering, sjekker/oppretter eller kobler til databasen.
        /// </summary>
        public DbHandler()
        {
            Logger.Info("Starter konstruksjon", Thismodule);
            //initialiserer databasen
            InitDb(); // dumper status kode, siden de ikke er i bruk.
        }

        /// <summary>
        ///     Automatisk dekonstruktør som blir kaldt når DbHandler ikke brukes lengre.
        /// </summary>
        ~DbHandler()
        {
            if (_connection == null) return;
            _connection.Dispose();
            _connection = null;
        }

        /// <summary>
        ///     Åpner databasen og initialiserer koblingen. Databasen er nå klar for jobb, og er opptatt for alle andre instanser/sammenhenger
        /// </summary>
        public void OpenDb()
        {
            if (_connection == null)
                _connection = new SqlCeConnection(_connectionString);

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        /// <summary>
        ///     Lukker databasen og koblingen. Nå kan andre også bruke databasen igjen.
        /// </summary>
        public void CloseDb()
        {
            //dersom databasen ikke er åpen vil ikke denne metoden gjøre noe. 
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        // Metoder til bruk av andre klasser for databasebehandling.

        // Metoder til bruk for denne klassen for utføre sql koder.

        private void InitDb()
        {
            //sjekker om databasen allerede eksisterer
            if (File.Exists(FileName))
            {
                Logger.Info("Fant eksisterende database", Thismodule);
            }
            else
            {
                Logger.Info("Oppretter ny database...", Thismodule);
                //Dersom den ikke eksisterer opprettes databasen. 
                var en = new SqlCeEngine(_connectionString);
                try
                {
                    en.CreateDatabase();
                }
                catch (Exception)
                {
                }
                finally
                {
                    en.Dispose();
                }

                //lager tabeller i databasen vi nettop opprettet.
                CreateTables();

                Logger.Info("...Success", Thismodule);
            }
        }

        private void CreateTables()
        {
            //SQL koden som skal kjøres for oppretting av tabellene i databasene. 
            string sql = "create table " + TbReadings + " (" + TbReadingsDate + " datetime not null, " +
                         TbReadingsDegree + " integer not null, " + TbReadingsStatus + " bit not null)";
            string sql1 = "create table " + TbEmail + " (" + TbEmailNumber + " int identity (1,1) primary key, " +
                          TbEmailAdress + " nvarchar(80) not null unique)";

            //Kjører SQL koden. Integeren i og j inneholder antall rader påvirket av kommandoen, dersom en av disse er 0 har noe feil skjedd. 
            int i = executeSql_NonQuery(sql);
            int j = executeSql_NonQuery(sql1);

            if (i != 0 && j != 0)
            {
                Logger.Info("Laget tabeller suksessfult", Thismodule);
            }
            else
            {
                Logger.Info("Klarte ikke lage tabeller, finnes det en error over meg?", Thismodule);
            }
        }

        #region public_methods

        /// <summary>
        ///     Sletter oppføringer i temp-databasen fra-til dato.
        /// </summary>
        /// <returns>
        ///     Returnerer antall rader påvirket (altså 0 = noe skjedde feil, 1 = en rad har blitt slettet, 2+ = flere rader har blitt slettet
        /// </returns>
        public int DelReadings(string fraDato, string tilDato)
        {
            string sql = string.Format("delete from {0} where {1} >= '{2}' and {1} <= '{3}'", TbReadings,
                                       TbReadingsDate, fraDato, tilDato);
            return executeSql_NonQuery(sql);
        }

        /// <summary>
        ///     Sletter en oppføring i databasen for temperaturer.
        /// </summary>
        /// <returns>
        ///     Returnerer antall rader påvirket (altså 0 = noe skjedde feil, 1 = en rad har blitt slettet, 2+ = flere rader har blitt slettet
        /// </returns>
        public int DelReading(DateTime datetime)
        {
            string sql = string.Format("delete from {0} where {1} = {2}", TbReadings, TbReadingsDate, datetime);
            return executeSql_NonQuery(sql);
        }

        /// <summary>
        ///     Sletter en oppføring i databasen for e-post.
        /// </summary>
        /// <returns>
        ///     Returnerer antall rader påvirket (altså 0 = noe skjedde feil, 1 = en rad har blitt slettet, 2+ = flere rader har blitt slettet
        /// </returns>
        public int DelEmail(int idnr)
        {
            string sql = string.Format("delete from {0} where {1} = {2}", TbEmail, TbEmailNumber, idnr);
            return executeSql_NonQuery(sql);
        }

        /// <summary>
        ///     henter siste måling fra temp-databasen.
        /// </summary>
        /// <returns>
        ///     Returnerer et SqlCeDataReader-objekt som kan loopes igjennom.
        /// </returns>
        public SqlCeDataReader GetLastReading()
        {
            string sql = string.Format("select {0}, {1}, {2} from {3} " +
                                       "where {0} = (select max({0}) form {3} as b)",
                                       TbReadingsDate,
                                       TbReadingsDegree,
                                       TbReadingsStatus,
                                       TbReadings);
            return executeSql_Reader(sql);
        }

        /// <summary>
        ///     henter ut en selektert oppføring i tempdatabasen
        /// </summary>
        /// <returns>
        ///     Returnerer et SqlCeDataReader-objekt som kan loopes igjennom.
        /// </returns>
        public SqlCeDataReader GetReadingToDate(DateTime dateTime)
        {
            string sql = string.Format("select * from {0} where {1} = '{2}'", TbReadings, TbReadingsDate, dateTime);
            return executeSql_Reader(sql);
        }

        /// <summary>
        ///     Henter alt som ligger i email tabellen.
        /// </summary>
        /// <returns>
        ///     Returnerer et SqlCeDataReader-objekt som kan loopes igjennom.
        /// </returns>
        public SqlCeDataReader GetEmails()
        {
            string sql = string.Format("select * from {0}", TbEmail);
            return executeSql_Reader(sql);
        }

        /// <summary>
        ///     Henter alt som ligger i readings tabellen.
        /// </summary>
        /// <returns>
        ///     Returnerer et SqlCeDataReader-objekt som kan loopes igjennom.
        /// </returns>
        public SqlCeDataReader GetReadings()
        {
            string sql = string.Format("select * from {0}", TbReadings);
            return executeSql_Reader(sql);
        }


        //public int SetReading(DateTime time, int C, Boolean status) //Sender parameterne videre

        /// <summary>
        ///     Oppretter en ny avlesing i databasen.
        /// </summary>
        /// <param name="time">ISO-8601 formatert slik: yy.MM.ddThh:mm:ss</param>
        /// <param name="c">Temperatur i Celcius (ganget med 100. Del på 100 og tolk som double ved uthenting).</param>
        /// <param name="status">Varmeovn på = true, av = false</param>
        /// <returns>Returnerer 0 eller 1. Dersom linjen er opprettet vil metoden returnere 1. </returns>
        public int SetReading(DateTime time, int c, Boolean status)
        {
            return executeSql_NonQuery(time, c, status);
        }

        /// <summary>
        ///     legger til epost i epostdatabasen
        /// </summary>
        /// <param name="email">Email som en string</param>
        /// <returns>Returnerer 0 eller 1. Dersom linjen er opprettet vil metoden returnere 1. </returns>
        public int AddEmail(string email)
        {
            return executeSql_NonQuery_Email(email);
        }

        #endregion

        #region executeSql

        /// <summary>
        ///     MERK: Denne metoden trenger at dbhandler objektet åpnes før kjøring, og lukkes etterpå, ved .OpenDb() og .CloseDb()
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        //sql stringen kommer aldri fra bruker-input
        private SqlCeDataReader executeSql_Reader(string sql)
        {
            SqlCeDataReader dataReader = null;

            using (var cmd = new SqlCeCommand(sql, _connection))
            {
                try
                {
                    dataReader = cmd.ExecuteReader();
                }
                catch (SqlCeException ssceE)
                {
                    Logger.Error(ssceE, Thismodule);
                }
                catch (Exception e)
                {
                    Logger.Error(e, Thismodule);
                }
            }
            return dataReader;
        }

        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        //sql stringen kommer aldri fra bruker-input
        private int executeSql_NonQuery(string sql)
        {
            //kobler til databasen og åpner den
            OpenDb();

            //variabel som inneholder antall rader som blir påvirket av kommandoen
            int affectedRows = 0;

            //Henter inn sql koden fra metode argumentet sql, og lager en sqlcommand sammen med koblingen til databasen.
            using (var cmd = new SqlCeCommand(sql, _connection))
            {
                //prøver å kjøre kommandoen. fanger opp errorer, men gjør ingenting med dem foreløpig. 
                try
                {
                    affectedRows = cmd.ExecuteNonQuery();
                }
                catch (SqlCeException ssceE)
                {
                    //Sender error til log tekst filen.
                    Logger.Error(ssceE, Thismodule);
                }
                catch (Exception e)
                {
                    //Sender error til log tekst filen.
                    Logger.Error(e, Thismodule);
                }
                finally
                {
                    // Følgende utkommenterte linje spammer loggen veldig, men er nyttig ved debugging
                    // if (affectedRows != 0) Logger.Info("Kjørte sql-kode: " + cmd.CommandText, thismodule);
                    //Lukker databasen.
                    CloseDb();
                }
            }
            return affectedRows;
        }

        private int executeSql_NonQuery(DateTime time, int c, Boolean status)
        {
            // sql-spørringen
            string sql = "insert into " + TbReadings + "(" + TbReadingsDate + ", " + TbReadingsDegree + ", " +
                         TbReadingsStatus + ") values(@date, @value, @status)";

            //kobler til databasen og åpner den
            OpenDb();


            //variabel som inneholder antall rader som blir påvirket av kommandoen
            int affectedRows = 0;

            //Henter inn sql koden fra metode argumentet sql, og lager en sqlcommand sammen med koblingen til databasen.
            using (var cmd = new SqlCeCommand(sql, _connection))
            {
                //prøver å kjøre kommandoen. fanger opp errorer. 
                try
                {
                    cmd.Parameters.AddWithValue("@date", time);
                    cmd.Parameters.AddWithValue("@value", c);
                    cmd.Parameters.AddWithValue("@status", status);
                    affectedRows = cmd.ExecuteNonQuery();
                }
                catch (SqlCeException ssceE)
                {
                    Logger.Error(ssceE, Thismodule);
                }
                catch (Exception e)
                {
                    Logger.Error(e, Thismodule);
                }
                finally
                {
                    // Følgende utkommenterte linje spammer loggen veldig, men er nyttig ved debugging
                    //if (affectedRows != 0) Logger.Info("Kjørte sql-kode: " + cmd.CommandText + " med parametere: @date = " + time + " , @value = " + C + " , @status = " + status + ".", thismodule);
                    CloseDb();
                }
            }
            return affectedRows;
        }

        private int executeSql_NonQuery_Email(string email)
        {
            // sql-spørringen
            string sql = "insert into " + TbEmail + "(" + TbEmailAdress + ") values(@email)";

            //kobler til databasen og åpner den
            OpenDb();

            //variabel som inneholder antall rader som blir påvirket av kommandoen
            int affectedRows = 0;

            //Henter inn sql koden fra metode argumentet sql, og lager en sqlcommand sammen med koblingen til databasen.
            using (var cmd = new SqlCeCommand(sql, _connection))
            {
                //prøver å kjøre kommandoen. fanger opp errorer. 
                try
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    affectedRows = cmd.ExecuteNonQuery();
                }
                catch (SqlCeException ssceE)
                {
                    Logger.Error(ssceE, Thismodule);
                }
                catch (Exception e)
                {
                    Logger.Error(e, Thismodule);
                }
                finally
                {
                    // Følgende utkommenterte linje spammer loggen veldig, men er nyttig ved debugging
                    //if (affectedRows != 0) Logger.Info("Kjørte sql-kode: " + cmd.CommandText + " med parametere: @email = " + email , thismodule);
                    CloseDb();
                }
            }
            return affectedRows;
        }

        #endregion
    }
}