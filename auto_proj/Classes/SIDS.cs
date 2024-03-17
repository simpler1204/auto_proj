using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

// 필수 추가 using 
using System.Configuration;  
using System.Diagnostics;
using System.Runtime.InteropServices;

enum DBTYPE
{
    MSSQL = 0,
    ORACLE = 1,
    ORACLE_TNS = 2,
    HISTORIAN = 3
}

class SIDS
{
    /* * * * Samil Data System Library * * * * 
     * Create : 2021.12.20 
     * Version : v1.1
     * Last Modify : 2022.01.20
     * 
     * 필수 : System.Configuration 참조추가
     * 변경 :
     * < 2022.01.05 > : 편의성 개선(GetAppConfig - int, bool)
     * < 2022.01.20 > : DB Connection String 관련 함수 생성(Return, Make)
     * < 2022.02.08 > : DB TYPE 및 관련 함수 생성
     * < 2024.03.05 > : - WriteProgramError 함수 추가 - Thread 및 Unhandle Error Log
     *                  - Program 중복실행 함수 추가
     * * * * * * * * * * * * * * * * * * * * */

    // ======= dll 참조
    [DllImport("user32")]
    private static extern bool SetForegroundWindow(IntPtr handle);

    [DllImport("User32")]
    private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

    // ======= 인스턴스
    private static SIDS _instance = null;
    private static readonly object _lock = new object();

    private SIDS() { }

    // SIDS.Instance 로 사용
    public static SIDS Instance
    {
        get
        {
            lock(_lock)
            {
                if (_instance == null)
                {
                    _instance = new SIDS();
                }

                return _instance;
            }
        }
    }

    // ======= [변수]
    public bool DEBUG
    {
        get { return GetAppConfigToBool("DEBUG_MODE"); }
    }
    public string LOGPATH
    {
        get {
            string path = GetAppConfigToString("LOG_PATH");

            if (path == "")
            {
                SetAppConfig("LOG_PATH", Environment.CurrentDirectory + "\\Log");
                return Environment.CurrentDirectory + "\\Log";
            }

            return path; 
        }
    }
    public bool REDUN
    {
        get
        {
            return GetAppConfigToBool("REDUN");
        }
    }

