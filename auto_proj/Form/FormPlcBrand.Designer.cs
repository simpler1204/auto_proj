
namespace auto_proj.Form
{
    partial class FormPlcBrand
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
            this.plcList = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtPlcName = new System.Windows.Forms.TextBox();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.plcList)).BeginInit();
            this.SuspendLayout();
            // 
            // plcList
            // 
            this.plcList.Location = new System.Drawing.Point(99, 103);
            this.plcList.Name = "plcList";
            this.plcList.Size = new System.Drawing.Size(319, 499);
            this.plcList.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(99, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(103, 33);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "PLC 종류";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(294, 616);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 46);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "추가";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPlcName
            // 
            this.txtPlcName.Location = new System.Drawing.Point(99, 621);
            this.txtPlcName.Name = "txtPlcName";
            this.txtPlcName.Size = new System.Drawing.Size(189, 36);
            this.txtPlcName.TabIndex = 3;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(424, 103);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(124, 46);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "삭제";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FormPlcBrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 936);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txtPlcName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.plcList);
            this.Name = "FormPlcBrand";
            this.Text = "PLC";
            this.Load += new System.EventHandler(this.FormPlcBrand_Load);
            ((System.ComponentModel.ISupportInitialize)(this.plcList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl plcList;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.TextBox txtPlcName;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
    }
}