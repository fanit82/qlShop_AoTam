using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using qlShop.models;
using System.Configuration;
using System.Data;
using System.IO;
using System.Data.OleDb;
using qlShop.qlshop_model;

namespace qlShop.models
{
    static class Utility
    {
        public const string QUANLY = "Quản lý";
        public const string NHANVIEN = "Nhân viên";
        public const string KeyConnectString = "QlShop";
        static public string strConnectString { get; set; }
        static public string TenKetNoi { get; set; }
        static public NguoiDung NguoiSuDung;
        static public string GetConnectString()
        {
            //return "Data Source=CNTT-NHATLH;Initial Catalog=qlShop;Integrated Security=True";
            //return "Server=.\\SQLExpress;AttachDbFilename=C:\\MyFolder\\MyDataFile.mdf;Database=dbname;Trusted_Connection=Yes";
            //return "Server=.;AttachDbFilename=|DataDirectory|\\Data\\qlShop.mdf;Database=qlShop2;Trusted_Connection=Yes";
            return strConnectString; //ConfigurationManager.ConnectionStrings[1].ToString();
        }
        static public bool isConect()
        {
            SqlConnection cnn = new SqlConnection(GetConnectString());
            try
            {
                cnn.Open();
                cnn.Close();
                //cnn.Dispose();
                return true;
            }
            catch (Exception)
            {                
                throw;
            }
            //return false;
        }

        public static DataSet ImportExcelXLS(string FileName, bool hasHeaders)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";

            DataSet output = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    if (!sheet.EndsWith("_"))
                    {
                        try
                        {
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                            cmd.CommandType = CommandType.Text;

                            DataTable outputTable = new DataTable(sheet);
                            output.Tables.Add(outputTable);
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                }
            }
            return output;
        }
    }
}

