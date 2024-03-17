using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using auto_proj.Form;

namespace auto_proj
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
               
        private void subPlcBrand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {           
            FormPlcBrand plcBrand = null;
            OpenForm(plcBrand, typeof(FormPlcBrand));
            
        }

        private void subCreationProj_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCreateProj createProj = null;
            OpenForm(createProj, typeof(FormCreateProj));
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
        private void subIOCount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCreateSystemIO formCreateTemplate = null;
            OpenForm(formCreateTemplate, typeof(FormCreateSystemIO));
        }

        private DevExpress.XtraEditors.XtraForm ShwoActiveForm(DevExpress.XtraEditors.XtraForm form, Type type)
        {
            if (form == null || form.IsDisposed)
            {
                form = (DevExpress.XtraEditors.XtraForm)Activator.CreateInstance(type);
                form.MdiParent = this;
                form.WindowState = FormWindowState.Normal;
            }
            else
            {
                form.Activate();
            }

            return form;
        }

        private void OpenForm(DevExpress.XtraEditors.XtraForm form, Type type)
        {
            
            if (this.ActiveMdiChild != null)
            {
                if (this.ActiveMdiChild != form)
                {
                    this.ActiveMdiChild.Close();
                }
                form = ShwoActiveForm(form, type);
            }
            else
            {
                form = ShwoActiveForm(form, type);
            }

            form.Show();
        }

        private void subCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCustomer formCustomer = null;
            OpenForm(formCustomer, typeof(FormCustomer));
        }

        private void subHmiBrand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormHmi formHmi = null;
            OpenForm(formHmi, typeof(FormHmi));
        }
    }
}
