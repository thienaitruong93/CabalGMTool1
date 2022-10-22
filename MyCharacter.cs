using System.Collections;
using System.Data;
using System.Data.SqlClient;

internal class MyCharacter
{
    private int _charNum;

    private string _charName;

    private long _Alz;

    private long _bankAlz;

    private int _DEX;

    private int _skillRank;

    private int _warpCode;

    private int _face;

    private int _hair;

    private int _hairColor;

    private int _classRank;

    private int _gender;

    private int _mapCode;

    private int _nation;

    private int _SP;

    private int _swordPoint;

    private int _UnusedPoint;

    private long _wExp;

    private int _aura;

    private int _className;

    private int _STR;

    private int _RP;

    private int _eCoint;

    private int _guildGrade;

    private int _guildNum;

    private string _guildName;

    private int _honour;

    private int _HPEncrypted;

    private int[] _HPCurMax;

    private int _MPEncrypted;

    private int[] _MPCurMax;

    private int _INT;

    private int _magicPoint;

    private int _LV;

    private int _DP;

    private int _style;

    private long _EXP;

    private int _worldIdx;

    private int _position;

    private int _rankEXP;

    private int _flag;

    private int _penaltyEXP;

    private DateTime _logoutTime;

    private DateTime _loginTime;

    private int _playTime;

    private int _channelIdx;

    private int _pkPenalty;

    private DateTime _createDate;

    private int _login;

    private int _guildGroupPer;

    private int _titleIdx;

    private int _totalWarPoint;

    private int _lastDayRank;

    private int _toDayRank;

    private int _warChannelType;

    private int _AP;

    private int _AP_Exp;

    private byte[] _AP_PassiveData;

    private byte[] _AP_BlendedData;

    private int _AP_Total;

    private string _skill;

    private byte[] _equipment;

    private byte[] _inventory;

    private byte[] _warehouse;

    private byte[] _titleData;

    private byte[] _skillData;

    public int CharNum => _charNum;

    public string CharName
    {
        get
        {
            return _charName;
        }
        set
        {
            _charName = value;
        }
    }

    public long Alz
    {
        get
        {
            return _Alz;
        }
        set
        {
            _Alz = value;
        }
    }

    public int AP
    {
        get
        {
            return _AP;
        }
        set
        {
            _AP = value;
        }
    }

    public int AP_Exp
    {
        get
        {
            return _AP_Exp;
        }
        set
        {
            _AP_Exp = value;
        }
    }

    public byte[] AP_PassiveData
    {
        get
        {
            return _AP_PassiveData;
        }
        set
        {
            _AP_PassiveData = value;
        }
    }

    public byte[] AP_BlendedData
    {
        get
        {
            return _AP_BlendedData;
        }
        set
        {
            _AP_BlendedData = value;
        }
    }

    public int AP_Total
    {
        get
        {
            return _AP_Total;
        }
        set
        {
            _AP_Total = value;
        }
    }

    public long BankAlz
    {
        get
        {
            return _bankAlz;
        }
        set
        {
            _bankAlz = value;
        }
    }

    public int DEX
    {
        get
        {
            return _DEX;
        }
        set
        {
            _DEX = value;
        }
    }

    public int DP
    {
        get
        {
            return _DP;
        }
        set
        {
            _DP = value;
        }
    }

    public int ECoint
    {
        get
        {
            return _eCoint;
        }
        set
        {
            _eCoint = value;
        }
    }

    public int GuildGrade
    {
        get
        {
            return _guildGrade;
        }
        set
        {
            _guildGrade = value;
        }
    }

    public int GuildNum
    {
        get
        {
            return _guildNum;
        }
        set
        {
            _guildNum = value;
        }
    }

    public string GuildName
    {
        get
        {
            return _guildName;
        }
        set
        {
            _guildName = value;
        }
    }

    public int Honour
    {
        get
        {
            return _honour;
        }
        set
        {
            _honour = value;
        }
    }

