using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhanSu
{
    public static class Common
    {
        public static string glbUserName = "";
        public static string glbUnit = "";
        public static  string pathCategory = AppDomain.CurrentDomain.BaseDirectory + "Data\\Category\\";
        public static string pathAccount = AppDomain.CurrentDomain.BaseDirectory + "Data\\Account\\";

        private static byte[] _key = { };
        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };

        //Giải mã
        public static string Decrypt(string stringToDecrypt)
        {
            stringToDecrypt = stringToDecrypt.Replace("-", "/");
            string SEncryptionKey = "r0b1nr0y";
            byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                _key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                  des.CreateDecryptor(_key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        //Mã hoá
        public static string Encrypt(string stringToEncrypt)
        {
            string SEncryptionKey = "r0b1nr0y";
            try
            {
                _key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                  des.CreateEncryptor(_key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                string base64 = Convert.ToBase64String(ms.ToArray());
                return base64;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public static void SaveFileContent(string filePath, string content)
        {
            try
            {
                content = Encrypt(content); 
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static string ReadFileContent(string filePath)
        {
            string content = string.Empty;
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Không tìm thấy thông tin dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
                content =  File.ReadAllText(filePath);
                content = Decrypt(content);
                return content;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        

}
}
