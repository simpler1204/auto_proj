using auto_proj.Classes;
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
using System.Data.SqlClient;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace auto_proj.Popup
{
    public partial class PopupSelectProj : DevExpress.XtraEditors.XtraForm
    {
        public event EventHandler SelectedProj;

        List<Project> projects = new List<Project>();

        DataTable dtProject = null;

        

        public class SelectedProjArgs : EventArgs
        {
            public Project project;
        }

        

        public PopupSelectProj()
        {
            InitializeComponent();
        }

        private void PopupSelectProj_Load(object sender, EventArgs e)
        {
            dtProject = GetProjects();   
            if (dtProject != null) gridProjects.DataSource = dtProject;

            gridView1.DoubleClick += GridView1_DoubleClick;            
        }

       

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            Project project = null;

            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = (GridView)sender;
            GridHitInfo info = view.CalcHitInfo(ea.Location);

            if (info.InRow || info.InRowCell)
            {
                DataRow row = view.GetDataRow(info.RowHandle);

                int id = int.Parse(row["proj_id"].ToString());
                string projCode = row["proj_code"].ToString();
                string projName = row["proj_name"].ToString();
                string plcBrand = row["plc_brand"].ToString();
                int plcCount = int.Parse(row["plc_count"].ToString());
                string sAi = row["ai_name"].ToString();
                string sAo = row["ao_name"].ToString();
                string sDi = row["di_name"].ToString();
                string sDo = row["do_name"].ToString();
                string instFileName = row["inst_file_name"].ToString();
                string instFilePath = row["inst_file_path"].ToString();
                byte[] instExcel = row["inst_excel"].ToString() == "" ? null : (byte[])row["inst_excel"];

                string templateFileName = row["template_file_name"].ToString();
                string templateFilePath = row["template_file_path"].ToString();
                byte[] templateExcel = row["template_excel"].ToString() == "" ? null : (byte[])row["template_excel"];

                string ioListFileName = row["ioList_file_name"].ToString();
                string ioListFilePath = row["ioList_file_path"].ToString();
                byte[] ioListExcel = row["ioList_excel"].ToString() == "" ? null : (byte[])row["ioList_excel"];

                string hmiFileName = row["hmi_file_name"].ToString();
                string hmiFilePath = row["hmi_file_path"].ToString();
                byte[] himExcel = row["hmi_excel"].ToString() == "" ? null : (byte[])row["hmi_excel"];

                DateTime created = (DateTime)row["created_date"];

                project = new Project(id, projCode, projName, plcBrand, plcCount, sAi, sAo, sDi, 
                    sDo, instFileName, instFilePath, instExcel, templateFileName, templateFilePath, 
                    templateExcel, ioListFileName, ioListFilePath, ioListExcel, hmiFileName, hmiFilePath, himExcel, created);

                SelectedProjArgs args = new SelectedProjArgs();
                args.project = project;
                SelectedProj(this, args);

                this.Close();
            }




        }

        private DataTable GetProjects()
        {
            DataTable dt = new DataTable();
            string connectString = SIDS.Instance.MakeConnectionString("DB");
            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = @"SELECT proj_id, proj_code, proj_name, plc_count, plc_brand, ai_name, ao_name, 
                                        di_name, do_name, inst_file_name, inst_file_path, inst_excel, template_file_name, template_file_path, 
	                                    template_excel, ioList_file_name, ioList_file_path, ioList_excel, hmi_file_name, hmi_file_path, hmi_excel, created_date, updated_date
	                             FROM proj_master
                                 ORDER BY created_date desc";
                using(SqlCommand cmd =  new SqlCommand(query, DBConn))
                {
                    DBConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);                  
                }
            }
            return dt.Rows.Count == 0 ? null : dt;
        }

        private void txtselect_TextChanged(object sender, EventArgs e)
        {
            IEnumerable<DataRow> finded = dtProject.AsEnumerable().Where(r => r.Field<string>("proj_name").Contains(txtselect.Text));
            gridProjects.DataSource = finded.CopyToDataTable();

            if (txtselect.Text.Trim() == "")
                gridProjects.DataSource = dtProject;

        }

       
    }
} 