    // ======= [LOG] 
    /// <summary>
    /// Error 발생시 로그 저장 함수
    /// 실행된 프로그램의 폴더에 Log_yy-MM-dd.log 형식으로 저장
    /// </summary>
    /// <param name="msg">저장될 메세지</param>
    /// <param name="isMsg">에러메세지 표시 여부 Default:false = DebugMode 여부</param>
    public void WriteErrorLog(string msg, bool isMsg = false)
    {
        try
        {
            // 메세지를 표시
            if (isMsg)
                MessageBox.Show(msg);

            if(DEBUG)
            {
                MessageBox.Show(msg);
                return;
            }

            string DirPath = LOGPATH;
            string FilePath = DirPath + "\\Log_" + DateTime.Today.ToString("yy-MM-dd") + ".txt";
            string temp;

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            // 폴더가 없으면 생성
            if (!di.Exists)
                Directory.CreateDirectory(DirPath);

            if (!fi.Exists)
            {
                // 파일이 없으면
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    temp = string.Format("[{0}] {1}", DateTime.Now, msg);
                    sw.WriteLine(temp);
                    sw.WriteLine("");
                    sw.Close();
                }
            }
            else
            {
                // 파일이 있으면
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    temp = string.Format("[{0}] {1}", DateTime.Now, msg);
                    sw.WriteLine(temp);
                    sw.WriteLine("");
                    sw.Close();
                }
            }
        }
        catch
        {

        }
    }

    public void WriteLog(string msg)
    {
        try
        {
            string DirPath = LOGPATH;
            string FilePath = DirPath + "\\Log_" + DateTime.Today.ToString("yy-MM-dd") + ".txt";
            string temp;

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            // 폴더가 없으면 생성
            if (!di.Exists)
                Directory.CreateDirectory(DirPath);

            if (!fi.Exists)
            {
                // 파일이 없으면
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    temp = string.Format("[{0}] {1}", DateTime.Now, msg);
                    sw.WriteLine(temp);
                    sw.WriteLine("");
                    sw.Close();
                }
            }
            else
            {
                // 파일이 있으면
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    temp = string.Format("[{0}] {1}", DateTime.Now, msg);
                    sw.WriteLine(temp);
                    sw.WriteLine("");
                    sw.Close();
                }
            }
        }
        catch
        {

        }
    }

    public void WriteProgramError(string msg)
    {
        try
        {
            string DirPath = LOGPATH + "\\Critical";
            string FilePath = DirPath + "\\Log_" + DateTime.Today.ToString("yy-MM-dd") + ".txt";
            string temp;

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            // 폴더가 없으면 생성
            if (!di.Exists)
                Directory.CreateDirectory(DirPath);

            if (!fi.Exists)
            {
                // 파일이 없으면
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    temp = string.Format("[{0}] {1}", DateTime.Now, msg);
                    sw.WriteLine(temp);
                    sw.WriteLine("");
                    sw.Close();
                }
            }
            else
            {
                // 파일이 있으면
                using (StreamWriter sw = File.AppendText(FilePath))
                {
                    temp = string.Format("[{0}] {1}", DateTime.Now, msg);
                    sw.WriteLine(temp);
                    sw.WriteLine("");
                    sw.Close();
                }
            }
        }
        catch
        {

        }
    }

    // ======= [CONFIG] 
    /// <summary>
    /// App.Config 파일에서 [key] 항목의 값을 가져오는 함수
    /// 해당 [key] 값이 없을경우 생성
    /// </summary>
    /// <param name="key">항목</param>
    /// <returns>string 형식의 값</returns>
    public string GetAppConfigToString(string key)
    {
        string result = "";
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        if (config.AppSettings.Settings.AllKeys.Contains(key))
        {
            result = ConfigurationManager.AppSettings[key].ToString();

            return result;
        }
        else
        {
            SetAppConfig(key, "");

            return result;
        }
    }

    public int GetAppConfigToInt(string key)
    {
        int result = 0;
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        if (config.AppSettings.Settings.AllKeys.Contains(key))
        {
            if(int.TryParse(ConfigurationManager.AppSettings[key].ToString(), out result))
                return result;
            else
            {
                SetAppConfig(key, "0");

                return result;
            }
        }
        else
        {
            SetAppConfig(key, "0");

            return result;
        }
    }

    public bool GetAppConfigToBool(string key)
    {
        bool result = false;
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        if (config.AppSettings.Settings.AllKeys.Contains(key))
        {
            if (bool.TryParse(ConfigurationManager.AppSettings[key].ToString(), out result))
                return result;
            else
            {
                SetAppConfig(key, "false");
                return result;
            }
        }
        else
        {
            SetAppConfig(key, "false");

            return result;
        }
    }

    /// <summary>
    /// App.Config 파일에 [key] 항목에 [value]의 값을 넣는다.
    /// 해당 [key] 값이 없을경우 생성
    /// </summary>
    /// <param name="key">App.Config 항목</param>
    /// <param name="value">key 항목의 값</param>
    public void SetAppConfig(string key, string value)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        if (config.AppSettings.Settings.AllKeys.Contains(key))
        {
            config.AppSettings.Settings[key].Value = value;
        }
        else
        {
            config.AppSettings.Settings.Add(new KeyValueConfigurationElement(key, value));
        }

        config.Save(ConfigurationSaveMode.Modified);

        ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
    }

    public void SetAppConfig(string key, int value)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        if (config.AppSettings.Settings.AllKeys.Contains(key))
        {
            config.AppSettings.Settings[key].Value = value.ToString();
        }
        else
        {
            config.AppSettings.Settings.Add(new KeyValueConfigurationElement(key, value.ToString()));
        }

        config.Save(ConfigurationSaveMode.Modified);

        ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
    }

    public void DeleteAppConfig(string key)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        if (config.AppSettings.Settings.AllKeys.Contains(key))
        {
            config.AppSettings.Settings.Remove(key);

            config.Save(ConfigurationSaveMode.Modified);
        }

        ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
    }

    public void DeleteRelationAppConfig(string key)
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        string[] relationKeys = ConfigurationManager.AppSettings.AllKeys
                             .Where(keys => keys.StartsWith(key)).ToArray();

        for (int i = 0; i < relationKeys.Length; i++)
        {
            if(config.AppSettings.Settings.AllKeys.Contains(relationKeys[i]))
            {
                config.AppSettings.Settings.Remove(relationKeys[i]);
            }
        }

        config.Save(ConfigurationSaveMode.Modified);

        ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
    }

    // ======= [DB] 
    public string ReturnConnectionString(DBTYPE _db, string _ip, string _id, string _pw, string _name)
    {
        string str = "";

        switch (_db)
        {
            case DBTYPE.HISTORIAN:
                str = _name;
                break;

            case DBTYPE.MSSQL:
                str = "Data Source=" + _ip + "; Initial Catalog=" + _name + "; User Id=" + _id + "; Password=" + _pw;
                break;

            case DBTYPE.ORACLE:
                str = $"Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST ={_ip})(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME ={_name}))); User ID = {_id}; Password ={_pw}; Connection Timeout = 30;";
                break;

            case DBTYPE.ORACLE_TNS:
                str = "Data Source=" + _name + "; User Id=" + _id + "; Password=" + _pw;
                break;

            default:
                break;
        }

        return str;
    }

    public DBTYPE GetDBTYPE(string key)
    {
        string db = GetAppConfigToString(key);

        switch (db)
        {
            case "MSSQL": return DBTYPE.MSSQL;
            case "ORACLE": return DBTYPE.ORACLE;
            case "HISTORIAN": return DBTYPE.HISTORIAN;
            case "ORACLE_TNS": return DBTYPE.ORACLE_TNS;
            default: return DBTYPE.MSSQL;
        }
    }

    public string MakeConnectionString(string key)
    {
        string db_IP    = GetAppConfigToString(key + "_IP");
        string db_ID    = GetAppConfigToString(key + "_ID");
        string db_PW    = GetAppConfigToString(key + "_PW");
        string db_NAME  = GetAppConfigToString(key + "_NAME");

        string db_CONNSTR = ReturnConnectionString(GetDBTYPE(key), db_IP, db_ID, db_PW, db_NAME);

        return db_CONNSTR;
    }

    // ======= [Program] 
    /// <summary>
    /// 프로그램 중복 실행 방지
    /// </summary>
    /// <returns></returns>
    public bool CheckProgramRun()
    {
        Process[] procs = null;
        string curProcess = Process.GetCurrentProcess().ProcessName.ToUpper();

        procs = Process.GetProcessesByName(curProcess);

        if (procs.Length > 1)
        {
            MessageBox.Show("SMS 프로그램이 실행중입니다.");

            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == curProcess)
                {
                    Console.WriteLine(SetForegroundWindow(process.MainWindowHandle).ToString());
                    ShowWindow(process.MainWindowHandle, 9);
                }
            }

            return false;
        }
        else
        {
            return true;
        }
    }
}

