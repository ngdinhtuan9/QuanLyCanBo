using GemBox.Spreadsheet;
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
        public static string pathManagerment = AppDomain.CurrentDomain.BaseDirectory + "Data\\Managerment\\";
        public static string path = AppDomain.CurrentDomain.BaseDirectory;
        private static byte[] _key = { };
        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        public static string zipPassword = "Duc@nhBTL";
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
        public static DateTime ConvertStringToDate(string strDate)
        {
            string format = "yyyy-MM-dd";
            DateTime dateObj = DateTime.ParseExact(strDate, format, System.Globalization.CultureInfo.InvariantCulture);
            return dateObj;
        }
        public static string ConvertDateToString(DateTime date)
        {
            string format = "yyyy-MM-dd";
            return date.ToString(format);

        }
        public static string GetFolderPath()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }

            return null;
        }
        public static bool ValidateExcelFile(string templateFilePath, string targetFilePath,ref string error)
        {
            // Khởi tạo GemBox.Spreadsheet
            SpreadsheetInfo.SetLicense("ETZX-IT28-33Q6-1HA2");

            // Đọc thông tin từ tệp Excel mẫu (template)
            ExcelFile templateWorkbook = ExcelFile.Load(templateFilePath);
            ExcelWorksheet templateWorksheet = templateWorkbook.Worksheets[0];
            int templateColumnCount = templateWorksheet.CalculateMaxUsedColumns();

            // Đọc thông tin từ tệp Excel cần kiểm tra
            ExcelFile targetWorkbook = ExcelFile.Load(targetFilePath);
            ExcelWorksheet targetWorksheet = targetWorkbook.Worksheets[0];
            int targetColumnCount = targetWorksheet.CalculateMaxUsedColumns();

            string[] headersTemplate = GetHeaders(templateWorksheet);
            // Lấy header từ tệp 2
            string[] headersTarget = GetHeaders(targetWorksheet);
            // So sánh số lượng header
            if (headersTemplate.Length != headersTarget.Length)
            {
                error = "Số lượng cột không giống nhau.";
                return false;
            }
            // So sánh từng header
            for (int i = 0; i < headersTemplate.Length; i++)
            {
                if (headersTemplate[i] != headersTarget[i])
                {
                    error = $"\"Tên cột tại vị trí {i + 1} sai ({headersTarget[i]}). Tên cột đúng là ('{headersTemplate[i]}')\"";
                    return false;
                }
            }
          
           if(targetWorkbook.Worksheets.Count() < 3)
            {
                error = "Thiếu sheet quá trình đào tạo và bồi dưỡng.";
                return false;
            };
           
            // Nếu số lượng cột và vị trí các cột đều khớp, tệp Excel được xem là hợp lệ
            error = "";
            return true;
        }
        static string[] GetHeaders(ExcelWorksheet worksheet)
        {
            int columnCount = worksheet.CalculateMaxUsedColumns();
            string[] headers = new string[columnCount];
            for (int i = 0; i < columnCount; i++)
            {
                // Lấy giá trị của ô đầu tiên trong cột làm header
                headers[i] = worksheet.Cells[0, i].Value?.ToString();
            }
            return headers;
        }

    }
    public class Checking
    {
        public static double CheckNullNumber(object obj)
        {
            if (obj == null)
            {
                return 0.0;
            }

            if (obj == DBNull.Value)
            {
                return 0.0;
            }

            double result = 0.0;
            double.TryParse(obj.ToString(), out result);
            return result;
        }

        public static decimal CheckNullNumberD(object obj)
        {
            if (obj == null)
            {
                return 0m;
            }

            if (obj == DBNull.Value)
            {
                return 0m;
            }

            decimal result = default(decimal);
            decimal.TryParse(obj.ToString(), out result);
            decimal.TryParse(result.ToString("G29"), out result);
            return Math.Round(result, 2);
        }

        public static int CheckNullInt(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }

                if (obj == DBNull.Value)
                {
                    return 0;
                }

                return Convert.ToInt32(obj);
            }
            catch (Exception)
            {
                return 0;
            }
           
        }

        public static uint CheckNullUnit(object obj)
        {
            if (obj == null)
            {
                return 0u;
            }

            if (obj == DBNull.Value)
            {
                return 0u;
            }

            uint result = 0u;
            uint.TryParse(obj.ToString(), out result);
            return result;
        }

        public static string CheckNullString(object obj)
        {
            if (obj == null)
            {
                return "";
            }

            if (obj == DBNull.Value)
            {
                return "";
            }

            return obj.ToString();
        }
        


    }
}
