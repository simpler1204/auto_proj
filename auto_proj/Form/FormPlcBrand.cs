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

namespace auto_proj.Form
{
    public partial class FormPlcBrand : DevExpress.XtraEditors.XtraForm
    {
        List<string> plcNames = new List<string>();


        public FormPlcBrand()
        {
            InitializeComponent();     
        }

        private void FormPlcBrand_Load(object sender, EventArgs e)
        {            
            GetPlcNames();
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {            
            int plcCount = plcList.ItemCount;
            if (plcCount < 1) return;
            string selected = plcList.SelectedItem.ToString();

            DialogResult result = MessageBox.Show($"{selected}을(를) 삭제 하시겠습니까?", "Warning", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;

            deletePlcName(selected);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string plcName = txtPlcName.Text.Trim();
            InsertPlcName(plcName);
            txtPlcName.Text = "";
        }

        public IEnumerator<string> GetPlcNames()
        {
            string connectString = SIDS.Instance.MakeConnectionString("DB");

            plcNames.Clear();

            using(SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = "SELECT plc_kind FROM PLC_KIND";

                using (SqlCommand cmd = new SqlCommand(query, DBConn))
                {
                    DBConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        plcNames.Add(reader[0].ToString());
                    }                   
                }
            }

            return plcNames.GetEnumerator();
        }      

        private void InsertPlcName(string name)
        {
            int rs;
            string connectString = SIDS.Instance.MakeConnectionString("DB");
            var isContain = plcNames.Contains(name);
            if (isContain)
            {                
                return;// 이미 등록 되어있으면 return 
            }

            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = "INSERT INTO plc_kind(plc_kind) VALUES(@plcKind)";
                using (SqlCommand cmd = new SqlCommand(query, DBConn))
                {
                    cmd.Parameters.Add("@plcKind", SqlDbType.NVarChar, 100).Value = name;
                    DBConn.Open();
                    rs = cmd.ExecuteNonQuery();
                }

                if (rs > 0)
                {
                    plcNames.Add(name);
                    PlcListRefresh();
                }
            }         
        }

        private void deletePlcName(string name)
        {
            int rs;
            string connectString = SIDS.Instance.MakeConnectionString("DB");
            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = "DELETE plc_kind WHERE plc_kind = @plcKind";
                using(SqlCommand cmd = new SqlCommand(query, DBConn))
                {
                    DBConn.Open();
                    cmd.Parameters.Add("@plcKind", SqlDbType.NVarChar, 100).Value = name;
                    rs = cmd.ExecuteNonQuery();
                }
            }

            if(rs > 0)
            {
                plcNames.Remove(name);
                PlcListRefresh();
            }
        }

        private void PlcListRefresh()
        {
            var sorted = plcNames.OrderBy(c => c).ToList();
            plcList.DataSource = sorted;
        }

       
    }
}