/// <summary>
/// 메모장 관련 Class
/// </summary>
public struct IniValue
{
    private static bool TryParseInt(string text, out int value)
    {
        int res;
        if (Int32.TryParse(text,
            System.Globalization.NumberStyles.Integer,
            System.Globalization.CultureInfo.InvariantCulture,
            out res))
        {
            value = res;
            return true;
        }
        value = 0;
        return false;
    }

    private static bool TryParseDouble(string text, out double value)
    {
        double res;
        if (Double.TryParse(text,
            System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture,
            out res))
        {
            value = res;
            return true;
        }
        value = Double.NaN;
        return false;
    }

    public string Value;

    public IniValue(object value)
    {
        var formattable = value as IFormattable;
        if (formattable != null)
        {
            Value = formattable.ToString(null, System.Globalization.CultureInfo.InvariantCulture);
        }
        else
        {
            Value = value != null ? value.ToString() : null;
        }
    }

    public IniValue(string value)
    {
        Value = value;
    }

    public bool ToBool(bool valueIfInvalid = false)
    {
        bool res;
        if (TryConvertBool(out res))
        {
            return res;
        }
        return valueIfInvalid;
    }

    public bool TryConvertBool(out bool result)
    {
        if (Value == null)
        {
            result = default(bool);
            return false;
        }
        var boolStr = Value.Trim().ToLowerInvariant();
        if (boolStr == "true")
        {
            result = true;
            return true;
        }
        else if (boolStr == "false")
        {
            result = false;
            return true;
        }
        result = default(bool);
        return false;
    }

