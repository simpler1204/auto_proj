using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using auto_proj.Enum;
using System.Data.SqlClient;
using System.Data;

namespace auto_proj.Classes
{
    public class Project : IInformation
    {
        int id;
        string projCode;
        string projName;
        string plcBrand;
        int plcCount;
        string sAi;
        string sAo;
        string sDi;
        string sDo;
        string instFileName;
        string instFilePath;
        byte[] instExcel;

        string templateFileName;
        string templateFilePath;
        byte[] templateExcel;

        string ioListFileName;
        string ioListFilePath;
        byte[] ioListExcel;

        string hmiFileName;
        string hmiFilePath;
        byte[] hmiExcel;
        DateTime created;

        public Project(int id, string projCode, string projName, string plcBrand, int plcCount, string sAi, string sAo, string sDi, string sDo, 
                        string instFileName, string instFilePath, byte[] instExcel, 
                        string templateFileName, string templateFilePath, byte[] templateExcel,
                        string ioListFileName, string ioListFilePath, byte[] ioListExcel,
                        string hmiFileName, string hmiFilePath, byte[] hmiExcel,
                        DateTime created) 
        {
            this.id = id;
            this.projCode = projCode;
            this.projName = projName;
            this.plcBrand = plcBrand;
            this.plcCount = plcCount;
            this.sAi = sAi;
            this.sAo = sAo;
            this.sDi = sDi;
            this.sDo = sDo;
            this.instFileName = instFileName;
            this.instFilePath = instFilePath;
            this.instExcel = instExcel;
            this.templateFileName = templateFileName;
            this.templateFilePath = templateFilePath;
            this.templateExcel = templateExcel;
            this.ioListFileName = ioListFileName;
            this.ioListFilePath = ioListFilePath;
            this.ioListExcel = ioListExcel;
            this.hmiFileName = hmiFileName;
            this.hmiFilePath = hmiFilePath;
            this.hmiExcel = hmiExcel;
            this.created = created;
        }

        public int ProjID { get => this.id; }
        public string ProjCode { get => this.projCode; set => this.projCode = value; }
        public string ProjName { get => this.projName; set => this.projName = value; }
        public string PlcBrand { get => this.plcBrand; set => this.plcBrand = value; }
        public int PlcCount
        {
            get => this.plcCount;
            set
            {
                if (value > 0) this.plcCount = value;
            }
        }
        public string AiDefine { get => this.sAi; set => this.sAi = value; }
        public string AoDefine { get => this.sAo; set => this.sAo = value; }
        public string DiDefine { get => this.sDi; set => this.sDi = value; }
        public string DoDefine { get => this.sDo; set => this.sDo = value; }
        public string InstFileName { get => this.instFileName; }
        public string InstFilePath { get => this.instFilePath; }
        public byte[] InstExcel { get => this.instExcel; }

        public string TemplateFileName{ get => this.templateFileName; }
        public string TemplatePath { get => this.templateFilePath; }
        public byte[] TemplateExcel { get => this.templateExcel; }
        public string IoListFileName { get => this.ioListFileName; }
        public string IoListFilePath { get => this.ioListFilePath; }
        public byte[] IoListExcel { get => this.ioListExcel; }
        public string HmiFileName { get => this.hmiFileName; }
        public string HmiFilePath { get => this.HmiFilePath; }
        public byte[] HmiExcel { get => this.HmiExcel; }

        public DateTime Created { get => this.created; }



        public void SetExcelFiles(string fileName, string filePath, byte[] excel, EXCEL_KIND kind)
        {
            switch(kind)
            {
                case EXCEL_KIND.INST:
                    this.instFileName = fileName;
                    this.instFilePath = filePath;                    
                    this.instExcel = excel;
                    break;
                case EXCEL_KIND.TEMPLATE:
                    this.templateFileName = fileName;
                    this.templateFilePath = filePath;                    
                    this.templateExcel = excel;
                    break;
                case EXCEL_KIND.IOLIST:
                    this.ioListFileName = fileName;
                    this.ioListFilePath = filePath;
                    this.ioListExcel = excel;
                    break;
                case EXCEL_KIND.HMI:
                    this.hmiFileName = fileName;
                    this.hmiFilePath = filePath;
                    this.hmiExcel = excel;
                    break;
            }            
        }
       