    public int HPEncrypted
    {
        get
        {
            return _HPEncrypted = encrypteHPMP(_HPCurMax);
        }
        set
        {
            _HPEncrypted = value;
            _HPCurMax = decodeHPMP(_HPEncrypted);
        }
    }

    public int MPEncrypted
    {
        get
        {
            return _MPEncrypted = encrypteHPMP(_MPCurMax);
        }
        set
        {
            _MPEncrypted = value;
            _MPCurMax = decodeHPMP(_MPEncrypted);
        }
    }

    public int[] HPCurMax
    {
        get
        {
            return _HPCurMax;
        }
        set
        {
            _HPCurMax = value;
            _HPEncrypted = encrypteHPMP(_HPCurMax);
        }
    }

    public int[] MPCurMax
    {
        get
        {
            return _MPCurMax;
        }
        set
        {
            _MPCurMax = value;
            _MPEncrypted = encrypteHPMP(_MPCurMax);
        }
    }

    public int INT
    {
        get
        {
            return _INT;
        }
        set
        {
            _INT = value;
        }
    }

    public int LV
    {
        get
        {
            return _LV;
        }
        set
        {
            _LV = value;
        }
    }

    public int MagicPoint
    {
        get
        {
            return _magicPoint;
        }
        set
        {
            _magicPoint = value;
        }
    }

    public int RP
    {
        get
        {
            return _RP;
        }
        set
        {
            _RP = value;
        }
    }

    public int SP
    {
        get
        {
            return _SP;
        }
        set
        {
            _SP = value;
        }
    }

    public int STR
    {
        get
        {
            return _STR;
        }
        set
        {
            _STR = value;
        }
    }

    public int SwordPoint
    {
        get
        {
            return _swordPoint;
        }
        set
        {
            _swordPoint = value;
        }
    }

    public int UnusedPoint
    {
        get
        {
            return _UnusedPoint;
        }
        set
        {
            _UnusedPoint = value;
        }
    }

    public long WExp
    {
        get
        {
            return _wExp;
        }
        set
        {
            _wExp = value;
        }
    }

    public int Aura
    {
        get
        {
            return _aura;
        }
        set
        {
            _aura = value;
        }
    }

    public int ClassName
    {
        get
        {
            return _className;
        }
        set
        {
            _className = value;
        }
    }

    public int ClassRank
    {
        get
        {
            return _classRank;
        }
        set
        {
            _classRank = value;
        }
    }

    public int Gender
    {
        get
        {
            return _gender;
        }
        set
        {
            _gender = value;
        }
    }

    public int MapCode
    {
        get
        {
            return _mapCode;
        }
        set
        {
            _mapCode = value;
        }
    }

    public int Nation
    {
        get
        {
            return _nation;
        }
        set
        {
            _nation = value;
        }
    }

    public int SkillRank
    {
        get
        {
            return _skillRank;
        }
        set
        {
            _skillRank = value;
        }
    }

    public int WarpCode
    {
        get
        {
            return _warpCode;
        }
        set
        {
            _warpCode = value;
        }
    }

    public int Face
    {
        get
        {
            return _face;
        }
        set
        {
            _face = value;
        }
    }

    public int Hair
    {
        get
        {
            return _hair;
        }
        set
        {
            _hair = value;
        }
    }

    public int WarChannelType
    {
        get
        {
            return _warChannelType;
        }
        set
        {
            _warChannelType = value;
        }
    }

    public int ToDayRank
    {
        get
        {
            return _toDayRank;
        }
        set
        {
            _toDayRank = value;
        }
    }

    public int LastDayRank
    {
        get
        {
            return _lastDayRank;
        }
        set
        {
            _lastDayRank = value;
        }
    }

    public int TotalWarPoint
    {
        get
        {
            return _totalWarPoint;
        }
        set
        {
            _totalWarPoint = value;
        }
    }

    public int TitleIdx
    {
        get
        {
            return _titleIdx;
        }
        set
        {
            _titleIdx = value;
        }
    }

