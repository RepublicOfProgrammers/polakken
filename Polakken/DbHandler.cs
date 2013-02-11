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

        private int initDb(){

            string fileName = "Database.sdf";
            string password = "fg8qaw890d89DS8";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            ConnectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", fileName, password);
            SqlCeEngine en = new SqlCeEngine(ConnectionString);
            en.CreateDatabase();

            return (int)dbStatus.NEW;
        }

        private int createTables() {
            SqlCeConnection cn = new SqlCeConnection(ConnectionString);
            
            if (cn.State==ConnectionState.Closed)
            {
                cn.Open();
            }
 
            SqlCeCommand cmd;
 
            string sql = "create table CoolPeople (" + "LastName nvarchar (40) not null, " + "FirstName nvarchar (40), " + "URL nvarchar (256) )"; 
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

        public DbHandler(){
            if (initDb() == (int)dbStatus.NEW) { 
                
            }
            
        }
    }
}
