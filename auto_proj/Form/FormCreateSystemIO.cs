using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using auto_proj.Popup;
using auto_proj.Classes;
using System.Runtime.InteropServices;
using auto_proj.Enum;
using System.IO;

namespace auto_proj.Form
{
    public partial class FormCreateSystemIO : DevExpress.XtraEditors.XtraForm
    {
        Project project;
        PopupSelectProj selectProj = null;

        Microsoft.Office.Interop.Excel.Application xlApp = null;
        Microsoft.Office.Interop.Excel.Workbook xlWorkbook = null;

        List<Sheet> sheetList = new List<Sheet>();
        List<PartIoCount> plcIoCountList = new List<PartIoCount>();
        
        string sludgeName = "SLUDGE";
        string[] arrWorkingPart = { "INST", "PKG", "MCC", "공조제어" };
        //string[] arrWorkingPart = { "INST" };
        string[] arrIoTypeNames = new string[4];

        DataTable dtInst = new DataTable();
        DataTable dtPkg = new DataTable();
        DataTable dtMcc = new DataTable();
        DataTable dtHvac = new DataTable();



        public FormCreateSystemIO()
        {
            InitializeComponent();           
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            selectProj = new PopupSelectProj();
            selectProj.SelectedProj += SelectProj_SelectedProj;
            selectProj.ShowDialog();
            selectProj.SelectedProj -= SelectProj_SelectedProj;
        }

        private void SelectProj_SelectedProj(object sender, EventArgs e)
        {           

            project = ((PopupSelectProj.SelectedProjArgs)e).project;
            txtCode.Text = project.ProjCode;
            txtName.Text = project.ProjName;
            txtPlc.Text = project.PlcBrand;
            txtCount.Text = project.PlcCount.ToString();
            txtAi.Text = project.AiDefine;
            txtAo.Text = project.AoDefine;
            txtDi.Text = project.DiDefine;
            txtDo.Text = project.DoDefine;
            txtInst.Text = project.InstFileName;
            txtCreated.Text = project.Created.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (project == null) return;

            ExcelOpen();

            arrIoTypeNames[0] = project.AiDefine;
            arrIoTypeNames[1] = project.AoDefine;
            arrIoTypeNames[2] = project.DiDefine;
            arrIoTypeNames[3] = project.DoDefine;

            try
            {
                for (int i = 0; i < arrWorkingPart.Length; i++)
                {
                    GetIoTypeCount(arrWorkingPart[i], arrIoTypeNames, project.PlcCount);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                ExcelClose();
            }

            GatheringIoCount();

        }

        private void GatheringIoCount()
        {
            foreach (var v in plcIoCountList)
            {
                if (v.PART_NAME == "INST")
                {
                    DoGathering("INST", v, dtInst, gridInst);
                }

                if (v.PART_NAME == "PKG")
                {
                    DoGathering("PKG", v, dtPkg, gridPkg);
                }

                if (v.PART_NAME == "MCC")
                {
                    DoGathering("MCC", v, dtMcc, gridMcc);
                }

                if (v.PART_NAME == "공조제어")
                {
                    DoGathering("HVAC", v, dtHvac, gridHvac);
                }
            }
        
        }

       
        private void DoGathering(string part, PartIoCount v, DataTable dt, DevExpress.XtraGrid.GridControl grid)
        {
            int aiSum = 0, aoSum = 0, diSum = 0, doSum = 0;

            for (int i = 0; i < project.PlcCount; i++)
            {
                // MessageBox.Show(v.ToString());
                DataRow row = dt.NewRow();
                row["PART"] = part;
                row["PLC"] = "PLC" + (i + 1).ToString();
                row["AI"] = v[i].AI_COUNT;
                row["AO"] = v[i].AO_COUNT;
                row["DI"] = v[i].DI_COUNT;
                row["DO"] = v[i].DO_COUNT;

                aiSum += v[i].AI_COUNT;
                aoSum += v[i].AO_COUNT;
                diSum += v[i].DI_COUNT;
                doSum += v[i].DO_COUNT;

                dt.Rows.Add(row);
            }

            DataRow instRow = dt.NewRow();
            instRow["PART"] = part;
            instRow["PLC"] = "합계 :";
            instRow["AI"] = aiSum;
            instRow["AO"] = aoSum;
            instRow["DI"] = diSum;
            instRow["DO"] = doSum;
            dt.Rows.Add(instRow);
            grid.DataSource = dt;
        }
       
        private Sheet GetSheet(string sheetName)
        {
            Sheet selectedSheet = null;
            foreach (Sheet sheet in sheetList)
            {
                if (!sheet.SheetName.Contains(sludgeName) && sheet.SheetName.Contains(sheetName))
                {
                    selectedSheet = sheet;
                }
            }
            return selectedSheet;
        }

        private int GetIoTypeColumnNumber(string sheetName)
        {
            Sheet sheet = GetSheet(sheetName);

            int number = 0;

            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= sheet.XlRange.Columns.Count; j++)
                {
                    if (sheet.XlRange.Cells[i, j] != null && sheet.XlRange.Cells[i, j].Value2 != null)
                    {                        
                        if (sheet.XlRange.Cells[i, j].Value2.ToString() == "IO_Type")
                        {
                            number = j;
                            break;
                        }
                    }
                    }
                    if (number > 0) break;
            }

            return number;
        }

        private int GetPLCColumnNumber(string sheetName)
        {
            Sheet sheet = GetSheet(sheetName);
           
            int number = 0;

            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= sheet.XlRange.Columns.Count; j++)
                {
                    if (sheet.XlRange.Cells[i, j] != null && sheet.XlRange.Cells[i, j].Value2 != null)
                    {
                        //MessageBox.Show((sheet.XlRange.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Text);
                        if ((sheet.XlRange.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Text == "PLC")
                        {
                            number = j;
                            break;
                        }
                    }
                }
                if (number > 0) break;
            }

