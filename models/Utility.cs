﻿using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using qlShop.models;
using System.Configuration;
namespace qlShop.models
{
    static class Utility
    {
        public const string QUANLY = "Quản lý";
        public const string NHANVIEN = "Nhân viên";
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
    }
}
