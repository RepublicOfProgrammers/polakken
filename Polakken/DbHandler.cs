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
        private enum dbStatus :int { NEW = 0, EXISTING, SUCCESS, ERROR }
        
        private string ConnectionString { get; set; }

        //database tables & collums
        public static readonly int DB_VERSION = 1;
        public static readonly string TB_READINGS = "Readings";
        public static readonly string TB_READINGS_DATE = "Date";
        public static readonly string TB_READINGS_DEGREE = "Degree";
        public static readonly string TB_READINGS_STATUS = "Status";

        public DbHandler()
        {
            int init_db_status = initDb();
            int create_tables_status;
            if (init_db_status == (int)dbStatus.NEW)
            {
                create_tables_status = createTables();
                if (create_tables_status == (int)dbStatus.SUCCESS) {
                    
                }
            }
            else if (init_db_status == (int)dbStatus.EXISTING) 
            {
            
            }
        }

        private int initDb()
        {
            string fileName = "Database.sdf";
            string password = "fg8qaw890d89DS8";

            if (File.Exists(fileName))
            {
                return (int)dbStatus.EXISTING;
            }
            else 
            {
                ConnectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", fileName, password);
                SqlCeEngine en = new SqlCeEngine(ConnectionString);
                en.CreateDatabase();

                return (int)dbStatus.NEW;
            }

        }

        private int createTables() {
            SqlCeConnection cn = new SqlCeConnection(ConnectionString);
            
            if (cn.State==ConnectionState.Closed)
            {
                cn.Open();
            }
 
            SqlCeCommand cmd;
 
            string sql = "create table " + TB_READINGS + " (" + TB_READINGS_DATE + " datetime not null, " + TB_READINGS_DEGREE + " integer, " + TB_READINGS_STATUS + " bit )"; 
            cmd = new SqlCeCommand(sql, cn);
 
            try
            {
                cmd.ExecuteNonQuery();
                //lblResults.Text = "Table Created.";
            }
            catch (SqlCeException sqlexception)
            {
                //MessageBox.Show(sqlexception.Message, "Oh Fudge.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Fooey.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
            return (int)dbStatus.SUCCESS;
        }
    }
}