    public int ToInt(int valueIfInvalid = 0)
    {
        int res;
        if (TryConvertInt(out res))
        {
            return res;
        }
        return valueIfInvalid;
    }

    public bool TryConvertInt(out int result)
    {
        if (Value == null)
        {
            result = default(int);
            return false;
        }
        if (TryParseInt(Value.Trim(), out result))
        {
            return true;
        }
        return false;
    }

    public double ToDouble(double valueIfInvalid = 0)
    {
        double res;
        if (TryConvertDouble(out res))
        {
            return res;
        }
        return valueIfInvalid;
    }

    public bool TryConvertDouble(out double result)
    {
        if (Value == null)
        {
            result = default(double);
            return false; ;
        }
        if (TryParseDouble(Value.Trim(), out result))
        {
            return true;
        }
        return false;
    }

    public string GetString()
    {
        return GetString(true, false);
    }

    public string GetString(bool preserveWhitespace)
    {
        return GetString(true, preserveWhitespace);
    }

    public string GetString(bool allowOuterQuotes, bool preserveWhitespace)
    {
        if (Value == null)
        {
            return "";
        }
        var trimmed = Value.Trim();
        if (allowOuterQuotes && trimmed.Length >= 2 && trimmed[0] == '"' && trimmed[trimmed.Length - 1] == '"')
        {
            var inner = trimmed.Substring(1, trimmed.Length - 2);
            return preserveWhitespace ? inner : inner.Trim();
        }
        else
        {
            return preserveWhitespace ? Value : Value.Trim();
        }
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator IniValue(byte o)
    {
        return new IniValue(o);
    }

    public static implicit operator IniValue(short o)
    {
        return new IniValue(o);
    }

    public static implicit operator IniValue(int o)
    {
        return new IniValue(o);
    }

    public static implicit operator IniValue(sbyte o)
    {
        return new IniValue(o);
    }

    public static implicit operator IniValue(ushort o)
    {
        return new IniValue(o);
    }

    public static implicit operator IniValue(uint o)
    {
        return new IniValue(o);
    }

    public static implicit operator IniValue(float o)
    {
        return new IniValue(o);
    }

    public static implicit operator IniValue(double o)
    {
        return new IniValue(o);
    }

    public static implicit operator IniValue(bool o)
    {
        return new IniValue(o);
    }

    public static implicit operator IniValue(string o)
    {
        return new IniValue(o);
    }

    private static readonly IniValue _default = new IniValue();
    public static IniValue Default { get { return _default; } }
}

public class IniFile : IEnumerable<KeyValuePair<string, IniSection>>, IDictionary<string, IniSection>
{
    private Dictionary<string, IniSection> sections;
    public IEqualityComparer<string> StringComparer;

    public bool SaveEmptySections;

    public IniFile()
        : this(DefaultComparer)
    {
    }

    public IniFile(IEqualityComparer<string> stringComparer)
    {
        StringComparer = stringComparer;
        sections = new Dictionary<string, IniSection>(StringComparer);
    }

    public void Save(string path, FileMode mode = FileMode.Create)
    {
        using (var stream = new FileStream(path, mode, FileAccess.Write))
        {
            Save(stream);
        }
    }

    public void Save(Stream stream)
    {
        using (var writer = new StreamWriter(stream))
        {
            Save(writer);
        }
    }

    public void Save(StreamWriter writer)
    {
        foreach (var section in sections)
        {
            if (section.Value.Count > 0 || SaveEmptySections)
            {
                writer.WriteLine(string.Format("[{0}]", section.Key.Trim()));
                foreach (var kvp in section.Value)
                {
                    writer.WriteLine(string.Format("{0}={1}", kvp.Key, kvp.Value));
                }
                writer.WriteLine("");
            }
        }
    }