    public int GuildGroupPer
    {
        get
        {
            return _guildGroupPer;
        }
        set
        {
            _guildGroupPer = value;
        }
    }

    public int Login
    {
        get
        {
            return _login;
        }
        set
        {
            _login = value;
        }
    }

    public DateTime CreateDate
    {
        get
        {
            return _createDate;
        }
        set
        {
            _createDate = value;
        }
    }

    public int PkPenalty
    {
        get
        {
            return _pkPenalty;
        }
        set
        {
            _pkPenalty = value;
        }
    }

    public int ChannelIdx
    {
        get
        {
            return _channelIdx;
        }
        set
        {
            _channelIdx = value;
        }
    }

    public int PlayTime
    {
        get
        {
            return _playTime;
        }
        set
        {
            _playTime = value;
        }
    }

    public DateTime LoginTime
    {
        get
        {
            return _loginTime;
        }
        set
        {
            _loginTime = value;
        }
    }

    public DateTime LogoutTime
    {
        get
        {
            return _logoutTime;
        }
        set
        {
            _logoutTime = value;
        }
    }

    public int PenaltyEXP
    {
        get
        {
            return _penaltyEXP;
        }
        set
        {
            _penaltyEXP = value;
        }
    }

    public int Flag
    {
        get
        {
            return _flag;
        }
        set
        {
            _flag = value;
        }
    }

    public int RankEXP
    {
        get
        {
            return _rankEXP;
        }
        set
        {
            _rankEXP = value;
        }
    }

    public long EXP
    {
        get
        {
            return _EXP;
        }
        set
        {
            _EXP = value;
        }
    }

    public int WorldIdx
    {
        get
        {
            return _worldIdx;
        }
        set
        {
            _worldIdx = value;
        }
    }

    public int Position
    {
        get
        {
            return _position;
        }
        set
        {
            _position = value;
        }
    }

    public int HairColor
    {
        get
        {
            return _hairColor;
        }
        set
        {
            _hairColor = value;
        }
    }

    public int Style
    {
        get
        {
            return encodeStyle();
        }
        set
        {
            _style = value;
            decodeStyle();
        }
    }

    public string Skill
    {
        get
        {
            return _skill;
        }
        set
        {
            _skill = value;
        }
    }

    public byte[] Equipment
    {
        get
        {
            return _equipment;
        }
        set
        {
            _equipment = value;
        }
    }

    public byte[] Inventory
    {
        get
        {
            return _inventory;
        }
        set
        {
            _inventory = value;
        }
    }

    public byte[] Warehouse
    {
        get
        {
            return _warehouse;
        }
        set
        {
            _warehouse = value;
        }
    }
    public byte[] TitleData
    {
        get
        {
            return _titleData;
        }
        set
        {
            _titleData = value;
        }
    }

    public byte[] SkillData
    {
        get
        {
            return _skillData;
        }
        set
        {
            _skillData = value;
        }
    }

    public MyCharacter(int charNum, string charName)
    {
        _charNum = charNum;
        _charName = charName;
    }

