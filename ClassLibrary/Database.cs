using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class Database
    {
        MySqlConnection conn;
        private MySqlConnection connection;
        private bool status;
        public Database()
        {
            status = Connection();
        }
        private bool Connection()
        {
            try
            {
                conn = new MySqlConnection();
                string host = "192.168.3.151";
                string port = "3306";
                string user = "root";
                string pwd = "1234";
                string db = "Project";
                conn.ConnectionString = string.Format(@"server={0};port={4};user={1};password={2};database={3};convert zero datetime=True", host, user, pwd, db, port);

                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Close()
        {
            if (status)
            {
                conn.Close();
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            if (status)
            {
                try
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
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

        public MySqlDataReader Reader2(string sql, Hashtable ht)
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

        public bool ReaderClose(MySqlDataReader sdr)
        {
            try
            {
                sdr.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool NonQuery2(string sql)
        {
            try
            {
                if (status)
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
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
        public bool NonQuery(string sql, Hashtable ht)
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

                    comm.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