    public void Load(string path, bool ordered = false)
    {
        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            Load(stream, ordered);
        }
    }

    public void Load(Stream stream, bool ordered = false)
    {
        using (var reader = new StreamReader(stream))
        {
            Load(reader, ordered);
        }
    }

    public void Load(StreamReader reader, bool ordered = false)
    {
        IniSection section = null;

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();

            if (line != null)
            {
                var trimStart = line.TrimStart();

                if (trimStart.Length > 0)
                {
                    if (trimStart[0] == '[')
                    {
                        var sectionEnd = trimStart.IndexOf(']');
                        if (sectionEnd > 0)
                        {
                            var sectionName = trimStart.Substring(1, sectionEnd - 1).Trim();
                            section = new IniSection(StringComparer) { Ordered = ordered };
                            sections[sectionName] = section;
                        }
                    }
                    else if (section != null && trimStart[0] != ';')
                    {
                        string key;
                        IniValue val;

                        if (LoadValue(line, out key, out val))
                        {
                            section[key] = val;
                        }
                    }
                }
            }
        }
    }

    private bool LoadValue(string line, out string key, out IniValue val)
    {
        var assignIndex = line.IndexOf('=');
        if (assignIndex <= 0)
        {
            key = null;
            val = null;
            return false;
        }

        key = line.Substring(0, assignIndex).Trim();
        var value = line.Substring(assignIndex + 1);

        val = new IniValue(value);
        return true;
    }

    public bool ContainsSection(string section)
    {
        return sections.ContainsKey(section);
    }

    public bool TryGetSection(string section, out IniSection result)
    {
        return sections.TryGetValue(section, out result);
    }

    bool IDictionary<string, IniSection>.TryGetValue(string key, out IniSection value)
    {
        return TryGetSection(key, out value);
    }

    public bool Remove(string section)
    {
        return sections.Remove(section);
    }

    public IniSection Add(string section, Dictionary<string, IniValue> values, bool ordered = false)
    {
        return Add(section, new IniSection(values, StringComparer) { Ordered = ordered });
    }

    public IniSection Add(string section, IniSection value)
    {
        if (value.Comparer != StringComparer)
        {
            value = new IniSection(value, StringComparer);
        }
        sections.Add(section, value);
        return value;
    }

    public IniSection Add(string section, bool ordered = false)
    {
        var value = new IniSection(StringComparer) { Ordered = ordered };
        sections.Add(section, value);
        return value;
    }

    void IDictionary<string, IniSection>.Add(string key, IniSection value)
    {
        Add(key, value);
    }

    bool IDictionary<string, IniSection>.ContainsKey(string key)
    {
        return ContainsSection(key);
    }

    public ICollection<string> Keys
    {
        get { return sections.Keys; }
    }

    public ICollection<IniSection> Values
    {
        get { return sections.Values; }
    }

    void ICollection<KeyValuePair<string, IniSection>>.Add(KeyValuePair<string, IniSection> item)
    {
        ((IDictionary<string, IniSection>)sections).Add(item);
    }

    public void Clear()
    {
        sections.Clear();
    }

    bool ICollection<KeyValuePair<string, IniSection>>.Contains(KeyValuePair<string, IniSection> item)
    {
        return ((IDictionary<string, IniSection>)sections).Contains(item);
    }

    void ICollection<KeyValuePair<string, IniSection>>.CopyTo(KeyValuePair<string, IniSection>[] array, int arrayIndex)
    {
        ((IDictionary<string, IniSection>)sections).CopyTo(array, arrayIndex);
    }

    public int Count
    {
        get { return sections.Count; }
    }

    bool ICollection<KeyValuePair<string, IniSection>>.IsReadOnly
    {
        get { return ((IDictionary<string, IniSection>)sections).IsReadOnly; }
    }

    bool ICollection<KeyValuePair<string, IniSection>>.Remove(KeyValuePair<string, IniSection> item)
    {
        return ((IDictionary<string, IniSection>)sections).Remove(item);
    }

    public IEnumerator<KeyValuePair<string, IniSection>> GetEnumerator()
    {
        return sections.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IniSection this[string section]
    {
        get
        {
            IniSection s;
            if (sections.TryGetValue(section, out s))
            {
                return s;
            }
            s = new IniSection(StringComparer);
            sections[section] = s;
            return s;
        }
        set
        {
            var v = value;
            if (v.Comparer != StringComparer)
            {
                v = new IniSection(v, StringComparer);
            }
            sections[section] = v;
        }
    }

    public string GetContents()
    {
        using (var stream = new MemoryStream())
        {
            Save(stream);
            stream.Flush();
            var builder = new StringBuilder(Encoding.UTF8.GetString(stream.ToArray()));
            return builder.ToString();
        }
    }

    public static IEqualityComparer<string> DefaultComparer = new CaseInsensitiveStringComparer();

    class CaseInsensitiveStringComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return String.Compare(x, y, true) == 0;
        }

        public int GetHashCode(string obj)
        {
            return obj.ToLowerInvariant().GetHashCode();
        }

