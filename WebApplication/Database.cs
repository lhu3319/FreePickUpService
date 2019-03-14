using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
namespace WebApplication
{
    public class MYsql
    {
        private MySqlConnection conn;
        bool status = true;
        public MYsql()
        {
            this.conn = GetConnection();
        }
        private MySqlConnection GetConnection()
        {
            string host = "192.168.3.151";
            string user = "root";
            string pwd = "1234";
            string db = "Project";

            string connStr = string.Format(@"server={0};user={1};password={2};database={3};convert zero datetime=True", host, user, pwd, db);
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                Console.WriteLine("pppppppppppppppppppppppppppppppppppppppp");
                status = true;
                return conn;
            }
            catch
            {
                Console.WriteLine("실패!!!!!!!!!!!!!!!!!!!!!");
                status = false;
                return null;
            }

        }
        public bool ConnectionClose()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool NonQuery(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    return comm.ExecuteReader();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public MySqlDataReader Reader(string sql, Hashtable ht)
        {
            if (status)
            {
                try
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;

                    foreach (DictionaryEntry data in ht)
                    {
                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }

                    return comm.ExecuteReader();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public void ReaderClose(MySqlDataReader reader)
        {
            reader.Close();
        }
    }
}