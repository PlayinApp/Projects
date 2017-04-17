using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace VaahiniAPI.DAL
{
    public class Execution
    {
        static SqlConnection con = null;
        static Execution()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
        public static DataTable ExecuteSelectCommand(string CommandName)
        {
            SqlCommand cmd = null;
            DataTable table = new DataTable();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = CommandName;
            try
            {
                con.Open();
                SqlDataAdapter da = null;
                using (da = new SqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                cmd = null;
            }

            return table;
        }
        public static DataTable ExecuteParamerizedSelectCommand(string CommandName, SqlParameter[] param)
        {
            SqlCommand cmd = null;
            DataTable table = new DataTable();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(param);
            try
            {
                con.Open();
                SqlDataAdapter da = null;
                using (da = new SqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                cmd = null;
            }

            return table;
        }
        public static bool ExecuteNonQuery(string CommandName, SqlParameter[] pars)
        {
            SqlCommand cmd = null;
            int res = 0;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(pars);

            try
            {
                con.Open();
                res = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                cmd = null;
            }

            if (res >= 1)
            {
                return true;
            }
            return false;
        }
        public static int ExecuteNonQuery_with_result(string CommandName, SqlParameter[] pars)
        {
            SqlCommand cmd = null;
            int res = 0;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(pars);

            try
            {
                SqlParameter returnParameter = cmd.Parameters.Add("result", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                con.Open();
                cmd.ExecuteNonQuery();
                int id1 = (int)returnParameter.Value;
                res = id1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                cmd = null;
            }
            return res;
        }
        public static DataSet ExecuteCommand(string CommandName, SqlParameter[] param)
        {

            SqlDataAdapter DataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            SqlCommand cmd = null;
            cmd.CommandText = "";
            cmd.Parameters.AddRange(param);

            cmd.CommandType = CommandType.Text;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                DataAdapter.Fill(objDataSet, "Categories");


                SqlDataAdapter DataAdapter2 = new SqlDataAdapter();
                SqlCommand DataCommand2 = new SqlCommand();
                DataCommand2.Connection = con;
                DataAdapter2.SelectCommand = DataCommand2;
                DataCommand2.CommandText = "";
                cmd.Parameters.AddRange(param);
                objDataSet.Relations.Add("CategoryToMenu", objDataSet.Tables["Categories"].Columns["menuCategoryId"], objDataSet.Tables["MenuItems"].Columns["menuCategoryId"]);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                cmd = null;
            }
            return objDataSet;
        }
        public static string ExecuteString(string CommandName, SqlParameter[] param)
        {

            SqlCommand cmd = null;
            int Id = 0;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(param);
            try
            {
                con.Open();
                Id = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                cmd = null;
            }
            return Id.ToString();
        }
        public static string ExecuteStringValue(string CommandName, SqlParameter[] param)
        {
            SqlCommand cmd = null;
            string Id = "";
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(param);
            try
            {
                con.Open();
                Id = (string)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                cmd = null;
            }
            return Id;
        }

    }
}