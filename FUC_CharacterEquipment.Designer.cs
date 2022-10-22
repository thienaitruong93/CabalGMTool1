using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;
using CabalGM1;
using static System.Net.Mime.MediaTypeNames;

public class FUC_CharacterEquipment : UserControl
{
    private IContainer components = null;

    int max_itemArray = 0;
    string[] itemidxs = new string[50000];
    string[] itemrealidxs = new string[50000];
    string[] itemnames = new string[50000];
    string[] itemtypes = new string[50000];
    string[] itemopts = new string[50000];
    string[,,] craftopts = new string[59, 10, 16];
    int max_titleArray = 0;
    string[] titleIndex = new string[5000];
    string[] titleIdx = new string[5000];
    string[] titleName = new string[5000];
    string selectedTitle = "";
    int max_skillArray = 0;
    string[] skillIndex = new string[50000];
    string[] skillId = new string[50000];
    string[] skillName = new string[50000];
    string[] skillDesc = new string[50000];
    

    private void FUC_CharacterEquipment_Load(object sender, EventArgs e)
    {
        List<object> ListTitle = UtilityXML.getListTitle();
        cbNewTitle.DataSource = ListTitle;
        cbNewTitle.DisplayMember = "Cont";
        cbNewTitle.ValueMember = "ID";
        cbNewTitle.SelectedIndex = 1;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void read_itemlist()
    {
        try
        {
            FileStream file = new FileStream("data/itemlist.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            string fcontents = sr.ReadToEnd();
            sr.Close();
            string[] flines = fcontents.Split("\r\n".ToCharArray());
            string[] items = new string[1];

            for (int i = 0; i < flines.Length - 1; i++)
            {
                if (flines[i].Length > 1)
                {
                    if (flines[i].Substring(0, 1) != ";")
                    {
                        items = flines[i].Split("\t".ToCharArray());
                        if (items.Length > 0)
                        {
                            itemidxs[i] = items[1];
                            itemrealidxs[i] = items[1];
                            itemopts[i] = items[2];
                            itemtypes[i] = items[3]; // Item type
                            itemnames[i] = items[4]; // Item name
                        }
                    }
                }
            }
            max_itemArray = flines.Length - 1;
        }
        catch (Exception ex)
        {
            MessageBox.Show("ERROR: " + ex.Message + "\n\n" + ex.StackTrace,
                GlobalClass.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void read_titleList()
    {
        try
        {
            FileStream file = new FileStream("data/titlelist.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            string fcontents = sr.ReadToEnd();
            sr.Close();
            string[] flines = fcontents.Split("\r\n".ToCharArray());
            string[] items = new string[1];

            for (int i = 0; i < flines.Length - 1; i++)
            {
                if (flines[i].Length > 1)
                {
                    if (flines[i].Substring(0, 1) != ";")
                    {
                        items = flines[i].Split("\t".ToCharArray());
                        if (items.Length > 0)
                        {
                            titleIndex[i] = items[1];
                            titleIdx[i] = items[2];
                            titleName[i] = items[3];
                        }
                    }
                }
            }
            max_titleArray = flines.Length - 1;
        }
        catch (Exception ex)
        {
            MessageBox.Show("ERROR: " + ex.Message + "\n\n" + ex.StackTrace,
                GlobalClass.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void loadEquipment()
    {
        if (GlobalClass.isAccountLoaded() && GlobalClass.isCharacterLoaded())
        {
            MyCharacter curMyChar = GlobalClass.CurMyChar;
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new SqlParameter("@CharacterIdx", curMyChar.CharNum));
            DataTable dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_tool_GetEquipment", arrayList);
            curMyChar.Equipment = (byte[])dataTable.Rows[0][1];
            SPLIT_ITEM(curMyChar.Equipment, dataGrid_Equipment);
        }
    }

    public void loadInventory()
    {
        if (GlobalClass.isAccountLoaded() && GlobalClass.isCharacterLoaded())
        {
            MyCharacter curMyChar = GlobalClass.CurMyChar;
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new SqlParameter("@CharacterIdx", curMyChar.CharNum));
            DataTable dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_tool_GetInventory", arrayList);
            curMyChar.Inventory = (byte[])dataTable.Rows[0][1];           
            SPLIT_ITEM(curMyChar.Inventory, dataGrid_Inventory);
        }
    }

    public void loadWarehouse()
    {
        if (GlobalClass.isAccountLoaded() && GlobalClass.isCharacterLoaded())
        {
            MyCharacter curMyChar = GlobalClass.CurMyChar;
            int userNum = GlobalClass.UserNum;
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new SqlParameter("@usernum", userNum));
            DataTable dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_tool_GetWarehouse", arrayList);
            curMyChar.Warehouse = (byte[])dataTable.Rows[0][1];
            arrayList = new ArrayList();
            arrayList.Add(new SqlParameter("@usernum", userNum));
            DataTable dataTable1 = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_tool_GetWarehouseAlz", arrayList);
            curMyChar.BankAlz = long.Parse(dataTable1.Rows[0][1].ToString());
            txtBankAlz.Text = curMyChar.BankAlz.ToString();
            SPLIT_ITEM(curMyChar.Warehouse, dataGrid_Warehouse);
        }
    }

    public void SPLIT_ITEM(byte[] inven, DataGridView dataGrid)
    {
        dataGrid.Rows.Clear();
        string[] inventory = new string[128];
        string varhex;
        varhex = MyMath.BytesToHex(inven);

        // split into individual items
        // write to txt file for fun
        int items = varhex.Length / 36;
        for (int i = 0; i < items; i++)
        {
            inventory[i] = varhex.Substring(i * 36, 36);
            int itemidx = Int32.Parse(inventory[i].Substring(3, 1) + inventory[i].Substring(0, 2), NumberStyles.HexNumber);
            int calcidx = Int32.Parse(inventory[i].Substring(5, 1) + inventory[i].Substring(2, 1) + inventory[i].Substring(3, 1) + inventory[i].Substring(0, 2), NumberStyles.HexNumber);
            int itemopt = Int32.Parse(inventory[i].Substring(22, 2) + inventory[i].Substring(20, 2) + inventory[i].Substring(18, 2) + inventory[i].Substring(16, 2), NumberStyles.HexNumber);
            int arrayidx = 0;
            string iidx = itemidx.ToString();
            string iopt = itemopt.ToString();
            for (int j = max_itemArray; j >= 0; j--)
            {

                if (itemidxs[j] == iidx)
                {
                    arrayidx = j;
                }
                if (itemidxs[j] == iidx && itemopts[j] == iopt)
                {
                    arrayidx = j;
                    break;
                }
            }

            if (arrayidx != 0)
            {
                dataGrid.Rows.Add();
                int plusbind = Int32.Parse(inventory[i].Substring(5, 1) + inventory[i].Substring(2, 1), NumberStyles.HexNumber)/2;
                int craft_type = Int32.Parse(inventory[i].Substring(14, 2), NumberStyles.HexNumber);
                int craft_amount = Int32.Parse(inventory[i].Substring(12, 1), NumberStyles.HexNumber);

                dataGrid.Rows[i].Cells[0].Value = calcidx.ToString();
                dataGrid.Rows[i].Cells[1].Value = itemidx.ToString();
                dataGrid.Rows[i].Cells[2].Value = itemopt.ToString();
                dataGrid.Rows[i].Cells[3].Value = (itemnames[arrayidx].ToString() == null ? "" : itemnames[arrayidx].ToString());

                // Show plusbind if there is one
                dataGrid.Rows[i].Cells[4].Value = plusbind.ToString();

                // Craft effect if there is one
                if (craft_type > 0)
                {
                    int itype = Int32.Parse(itemtypes[arrayidx]);
                    if (itype == 1 || itype == 2 || itype == 3 || itype == 4
                        || itype == 5 || itype == 6 || itype == 7 || itype == 8
                        || itype == 9 || itype == 22 || itype == 32 || itype == 33)
                    {
                        dataGrid.Rows[i].Cells[5].Value = "";
                        /*dataGrid.Rows[i].Cells[5].Value =
                            craftopts[Int32.Parse(itemtypes[arrayidx], NumberStyles.HexNumber)
                            , craft_type, craft_amount];*/
                    }
                }
                else
                {
                    dataGrid.Rows[i].Cells[5].Value = "";
                }

                // Add item binary on the end
                #region "Binary"
                string vbin = inventory[i].Insert(6, " "); // idx + plusbind
                vbin = vbin.Insert(17, " "); // serial
                vbin = vbin.Insert(20, " "); // slot 1 / craft
                vbin = vbin.Insert(23, " "); // slot 2 / craft
                vbin = vbin.Insert(26, " "); // num of slot / craft
                vbin = vbin.Insert(29, " "); // position
                vbin = vbin.Insert(32, " "); // leaves durationidx
                                             //dataGrid.Rows[i].Cells[6].Value = inventory[i];
                dataGrid.Rows[i].Cells[6].Value = vbin;
                #endregion
            }               
        }
    }

    public void loadTitle()
    {
        if (GlobalClass.isAccountLoaded() && GlobalClass.isCharacterLoaded())
        {
            MyCharacter curMyChar = GlobalClass.CurMyChar;
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new SqlParameter("@CharacterIdx", curMyChar.CharNum));
            DataTable dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_tool_title_get", arrayList);
            curMyChar.TitleIdx = int.Parse(dataTable.Rows[0][1].ToString());
            curMyChar.TitleData = (byte[])dataTable.Rows[0][2];
            txtTitleData.Text = MyMath.ByteArrayToString(curMyChar.TitleData);
            SPLIT_TITLE(curMyChar.TitleData, dataGrid_Title);
        }
    }

    public void SPLIT_TITLE(byte[] title, DataGridView dataGrid)
    {
        dataGrid.Rows.Clear();
        string[] titleDt = new string[128];
        string varhex;
        varhex = MyMath.BytesToHex(title);

        // split into individual items
        // write to txt file for fun
        int count = varhex.Length / 12;
        for (int i = 0; i < count; i++)
        {
            titleDt[i] = varhex.Substring(i * 12, 12);
            int titleidx = Int32.Parse(titleDt[i].Substring(2, 2) + titleDt[i].Substring(0, 2), NumberStyles.HexNumber);          
            int arrayidx = 0;
            string iidx = titleidx.ToString();
            for (int j = max_titleArray; j >= 0; j--)
            {

                if (titleIndex[j] == iidx)
                {
                    arrayidx = j;
                }
            }

            if (arrayidx != 0)
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Cells[0].Value = false;
                dataGrid.Rows[i].Cells[1].Value = titleidx.ToString();
                dataGrid.Rows[i].Cells[2].Value = titleDt[i].ToString();
                dataGrid.Rows[i].Cells[3].Value = (titleName[arrayidx].ToString() == null ? "" : titleName[arrayidx].ToString());
            }
        }
    }

    private void read_skillList()
    {
        try
        {
            FileStream file = new FileStream("data/skilllist.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            string fcontents = sr.ReadToEnd();
            sr.Close();
            string[] flines = fcontents.Split("\r\n".ToCharArray());
            string[] items = new string[1];

            for (int i = 0; i < flines.Length - 1; i++)
            {
                if (flines[i].Length > 1)
                {
                    if (flines[i].Substring(0, 1) != ";")
                    {
                        items = flines[i].Split("\t".ToCharArray());
                        if (items.Length > 0)
                        {
                            skillId[i] = items[0];
                            skillName[i] = items[1];
                            skillDesc[i] = items[2];
                        }
                    }
                }
            }
            max_skillArray = flines.Length - 1;
        }
        catch (Exception ex)
        {
            MessageBox.Show("ERROR: " + ex.Message + "\n\n" + ex.StackTrace,
                GlobalClass.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void loadSkill()
    {
        if (GlobalClass.isAccountLoaded() && GlobalClass.isCharacterLoaded())
        {
            MyCharacter curMyChar = GlobalClass.CurMyChar;
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new SqlParameter("@CharacterIdx", curMyChar.CharNum));
            DataTable dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_tool_GetSkill", arrayList);
            curMyChar.SkillData = (byte[])dataTable.Rows[0][1];
            SPLIT_SKILL(curMyChar.SkillData, dataGrid_Skill);
        }
    }

    public void SPLIT_SKILL(byte[] skill, DataGridView dataGrid)
    {
        dataGrid.Rows.Clear();
        string[] skillDt = new string[500];
        string varhex;
        varhex = MyMath.BytesToHex(skill);

        // split into individual items
        // write to txt file for fun
        int count = varhex.Length / 10;
        for (int i = 0; i < count; i++)
        {
            skillDt[i] = varhex.Substring(i * 10, 10);
            int skillIdx = Int32.Parse(skillDt[i].Substring(2, 2) + skillDt[i].Substring(0, 2), NumberStyles.HexNumber);
            int skillLv = Int32.Parse(skillDt[i].Substring(4, 2), NumberStyles.HexNumber);
            int slotPos = Int32.Parse(skillDt[i].Substring(6, 2), NumberStyles.HexNumber);
            int arrayidx = 0;
            string iidx = skillIdx.ToString();
            for (int j = max_skillArray; j >= 0; j--)
            {

                if (skillId[j] == iidx)
                {
                    arrayidx = j;
                }
            }

            if (arrayidx != 0)
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Cells[0].Value = skillIdx.ToString("D3");
                dataGrid.Rows[i].Cells[1].Value = skillName[arrayidx].ToString();
                dataGrid.Rows[i].Cells[2].Value = skillLv.ToString();
                dataGrid.Rows[i].Cells[3].Value = slotPos.ToString("D3");
                dataGrid.Rows[i].Cells[4].Value = skillDesc[arrayidx].ToString();
            }
        }
    }

    private void btnUpdateWare_Click(object sender, EventArgs e)
    {
        ArrayList arrayList = new ArrayList();
        MyCharacter curMyChar = GlobalClass.CurMyChar;
        curMyChar.BankAlz = long.Parse(txtBankAlz.Text);
        arrayList.Add(new SqlParameter("@UserNum", GlobalClass.UserNum));
        arrayList.Add(new SqlParameter("@Alz", curMyChar.BankAlz));
        arrayList.Add(new SqlParameter("@encrypted", -1));
        bool flag = UtilityDatabase.execStoredPro(GlobalClass.SQLGameDB, "cabal_tool_SetWarehouseAlz", arrayList);
        if (!flag)
        {
            MessageBox.Show("Can not save Warehouse Alz");
        }
        else
        {
            MessageBox.Show("Save Successfully!");
        }
    }

    private void btnClearInv_Click(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Do you want to Clear Inventory?", "Clear Inventory!!!!!", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            ArrayList arrayList = new ArrayList();
            MyCharacter curMyChar = GlobalClass.CurMyChar;
            byte[] value = MyMath.StringToByteArray("");
            arrayList.Add(new SqlParameter("@CharacterIdx", curMyChar.CharNum));
            arrayList.Add(new SqlParameter("@Data", value));
            bool flag = UtilityDatabase.execStoredPro(GlobalClass.SQLGameDB, "cabal_tool_SetInventory", arrayList);
            if (!flag)
            {
                MessageBox.Show("Can not clear Inventory!");
            }
            else
            {
                MessageBox.Show("Clear Inventory Successfully!");
            }
        }
        else if (dialogResult == DialogResult.No)
        {
            return;
        }
    }

    private void txtBankAlz_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar)
    && !char.IsDigit(e.KeyChar)
    && e.KeyChar != '.')
        {
            e.Handled = true;
        }
    }
    private void cbNewTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedTitle = cbNewTitle.SelectedValue.ToString();
    }

    private void btnAddTitle_Click(object sender, EventArgs e)
    {
        if (!isTitleExisted(selectedTitle))
        {
            string titleAdd = txtTitleData.Text + selectedTitle;
            MyCharacter curMyChar = GlobalClass.CurMyChar;
            byte[] value = MyMath.StringToByteArray(titleAdd);
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new SqlParameter("@CharacterIdx", curMyChar.CharNum));
            arrayList.Add(new SqlParameter("@Data", value));
            UtilityDatabase.execStoredPro(GlobalClass.SQLGameDB, "cabal_tool_SetATitleData", arrayList);
            loadTitle();
        }
        else
        {
            MessageBox.Show(selectedTitle);
        }
    }

