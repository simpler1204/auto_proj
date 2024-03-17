
namespace auto_proj.Form
{
    partial class FormHmi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.txtHmiName = new System.Windows.Forms.TextBox();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.hmiList = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.hmiList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(436, 116);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(124, 46);
            this.btnRemove.TabIndex = 14;
            this.btnRemove.Text = "삭제";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtHmiName
            // 
            this.txtHmiName.Location = new System.Drawing.Point(111, 634);
            this.txtHmiName.Name = "txtHmiName";
            this.txtHmiName.Size = new System.Drawing.Size(189, 36);
            this.txtHmiName.TabIndex = 13;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(306, 629);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 46);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "추가";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(111, 77);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(110, 33);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "HMI 종류";
            // 
            // hmiList
            // 
            this.hmiList.Location = new System.Drawing.Point(111, 116);
            this.hmiList.Name = "hmiList";
            this.hmiList.Size = new System.Drawing.Size(319, 499);
            this.hmiList.TabIndex = 10;
            // 
            // FormHmi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 936);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txtHmiName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.hmiList);
            this.Name = "FormHmi";
            this.Text = "HMI";
            this.Load += new System.EventHandler(this.FormHmi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hmiList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private System.Windows.Forms.TextBox txtHmiName;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ListBoxControl hmiList;
    }
}