#if JS
        public new bool Equals(object x, object y) {
            var xs = x as string;
            var ys = y as string;
            if (xs == null || ys == null) {
                return xs == null && ys == null;
            }
            return Equals(xs, ys);
        }

        public int GetHashCode(object obj) {
            if (obj is string) {
                return GetHashCode((string)obj);
            }
            return obj.ToStringInvariant().ToLowerInvariant().GetHashCode();
        }
#endif
    }
}

public class IniSection : IEnumerable<KeyValuePair<string, IniValue>>, IDictionary<string, IniValue>
{
    private Dictionary<string, IniValue> values;

    #region Ordered
    private List<string> orderedKeys;

    public int IndexOf(string key)
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call IndexOf(string) on IniSection: section was not ordered.");
        }
        return IndexOf(key, 0, orderedKeys.Count);
    }

    public int IndexOf(string key, int index)
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call IndexOf(string, int) on IniSection: section was not ordered.");
        }
        return IndexOf(key, index, orderedKeys.Count - index);
    }

    public int IndexOf(string key, int index, int count)
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call IndexOf(string, int, int) on IniSection: section was not ordered.");
        }
        if (index < 0 || index > orderedKeys.Count)
        {
            throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
        }
        if (count < 0)
        {
            throw new IndexOutOfRangeException("Count cannot be less than zero." + Environment.NewLine + "Parameter name: count");
        }
        if (index + count > orderedKeys.Count)
        {
            throw new ArgumentException("Index and count were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
        }
        var end = index + count;
        for (int i = index; i < end; i++)
        {
            if (Comparer.Equals(orderedKeys[i], key))
            {
                return i;
            }
        }
        return -1;
    }

    public int LastIndexOf(string key)
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call LastIndexOf(string) on IniSection: section was not ordered.");
        }
        return LastIndexOf(key, 0, orderedKeys.Count);
    }

    public int LastIndexOf(string key, int index)
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call LastIndexOf(string, int) on IniSection: section was not ordered.");
        }
        return LastIndexOf(key, index, orderedKeys.Count - index);
    }

    public int LastIndexOf(string key, int index, int count)
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call LastIndexOf(string, int, int) on IniSection: section was not ordered.");
        }
        if (index < 0 || index > orderedKeys.Count)
        {
            throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
        }
        if (count < 0)
        {
            throw new IndexOutOfRangeException("Count cannot be less than zero." + Environment.NewLine + "Parameter name: count");
        }
        if (index + count > orderedKeys.Count)
        {
            throw new ArgumentException("Index and count were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
        }
        var end = index + count;
        for (int i = end - 1; i >= index; i--)
        {
            if (Comparer.Equals(orderedKeys[i], key))
            {
                return i;
            }
        }
        return -1;
    }

    public void Insert(int index, string key, IniValue value)
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call Insert(int, string, IniValue) on IniSection: section was not ordered.");
        }
        if (index < 0 || index > orderedKeys.Count)
        {
            throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
        }
        values.Add(key, value);
        orderedKeys.Insert(index, key);
    }

    public void InsertRange(int index, IEnumerable<KeyValuePair<string, IniValue>> collection)
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call InsertRange(int, IEnumerable<KeyValuePair<string, IniValue>>) on IniSection: section was not ordered.");
        }
        if (collection == null)
        {
            throw new ArgumentNullException("Value cannot be null." + Environment.NewLine + "Parameter name: collection");
        }
        if (index < 0 || index > orderedKeys.Count)
        {
            throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
        }
        foreach (var kvp in collection)
        {
            Insert(index, kvp.Key, kvp.Value);
            index++;
        }
    }

    public void RemoveAt(int index)
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call RemoveAt(int) on IniSection: section was not ordered.");
        }
        if (index < 0 || index > orderedKeys.Count)
        {
            throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
        }
        var key = orderedKeys[index];
        orderedKeys.RemoveAt(index);
        values.Remove(key);
    }

    public void RemoveRange(int index, int count)
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call RemoveRange(int, int) on IniSection: section was not ordered.");
        }
        if (index < 0 || index > orderedKeys.Count)
        {
            throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
        }
        if (count < 0)
        {
            throw new IndexOutOfRangeException("Count cannot be less than zero." + Environment.NewLine + "Parameter name: count");
        }
        if (index + count > orderedKeys.Count)
        {
            throw new ArgumentException("Index and count were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
        }
        for (int i = 0; i < count; i++)
        {
            RemoveAt(index);
        }
    }

    public void Reverse()
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call Reverse() on IniSection: section was not ordered.");
        }
        orderedKeys.Reverse();
    }

    public void Reverse(int index, int count)
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call Reverse(int, int) on IniSection: section was not ordered.");
        }
        if (index < 0 || index > orderedKeys.Count)
        {
            throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
        }
        if (count < 0)
        {
            throw new IndexOutOfRangeException("Count cannot be less than zero." + Environment.NewLine + "Parameter name: count");
        }
        if (index + count > orderedKeys.Count)
        {
            throw new ArgumentException("Index and count were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");
        }
        orderedKeys.Reverse(index, count);
    }

    public ICollection<IniValue> GetOrderedValues()
    {
        if (!Ordered)
        {
            throw new InvalidOperationException("Cannot call GetOrderedValues() on IniSection: section was not ordered.");
        }
        var list = new List<IniValue>();
        for (int i = 0; i < orderedKeys.Count; i++)
        {
            list.Add(values[orderedKeys[i]]);
        }
        return list;
    }

    public IniValue this[int index]
    {
        get
        {
            if (!Ordered)
            {
                throw new InvalidOperationException("Cannot index IniSection using integer key: section was not ordered.");
            }
            if (index < 0 || index >= orderedKeys.Count)
            {
                throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
            }
            return values[orderedKeys[index]];
        }
        set
        {
            if (!Ordered)
            {
                throw new InvalidOperationException("Cannot index IniSection using integer key: section was not ordered.");
            }
            if (index < 0 || index >= orderedKeys.Count)
            {
                throw new IndexOutOfRangeException("Index must be within the bounds." + Environment.NewLine + "Parameter name: index");
            }
            var key = orderedKeys[index];
            values[key] = value;
        }
    }

    public bool Ordered
    {
        get
        {
            return orderedKeys != null;
        }
        set
        {
            if (Ordered != value)
            {
                orderedKeys = value ? new List<string>(values.Keys) : null;
            }
        }
    }
    #endregion

    public IniSection()
        : this(IniFile.DefaultComparer)
    {
    }

    public IniSection(IEqualityComparer<string> stringComparer)
    {
        this.values = new Dictionary<string, IniValue>(stringComparer);
    }

    public IniSection(Dictionary<string, IniValue> values)
        : this(values, IniFile.DefaultComparer)
    {
    }

    public IniSection(Dictionary<string, IniValue> values, IEqualityComparer<string> stringComparer)
    {
        this.values = new Dictionary<string, IniValue>(values, stringComparer);
    }

    public IniSection(IniSection values)
        : this(values, IniFile.DefaultComparer)
    {
    }

    public IniSection(IniSection values, IEqualityComparer<string> stringComparer)
    {
        this.values = new Dictionary<string, IniValue>(values.values, stringComparer);
    }

    public void Add(string key, IniValue value)
    {
        values.Add(key, value);
        if (Ordered)
        {
            orderedKeys.Add(key);
        }
    }

    public bool ContainsKey(string key)
    {
        return values.ContainsKey(key);
    }

    /// <summary>
    /// Returns this IniSection's collection of keys. If the IniSection is ordered, the keys will be returned in order.
    /// </summary>
    public ICollection<string> Keys
    {
        get { return Ordered ? (ICollection<string>)orderedKeys : values.Keys; }
    }

    public bool Remove(string key)
    {
        var ret = values.Remove(key);
        if (Ordered && ret)
        {
            for (int i = 0; i < orderedKeys.Count; i++)
            {
                if (Comparer.Equals(orderedKeys[i], key))
                {
                    orderedKeys.RemoveAt(i);
                    break;
                }
            }
        }
        return ret;
    }

    public bool TryGetValue(string key, out IniValue value)
    {
        return values.TryGetValue(key, out value);
    }

    /// <summary>
    /// Returns the values in this IniSection. These values are always out of order. To get ordered values from an IniSection call GetOrderedValues instead.
    /// </summary>
    public ICollection<IniValue> Values
    {
        get
        {
            return values.Values;
        }
    }

    void ICollection<KeyValuePair<string, IniValue>>.Add(KeyValuePair<string, IniValue> item)
    {
        ((IDictionary<string, IniValue>)values).Add(item);
        if (Ordered)
        {
            orderedKeys.Add(item.Key);
        }
    }

    public void Clear()
    {
        values.Clear();
        if (Ordered)
        {
            orderedKeys.Clear();
        }
    }

    bool ICollection<KeyValuePair<string, IniValue>>.Contains(KeyValuePair<string, IniValue> item)
    {
        return ((IDictionary<string, IniValue>)values).Contains(item);
    }

    void ICollection<KeyValuePair<string, IniValue>>.CopyTo(KeyValuePair<string, IniValue>[] array, int arrayIndex)
    {
        ((IDictionary<string, IniValue>)values).CopyTo(array, arrayIndex);
    }

    public int Count
    {
        get { return values.Count; }
    }

    bool ICollection<KeyValuePair<string, IniValue>>.IsReadOnly
    {
        get { return ((IDictionary<string, IniValue>)values).IsReadOnly; }
    }

    bool ICollection<KeyValuePair<string, IniValue>>.Remove(KeyValuePair<string, IniValue> item)
    {
        var ret = ((IDictionary<string, IniValue>)values).Remove(item);
        if (Ordered && ret)
        {
            for (int i = 0; i < orderedKeys.Count; i++)
            {
                if (Comparer.Equals(orderedKeys[i], item.Key))
                {
                    orderedKeys.RemoveAt(i);
                    break;
                }
            }
        }
        return ret;
    }

    public IEnumerator<KeyValuePair<string, IniValue>> GetEnumerator()
    {
        if (Ordered)
        {
            return GetOrderedEnumerator();
        }
        else
        {
            return values.GetEnumerator();
        }
    }

    private IEnumerator<KeyValuePair<string, IniValue>> GetOrderedEnumerator()
    {
        for (int i = 0; i < orderedKeys.Count; i++)
        {
            yield return new KeyValuePair<string, IniValue>(orderedKeys[i], values[orderedKeys[i]]);
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEqualityComparer<string> Comparer { get { return values.Comparer; } }

    public IniValue this[string name]
    {
        get
        {
            IniValue val;
            if (values.TryGetValue(name, out val))
            {
                return val;
            }
            return IniValue.Default;
        }
        set
        {
            if (Ordered && !orderedKeys.Contains(name, Comparer))
            {
                orderedKeys.Add(name);
            }
            values[name] = value;
        }
    }

    public static implicit operator IniSection(Dictionary<string, IniValue> dict)
    {
        return new IniSection(dict);
    }

    public static explicit operator Dictionary<string, IniValue>(IniSection section)
    {
        return section.values;
    }
}
