
using LeitorXMLPowerBI.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace LeitorXMLPowerBI.Data
{
    internal class DatabaseAccess : IDisposable
    {
        private bool disposed = false;
                
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
                
        public SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        public bool InserirHeaderXML(HeaderXML pw)
        {
            bool status = true;
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    string queryString = "InsertHeaderXML";

                    SqlCommand cm = new SqlCommand(queryString, conn);

                    cm.Parameters.Add("@EventType", SqlDbType.Int).Value = pw.EventType;
                    cm.Parameters.Add("@EventDate", SqlDbType.Date).Value = pw.EventDate;
                    cm.Parameters.Add("@EventDateAge", SqlDbType.Int).Value = pw.EventDateAge;
                    cm.Parameters.Add("@EventDateFromEpoch", SqlDbType.VarChar).Value = pw.EventDateFromEpoch;
                    cm.Parameters.Add("@EntryType", SqlDbType.Int).Value = pw.EntryType;
                    cm.Parameters.Add("@EntryGuid", SqlDbType.Date).Value = pw.EntryGuid;
                    cm.Parameters.Add("@EntryDate", SqlDbType.Int).Value = pw.EntryDate;
                    cm.Parameters.Add("@EntryDateAge", SqlDbType.VarChar).Value = pw.EntryDateAge;
                    cm.Parameters.Add("@EntryDateFromEpoch", SqlDbType.VarChar).Value = pw.EntryDateFromEpoch;
                    cm.Parameters.Add("@EntrySource", SqlDbType.VarChar).Value = pw.EntrySource;




                    cm.CommandType = CommandType.Text;           
                    conn.Open();

                    cm.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    status = false;
                    Console.WriteLine(Ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return status;
        }

        public bool InserirOrdemServicoXML(FormXML os)
        {
            bool status = true;
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    string queryString = "InsertOrdemServico";

                    SqlCommand cm = new SqlCommand(queryString, conn);

                    cm.Parameters.Add("@Code", SqlDbType.VarChar).Value = os.Code;
                    cm.Parameters.Add("@DS_NAME", SqlDbType.VarChar).Value = os.DS_NAME;
                    cm.Parameters.Add("@NR_VERSION", SqlDbType.VarChar).Value = os.NR_VERSION;
                    cm.Parameters.Add("@Category", SqlDbType.VarChar).Value = os.Category;                    

                    foreach (var item in os.field.Field)
                    {
                        cm.Parameters.Add("@" + item.Id, SqlDbType.VarChar).Value = item.Value;                        
                    }

                    cm.Parameters.Add("@CustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cm.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    cm.ExecuteNonQuery();

                    int contractID = Convert.ToInt32(cm.Parameters["@CustomerID"].Value);
                }
                catch (Exception Ex)
                {
                    status = false;
                    Console.WriteLine(Ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return status;
        }

        public bool InserirOrdemServicoImpXML(FormXML os)
        {
            bool status = true;
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    string queryString = "InsertOrdemServicoImp";

                    SqlCommand cm = new SqlCommand(queryString, conn);

                    cm.Parameters.Add("@Code", SqlDbType.VarChar).Value = os.Code;
                    cm.Parameters.Add("@DS_NAME", SqlDbType.VarChar).Value = os.DS_NAME;
                    cm.Parameters.Add("@NR_VERSION", SqlDbType.VarChar).Value = os.NR_VERSION;
                    cm.Parameters.Add("@Category", SqlDbType.VarChar).Value = os.Category;

                    foreach (var item in os.field.Field)
                    {
                        cm.Parameters.Add("@" + item.Id, SqlDbType.VarChar).Value = item.Value;
                    }

                    cm.Parameters.Add("@CustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cm.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    cm.ExecuteNonQuery();

                    int contractID = Convert.ToInt32(cm.Parameters["@CustomerID"].Value);
                }
                catch (Exception Ex)
                {
                    status = false;
                    Console.WriteLine(Ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return status;
        }

        public bool InserirControleServicoXML(FormXML os)
        {
            bool status = true;
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    string queryString = "InsertControleServico";

                    SqlCommand cm = new SqlCommand(queryString, conn);

                    cm.Parameters.Add("@Code", SqlDbType.VarChar).Value = os.Code;
                    cm.Parameters.Add("@DS_NAME", SqlDbType.VarChar).Value = os.DS_NAME;
                    cm.Parameters.Add("@NR_VERSION", SqlDbType.VarChar).Value = os.NR_VERSION;
                    cm.Parameters.Add("@Category", SqlDbType.VarChar).Value = os.Category;

                    foreach (var item in os.field.Field)
                    {
                        cm.Parameters.Add("@" + item.Id, SqlDbType.VarChar).Value = item.Value;
                    }

                    cm.Parameters.Add("@CustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cm.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    cm.ExecuteNonQuery();

                    int contractID = Convert.ToInt32(cm.Parameters["@CustomerID"].Value);
                }
                catch (Exception Ex)
                {
                    status = false;
                    Console.WriteLine(Ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return status;
        }

        public bool InserirControleServicoImpXML(FormXML os)
        {
            bool status = true;
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    string queryString = "InsertControleServicoImp";

                    SqlCommand cm = new SqlCommand(queryString, conn);

                    cm.Parameters.Add("@Code", SqlDbType.VarChar).Value = os.Code;
                    cm.Parameters.Add("@DS_NAME", SqlDbType.VarChar).Value = os.DS_NAME;
                    cm.Parameters.Add("@NR_VERSION", SqlDbType.VarChar).Value = os.NR_VERSION;
                    cm.Parameters.Add("@Category", SqlDbType.VarChar).Value = os.Category;

                    foreach (var item in os.field.Field)
                    {
                        cm.Parameters.Add("@" + item.Id, SqlDbType.VarChar).Value = item.Value;
                    }

                    cm.Parameters.Add("@CustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cm.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    cm.ExecuteNonQuery();

                    int contractID = Convert.ToInt32(cm.Parameters["@CustomerID"].Value);
                }
                catch (Exception Ex)
                {
                    status = false;
                    Console.WriteLine(Ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return status;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
                
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
