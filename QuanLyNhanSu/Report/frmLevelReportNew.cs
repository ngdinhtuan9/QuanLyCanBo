using GemBox.Spreadsheet;
using QuanLyNhanSu.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhanSu.Report
{
    public partial class frmLevelReportNew : Form
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "Data\\Account\\Account.txt";
        List<User> allUser;

        string fileName = "Person\\Person.txt";
        // List<Person> person;
        List<Person> allperson; 

        List<Unit> allUnits;
        string fileUnitName = "Units\\Units.txt";
        public frmLevelReportNew()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                List<Person> personSearch = new List<Person>();
                personSearch = allperson;
                var total = personSearch
                                        //.Where(person => person.UnitCode == "Phòng Tổ chức cán bộ")
                                        .GroupBy(person => new { person.UnitCode})
                                        .Select(group => new
                                        {
                                            UnitCode = group.Key.UnitCode,
                                           // InternalAcademicLevelName = group.Key.InternalAcademicLevelName,
                                            totalPeople = group.Count()
                                        }).ToList();

                var internalAcademicLevelName = personSearch
                                        //.Where(person => person.UnitCode == "Phòng Tổ chức cán bộ")
                                        .GroupBy(person => new { person.UnitCode, person.InternalAcademicLevelName })
                                        .Select(group => new
                                        {
                                            UnitCode   = group.Key.UnitCode,
                                            InternalAcademicLevelName = group.Key.InternalAcademicLevelName,
                                            Count = group.Count()
                                        }).ToList();

                var academicLevelName = personSearch
                                       //.Where(person => person.UnitCode == "Phòng Tổ chức cán bộ")
                                       .GroupBy(person => new { person.UnitCode, person.AcademicLevelName })
                                       .Select(group => new
                                       {
                                           UnitCode = group.Key.UnitCode,
                                           AcademicLevelName  = group.Key.AcademicLevelName,
                                           Count = group.Count()
                                       }).ToList();

                var curInternalAcademicLevelName = personSearch
                                       //.Where(person => person.UnitCode == "Phòng Tổ chức cán bộ")
                                       .GroupBy(person => new { person.UnitCode, person.CurInternalAcademicLevelName })
                                       .Select(group => new
                                       {
                                           UnitCode   = group.Key.UnitCode,
                                           CurInternalAcademicLevelName = group.Key.CurInternalAcademicLevelName,
                                           Count = group.Count()
                                       }).ToList();

                var politicalLevel = personSearch
                                      //.Where(person => person.UnitCode == "Phòng Tổ chức cán bộ")
                                      .GroupBy(person => new { person.UnitCode, person.PoliticalLevel })
                                      .Select(group => new
                                      {
                                          UnitCode = group.Key.UnitCode,
                                          PoliticalLevel = group.Key.PoliticalLevel,
                                          Count = group.Count()
                                      }).ToList();

                var fosteringPLNV = personSearch
                                       .Where(person => person.FosteringPLNV != "")
                                       .GroupBy(person => new { person.UnitCode })
                                       .Select(group => new
                                       {
                                           UnitCode = group.Key.UnitCode,
                                           Count = group.Count()
                                       }).ToList();

                var tittleTraning = personSearch
                                       .Where(person => person.TittleTraning != "")
                                       .GroupBy(person => new { person.UnitCode })
                                       .Select(group => new
                                       {
                                           UnitCode = group.Key.UnitCode,
                                           Count = group.Count()
                                       }).ToList();
                var tittleTraningPlanning = personSearch
                                       .Where(person => person.TittleTraningPlanning != "")
                                       .GroupBy(person => new { person.UnitCode })
                                       .Select(group => new
                                       {
                                           UnitCode = group.Key.UnitCode,
                                           Count = group.Count()
                                       }).ToList();
                var fosteringQPA = personSearch
                                       .Where(person => person.FosteringQPA != "")
                                       .GroupBy(person => new { person.UnitCode })
                                       .Select(group => new
                                       {
                                           UnitCode = group.Key.UnitCode,
                                           Count = group.Count()
                                       }).ToList();
                var classify = personSearch
                                       .Where(person => person.Classify != "")
                                       .GroupBy(person => new { person.UnitCode })
                                       .Select(group => new
                                       {
                                           UnitCode = group.Key.UnitCode,
                                           Count = group.Count()
                                       }).ToList();
                var competition = personSearch
                                       .Where(person => person.Competition != "")
                                       .GroupBy(person => new { person.UnitCode })
                                       .Select(group => new
                                       {
                                           UnitCode = group.Key.UnitCode,
                                           Count = group.Count()
                                       }).ToList();


                string  selectedFilePath = "";
                SpreadsheetInfo.SetLicense(Common.excelLicence);
                string filePath = QLNSCommon.path + "Template\\BieuMauThongKeTrinhDo.xlsx";
                // Load file Excel đã có sẵn
                ExcelFile workbook = ExcelFile.Load(filePath);
                ExcelWorksheet worksheet = workbook.Worksheets[0];
                //ExcelWorksheet worksheetTranning = workbook.Worksheets[1];
                //ExcelWorksheet worksheetFostering = workbook.Worksheets[2];

                int startRow = 4;
                // int startRowTranning = 2;
                // int startRowFostering = 2;
                List<Unit> units = allUnits;
                if(cbxUnit.Text != "Tất cả")
                {
                    units = allUnits.Where(unit => unit.Name == cbxUnit.Text).ToList();
                }

                int stt = 0;
                for (int row = 0; row < units.Count; row++)
                {
                    stt = stt + 1;
                    worksheet.Cells[startRow + row + 1, 0].Value = stt;
                    worksheet.Cells[startRow + row + 1, 1].Value = units[row].Name;

                    var totalSub = total.Where(person => person.UnitCode == units[row].Name).ToList();
                    if (totalSub.Count() > 0)
                    {
                        worksheet.Cells[startRow + row + 1, 2].Value = totalSub[0].totalPeople;
                    }
                   

                    var internalAcademicLevelNameSub = internalAcademicLevelName.Where(person => person.UnitCode == units[row].Name).ToList();
                   for (int i = 0; i < internalAcademicLevelNameSub.Count; i++)
                    {
                        if (internalAcademicLevelNameSub[i].InternalAcademicLevelName == "Tiến sĩ")
                        {
                            worksheet.Cells[startRow + row + 1, 3].Value = internalAcademicLevelNameSub[i].Count;
                        }else if(internalAcademicLevelNameSub[i].InternalAcademicLevelName == "Thạc sĩ")
                        {
                            worksheet.Cells[startRow + row + 1, 4].Value = internalAcademicLevelNameSub[i].Count;
                        }
                        else if (internalAcademicLevelNameSub[i].InternalAcademicLevelName == "Đại học")
                        {
                            worksheet.Cells[startRow + row + 1, 5].Value = internalAcademicLevelNameSub[i].Count;
                        }
                        else if (internalAcademicLevelNameSub[i].InternalAcademicLevelName == "Cao đẳng")
                        {
                            worksheet.Cells[startRow + row + 1, 6].Value = internalAcademicLevelNameSub[i].Count;
                        }
                        else if (internalAcademicLevelNameSub[i].InternalAcademicLevelName == "Trung cấp")
                        {
                            worksheet.Cells[startRow + row + 1, 7].Value = internalAcademicLevelNameSub[i].Count;
                        }
                    }
                    var academicLevelNameSub = academicLevelName.Where(person => person.UnitCode == units[row].Name).ToList();
                    for (int i = 0; i < academicLevelNameSub.Count; i++)
                    {
                        if (academicLevelNameSub[i].AcademicLevelName == "Tiến sĩ")
                        {
                            worksheet.Cells[startRow + row + 1, 8].Value = academicLevelNameSub[i].Count;
                        }
                        else if (academicLevelNameSub[i].AcademicLevelName == "Thạc sĩ")
                        {
                            worksheet.Cells[startRow + row + 1, 9].Value = academicLevelNameSub[i].Count;
                        }
                        else if (academicLevelNameSub[i].AcademicLevelName == "Đại học")
                        {
                            worksheet.Cells[startRow + row + 1, 10].Value = academicLevelNameSub[i].Count;
                        }
                        else if (academicLevelNameSub[i].AcademicLevelName == "Cao đẳng")
                        {
                            worksheet.Cells[startRow + row + 1, 11].Value = academicLevelNameSub[i].Count;
                        }
                        else if (academicLevelNameSub[i].AcademicLevelName == "Trung cấp")
                        {
                            worksheet.Cells[startRow + row + 1, 12].Value = academicLevelNameSub[i].Count;
                        }
                        else if (academicLevelNameSub[i].AcademicLevelName == "Sơ cấp")
                        {
                            worksheet.Cells[startRow + row + 1, 13].Value = academicLevelNameSub[i].Count;
                        }
                        else if (academicLevelNameSub[i].AcademicLevelName == "Cán bộ chuyên nghiệp")
                        {
                            worksheet.Cells[startRow + row + 1, 14].Value = academicLevelNameSub[i].Count;
                        }
                    }
                    var curInternalAcademicLevelNameSub = curInternalAcademicLevelName.Where(person => person.UnitCode == units[row].Name).ToList();
                    if (curInternalAcademicLevelNameSub.Count > 0)
                    {
                        for (int i = 0; i < curInternalAcademicLevelNameSub.Count; i++)
                        {
                            if (curInternalAcademicLevelNameSub[i].CurInternalAcademicLevelName == "Tiến sĩ")
                            {
                                worksheet.Cells[startRow + row + 1, 15].Value = curInternalAcademicLevelNameSub[i].Count;
                            }
                            else if (curInternalAcademicLevelNameSub[i].CurInternalAcademicLevelName == "Thạc sĩ")
                            {
                                worksheet.Cells[startRow + row + 1, 16].Value = curInternalAcademicLevelNameSub[i].Count;
                            }
                            else if (curInternalAcademicLevelNameSub[i].CurInternalAcademicLevelName == "Đại học")
                            {
                                worksheet.Cells[startRow + row + 1, 17].Value = curInternalAcademicLevelNameSub[i].Count;
                            }
                            else if (curInternalAcademicLevelNameSub[i].CurInternalAcademicLevelName == "Cao đẳng")
                            {
                                worksheet.Cells[startRow + row + 1, 18].Value = curInternalAcademicLevelNameSub[i].Count;
                            }
                            else if (curInternalAcademicLevelNameSub[i].CurInternalAcademicLevelName == "Trung cấp")
                            {
                                worksheet.Cells[startRow + row + 1, 19].Value = curInternalAcademicLevelNameSub[i].Count;
                            }
                        }
                    }
                    

                    var fosteringPLNVSub = fosteringPLNV.Where(person => person.UnitCode == units[row].Name).ToList();
                    if (fosteringPLNVSub.Count > 0)
                    {
                        worksheet.Cells[startRow + row + 1, 20].Value = fosteringPLNVSub[0].Count;
                    }
                    var tittleTraningSub = tittleTraning.Where(person => person.UnitCode == units[row].Name).ToList();
                    if (tittleTraningSub.Count > 0)
                    {
                        worksheet.Cells[startRow + row + 1, 21].Value = tittleTraningSub[0].Count;
                    }
                    var tittleTraningPlanningSub = tittleTraningPlanning.Where(person => person.UnitCode == units[row].Name).ToList();
                    if (tittleTraningPlanningSub.Count > 0)
                    {
                        worksheet.Cells[startRow + row + 1, 22].Value = tittleTraningPlanningSub[0].Count;
                    }
                    var fosteringQPASub = fosteringQPA.Where(person => person.UnitCode == units[row].Name).ToList();
                    if (fosteringQPASub.Count > 0)
                    {
                        worksheet.Cells[startRow + row + 1, 23].Value = fosteringQPASub[0].Count;
                    }
                    var politicalLevelSub = politicalLevel.Where(person => person.UnitCode == units[row].Name).ToList();
                    for (int i = 0; i < politicalLevelSub.Count; i++)
                    {
                        if (politicalLevelSub[i].PoliticalLevel == "Cao cấp")
                        {
                            worksheet.Cells[startRow + row + 1, 24].Value = politicalLevelSub[i].Count;
                        }
                        else if (politicalLevelSub[i].PoliticalLevel == "Trung cấp")
                        {
                            worksheet.Cells[startRow + row + 1, 25].Value = politicalLevelSub[i].Count;
                        }
                        else if (politicalLevelSub[i].PoliticalLevel == "Sơ cấp")
                        {
                            worksheet.Cells[startRow + row + 1, 26].Value = politicalLevelSub[i].Count;
                        }
                    }
                    var classifySub = classify.Where(person => person.UnitCode == units[row].Name).ToList();
                    if (classifySub.Count > 0)
                    {
                        worksheet.Cells[startRow + row + 1, 27].Value = classifySub[0].Count;
                    }
                    var competitionSub = competition.Where(person => person.UnitCode == units[row].Name).ToList();
                    if (competitionSub.Count > 0)
                    {
                        worksheet.Cells[startRow + row + 1, 28].Value = competitionSub[0].Count;
                    }
                }
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    // Show the dialog and get the result.
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the selected file path.
                        string filePathName = saveFileDialog.FileName;
                        selectedFilePath = filePathName;
                        workbook.Save(filePathName);
                    }
                }
                if (MessageBox.Show("Lưu dữ liệu thành công. Bạn có muốn mở báo cáo không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Checking.CheckNullString(selectedFilePath) == "")
                    {
                        return;
                    }
                    Process.Start(selectedFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
         
       
        XmlNodeList nodeList;
        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            try
            {
                string unit = Common.ReadFileContent(QLNSCommon.pathCategory + fileUnitName);
                allUnits = new List<Unit>();
                allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(unit);
                if (allUnits.Count > 1)
                {
                    Unit unitAll = new Unit();
                    unitAll.Name = "Tất cả";
                    unitAll.Id = 0;
                    allUnits.Add(unitAll);
                }
                cbxUnit.DataSource = allUnits;
                cbxUnit.DisplayMember = "Name";
                cbxUnit.ValueMember = "Id";
                cbxUnit.Text = "Tất cả";
                cbxUnit.DropDownWidth = 400;
                cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;

                string contentUser = Common.ReadFileContent(path);
                allUser = new List<User>();
                allUser = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(contentUser);

                string content = Common.ReadFileContent(QLNSCommon.pathManagerment + fileName);
                allperson = new List<Person>();
                allperson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            
        }
       
    }
}