    public bool updateCharInfo()
    {
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@CharacterIdx", _charNum));
        arrayList.Add(new SqlParameter("@Name", _charName));
        arrayList.Add(new SqlParameter("@LEV", _LV));
        arrayList.Add(new SqlParameter("@EXP", _EXP));
        arrayList.Add(new SqlParameter("@STR", _STR));
        arrayList.Add(new SqlParameter("@DEX", _DEX));
        arrayList.Add(new SqlParameter("@INT", _INT));
        arrayList.Add(new SqlParameter("@PNT", _UnusedPoint));
        arrayList.Add(new SqlParameter("@Rank", _skillRank));
        arrayList.Add(new SqlParameter("@Alz", _Alz));
        arrayList.Add(new SqlParameter("@WorldIdx", _worldIdx));
        arrayList.Add(new SqlParameter("@Position", _position));
        arrayList.Add(new SqlParameter("@Style", encodeStyle()));
        arrayList.Add(new SqlParameter("@HP", _HPEncrypted));
        arrayList.Add(new SqlParameter("@MP", _MPEncrypted));
        arrayList.Add(new SqlParameter("@SwdPNT", _swordPoint));
        arrayList.Add(new SqlParameter("@MagPNT", _magicPoint));
        arrayList.Add(new SqlParameter("@RankEXP", _rankEXP));
        arrayList.Add(new SqlParameter("@Flags", _flag));
        arrayList.Add(new SqlParameter("@WarpBField", _warpCode));
        arrayList.Add(new SqlParameter("@MapsBField", _mapCode));
        arrayList.Add(new SqlParameter("@SP", _SP));
        arrayList.Add(new SqlParameter("@PenaltyEXP", _penaltyEXP));
        arrayList.Add(new SqlParameter("@RP", _RP));
        arrayList.Add(new SqlParameter("@Reputation", _honour));
        arrayList.Add(new SqlParameter("@PKPenalty", _pkPenalty));
        arrayList.Add(new SqlParameter("@Nation", _nation));
        arrayList.Add(new SqlParameter("@encrypted", -1));
        arrayList.Add(new SqlParameter("@warExp", _wExp));
        arrayList.Add(new SqlParameter("@TOTALWARPOINT", _totalWarPoint));
        arrayList.Add(new SqlParameter("@WARPOINT", SqlDbType.BigInt));
        arrayList.Add(new SqlParameter("@LORDTYPE", SqlDbType.BigInt));
        bool flag = UtilityDatabase.execStoredPro(GlobalClass.SQLGameDB, "cabal_tool_SetCharacter", arrayList);
        arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@CharacterIndex", _charNum));
        arrayList.Add(new SqlParameter("@DP", _DP));
        bool flag2 = UtilityDatabase.execStoredPro(GlobalClass.SQLGameDB, "cabal_tool_SetDungeonPoint", arrayList);
        arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@CharacterIdx", _charNum));
        arrayList.Add(new SqlParameter("@AbilityPoint", _AP));
        arrayList.Add(new SqlParameter("@AbilityExp", _AP_Exp));
        arrayList.Add(new SqlParameter("@PassiveAbilityData", _AP_PassiveData));
        arrayList.Add(new SqlParameter("@BlendedAbilityData", _AP_BlendedData));
        arrayList.Add(new SqlParameter("@PointTotal", _AP_Total));
        bool flag3 = UtilityDatabase.execStoredPro(GlobalClass.SQLGameDB, "cabal_tool_SetAbility", arrayList);
        return flag && flag3 && flag2;
    }

    public void decodeStyle()
    {
        _gender = _style / MyMath.hex2dec("4000000");
        _aura = _style % MyMath.hex2dec("4000000") / MyMath.hex2dec("200000") / 2;
        _hair = _style % MyMath.hex2dec("200000") / MyMath.hex2dec("20000");
        _hairColor = _style % MyMath.hex2dec("20000") / MyMath.hex2dec("2000");
        _face = _style % MyMath.hex2dec("2000") / MyMath.hex2dec("100");
        _classRank = _style % MyMath.hex2dec("100") / 8;
        _className = _style % 8;
    }
    public int encodeStyle()
    {
        return _gender * MyMath.hex2dec("4000000") + _aura * 2 * MyMath.hex2dec("200000") + _hair * MyMath.hex2dec("20000") + _hairColor * MyMath.hex2dec("2000") + _face * MyMath.hex2dec("100") + _classRank * 8 + _className;
    }
    public int[] decodeHPMP(int point)
    {
        string text = MyMath.dec2hex(point, pad: true);
        string hexval = text.Substring(0, 4);
        string hexval2 = text.Substring(4, 4);
        return new int[2]
        {
            MyMath.hex2dec(hexval),
            MyMath.hex2dec(hexval2)
        };
    }

    public int encrypteHPMP(int[] point)
    {
        string hexval = MyMath.doubledec2hex(point[0], point[1]);
        return MyMath.hex2dec(hexval);
    }
}
