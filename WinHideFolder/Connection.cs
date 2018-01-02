using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;


namespace WinHideFolder
{
    class Connection
    {
        public int count=0;
        public SqlCeConnection cn = new SqlCeConnection(@"Data Source = C:\Users\Sobuz Ahmmed\Documents\path.sdf");
        public Boolean insert(string path)
        {
            cn.Open();
            string pass = "";
            SqlCeCommand sc = new SqlCeCommand("INSERT INTO WFH VALUES(@name,@password)", cn);
            sc.Parameters.AddWithValue("@name", path);
            sc.Parameters.AddWithValue("@password", pass);
            try
            {
                sc.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                cn.Close();
                // return false;
                throw;
            }
            cn.Close();
            return true;
        }
        public Boolean checkUserPass(String name, String password)
        {
            cn.Open();
            try
            {
                SqlCeCommand oSqlCommand = new SqlCeCommand("select * from WFH", cn);
                SqlCeDataReader oSqlDataReader = oSqlCommand.ExecuteReader();

                while (oSqlDataReader.Read())
                {
                    if (oSqlDataReader[0].Equals(name) && oSqlDataReader[1].Equals(password))
                    {
                        cn.Close();
                        return true;

                    }
                }



            }
            catch (Exception exp)
            {
                cn.Close();
                return false;
                // error = exp.Message.ToString();
                //return error;
            }
            cn.Close();
            return false;
        }
        public Boolean delete(string name)
        {
            cn.Open();
            try
            {
                SqlCeCommand sc = new SqlCeCommand("Delete from WFH where name = '" + name + "'", cn);
                sc.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                cn.Close();
                // return false;
                throw;
            }
            cn.Close();
            return true;
        }
        public string[] load()
        {
            cn.Open();
            string[] names=new string[100];
            try
            {
                SqlCeCommand oSqlCommand = new SqlCeCommand("select * from WFH", cn);
                SqlCeDataReader oSqlDataReader = oSqlCommand.ExecuteReader();
                count=0;
                while (oSqlDataReader.Read())
                {
                    if (oSqlDataReader[0].ToString() != null)
                    {
                        names[count] = oSqlDataReader[0].ToString();
                        count++;
                    }
                }



            }
            catch (Exception exp)
            {
                cn.Close();
                throw;
                // error = exp.Message.ToString();
                //return error;
            }
            cn.Close();
            return names;
        }
    }
}
