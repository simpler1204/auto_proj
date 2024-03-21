
namespace auto_proj
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.menuStandardInfo = new DevExpress.XtraBars.BarSubItem();
            this.subCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.subPlcBrand = new DevExpress.XtraBars.BarButtonItem();
            this.subHmiBrand = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.subCreationProj = new DevExpress.XtraBars.BarButtonItem();
            this.subIOCount = new DevExpress.XtraBars.BarButtonItem();
            this.subModule = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.subCreateProj = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 3";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Custom 3";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.menuStandardInfo,
            this.subCreateProj,
            this.barSubItem1,
            this.subPlcBrand,
            this.barSubItem2,
            this.barSubItem3,
            this.subCreationProj,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barSubItem4,
            this.subIOCount,
            this.subCustomer,
            this.subHmiBrand,
            this.subModule});
            this.barManager1.MainMenu = this.bar3;
            this.barManager1.MaxItemId = 22;
            // 
            // bar3
            // 
            this.bar3.BarName = "Main menu";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStandardInfo),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem4)});
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Main menu";
            // 
            // menuStandardInfo
            // 
            this.menuStandardInfo.Caption = "기준정보";
            this.menuStandardInfo.Id = 8;
            this.menuStandardInfo.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.subCustomer),
            new DevExpress.XtraBars.LinkPersistInfo(this.subPlcBrand),
            new DevExpress.XtraBars.LinkPersistInfo(this.subHmiBrand)});
            this.menuStandardInfo.Name = "menuStandardInfo";
            // 
            // subCustomer
            // 
            this.subCustomer.Caption = "고객사";
            this.subCustomer.Id = 19;
            this.subCustomer.Name = "subCustomer";
            this.subCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.subCustomer_ItemClick);
            // 
            // subPlcBrand
            // 
            this.subPlcBrand.Caption = "PLC 종류";
            this.subPlcBrand.Id = 11;
            this.subPlcBrand.Name = "subPlcBrand";
            this.subPlcBrand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.subPlcBrand_ItemClick);
            // 
            // subHmiBrand
            // 
            this.subHmiBrand.Caption = "HMI 종류";
            this.subHmiBrand.Id = 20;
            this.subHmiBrand.Name = "subHmiBrand";
            this.subHmiBrand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.subHmiBrand_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "설계팀";
            this.barSubItem2.Id = 12;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.subCreationProj),
            new DevExpress.XtraBars.LinkPersistInfo(this.subIOCount),
            new DevExpress.XtraBars.LinkPersistInfo(this.subModule),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // subCreationProj
            // 
            this.subCreationProj.Caption = "프로젝트 생성";
            this.subCreationProj.Id = 14;
            this.subCreationProj.Name = "subCreationProj";
            this.subCreationProj.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.subCreationProj_ItemClick);
            // 
            // subIOCount
            // 
            this.subIOCount.Caption = "SYSTEM 구성안 IO 수량";
            this.subIOCount.Id = 18;
            this.subIOCount.Name = "subIOCount";
            this.subIOCount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.subIOCount_ItemClick);
            // 
            // subModule
            // 
            this.subModule.Caption = "Panel Module 수량";
            this.subModule.Id = 21;
            this.subModule.Name = "subModule";
            this.subModule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.subModule_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "템플릿 생성";
            this.barButtonItem2.Id = 15;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "PLC";
            this.barSubItem3.Id = 13;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "로직 생성";
            this.barButtonItem3.Id = 16;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "HMI";
            this.barSubItem4.Id = 17;
            this.barSubItem4.Name = "barSubItem4";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(2227, 62);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1259);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(2227, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 62);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1197);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(2227, 62);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1197);
            // 
            // subCreateProj
            // 
            this.subCreateProj.Caption = "프로젝트 생성";
            this.subCreateProj.Id = 9;
            this.subCreateProj.Name = "subCreateProj";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 10;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2227, 1259);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Form1";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem menuStandardInfo;
        private DevExpress.XtraBars.BarButtonItem subCreateProj;
        private DevExpress.XtraBars.BarButtonItem subPlcBrand;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem subCreationProj;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraBars.BarButtonItem subIOCount;
        private DevExpress.XtraBars.BarButtonItem subCustomer;
        private DevExpress.XtraBars.BarButtonItem subHmiBrand;
        private DevExpress.XtraBars.BarButtonItem subModule;
    }
}

