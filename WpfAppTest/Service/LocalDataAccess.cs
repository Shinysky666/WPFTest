using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTest.Common;
using WpfAppTest.Service.DataEntity;

namespace WpfAppTest.Service
{
    public class LocalDataAccess
    {
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataAdapter adapter;

        private static LocalDataAccess instance;
        private LocalDataAccess()
        {

        }

        public static LocalDataAccess GetInstance()
        {
            return instance ?? (instance = new LocalDataAccess());//如果instance为null 则重新创建
        }

        private void Dispose()
        {
            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if (command != null)
            {
                command.Dispose();
                command = null;
            }
            if(connection!=null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        private bool DBConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            if (connection == null)
                connection = new MySqlConnection(connStr);
            try
            {
                connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public UserEntity CheckUserInfo(string userName,string pwd)
        {
            try
            {
                if(DBConnection())
                {
                    string sql =
                        "select * from user where user_name=@username and password=@pwd and is_validation=1";
                    adapter = new MySqlDataAdapter(sql, connection);
                    adapter.SelectCommand.Parameters.Add(new MySqlParameter("@username", MySqlDbType.VarChar)
                    { Value = userName });
                    adapter.SelectCommand.Parameters.Add(new MySqlParameter("@pwd", MySqlDbType.VarChar)
                    { Value = MD5Provider.GetMD5String(pwd + "@" + userName) });

                    DataTable table = new DataTable();
                    int count = adapter.Fill(table);

                    if (count <= 0)
                        throw new Exception("用户名或密码不正确");

                    DataRow dr = table.Rows[0];
                    if(dr.Field<Int32>("is_canlogin")==0)
                    {
                        throw new Exception("用户没有权限使用此平台");
                    }

                    //与数据库表中数据相对应
                    UserEntity userinfo = new UserEntity();
                    userinfo.UserName = dr.Field<string>("user_name");
                    userinfo.RealName = dr.Field<string>("real_name");
                    userinfo.Password = dr.Field<string>("password");
                    userinfo.Avator = dr.Field<string>("avator");
                    userinfo.Gender = dr.Field<Int32>("gender");

                    Console.WriteLine(dr.ToString());

                    return userinfo;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                this.Dispose();
            }
            return null;
        }

    }
}
