
namespace auto_proj.Form
{
    partial class FormCreateProj
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateProj));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.buttons = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbHmi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbCustomer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtDoName = new System.Windows.Forms.TextBox();
            this.txtDiName = new System.Windows.Forms.TextBox();
            this.txtAoName = new System.Windows.Forms.TextBox();
            this.txtAiName = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbPlcBrand = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbPlcCount = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtProjCode = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtProjName = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHmi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlcBrand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlcCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttons
            // 
            this.buttons.ButtonInterval = 30;
            windowsUIButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions1.SvgImage")));
            windowsUIButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions2.SvgImage")));
            windowsUIButtonImageOptions3.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions3.SvgImage")));
            this.buttons.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("New", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Cancel", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.buttons.Location = new System.Drawing.Point(10, 23);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(348, 124);
            this.buttons.TabIndex = 1;
            this.buttons.Text = "windowsUIButtonPanel1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmbHmi);
            this.panelControl1.Controls.Add(this.cmbCustomer);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.btnExcel);
            this.panelControl1.Controls.Add(this.txtFileName);
            this.panelControl1.Controls.Add(this.txtFilePath);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Controls.Add(this.txtDoName);
            this.panelControl1.Controls.Add(this.txtDiName);
            this.panelControl1.Controls.Add(this.txtAoName);
            this.panelControl1.Controls.Add(this.txtAiName);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.cmbPlcBrand);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.cmbPlcCount);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtProjCode);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtProjName);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(2, 179);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1166, 745);
            this.panelControl1.TabIndex = 2;
            // 
            // cmbHmi
            // 
            this.cmbHmi.Location = new System.Drawing.Point(179, 268);
            this.cmbHmi.Name = "cmbHmi";
            this.cmbHmi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbHmi.Size = new System.Drawing.Size(176, 44);
            this.cmbHmi.TabIndex = 24;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Location = new System.Drawing.Point(180, 112);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCustomer.Size = new System.Drawing.Size(176, 44);
            this.cmbCustomer.TabIndex = 23;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(54, 274);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(118, 29);
            this.labelControl11.TabIndex = 22;
            this.labelControl11.Text = "HMI 종류 : ";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(85, 119);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(87, 29);
            this.labelControl10.TabIndex = 20;
            this.labelControl10.Text = "고객사 : ";
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(903, 616);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(150, 46);
            this.btnExcel.TabIndex = 19;
            this.btnExcel.Text = "search";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(179, 621);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(716, 36);
            this.txtFileName.TabIndex = 18;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(179, 666);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(981, 36);
            this.txtFilePath.TabIndex = 17;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(94, 613);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(78, 29);
            this.labelControl9.TabIndex = 16;
            this.labelControl9.Text = "Excel : ";
            // 
            // txtDoName
            // 
            this.txtDoName.Location = new System.Drawing.Point(179, 560);
            this.txtDoName.Name = "txtDoName";
            this.txtDoName.Size = new System.Drawing.Size(289, 36);
            this.txtDoName.TabIndex = 15;
            // 
            // txtDiName
            // 
            this.txtDiName.Location = new System.Drawing.Point(179, 502);
            this.txtDiName.Name = "txtDiName";
            this.txtDiName.Size = new System.Drawing.Size(289, 36);
            this.txtDiName.TabIndex = 14;
            // 
            // txtAoName
            // 
            this.txtAoName.Location = new System.Drawing.Point(179, 444);
            this.txtAoName.Name = "txtAoName";
            this.txtAoName.Size = new System.Drawing.Size(289, 36);
            this.txtAoName.TabIndex = 13;
            // 
            // txtAiName
            // 
            this.txtAiName.Location = new System.Drawing.Point(179, 379);
            this.txtAiName.Name = "txtAiName";
            this.txtAiName.Size = new System.Drawing.Size(289, 36);
            this.txtAiName.TabIndex = 12;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(44, 560);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(128, 29);
            this.labelControl8.TabIndex = 11;
            this.labelControl8.Text = "DO명 정의 : ";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(52, 505);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(120, 29);
            this.labelControl7.TabIndex = 10;
            this.labelControl7.Text = "DI명 정의 : ";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(46, 444);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(126, 29);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "AO명 정의 : ";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(54, 379);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(118, 29);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "AI명 정의 : ";
            // 
            // cmbPlcBrand
            // 
            this.cmbPlcBrand.Location = new System.Drawing.Point(179, 165);
            this.cmbPlcBrand.Name = "cmbPlcBrand";
            this.cmbPlcBrand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPlcBrand.Size = new System.Drawing.Size(176, 44);
            this.cmbPlcBrand.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(59, 173);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(113, 29);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "PLC 종류 : ";
            // 
            // cmbPlcCount
            // 
            this.cmbPlcCount.EditValue = "1";
            this.cmbPlcCount.Location = new System.Drawing.Point(179, 218);
            this.cmbPlcCount.Name = "cmbPlcCount";
            this.cmbPlcCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPlcCount.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbPlcCount.Size = new System.Drawing.Size(176, 44);
            this.cmbPlcCount.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(59, 226);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(113, 29);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "PLC 갯수 : ";
            // 
            // txtProjCode
            // 
            this.txtProjCode.Location = new System.Drawing.Point(179, 26);
            this.txtProjCode.Name = "txtProjCode";
            this.txtProjCode.Size = new System.Drawing.Size(176, 36);
            this.txtProjCode.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(158, 29);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "프로젝트 코드 : ";
            // 
            // txtProjName
            // 
            this.txtProjName.Location = new System.Drawing.Point(179, 70);
            this.txtProjName.Name = "txtProjName";
            this.txtProjName.Size = new System.Drawing.Size(607, 36);
            this.txtProjName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 74);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(158, 29);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "프로젝트 이름 : ";
            // 
            // FormCreateProj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 936);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.buttons);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximizeBox = false;
            this.Name = "FormCreateProj";
            this.Text = "프로젝트 생성";
            this.Load += new System.EventHandler(this.FormCreateProj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHmi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlcBrand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlcCount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel buttons;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPlcCount;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox txtProjCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txtProjName;
        private System.Windows.Forms.TextBox txtDoName;
        private System.Windows.Forms.TextBox txtDiName;
        private System.Windows.Forms.TextBox txtAoName;
        private System.Windows.Forms.TextBox txtAiName;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPlcBrand;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtFilePath;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.ComboBoxEdit cmbHmi;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCustomer;
        private DevExpress.XtraEditors.LabelControl labelControl11;
    }
}