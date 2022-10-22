using System.Data;
using System.Data.SqlClient;

internal class GlobalClass
{
    private static string _appname = ".: CABAL GM Tool (v1.0 EP8)";

    private static string _sqlServerIP = "";

    private static string _sqlUserName = "";

    private static string _sqlPort = "";

    private static string _sqlPassword = "";

    private static string _sqlAccountDB = "";

    private static string _sqlCabalCashDB = "";

    private static string _sqlCashShopDB = "";

    private static string _sqlCabalGuildDB = "";

    private static string _sqlAuthenticateDB = "";

    private static string _sqlManagerDB = "";

    private static string _sqlEventDB = "";

    private static string _sqlNetCafeDB = "";

    private static string _sqlGameDB = "";

    private static bool _sqlDBConnected = false;

    private static int _userNum = 0;

    private static string _userName = null;

    private static int _authtype = 0;

    private static int _premtype = 0;

    private static int _servicekind = 0;

    private static int _payminutes;

    private static DateTime _premexpiry;

    private static bool _isonline = false;

    private static string _language = "English";

    private static string _selectedChar = "";

    private static string _accidCur = "";

    private static string _aidCur = "";

    private static int _cIdxCur = 0;

    private static string _gServerUser = "";

    private static string _gServUPass = "";

    private static string _gServerIp = "";

    private static int _gServSshPort;

    private static int _loginport = 38170;

    private static string[] weapons = new string[5] { "Crystal", "Orb", "Blade", "Katana", "Greatsword" };

    private static string[] armour = new string[4] { "Gloves", "Boots", "Helm", "Suit" };

    private static string _ip = "";

    private static string _ItemID = null;

    private static string _TransID = "0";

    private static string _ServerID = "1";

    private static string _OptionID = null;

    private static string _DurationID = null;

    private static string _charNum = "";

    private static int _petId = 0;

    private static DataTable _listServer;

    private static MyCharacter _curMyChar;

    internal static MyCharacter CurMyChar
    {
        get
        {
            return _curMyChar;
        }
        set
        {
            _curMyChar = value;
        }
    }

    public static string appName
    {
        get
        {
            return _appname;
        }
        set
        {
            _appname = value;
        }
    }

    public static bool DBConnected
    {
        get
        {
            return _sqlDBConnected;
        }
        set
        {
            _sqlDBConnected = value;
        }
    }

    public static string DurationID
    {
        get
        {
            return _DurationID;
        }
        set
        {
            _DurationID = value;
        }
    }

    public static string OptionID
    {
        get
        {
            return _OptionID;
        }
        set
        {
            _OptionID = value;
        }
    }

    public static string ServerID
    {
        get
        {
            return _ServerID;
        }
        set
        {
            _ServerID = value;
        }
    }

    public static string TransID
    {
        get
        {
            return _TransID;
        }
        set
        {
            _TransID = value;
        }
    }

    public static string ItemID
    {
        get
        {
            return _ItemID;
        }
        set
        {
            _ItemID = value;
        }
    }

    public static string ip
    {
        get
        {
            return _ip;
        }
        set
        {
            _ip = value;
        }
    }

    public static int port
    {
        get
        {
            return _loginport;
        }
        set
        {
            _loginport = value;
        }
    }

    public static string SQLServerIP
    {
        get
        {
            return _sqlServerIP;
        }
        set
        {
            _sqlServerIP = value;
        }
    }

    public static string SQLPort
    {
        get
        {
            return _sqlPort;
        }
        set
        {
            _sqlPort = value;
        }
    }

    public static string SQLUser
    {
        get
        {
            return _sqlUserName;
        }
        set
        {
            _sqlUserName = value;
        }
    }

    public static string SQLPass
    {
        get
        {
            return _sqlPassword;
        }
        set
        {
            _sqlPassword = value;
        }
    }

    public static string SQLGameDB
    {
        get
        {
            return _sqlGameDB;
        }
        set
        {
            _sqlGameDB = value;
        }
    }

    public static string SQLAccountDB
    {
        get
        {
            return _sqlAccountDB;
        }
        set
        {
            _sqlAccountDB = value;
        }
    }

    public static string SQLCabalCashDB
    {
        get
        {
            return _sqlCabalCashDB;
        }
        set
        {
            _sqlCabalCashDB = value;
        }
    }

    public static string SQLCashShopDB
    {
        get
        {
            return _sqlCashShopDB;
        }
        set
        {
            _sqlCashShopDB = value;
        }
    }

    public static string SQLCabalGuildDB
    {
        get
        {
            return _sqlCabalGuildDB;
        }
        set
        {
            _sqlCabalGuildDB = value;
        }
    }

    public static string SQLNetCafeDB
    {
        get
        {
            return _sqlNetCafeDB;
        }
        set
        {
            _sqlNetCafeDB = value;
        }
    }

    public static string SQLManagerDB
    {
        get
        {
            return _sqlManagerDB;
        }
        set
        {
            _sqlManagerDB = value;
        }
    }

    public static string SQLEventDataDB
    {
        get
        {
            return _sqlEventDB;
        }
        set
        {
            _sqlEventDB = value;
        }
    }

    public static string SQlAuthDB
    {
        get
        {
            return _sqlAuthenticateDB;
        }
        set
        {
            _sqlAuthenticateDB = value;
        }
    }

