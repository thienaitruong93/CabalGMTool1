using System.Collections;
using System.Data;
using System.Data.SqlClient;

internal class UtilityDatabase
{
    private static SqlConnection getConnection(string db)
    {
        return new SqlConnection("Data Source=" + GlobalClass.SQLServerIP + "," + GlobalClass.SQLPort + ";Initial Catalog=" + db + ";User Id=" + GlobalClass.SQLUser + ";Password=" + GlobalClass.SQLPass + "; Connect Timeout = 10;");
    }

    public static bool testConnection(string db)
    {
        SqlConnection connection = getConnection(db);
        try
        {
            connection.Open();
            connection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to connect to the SQL server. \n\r \n\r" + ex.Message.ToString(), ".:Connection Failed:.");
            connection.Close();
            return false;
        }
        return true;
    }

    public static bool testConnection()
    {
        bool flag = testConnection(GlobalClass.SQLAccountDB);
        if (!flag)
        {
            GlobalClass.DBConnected = flag;
            return GlobalClass.DBConnected;
        }
        bool flag2 = testConnection(GlobalClass.SQlAuthDB);
        bool flag3 = testConnection(GlobalClass.SQLCabalCashDB);
        bool flag4 = testConnection(GlobalClass.SQLCabalGuildDB);
        bool flag5 = testConnection(GlobalClass.SQLEventDataDB);
        bool flag6 = testConnection(GlobalClass.SQLGameDB);
        bool flag7 = testConnection(GlobalClass.SQLManagerDB);
        bool flag8 = testConnection(GlobalClass.SQLNetCafeDB);
        GlobalClass.DBConnected = flag && flag2 && flag3 && flag4 && flag5 && flag6 && flag7 && flag8;
        return GlobalClass.DBConnected;
    }

    public static bool execStoredPro(string db, string storedProName, ArrayList listParameters)
    {
        SqlConnection connection = getConnection(db);
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(storedProName, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < listParameters.Count; i++)
            {
                sqlCommand.Parameters.Add(listParameters[i]);
            }
            sqlCommand.ExecuteScalar();
            connection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error. \n\r \n\r" + ex.Message.ToString(), ".: Execute Stored Procedures :.");
            connection.Close();
            return false;
        }
        return true;
    }

    public static DataTable selectStoredPro(string db, string storedProName, ArrayList listParameters)
    {
        SqlConnection connection = getConnection(db);
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(storedProName, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < listParameters.Count; i++)
            {
                sqlCommand.Parameters.Add(listParameters[i]);
            }
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlCommand.ExecuteReader());
            connection.Close();
            return dataTable;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error. \n\r \n\r" + ex.Message.ToString(), ".: Select Stored Procedures :.");
            connection.Close();
        }
        return null;
    }

    public static DataTable selectQuery(string db, string query)
    {
        SqlConnection connection = getConnection(db);
        try
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error. \n\r \n\r" + ex.Message.ToString(), ".: Select Querry :.");
            connection.Close();
        }
        return null;
    }

    public static bool updateQuery(string db, string query)
    {
        SqlConnection connection = getConnection(db);
        try
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error. \n\r \n\r" + ex.Message.ToString(), ".: Select Querry :.");
            connection.Close();
            return false;
        }
        return true;
    }

    public static bool addItem2CashInventory(int userNum, int tranNo, int serverIdx, int itemIdx, int itemOpt, int durationIdx)
    {
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@UserNum", GlobalClass.UserNum));
        arrayList.Add(new SqlParameter("@TranNo", tranNo));
        arrayList.Add(new SqlParameter("@ServerIdx", serverIdx));
        arrayList.Add(new SqlParameter("@ItemIdx", itemIdx));
        arrayList.Add(new SqlParameter("@ItemOpt", itemOpt));
        arrayList.Add(new SqlParameter("@DurationIdx", durationIdx));
        return execStoredPro(GlobalClass.SQLCabalCashDB, "up_AddMyCashItemByItem", arrayList);
    }

    public static bool addItemToAll(int itemIdx, int itemOpt, int durationIdx, int isOnline)
    {
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@ItemIdx", itemIdx));
        arrayList.Add(new SqlParameter("@ItemOpt", itemOpt));
        arrayList.Add(new SqlParameter("@DurationIdx", durationIdx));
        arrayList.Add(new SqlParameter("@onlineonly", isOnline));
        return execStoredPro(GlobalClass.SQLGameDB, "cabal_tool_giveitemtoall", arrayList);
    }

    public static bool addPet2CashInventory(int userNum, int tranNo, int serverIdx, int itemIdx, string itemOpt, int durationIdx)
    {
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@UserNum", GlobalClass.UserNum));
        arrayList.Add(new SqlParameter("@TranNo", tranNo));
        arrayList.Add(new SqlParameter("@ServerIdx", serverIdx));
        arrayList.Add(new SqlParameter("@ItemIdx", itemIdx));
        arrayList.Add(new SqlParameter("@ItemOpt", itemOpt));
        arrayList.Add(new SqlParameter("@DurationIdx", durationIdx));
        return execStoredPro(GlobalClass.SQLCabalCashDB, "up_AddMyCashPet", arrayList);
    }

    public static bool sendMail(int ReceiverID, string Title, string Content, long Alz, int ItemKindIdx, int ItemOption, int ItemDurationIdx, int MailToAll)
    {
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@Title", Title));
        arrayList.Add(new SqlParameter("@Content", Content));
        arrayList.Add(new SqlParameter("@Alz", Alz));
        arrayList.Add(new SqlParameter("@ItemKindIdx", ItemKindIdx));
        arrayList.Add(new SqlParameter("@ItemOption", ItemOption));
        arrayList.Add(new SqlParameter("@ItemDurationIdx", ItemDurationIdx));
        if (MailToAll == 0)
        {
            arrayList.Add(new SqlParameter("@ReceiverCharIdx", ReceiverID));
            return execStoredPro(GlobalClass.SQLGameDB, "cabal_sp_mail_send_GM", arrayList);
        }
        else
        {
            return execStoredPro(GlobalClass.SQLGameDB, "cabal_sp_mail_send_all", arrayList);
        }
    }

    public static bool sendMailItem(int ReceiverID, string Title, string Content, long Alz, int ItemKindIdx, int ItemOption, int ItemDurationIdx, int MailToAll)
    {
        return sendMail(ReceiverID, Title, Content, Alz, ItemKindIdx, ItemOption, ItemDurationIdx, MailToAll);
    }

    public static bool setSkill(int charNum, string skillHexStr)
    {
        byte[] value = MyMath.StringToByteArray(skillHexStr);
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@CharacterIdx", charNum));
        arrayList.Add(new SqlParameter("@Data", value));
        return execStoredPro(GlobalClass.SQLGameDB, "cabal_tool_SetSkill", arrayList);
    }
}
