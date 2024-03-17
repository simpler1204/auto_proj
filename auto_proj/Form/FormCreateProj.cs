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
using auto_proj.Classes;
using System.Data.SqlClient;

namespace auto_proj.Form
{
    public partial class FormCreateProj : DevExpress.XtraEditors.XtraForm
    {
        byte[] instExcelBytes;
        public FormCreateProj()
        {
            InitializeComponent();
            this.instExcelBytes = null;

            //combobox 수정 방지
            cmbPlcCount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbPlcBrand.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        private void FormCreateProj_Load(object sender, EventArgs e)
        {
            panelControl1.Visible = false;
            buttons.ButtonClick += Buttons_ButtonClick;
            AddPlcBrand();
            AddCustomerNames();
            AddHmiNames();
        }

        private void AddPlcBrand()
        {
            FormPlcBrand formPlcBrand = new FormPlcBrand();
            IEnumerator<string> em = formPlcBrand.GetPlcNames();
            while (em.MoveNext())
            {
                cmbPlcBrand.Properties.Items.Add(em.Current);
            }            
        }

        private void AddCustomerNames()
        {
            FormCustomer formCustomer = new FormCustomer();
            IEnumerator<string> em = formCustomer.GetCustomerNames();
            while (em.MoveNext())
            {
                cmbCustomer.Properties.Items.Add(em.Current);
            }
        }

        private void AddHmiNames()
        {
            FormHmi fromHmi = new FormHmi();
            IEnumerator<string> em = fromHmi.GetHmiNames();
            while (em.MoveNext())
            {               
                cmbHmi.Properties.Items.Add(em.Current);
            }
        }

        private void Buttons_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            String name = e.Button.Properties.Caption;

            switch (name)
            {
                case "New":
                    new_function();
                    break;
                case "Cancel":                    
                    cancel_function();
                    break;
                case "Save":
                    save_function();
                    break;
            }
        }

        private void new_function()
        {
            panelControl1.Visible = true;
            txtProjName.Text = "";
            txtProjCode.Text = "";
            txtAiName.Text = "";
            txtAoName.Text = "";
            txtDiName.Text = "";
            txtDoName.Text = "";
            cmbPlcBrand.Text = "";
            cmbPlcCount.Text = "";
            txtFileName.Text = "";
            txtFilePath.Text = "";
            cmbCustomer.Text = "";
            cmbHmi.Text = "";
        }

        private void cancel_function()
        {
            panelControl1.Visible = false;
        }

        private void save_function()
        {
            string sCode, sName, sBrand, sCustomer, sHmi, sAi, sAo, sDi, sDo;
            string fileName = string.Empty;
            string fileTotalName = string.Empty;
            int plcCount;

            if (!CheckFields()) return; // 빠진 항목이 있으면 return;

            sCode = txtProjCode.Text.Trim();
            sName = txtProjName.Text.Trim();
            sBrand = cmbPlcBrand.Text.Trim();
            sCustomer = cmbCustomer.Text.Trim();
            sHmi = cmbHmi.Text.Trim();
            sAi = txtAiName.Text.Trim();
            sAo = txtAoName.Text.Trim();
            sDi = txtDiName.Text.Trim();
            sDo = txtDoName.Text.Trim();
            plcCount = int.Parse(cmbPlcCount.Text.Trim());
            fileName = txtFileName.Text.Trim();
            fileTotalName = txtFilePath.Text.Trim();
            int rtn = 0;

            string connectString = SIDS.Instance.MakeConnectionString("DB");
            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = @"INSERT INTO proj_master(proj_code, proj_name, customer, plc_count, plc_brand, hmi, ai_name, ao_name, di_name, do_name, inst_file_name, inst_file_path, inst_excel, created_date)
                                VALUES(@code, @name, @customer, @Count, @plc, @hmi, @ai, @ao, @di, @do, @file_name, @file_path, @inst_excel, getdate())";
               
                using(SqlCommand cmd = new SqlCommand(query, DBConn))
                {                   
                    cmd.Parameters.Add("@code", SqlDbType.NVarChar).Value = sCode;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = sName;
                    cmd.Parameters.Add("@customer", SqlDbType.NVarChar).Value = sCustomer;
                    cmd.Parameters.Add("@Count", SqlDbType.Int).Value = plcCount;
                    cmd.Parameters.Add("@plc", SqlDbType.NVarChar).Value = sBrand;
                    cmd.Parameters.Add("@hmi", SqlDbType.NVarChar).Value = sHmi;
                    cmd.Parameters.Add("@ai", SqlDbType.NVarChar).Value = sAi;
                    cmd.Parameters.Add("@ao", SqlDbType.NVarChar).Value = sAo;
                    cmd.Parameters.Add("@di", SqlDbType.NVarChar).Value = sDi;
                    cmd.Parameters.Add("@do", SqlDbType.NVarChar).Value = sDo;
                    cmd.Parameters.Add("@file_name", SqlDbType.NVarChar).Value = fileName;
                    cmd.Parameters.Add("@file_path", SqlDbType.NVarChar).Value = fileTotalName;
                    cmd.Parameters.Add("@inst_excel", SqlDbType.VarBinary).Value = instExcelBytes;

                    try
                    {
                        DBConn.Open();
                        rtn = cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }                    
                }
            }
            panelControl1.Visible = false;

            if(rtn > 0)
                MessageBox.Show("프로젝스 생성 완료", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("프로젝스 생성 실패", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            string fileTotalName = string.Empty;
            instExcelBytes = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileTotalName = openFileDialog.FileName;
                string[] splited = fileTotalName.Split('\\');
                fileName = splited.Last<string>();
                txtFilePath.Text = fileTotalName;
                txtFileName.Text = fileName;
            }

            try
            {
                if (fileName != string.Empty)
                    instExcelBytes = BinaryFile.GetBinaryFromFile(fileTotalName);
                else
                    return;
            }
            catch(Exception ex)
            {
                txtFilePath.Text = "";
                txtFileName.Text = "";
                MessageBox.Show(ex.ToString());
            }

            //  BinaryFile.MakeFileFromBinary(bytes, splited.Last<string>());
        }

        private bool CheckFields()
        {
            bool rtn = true;
            if (txtProjCode.Text.Trim() == "") { rtn = false; return rtn; }
            if (txtProjName.Text.Trim() == "") { rtn = false; return rtn; }
            if (cmbCustomer.Text.Trim() == "") { rtn = false; return rtn; }
            if (cmbPlcBrand.Text.Trim() == "") { rtn = false; return rtn; }
            if (cmbHmi.Text.Trim() == "") { rtn = false; return rtn; }
            if (txtAiName.Text.Trim() == "") { rtn = false; return rtn; }
            if (txtAoName.Text.Trim() == "") { rtn = false; return rtn; }
            if (txtDiName.Text.Trim() == "") { rtn = false; return rtn; }
            if (txtDoName.Text.Trim() == "") { rtn = false; return rtn; }
            if (cmbPlcCount.Text.Trim() == "") { rtn = false; return rtn; }
            if (txtFileName.Text.Trim() == "") { rtn = false; return rtn; }
            if (txtFilePath.Text.Trim() == "") { rtn = false; return rtn; }

            return rtn;
        }
    }
}