            return number;
        }

        private void GetIoTypeCount(string s, string[] ioTypenames, int plcCount)
        {
            try
            {
                Sheet sheet = GetSheet(s);
               

                int ioTypeColumn = GetIoTypeColumnNumber(s);
                int plcColumn = GetPLCColumnNumber(s);
               

                if (sheet == null)
                {
                    MessageBox.Show($"{s} 이름의 sheet가 존재하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ExcelClose();
                    return;
                }

                PartIoCount partIoCount = new PartIoCount(s);

                for (int i = 3; i <= sheet.XlRange.Rows.Count; i++)
                {
                    if (sheet.XlRange.Cells[i, ioTypeColumn] != null && sheet.XlRange.Cells[i, ioTypeColumn].Value2 != null
                        && sheet.XlRange.Cells[i, plcColumn] != null && sheet.XlRange.Cells[i, plcColumn].Value2 != null)
                    {
                        for (int j = 0; j < arrIoTypeNames.Length; j++)
                        {
                            for (int h = 0; h < project.PlcCount; h++)
                            {
                                if (sheet.XlRange.Cells[i, ioTypeColumn].Value2.ToString().Trim() == arrIoTypeNames[j] && sheet.XlRange.Cells[i, plcColumn].Value2.ToString().Trim() == "PLC" + (h + 1).ToString())
                                {
                                   
                                    if (j == 0) partIoCount[h].AI_COUNT++;
                                    if (j == 1) partIoCount[h].AO_COUNT++;
                                    if (j == 2) partIoCount[h].DI_COUNT++;
                                    if (j == 3) partIoCount[h].DO_COUNT++;
                                }
                            }
                        }

                        //    if (sheet.XlRange.Cells[i, ioTypeColumn].Value2.ToString().Trim() == "ANALOG INPUT" && sheet.XlRange.Cells[i, plcColumn].Value2.ToString().Trim() == "PLC1")
                        //        plc1_aiCount++;
                        //    else if (sheet.XlRange.Cells[i, ioTypeColumn].Value2.ToString().Trim() == "ANALOG INPUT" && sheet.XlRange.Cells[i, plcColumn].Value2.ToString().Trim() == "PLC2")
                        //        plc2_aiCount++;
                        //    else if (sheet.XlRange.Cells[i, ioTypeColumn].Value2.ToString().Trim() == "ANALOG OUTPUT" && sheet.XlRange.Cells[i, plcColumn].Value2.ToString().Trim() == "PLC1")
                        //        plc1_aoCount++;
                        //    else if (sheet.XlRange.Cells[i, ioTypeColumn].Value2.ToString().Trim() == "ANALOG OUTPUT" && sheet.XlRange.Cells[i, plcColumn].Value2.ToString().Trim() == "PLC2")
                        //        plc2_aoCount++;
                        //    else if (sheet.XlRange.Cells[i, ioTypeColumn].Value2.ToString().Trim() == "DISCRETE INPUT" && sheet.XlRange.Cells[i, plcColumn].Value2.ToString().Trim() == "PLC1")
                        //        plc1_diCount++;
                        //    else if (sheet.XlRange.Cells[i, ioTypeColumn].Value2.ToString().Trim() == "DISCRETE INPUT" && sheet.XlRange.Cells[i, plcColumn].Value2.ToString().Trim() == "PLC2")
                        //        plc2_diCount++;
                        //    else if (sheet.XlRange.Cells[i, ioTypeColumn].Value2.ToString().Trim() == "DISCRETE OUTPUT" && sheet.XlRange.Cells[i, plcColumn].Value2.ToString().Trim() == "PLC1")
                        //        plc1_doCount++;
                        //    else if (sheet.XlRange.Cells[i, ioTypeColumn].Value2.ToString().Trim() == "DISCRETE OUTPUT" && sheet.XlRange.Cells[i, plcColumn].Value2.ToString().Trim() == "PLC2")
                        //        plc2_doCount++;
                        //
                    }

                }
               
                plcIoCountList.Add(partIoCount);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               // MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        private void ExcelOpen()
        {           
            bool isExists = BinaryFile.MakeFileFromBinary(project.InstExcel, project.InstFileName);          

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkbook = xlApp.Workbooks.Open(Environment.CurrentDirectory + "\\" + project.InstFileName);

            for (int i = 1; i <= xlWorkbook.Worksheets.Count; i++)
            {
                Sheet sheet = new Sheet(xlWorkbook.Worksheets[i]);
                sheetList.Add(sheet);               
            }
        }


        private void ExcelClose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            foreach (var sheet in sheetList)
            {                
                sheet.Close();
            }

           
            Marshal.ReleaseComObject(xlWorkbook);           
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }

        private void FormCreateSystemIO_Load(object sender, EventArgs e)
        {           
            CreateDataTable();
        }

        private void CreateDataTable()
        {        
            DataTable[] dts = { dtInst, dtPkg, dtMcc, dtHvac };

            foreach(var dt in dts)
            {
                DataColumn column1 = new DataColumn("PART", typeof(string));
                DataColumn column2 = new DataColumn("PLC", typeof(string));
                DataColumn column3 = new DataColumn("AI", typeof(int));
                DataColumn column4 = new DataColumn("AO", typeof(int));
                DataColumn column5 = new DataColumn("DI", typeof(int));
                DataColumn column6 = new DataColumn("DO", typeof(int));

                dt.Columns.Add(column1);
                dt.Columns.Add(column2);
                dt.Columns.Add(column3);
                dt.Columns.Add(column4);
                dt.Columns.Add(column5);
                dt.Columns.Add(column6);

            }            
        }
    }
}