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
    public partial class FormHmi : DevExpress.XtraEditors.XtraForm
    {
        List<string> hmis = new List<string>();

        public FormHmi()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtHmiName.Text.Trim() != "")
                AddCustomer(txtHmiName.Text.Trim());
        }

        private void AddCustomer(string name)
        {
            string connectString = SIDS.Instance.MakeConnectionString("DB");
            int rtn = 0;
            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = "INSERT INTO hmi(hmi_name) VALUES(@name)";
                using (SqlCommand cmd = new SqlCommand(query, DBConn))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;

                    try
                    {
                        DBConn.Open();
                        rtn = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }

            if (rtn > 0) hmis.Add(name);

            hmiList.DataSource = hmis;
            HmiListRefresh();
            txtHmiName.Text = "";
        }

     
        private void SelectCustomer()
        {
            string connectString = SIDS.Instance.MakeConnectionString("DB");
            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = "SELECT hmi_name FROM hmi";
                SqlDataReader reader = null;
                using (SqlCommand cmd = new SqlCommand(query, DBConn))
                {
                    try
                    {
                        DBConn.Open();
                        reader = cmd.ExecuteReader();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }

                if (reader == null) return;
                while (reader.Read())
                {
                    hmis.Add(reader["hmi_name"].ToString());
                }
            }

            hmiList.DataSource = hmis;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int customerCount = hmiList.ItemCount;
            if (customerCount < 1) return;
            string selected = hmiList.SelectedItem.ToString();

            DialogResult result = MessageBox.Show($"{selected}을(를) 삭제 하시겠습니까?", "Warning",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;

            RemoveCustomer(selected);
        }

        private void RemoveCustomer(string customerName)
        {
            int rs;
            string connectString = SIDS.Instance.MakeConnectionString("DB");
            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = "DELETE hmi WHERE hmi_name = @name";
                using (SqlCommand cmd = new SqlCommand(query, DBConn))
                {
                    DBConn.Open();
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = customerName;
                    rs = cmd.ExecuteNonQuery();
                }
            }
            hmis.Remove(customerName);
            HmiListRefresh();

        }

        private void HmiListRefresh()
        {
            var sorted = hmis.OrderBy(c => c).ToList();
            hmiList.DataSource = sorted;
        }

        private void FormHmi_Load(object sender, EventArgs e)
        {
            SelectCustomer();
        }

        public IEnumerator<string> GetHmiNames()
        {
            string connectString = SIDS.Instance.MakeConnectionString("DB");

            hmis.Clear();

            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = "SELECT hmi_name FROM hmi";

                using (SqlCommand cmd = new SqlCommand(query, DBConn))
                {
                    DBConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        hmis.Add(reader[0].ToString());
                    }
                }
            }

            return hmis.GetEnumerator();
        }
    }
}