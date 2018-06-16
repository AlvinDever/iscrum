using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Data.SQLite;


namespace iScrum.Respository
{
    public class SqliteHelper
    {
        private static string connecString = ConfigurationManager.ConnectionStrings["iscrum_sqlite"].ConnectionString;
        private static DbProviderFactory fact = DbProviderFactories.GetFactory("System.Data.SQLite");

        public DataSet GetToDoList()
        {
            DataSet ds = new DataSet();
            
            try
            {
                using (SQLiteConnection conn = (SQLiteConnection)fact.CreateConnection())
                {
                    conn.ConnectionString = connecString;
                    //conn.ConnectionString ="Data Source=" + AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;
                    conn.Open();

                    string sql = "SELECT * FROM todo";

                    SQLiteDataAdapter liteAdapter = new SQLiteDataAdapter(sql, conn);
                    
                    liteAdapter.Fill(ds);
                }
                return ds;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool AddToDo(Model.ToDo toDo)
        {
            int num = -1;
            try
            {
                using (SQLiteConnection conn = (SQLiteConnection)fact.CreateConnection())
                {
                    conn.ConnectionString = connecString;
                    //conn.ConnectionString ="Data Source=" + AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString;
                    conn.Open();

                    string strsql = "INSERT INTO ToDo values (NULL,@name)";
                    SQLiteParameter parameter = new SQLiteParameter("@name", toDo.Name);
                    SQLiteCommand cmd = new SQLiteCommand(strsql, conn);
                    cmd.Parameters.Add(parameter);
                    num = cmd.ExecuteNonQuery();

                    return num > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