    private void btnDelTitle_Click(object sender, EventArgs e)
    {
        string titleData = "";
        string delTitle = "";
        foreach (DataGridViewRow row in dataGrid_Title.Rows)
        {
            if (!(bool)row.Cells[0].Value)
            {
                titleData += row.Cells[2].Value.ToString();
            }
            else
            {
                delTitle += row.Cells[2].Value.ToString();
            }
        }
        //update New List Title after Del
        MyCharacter curMyChar = GlobalClass.CurMyChar;
        byte[] value = MyMath.StringToByteArray(titleData);
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@CharacterIdx", curMyChar.CharNum));
        arrayList.Add(new SqlParameter("@Data", value));
        UtilityDatabase.execStoredPro(GlobalClass.SQLGameDB, "cabal_tool_SetATitleData", arrayList);
        MessageBox.Show("Delete Title Successfully!");
        loadTitle();       
    }

    private bool isTitleExisted(string selTitle)
    {
        bool isExisted = false;
        for (int i=0; i< dataGrid_Title.RowCount; i++)
        {
            if (selTitle == dataGrid_Title.Rows[i].Cells[2].Value.ToString())
                {
                isExisted = true;
                break;
            }
            else
            {
                isExisted = false;
            }
        }
        return isExisted;
    }

    private void InitializeComponent()
    {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGrid_Equipment = new System.Windows.Forms.DataGridView();
            this.InvItemIdx_Eq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvRealItemIdx_Eq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvItemOpt_Eq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvItemName_Eq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvPlusBind_Eq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvCraftAtt_Eq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvItemBinary_Eq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnClearInv = new System.Windows.Forms.Button();
            this.dataGrid_Inventory = new System.Windows.Forms.DataGridView();
            this.InvItemIdx_In = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvRealItemIdx_In = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvItemOpt_In = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvItemName_In = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvPlusBind_In = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvCraftAtt_In = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvItemBinary_In = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnUpdateWare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBankAlz = new System.Windows.Forms.TextBox();
            this.dataGrid_Warehouse = new System.Windows.Forms.DataGridView();
            this.InvItemIdx_Wa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvRealItemIdx_Wa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvItemOpt_Wa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvItemName_Wa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvPlusBind_Wa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvCraftAtt_Wa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvItemBinary_Wa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnDelTitle = new System.Windows.Forms.Button();
            this.btnAddTitle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNewTitle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitleData = new System.Windows.Forms.TextBox();
            this.dataGrid_Title = new System.Windows.Forms.DataGridView();
            this.ckSelectTitle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TitleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleHex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGrid_Skill = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.colSkiID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkiLv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkiPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkiDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Equipment)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Inventory)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Warehouse)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Title)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Skill)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(769, 874);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGrid_Equipment);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(761, 841);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Equipments";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGrid_Equipment
            // 
            this.dataGrid_Equipment.AllowUserToAddRows = false;
            this.dataGrid_Equipment.AllowUserToDeleteRows = false;
            this.dataGrid_Equipment.AllowUserToResizeRows = false;
            this.dataGrid_Equipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid_Equipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Equipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvItemIdx_Eq,
            this.InvRealItemIdx_Eq,
            this.InvItemOpt_Eq,
            this.InvItemName_Eq,
            this.InvPlusBind_Eq,
            this.InvCraftAtt_Eq,
            this.InvItemBinary_Eq});
            this.dataGrid_Equipment.Location = new System.Drawing.Point(5, 7);
            this.dataGrid_Equipment.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid_Equipment.Name = "dataGrid_Equipment";
            this.dataGrid_Equipment.ReadOnly = true;
            this.dataGrid_Equipment.RowHeadersVisible = false;
            this.dataGrid_Equipment.RowHeadersWidth = 51;
            this.dataGrid_Equipment.RowTemplate.Height = 29;
            this.dataGrid_Equipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid_Equipment.Size = new System.Drawing.Size(749, 481);
            this.dataGrid_Equipment.TabIndex = 1;
            // 
            // InvItemIdx_Eq
            // 
            this.InvItemIdx_Eq.HeaderText = "ItemIdx";
            this.InvItemIdx_Eq.MinimumWidth = 6;
            this.InvItemIdx_Eq.Name = "InvItemIdx_Eq";
            this.InvItemIdx_Eq.ReadOnly = true;
            this.InvItemIdx_Eq.Width = 88;
            // 
            // InvRealItemIdx_Eq
            // 
            this.InvRealItemIdx_Eq.HeaderText = "RealItemIdx";
            this.InvRealItemIdx_Eq.MinimumWidth = 6;
            this.InvRealItemIdx_Eq.Name = "InvRealItemIdx_Eq";
            this.InvRealItemIdx_Eq.ReadOnly = true;
            this.InvRealItemIdx_Eq.Width = 117;
            // 
            // InvItemOpt_Eq
            // 
            this.InvItemOpt_Eq.HeaderText = "ItemOpt";
            this.InvItemOpt_Eq.MinimumWidth = 6;
            this.InvItemOpt_Eq.Name = "InvItemOpt_Eq";
            this.InvItemOpt_Eq.ReadOnly = true;
            this.InvItemOpt_Eq.Width = 93;
            // 
            // InvItemName_Eq
            // 
            this.InvItemName_Eq.HeaderText = "Item name";
            this.InvItemName_Eq.MinimumWidth = 6;
            this.InvItemName_Eq.Name = "InvItemName_Eq";
            this.InvItemName_Eq.ReadOnly = true;
            this.InvItemName_Eq.Width = 109;
            // 
            // InvPlusBind_Eq
            // 
            this.InvPlusBind_Eq.HeaderText = "+";
            this.InvPlusBind_Eq.MinimumWidth = 6;
            this.InvPlusBind_Eq.Name = "InvPlusBind_Eq";
            this.InvPlusBind_Eq.ReadOnly = true;
            this.InvPlusBind_Eq.Width = 48;
            // 
            // InvCraftAtt_Eq
            // 
            this.InvCraftAtt_Eq.HeaderText = "Craft effect";
            this.InvCraftAtt_Eq.MinimumWidth = 6;
            this.InvCraftAtt_Eq.Name = "InvCraftAtt_Eq";
            this.InvCraftAtt_Eq.ReadOnly = true;
            this.InvCraftAtt_Eq.Width = 112;
            // 
            // InvItemBinary_Eq
            // 
            this.InvItemBinary_Eq.HeaderText = "Item Binary";
            this.InvItemBinary_Eq.MinimumWidth = 6;
            this.InvItemBinary_Eq.Name = "InvItemBinary_Eq";
            this.InvItemBinary_Eq.ReadOnly = true;
            this.InvItemBinary_Eq.Width = 113;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnClearInv);
            this.tabPage2.Controls.Add(this.dataGrid_Inventory);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(761, 841);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inventory";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnClearInv
            // 
            this.btnClearInv.Location = new System.Drawing.Point(616, 548);
            this.btnClearInv.Name = "btnClearInv";
            this.btnClearInv.Size = new System.Drawing.Size(139, 40);
            this.btnClearInv.TabIndex = 65;
            this.btnClearInv.Text = "Clear Inventory";
            this.btnClearInv.UseVisualStyleBackColor = true;
            this.btnClearInv.Click += new System.EventHandler(this.btnClearInv_Click);
            // 
            // dataGrid_Inventory
            // 
            this.dataGrid_Inventory.AllowUserToAddRows = false;
            this.dataGrid_Inventory.AllowUserToDeleteRows = false;
            this.dataGrid_Inventory.AllowUserToResizeRows = false;
            this.dataGrid_Inventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid_Inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Inventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvItemIdx_In,
            this.InvRealItemIdx_In,
            this.InvItemOpt_In,
            this.InvItemName_In,
            this.InvPlusBind_In,
            this.InvCraftAtt_In,
            this.InvItemBinary_In});
            this.dataGrid_Inventory.Location = new System.Drawing.Point(6, 6);
            this.dataGrid_Inventory.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid_Inventory.Name = "dataGrid_Inventory";
            this.dataGrid_Inventory.ReadOnly = true;
            this.dataGrid_Inventory.RowHeadersVisible = false;
            this.dataGrid_Inventory.RowHeadersWidth = 51;
            this.dataGrid_Inventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid_Inventory.Size = new System.Drawing.Size(754, 535);
            this.dataGrid_Inventory.TabIndex = 64;
            // 
            // InvItemIdx_In
            // 
            this.InvItemIdx_In.HeaderText = "ItemIdx";
            this.InvItemIdx_In.MinimumWidth = 6;
            this.InvItemIdx_In.Name = "InvItemIdx_In";
            this.InvItemIdx_In.ReadOnly = true;
            this.InvItemIdx_In.Width = 88;
            // 
            // InvRealItemIdx_In
            // 
            this.InvRealItemIdx_In.HeaderText = "RealItemIdx";
            this.InvRealItemIdx_In.MinimumWidth = 6;
            this.InvRealItemIdx_In.Name = "InvRealItemIdx_In";
            this.InvRealItemIdx_In.ReadOnly = true;
            this.InvRealItemIdx_In.Width = 117;
            // 
            // InvItemOpt_In
            // 
            this.InvItemOpt_In.HeaderText = "ItemOpt";
            this.InvItemOpt_In.MinimumWidth = 6;
            this.InvItemOpt_In.Name = "InvItemOpt_In";
            this.InvItemOpt_In.ReadOnly = true;
            this.InvItemOpt_In.Width = 93;
            // 
            // InvItemName_In
            // 
            this.InvItemName_In.HeaderText = "Item name";
            this.InvItemName_In.MinimumWidth = 6;
            this.InvItemName_In.Name = "InvItemName_In";
            this.InvItemName_In.ReadOnly = true;
            this.InvItemName_In.Width = 109;
            // 
            // InvPlusBind_In
            // 
            this.InvPlusBind_In.HeaderText = "+";
            this.InvPlusBind_In.MinimumWidth = 6;
            this.InvPlusBind_In.Name = "InvPlusBind_In";
            this.InvPlusBind_In.ReadOnly = true;
            this.InvPlusBind_In.Width = 48;
            // 
            // InvCraftAtt_In
            // 
            this.InvCraftAtt_In.HeaderText = "Craft effect";
            this.InvCraftAtt_In.MinimumWidth = 6;
            this.InvCraftAtt_In.Name = "InvCraftAtt_In";
            this.InvCraftAtt_In.ReadOnly = true;
            this.InvCraftAtt_In.Width = 112;
            // 
            // InvItemBinary_In
            // 
            this.InvItemBinary_In.HeaderText = "Item Binary";
            this.InvItemBinary_In.MinimumWidth = 6;
            this.InvItemBinary_In.Name = "InvItemBinary_In";
            this.InvItemBinary_In.ReadOnly = true;
            this.InvItemBinary_In.Width = 113;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnUpdateWare);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.txtBankAlz);
            this.tabPage3.Controls.Add(this.dataGrid_Warehouse);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(761, 841);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Warehouse";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnUpdateWare
            // 
            this.btnUpdateWare.Location = new System.Drawing.Point(210, 537);
            this.btnUpdateWare.Name = "btnUpdateWare";
            this.btnUpdateWare.Size = new System.Drawing.Size(121, 60);
            this.btnUpdateWare.TabIndex = 3;
            this.btnUpdateWare.Text = "Update Storage\'s Alz";
            this.btnUpdateWare.UseVisualStyleBackColor = true;
            this.btnUpdateWare.Click += new System.EventHandler(this.btnUpdateWare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 497);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Warehouse\'s Alz:";
            // 
            // txtBankAlz
            // 
            this.txtBankAlz.Location = new System.Drawing.Point(158, 494);
            this.txtBankAlz.Name = "txtBankAlz";
            this.txtBankAlz.Size = new System.Drawing.Size(173, 27);
            this.txtBankAlz.TabIndex = 1;
            this.txtBankAlz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBankAlz_KeyPress);
            // 
            // dataGrid_Warehouse
            // 
            this.dataGrid_Warehouse.AllowUserToAddRows = false;
            this.dataGrid_Warehouse.AllowUserToDeleteRows = false;
            this.dataGrid_Warehouse.AllowUserToResizeRows = false;
            this.dataGrid_Warehouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid_Warehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Warehouse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvItemIdx_Wa,
            this.InvRealItemIdx_Wa,
            this.InvItemOpt_Wa,
            this.InvItemName_Wa,
            this.InvPlusBind_Wa,
            this.InvCraftAtt_Wa,
            this.InvItemBinary_Wa});
            this.dataGrid_Warehouse.Location = new System.Drawing.Point(6, 6);
            this.dataGrid_Warehouse.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid_Warehouse.Name = "dataGrid_Warehouse";
            this.dataGrid_Warehouse.ReadOnly = true;
            this.dataGrid_Warehouse.RowHeadersVisible = false;
            this.dataGrid_Warehouse.RowHeadersWidth = 51;
            this.dataGrid_Warehouse.RowTemplate.Height = 29;
            this.dataGrid_Warehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid_Warehouse.Size = new System.Drawing.Size(749, 481);
            this.dataGrid_Warehouse.TabIndex = 0;
            // 
            // InvItemIdx_Wa
            // 
            this.InvItemIdx_Wa.HeaderText = "ItemIdx";
            this.InvItemIdx_Wa.MinimumWidth = 6;
            this.InvItemIdx_Wa.Name = "InvItemIdx_Wa";
            this.InvItemIdx_Wa.ReadOnly = true;
            this.InvItemIdx_Wa.Width = 88;
            // 
            // InvRealItemIdx_Wa
            // 
            this.InvRealItemIdx_Wa.HeaderText = "RealItemIdx";
            this.InvRealItemIdx_Wa.MinimumWidth = 6;
            this.InvRealItemIdx_Wa.Name = "InvRealItemIdx_Wa";
            this.InvRealItemIdx_Wa.ReadOnly = true;
            this.InvRealItemIdx_Wa.Width = 117;
            // 
            // InvItemOpt_Wa
            // 
            this.InvItemOpt_Wa.HeaderText = "ItemOpt";
            this.InvItemOpt_Wa.MinimumWidth = 6;
            this.InvItemOpt_Wa.Name = "InvItemOpt_Wa";
            this.InvItemOpt_Wa.ReadOnly = true;
            this.InvItemOpt_Wa.Width = 93;
            // 
            // InvItemName_Wa
            // 
            this.InvItemName_Wa.HeaderText = "Item name";
            this.InvItemName_Wa.MinimumWidth = 6;
            this.InvItemName_Wa.Name = "InvItemName_Wa";
            this.InvItemName_Wa.ReadOnly = true;
            this.InvItemName_Wa.Width = 109;
            // 
            // InvPlusBind_Wa
            // 
            this.InvPlusBind_Wa.HeaderText = "+";
            this.InvPlusBind_Wa.MinimumWidth = 6;
            this.InvPlusBind_Wa.Name = "InvPlusBind_Wa";
            this.InvPlusBind_Wa.ReadOnly = true;
            this.InvPlusBind_Wa.Width = 48;
            // 
            // InvCraftAtt_Wa
            // 
            this.InvCraftAtt_Wa.HeaderText = "Craft effect";
            this.InvCraftAtt_Wa.MinimumWidth = 6;
            this.InvCraftAtt_Wa.Name = "InvCraftAtt_Wa";
            this.InvCraftAtt_Wa.ReadOnly = true;
            this.InvCraftAtt_Wa.Width = 112;
            // 
            // InvItemBinary_Wa
            // 
            this.InvItemBinary_Wa.HeaderText = "Item Binary";
            this.InvItemBinary_Wa.MinimumWidth = 6;
            this.InvItemBinary_Wa.Name = "InvItemBinary_Wa";
            this.InvItemBinary_Wa.ReadOnly = true;
            this.InvItemBinary_Wa.Width = 113;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnDelTitle);
            this.tabPage4.Controls.Add(this.btnAddTitle);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.cbNewTitle);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.txtTitleData);
            this.tabPage4.Controls.Add(this.dataGrid_Title);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(761, 841);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Title";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnDelTitle
            // 
            this.btnDelTitle.Location = new System.Drawing.Point(624, 687);
            this.btnDelTitle.Name = "btnDelTitle";
            this.btnDelTitle.Size = new System.Drawing.Size(131, 67);
            this.btnDelTitle.TabIndex = 7;
            this.btnDelTitle.Text = "Delete Title";
            this.btnDelTitle.UseVisualStyleBackColor = true;
            this.btnDelTitle.Click += new System.EventHandler(this.btnDelTitle_Click);
            // 
            // btnAddTitle
            // 
            this.btnAddTitle.Location = new System.Drawing.Point(467, 687);
            this.btnAddTitle.Name = "btnAddTitle";
            this.btnAddTitle.Size = new System.Drawing.Size(131, 67);
            this.btnAddTitle.TabIndex = 6;
            this.btnAddTitle.Text = "Add Title";
            this.btnAddTitle.UseVisualStyleBackColor = true;
            this.btnAddTitle.Click += new System.EventHandler(this.btnAddTitle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 640);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Title List:";
            // 
            // cbNewTitle
            // 
            this.cbNewTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbNewTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNewTitle.FormattingEnabled = true;
            this.cbNewTitle.Location = new System.Drawing.Point(135, 637);
            this.cbNewTitle.Name = "cbNewTitle";
            this.cbNewTitle.Size = new System.Drawing.Size(620, 28);
            this.cbNewTitle.TabIndex = 3;
            this.cbNewTitle.SelectedIndexChanged += new System.EventHandler(this.cbNewTitle_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title Data:";
            // 
            // txtTitleData
            // 
            this.txtTitleData.Location = new System.Drawing.Point(135, 445);
            this.txtTitleData.Multiline = true;
            this.txtTitleData.Name = "txtTitleData";
            this.txtTitleData.Size = new System.Drawing.Size(620, 186);
            this.txtTitleData.TabIndex = 1;
            // 
            // dataGrid_Title
            // 
            this.dataGrid_Title.AllowUserToAddRows = false;
            this.dataGrid_Title.AllowUserToDeleteRows = false;
            this.dataGrid_Title.AllowUserToResizeRows = false;
            this.dataGrid_Title.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid_Title.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Title.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ckSelectTitle,
            this.TitleCode,
            this.TitleHex,
            this.TitleCnt});
            this.dataGrid_Title.Location = new System.Drawing.Point(6, 6);
            this.dataGrid_Title.Name = "dataGrid_Title";
            this.dataGrid_Title.RowHeadersVisible = false;
            this.dataGrid_Title.RowHeadersWidth = 51;
            this.dataGrid_Title.RowTemplate.Height = 29;
            this.dataGrid_Title.Size = new System.Drawing.Size(749, 419);
            this.dataGrid_Title.TabIndex = 0;
            // 
            // ckSelectTitle
            // 
            this.ckSelectTitle.HeaderText = "Select";
            this.ckSelectTitle.MinimumWidth = 6;
            this.ckSelectTitle.Name = "ckSelectTitle";
            this.ckSelectTitle.Width = 55;
            // 
            // TitleCode
            // 
            this.TitleCode.HeaderText = "Code";
            this.TitleCode.MinimumWidth = 6;
            this.TitleCode.Name = "TitleCode";
            this.TitleCode.Width = 73;
            // 
            // TitleHex
            // 
            this.TitleHex.HeaderText = "Hex";
            this.TitleHex.MinimumWidth = 6;
            this.TitleHex.Name = "TitleHex";
            this.TitleHex.Width = 64;
            // 
            // TitleCnt
            // 
            this.TitleCnt.HeaderText = "Content";
            this.TitleCnt.MinimumWidth = 6;
            this.TitleCnt.Name = "TitleCnt";
            this.TitleCnt.Width = 90;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGrid_Skill);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(761, 841);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Skill";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGrid_Skill
            // 
            this.dataGrid_Skill.AllowUserToAddRows = false;
            this.dataGrid_Skill.AllowUserToDeleteRows = false;
            this.dataGrid_Skill.AllowUserToResizeRows = false;
            this.dataGrid_Skill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid_Skill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Skill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSkiID,
            this.colSkiName,
            this.colSkiLv,
            this.colSkiPos,
            this.colSkiDesc});
            this.dataGrid_Skill.Location = new System.Drawing.Point(6, 6);
            this.dataGrid_Skill.Name = "dataGrid_Skill";
            this.dataGrid_Skill.RowHeadersWidth = 51;
            this.dataGrid_Skill.RowTemplate.Height = 29;
            this.dataGrid_Skill.Size = new System.Drawing.Size(749, 419);
            this.dataGrid_Skill.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(761, 841);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Dungeon";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // colSkiID
            // 
            this.colSkiID.HeaderText = "Skill ID";
            this.colSkiID.MinimumWidth = 6;
            this.colSkiID.Name = "colSkiID";
            this.colSkiID.Width = 84;
            // 
            // colSkiName
            // 
            this.colSkiName.HeaderText = "Name";
            this.colSkiName.MinimumWidth = 6;
            this.colSkiName.Name = "colSkiName";
            this.colSkiName.Width = 78;
            // 
            // colSkiLv
            // 
            this.colSkiLv.HeaderText = "Level";
            this.colSkiLv.MinimumWidth = 6;
            this.colSkiLv.Name = "colSkiLv";
            this.colSkiLv.Width = 72;
            // 
            // colSkiPos
            // 
            this.colSkiPos.HeaderText = "Position";
            this.colSkiPos.MinimumWidth = 6;
            this.colSkiPos.Name = "colSkiPos";
            this.colSkiPos.Width = 90;
            // 
            // colSkiDesc
            // 
            this.colSkiDesc.HeaderText = "Description";
            this.colSkiDesc.MinimumWidth = 6;
            this.colSkiDesc.Name = "colSkiDesc";
            this.colSkiDesc.Width = 114;
            // 
            // FUC_CharacterEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FUC_CharacterEquipment";
            this.Size = new System.Drawing.Size(775, 880);
            this.Load += new System.EventHandler(this.FUC_CharacterEquipment_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Equipment)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Inventory)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Warehouse)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Title)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Skill)).EndInit();
            this.ResumeLayout(false);

    }

    public FUC_CharacterEquipment()
    {
        InitializeComponent();
        read_itemlist();
        read_titleList();
        read_skillList();
    }

    public static implicit operator FUC_CharacterEquipment(CabalGM1.FUC_CharacterEquipment v)
    {
        throw new NotImplementedException();
    }

    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private DataGridView dataGrid_Inventory;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemIdx_In;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvRealItemIdx_In;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemOpt_In;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemName_In;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvPlusBind_In;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvCraftAtt_In;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemBinary_In;
    private DataGridView dataGrid_Warehouse;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemIdx_Wa;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvRealItemIdx_Wa;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemOpt_Wa;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemName_Wa;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvPlusBind_Wa;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvCraftAtt_Wa;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemBinary_Wa;
    private Label label1;
    private TextBox txtBankAlz;
    private DataGridView dataGrid_Equipment;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemIdx_Eq;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvRealItemIdx_Eq;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemOpt_Eq;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemName_Eq;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvPlusBind_Eq;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvCraftAtt_Eq;
    private System.Windows.Forms.DataGridViewTextBoxColumn InvItemBinary_Eq;
    private Button btnUpdateWare;
    private Button btnClearInv;
    private TabPage tabPage4;
    private DataGridView dataGrid_Title;
    private TextBox txtTitleData;
    private Label label2;
    private DataGridViewCheckBoxColumn ckSelectTitle;
    private DataGridViewTextBoxColumn TitleCode;
    private DataGridViewTextBoxColumn TitleHex;
    private DataGridViewTextBoxColumn TitleCnt;
    private Label label3;
    private ComboBox cbNewTitle;
    private Button btnAddTitle;
    private Button btnDelTitle;
    private TabPage tabPage5;
    private TabPage tabPage6;
    private DataGridView dataGrid_Skill;
    private DataGridViewTextBoxColumn colSkiID;
    private DataGridViewTextBoxColumn colSkiName;
    private DataGridViewTextBoxColumn colSkiLv;
    private DataGridViewTextBoxColumn colSkiPos;
    private DataGridViewTextBoxColumn colSkiDesc;
}