        public string GetInformation()
        {
            return "프로젝트 클래스";
        }

        public override string ToString()
        {
            return $"코드 : {this.projCode}, 이름 : {this.projName}, 생성일 : {this.created}";
        }

        public int ProjectUpudate(Project project)
        {
            string connectString = SIDS.Instance.MakeConnectionString("DB");
            int rtn = 0;
            using (SqlConnection DBConn = new SqlConnection(connectString))
            {
                string query = @"UPDATE proj_master SET proj_code = @code, 
                                                        proj_name = @name, 
                                                        plc_count = @count, 
                                                        plc_brand = @brand, 
                                                        ai_name = @ai, 
                                                        ao_name = @ao, 
                                                        di_name = @di, 
                                                        do_name = @do, 
                                                        inst_file_name = @instFileName, 
                                                        inst_file_path = @instFilePath, 
                                                        inst_excel = @instExcel, 
                                                        template_file_name = @templateFileName, 
                                                        template_file_path = @templateFilePath, 
	                                                    templet_excel = @templateExcel, 
                                                        iolist_file_name = @ioListFileName, 
                                                        iolist_file_path = @ioListFilePath, 
                                                        iolist_excel = @ioListExcel, 
                                                        hmi_file_name = @hmiFileName,
                                                        him_file_path = @hmiFilePath,
                                                        hmi_excel = @hmiExcel, 
                                                        updated_date = getDate()
                                 WHERE proj_id = @id";

                using (SqlCommand cmd = new SqlCommand(query, DBConn))
                {
                    cmd.Parameters.Add("@code", SqlDbType.NVarChar).Value = ProjCode;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = ProjName;
                    cmd.Parameters.Add("@count", SqlDbType.Int).Value = PlcCount;
                    cmd.Parameters.Add("@brand", SqlDbType.NVarChar).Value = PlcBrand;
                    cmd.Parameters.Add("@ai", SqlDbType.NVarChar).Value = AiDefine;
                    cmd.Parameters.Add("@ao", SqlDbType.NVarChar).Value = AoDefine;
                    cmd.Parameters.Add("@di", SqlDbType.NVarChar).Value = DiDefine;
                    cmd.Parameters.Add("@do", SqlDbType.NVarChar).Value = DoDefine;
                    cmd.Parameters.Add("@instFileName", SqlDbType.NVarChar).Value = InstFileName;
                    cmd.Parameters.Add("@instFilePath", SqlDbType.NVarChar).Value = InstFilePath;
                    cmd.Parameters.Add("@instExcel", SqlDbType.VarBinary).Value = InstExcel;
                    cmd.Parameters.Add("@templateFileName", SqlDbType.NVarChar).Value = TemplateFileName;
                    cmd.Parameters.Add("@templateFilePath", SqlDbType.NVarChar).Value = templateFilePath;
                    cmd.Parameters.Add("@templateExcel", SqlDbType.NVarChar).Value = TemplateExcel;
                    cmd.Parameters.Add("@ioListFileName", SqlDbType.NVarChar).Value = IoListFileName;
                    cmd.Parameters.Add("@ioListFilePath", SqlDbType.NVarChar).Value = IoListFilePath;
                    cmd.Parameters.Add("@ioListExcel", SqlDbType.VarBinary).Value = IoListExcel;
                    cmd.Parameters.Add("@hmiFileName", SqlDbType.NVarChar).Value = HmiFileName;
                    cmd.Parameters.Add("@hmiFilePath", SqlDbType.NVarChar).Value = hmiFilePath;
                    cmd.Parameters.Add("@hmiExcel", SqlDbType.VarBinary).Value = hmiExcel;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = ProjID;

                    try
                    {
                        DBConn.Open();
                        rtn = cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return rtn;
        }

    }
}
