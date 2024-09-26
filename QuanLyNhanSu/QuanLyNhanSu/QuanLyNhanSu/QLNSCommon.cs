using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public class QLNSCommon
    {
        public static string pathCategory = AppDomain.CurrentDomain.BaseDirectory + "Data\\Category\\";
        public static string pathAccount = AppDomain.CurrentDomain.BaseDirectory + "Data\\Account\\";
        public static string pathManagerment = AppDomain.CurrentDomain.BaseDirectory + "Data\\Managerment\\";
        public static string path = AppDomain.CurrentDomain.BaseDirectory;
        public static string glbVersion = "1.0.1";
        public static string glbContact = "0912899900";
        public static string glbUserCache = "";
        public static bool IsValidDate(string dateStr, string format)
        {
            DateTime date;
            return DateTime.TryParseExact(dateStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
        public static void CloseFormIfOpen(Type formType)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == formType)
                {
                    form.Close();
                    return; // Thoát khỏi vòng lặp sau khi đóng form
                }
            }
        }
        public static void SetComboBoxDropDownWidth(System.Windows.Forms.ComboBox comboBox)
        {
            int maxWidth = 0;
            foreach (var item in comboBox.Items)
            {
                int itemWidth = TextRenderer.MeasureText(item.ToString(), comboBox.Font).Width;
                if (itemWidth > maxWidth)
                {
                    maxWidth = itemWidth;
                }
            }
            comboBox.DropDownWidth = maxWidth + SystemInformation.VerticalScrollBarWidth;
        }
    }
}
