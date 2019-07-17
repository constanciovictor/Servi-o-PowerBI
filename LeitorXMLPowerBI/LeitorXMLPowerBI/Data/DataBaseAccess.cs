
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
        // Flag: Has Dispose already been called?
        private bool disposed = false;

        // Instantiate a SafeHandle instance.
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Define connection
        public SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        public DataTable GetData(string procedureName)
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    // Create command
                    SqlCommand cm = new SqlCommand(procedureName, conn);
                    cm.CommandType = CommandType.StoredProcedure;

                    // Open connection
                    conn.Open();

                    using (SqlDataReader reader = cm.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return table;
        }

        public DataTable GetData(string procedureName, List<SqlParameter> listParam)
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    // Create command
                    SqlCommand cm = new SqlCommand(procedureName, conn);
                    cm.CommandType = CommandType.StoredProcedure;
                    if (listParam != null)
                    {
                        foreach (SqlParameter p in listParam)
                        {
                            cm.Parameters.Add(p);
                        }
                    }

                    // Open connection
                    conn.Open();

                    using (SqlDataReader reader = cm.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return table;
        }

        public bool InserirPontoXML(PowerBIXML pw)
        {
            bool status = true;
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    string queryString = "INSERT INTO dbo.TB_POWERBI_XML(ID_TP_XML, DT_INCLUSAO, DT_EVENT, CD_FORM, XML_COMPL) values (" +
                    "@id_tp_xml, getdate(), @dt_event, @cd_form, @xml_compl)";

                    SqlCommand cm = new SqlCommand(queryString, conn);

                    cm.Parameters.Add("@id_tp_xml", SqlDbType.Int).Value = pw.ID_TP_XML;
                    cm.Parameters.Add("@dt_event", SqlDbType.Date).Value = pw.DataEvent;
                    cm.Parameters.Add("@cd_form", SqlDbType.Int).Value = pw.CdForm;
                    cm.Parameters.Add("@xml_compl", SqlDbType.VarChar).Value = pw.XmlCompl;


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

        // Protected implementation of Dispose pattern.
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

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
