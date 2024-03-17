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
    public partial class FormCustomer : DevExpress.XtraEditors.XtraForm
    {
        List<string> customers = new List<string>();

        public FormCustomer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim() != "")
                AddCustomer(txtCustomerName.Text.Trim());
        }

        private void AddCustomer(string name)
        {
            string connectString = SIDS.Instance.MakeConnectionString("DB");
            int rtn = 0;
            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = "INSERT INTO customer(customer_name) VALUES(@name)";
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

            if (rtn > 0) customers.Add(name);

            customerList.DataSource = customers;
            CustomerListRefresh();
            txtCustomerName.Text = "";
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            SelectCustomer();
        }

        private void SelectCustomer()
        {
            string connectString = SIDS.Instance.MakeConnectionString("DB");
            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = "SELECT customer_name FROM customer";
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
                    customers.Add(reader["customer_name"].ToString());
                }
            }

            customerList.DataSource = customers;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int customerCount = customerList.ItemCount;
            if (customerCount < 1) return;
            string selected = customerList.SelectedItem.ToString();

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
                string query = "DELETE customer WHERE customer_name = @name";
                using (SqlCommand cmd = new SqlCommand(query, DBConn))
                {
                    DBConn.Open();
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = customerName;
                    rs = cmd.ExecuteNonQuery();
                }
            }
            customers.Remove(customerName);
            CustomerListRefresh();

        }

        private void CustomerListRefresh()
        {
            var sorted = customers.OrderBy(c => c).ToList();
            customerList.DataSource = sorted;
        }

        public IEnumerator<string> GetCustomerNames()
        {
            string connectString = SIDS.Instance.MakeConnectionString("DB");

            customers.Clear();

            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = "SELECT customer_name FROM customer";

                using (SqlCommand cmd = new SqlCommand(query, DBConn))
                {
                    DBConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        customers.Add(reader[0].ToString());
                    }
                }
            }

            return customers.GetEnumerator();
        }
    }
}