    public static int UserNum
    {
        get
        {
            return _userNum;
        }
        set
        {
            _userNum = value;
        }
    }

    public static string UserName
    {
        get
        {
            return _userName;
        }
        set
        {
            _userName = value;
        }
    }

    public static int AuthType
    {
        get
        {
            return _authtype;
        }
        set
        {
            _authtype = value;
        }
    }

    public static int PremType
    {
        get
        {
            return _premtype;
        }
        set
        {
            _premtype = value;
        }
    }

    public static int ServiceKind
    {
        get
        {
            return _servicekind;
        }
        set
        {
            _servicekind = value;
        }
    }

    public static int PayMinutes
    {
        get
        {
            return _payminutes;
        }
        set
        {
            _payminutes = value;
        }
    }

    public static DateTime PremExpiry
    {
        get
        {
            return _premexpiry;
        }
        set
        {
            _premexpiry = value;
        }
    }

    public static bool IsOnline
    {
        get
        {
            return _isonline;
        }
        set
        {
            _isonline = value;
        }
    }

    public static string Language
    {
        get
        {
            return _language;
        }
        set
        {
            _language = value;
        }
    }

    public static string selectedChar
    {
        get
        {
            return _selectedChar;
        }
        set
        {
            _selectedChar = value;
        }
    }

    public static string AccidCur
    {
        get
        {
            return _accidCur;
        }
        set
        {
            _accidCur = value;
        }
    }

    public static string AidCur
    {
        get
        {
            return _aidCur;
        }
        set
        {
            _aidCur = value;
        }
    }

    public static int cIdxCur
    {
        get
        {
            return _cIdxCur;
        }
        set
        {
            _cIdxCur = value;
        }
    }

    public static string gServerUser
    {
        get
        {
            return _gServerUser;
        }
        set
        {
            _gServerUser = value;
        }
    }

    public static string gServerIp
    {
        get
        {
            return _gServerIp;
        }
        set
        {
            _gServerIp = value;
        }
    }

    public static int gServPort
    {
        get
        {
            return _gServSshPort;
        }
        set
        {
            _gServSshPort = value;
        }
    }

    public static string gServUPass
    {
        get
        {
            return _gServUPass;
        }
        set
        {
            _gServUPass = value;
        }
    }

    public static string CharNum
    {
        get
        {
            return _charNum;
        }
        set
        {
            _charNum = value;
        }
    }

    public static int PetId
    {
        get
        {
            return _petId;
        }
        set
        {
            _petId = value;
        }
    }

    public static DataTable ListServer
    {
        get
        {
            return _listServer;
        }
        set
        {
            _listServer = value;
        }
    }

    public static bool isAccountLoaded()
    {
        if (UserNum <= 0)
        {
            MessageBox.Show("You must search Account first!!!");
            return false;
        }
        return true;
    }

    public static bool isCharacterLoaded()
    {
        MyCharacter curMyChar = CurMyChar;
        if (curMyChar == null)
        {
            MessageBox.Show("You must select Character first!!!");
            return false;
        }
        return true;
    }

    public static string charname_to_accid(string cname)
    {
        SqlConnection sqlConnection = new SqlConnection("user id=" + SQLUser + ";password=" + SQLPass + ";server=" + SQLServerIP + "," + SQLPort + ";connection timeout=10");
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = new SqlCommand("select CharacterIdx from " + SQLGameDB + ".dbo.cabal_character_table where Name='" + cname + "'", sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                int num = Convert.ToInt32(sqlDataReader[0]);
                return (num / 8).ToString();
            }
            sqlConnection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + "     ", appName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        return "";
    }

    public static string accname_to_accid(string aname)
    {
        string result = "";
        SqlConnection sqlConnection = new SqlConnection("user id=" + SQLUser + ";password=" + SQLPass + ";server=" + SQLServerIP + "," + SQLPort + ";connection timeout=10");
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = new SqlCommand("select UserNum from " + SQLAccountDB + ".dbo.cabal_auth_table where ID='" + aname + "'", sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                result = sqlDataReader[0].ToString();
                return result;
            }
            sqlConnection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + "     ", appName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        return result;
    }

    public static string accid_to_accname(string aid)
    {
        string result = "";
        SqlConnection sqlConnection = new SqlConnection("user id=" + SQLUser + ";password=" + SQLPass + ";server=" + SQLServerIP + "," + SQLPort + ";connection timeout=10");
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = new SqlCommand("select ID from " + SQLAccountDB + ".dbo.cabal_auth_table where UserNum='" + aid + "'", sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                result = sqlDataReader[0].ToString();
                return result;
            }
            sqlConnection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + "     ", appName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        return result;
    }

    public static object ReadInventory(string CharIdx)
    {
        object result = new object();
        SqlConnection sqlConnection = new SqlConnection("user id=" + SQLUser + ";password=" + SQLPass + ";server=" + SQLServerIP + "," + SQLPort + ";connection timeout=10");
        sqlConnection.Open();
        SqlCommand sqlCommand = new SqlCommand("exec " + SQLGameDB + ".dbo.cabal_tool_GetInventory " + CharIdx, sqlConnection);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            result = sqlDataReader[1];
        }
        sqlConnection.Close();
        return result;
    }

}
