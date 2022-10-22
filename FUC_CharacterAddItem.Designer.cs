using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using CabalGM1;

public class FUC_CharacterAddItem : UserControl
{
    private IContainer components = null;

    private Button btResetSkill;

    private Button btAddGMSkill;

    private Button btAddSkillBook;

    private GroupBox groupBox1;

    private Label label4;

    private Label label1;

    private Label label2;

    private Label label3;

    private Label label11;

    private ComboBox cbEquiClass;

    private ComboBox cbEquiMaterial;

    private DomainUpDown dupEquiUpgrade;

    private DomainUpDown dupEquiSlot;

    private Label label12;

    private ComboBox cbEquiDuration;

    private Button btAddEquipment;

    private TextBox txEquiID;

    private GroupBox groupBox2;

    private ComboBox cbEquiType;

    private Label label13;

    private RadioButton rbBindCharUsed;

    private RadioButton rbBindCharNotUse;

    private RadioButton rbBindAcc;

    private RadioButton rbBindNone;

    private Label label14;

    private GroupBox groupBox3;

    private Label label8;

    private Label label7;

    private Label label6;

    private Label label5;

    private ComboBox cbEquiOpt4;

    private ComboBox cbEquiOptPro4;

    private ComboBox cbEquiOpt3;

    private ComboBox cbEquiOptPro3;

    private ComboBox cbEquiOpt2;

    private ComboBox cbEquiOptPro2;

    private ComboBox cbEquiOpt1;

    private ComboBox cbEquiOptPro1;

    private TextBox txEquiOpt;

    private Label lbEquiOpt;

    private Label lbEquiID;

    private GroupBox groupBox4;

    private TextBox txtItemAmount;

    private Label label15;

    private ComboBox cbItemName;

    private Label label10;

    private ComboBox cbItemClass;

    private Label label9;

    private Button btAddItem;

    private TextBox txtItemOpt;

    private Label label16;

    private TextBox txtItemID;

    private Label label17;

    private ComboBox cbItemDuration;

    private Label label18;

    private TextBox txItemDesc;

    private Label label19;

    private ComboBox cbItemType;

    private int itemToOnlUser = 0;

    private int mailToAllUser = 0;

    private List<object> listItems;

    private bool multiId = false;

    private bool multiOpt = false;

    public FUC_CharacterAddItem()
    {
        InitializeComponent();
        loadPetOpt();
    }

    private void FUC_CharacterAddItem_Load(object sender, EventArgs e)
    {
        cbEquiClass.DataSource = UtilityXML.loadEquiClass();
        cbEquiDuration.SelectedIndex = 0;
        cbEquiOpt1.SelectedIndex = 0;
        cbEquiOpt2.SelectedIndex = 7;
        cbEquiOpt3.SelectedIndex = 7;
        cbEquiOpt4.SelectedIndex = 7;
        List<object> listDurationID = UtilityXML.getListDurationID();
        cbEquiDuration.DataSource = listDurationID;
        cbEquiDuration.DisplayMember = "Cont";
        cbEquiDuration.ValueMember = "ID";
        cbEquiDuration.SelectedIndex = listDurationID.Count - 1;
        cbItemClass.DataSource = UtilityXML.loadItemClass();
        cbItemName.SelectedIndex = -1;
        listDurationID = UtilityXML.getListDurationID();
        cbItemDuration.DataSource = listDurationID;
        cbItemDuration.DisplayMember = "Cont";
        cbItemDuration.ValueMember = "ID";
        cbItemDuration.SelectedIndex = listDurationID.Count - 1;
        listDurationID = UtilityXML.getListDurationID();
        cbItemMailDuration.DataSource = listDurationID;
        cbItemMailDuration.DisplayMember = "Cont";
        cbItemMailDuration.ValueMember = "ID";
        cbItemMailDuration.SelectedIndex = listDurationID.Count - 1;
    }

    private void btReset_Click(object sender, EventArgs e)
    {
        if (GlobalClass.isAccountLoaded() && GlobalClass.isCharacterLoaded())
        {
            MyCharacter curMyChar = GlobalClass.CurMyChar;
            string query = "SELECT SkillData FROM cabal_new_character_data WHERE ClassType = " + curMyChar.ClassName;
            DataTable dataTable = UtilityDatabase.selectQuery(GlobalClass.SQLGameDB, query);
            curMyChar.Skill = MyMath.ByteArrayToString((byte[])dataTable.Rows[0][0]);
            UtilityDatabase.setSkill(curMyChar.CharNum, curMyChar.Skill);
            MessageBox.Show("Success");
        }
    }

    private void btAddGMSkill_Click(object sender, EventArgs e)
    {
        if (GlobalClass.isAccountLoaded() && GlobalClass.isCharacterLoaded())
        {
            MyCharacter curMyChar = GlobalClass.CurMyChar;
            curMyChar.Skill += MySkill.encryptedSkill(146, 1, 36);
            curMyChar.Skill += MySkill.encryptedSkill(147, 1, 37);
            curMyChar.Skill += MySkill.encryptedSkill(462, 1, 38);
            curMyChar.Skill += MySkill.encryptedSkill(463, 1, 39);
            UtilityDatabase.setSkill(curMyChar.CharNum, curMyChar.Skill);
            MessageBox.Show("Success");
        }
    }

    private void btAddSkillBook_Click(object sender, EventArgs e)
    {
        if (GlobalClass.isAccountLoaded() && GlobalClass.isCharacterLoaded())
        {
            MyCharacter curMyChar = GlobalClass.CurMyChar;
            UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 2105, 0, 31);
            UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 2106, 0, 31);
            UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 2135, 0, 31);
            if (curMyChar.ClassName == 1)
            {
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3261, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3262, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3263, 0, 31);
            }
            else if (curMyChar.ClassName == 2)
            {
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3264, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3265, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3266, 0, 31);
            }
            else if (curMyChar.ClassName == 3)
            {
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3267, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3268, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3269, 0, 31);
            }
            else if (curMyChar.ClassName == 4)
            {
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3270, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3271, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3272, 0, 31);
            }
            else if (curMyChar.ClassName == 5)
            {
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3273, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3274, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3275, 0, 31);
            }
            else if (curMyChar.ClassName == 6)
            {
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3276, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3277, 0, 31);
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, 3278, 0, 31);
            }
            MessageBox.Show("Success");
        }
    }

    public List<object> loadListSlotOption()
    {
        return UtilityXML.loadCraftSlotOption("EquipmentSlot.xml", cbEquiClass.SelectedValue.ToString());
    }

    public List<object> loadCraftOpt()
    {
        return UtilityXML.loadCraftSlotOption("EquipmentCraft.xml", cbEquiClass.SelectedValue.ToString());
    }

    private void cbEquiClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbEquiClass.SelectedIndex <= 4)
        {
            cbEquiOpt1.SelectedIndex = 0;
            cbEquiOpt2.SelectedIndex = 7;
            cbEquiOpt3.SelectedIndex = 7;
            cbEquiOpt4.SelectedIndex = 7;
        }
        else
        {
            cbEquiOpt1.SelectedIndex = 0;
            cbEquiOpt2.SelectedIndex = 0;
            cbEquiOpt3.SelectedIndex = 0;
            cbEquiOpt4.SelectedIndex = 0;
        }
        cbEquiType.DataSource = UtilityXML.loadEquipTypes(cbEquiClass.SelectedValue.ToString());
        List<object> dataSource = ((cbEquiOpt1.SelectedIndex == 0) ? loadListSlotOption() : loadCraftOpt());
        cbEquiOptPro1.DataSource = dataSource;
        cbEquiOptPro1.DisplayMember = "Cont";
        cbEquiOptPro1.ValueMember = "ID";
        dataSource = ((cbEquiOpt2.SelectedIndex == 0) ? loadListSlotOption() : loadCraftOpt());
        cbEquiOptPro2.DataSource = dataSource;
        cbEquiOptPro2.DisplayMember = "Cont";
        cbEquiOptPro2.ValueMember = "ID";
        dataSource = ((cbEquiOpt3.SelectedIndex == 0) ? loadListSlotOption() : loadCraftOpt());
        cbEquiOptPro3.DataSource = dataSource;
        cbEquiOptPro3.DisplayMember = "Cont";
        cbEquiOptPro3.ValueMember = "ID";
        dataSource = ((cbEquiOpt4.SelectedIndex == 0) ? loadListSlotOption() : loadCraftOpt());
        cbEquiOptPro4.DataSource = dataSource;
        cbEquiOptPro4.DisplayMember = "Cont";
        cbEquiOptPro4.ValueMember = "ID";
        calcItemIDOpt();
    }

    private void cbEquiType_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<object> list = UtilityXML.loadEquips(cbEquiClass.SelectedValue.ToString(), cbEquiType.SelectedValue.ToString());
        if (list != null)
        {
            cbEquiMaterial.DataSource = list.ToList();
            cbEquiMaterial.DisplayMember = "Name";
            cbEquiMaterial.ValueMember = "Id";
            calcItemIDOpt();
        }
    }

    private void dupEquiSlot_SelectedItemChanged(object sender, EventArgs e)
    {
        switch (int.Parse(dupEquiSlot.Text))
        {
            case 0:
                cbEquiOpt1.Enabled = false;
                cbEquiOpt2.Enabled = false;
                cbEquiOpt3.Enabled = false;
                cbEquiOpt4.Enabled = false;
                cbEquiOptPro1.Enabled = false;
                cbEquiOptPro2.Enabled = false;
                cbEquiOptPro3.Enabled = false;
                cbEquiOptPro4.Enabled = false;
                break;
            case 1:
                cbEquiOpt1.Enabled = true;
                cbEquiOpt2.Enabled = false;
                cbEquiOpt3.Enabled = false;
                cbEquiOpt4.Enabled = false;
                cbEquiOptPro1.Enabled = true;
                cbEquiOptPro2.Enabled = false;
                cbEquiOptPro3.Enabled = false;
                cbEquiOptPro4.Enabled = false;
                break;
            case 2:
                cbEquiOpt1.Enabled = true;
                cbEquiOpt2.Enabled = true;
                cbEquiOpt3.Enabled = false;
                cbEquiOpt4.Enabled = false;
                cbEquiOptPro1.Enabled = true;
                cbEquiOptPro2.Enabled = true;
                cbEquiOptPro3.Enabled = false;
                cbEquiOptPro4.Enabled = false;
                break;
            case 3:
                cbEquiOpt1.Enabled = true;
                cbEquiOpt2.Enabled = true;
                cbEquiOpt3.Enabled = true;
                cbEquiOpt4.Enabled = false;
                cbEquiOptPro1.Enabled = true;
                cbEquiOptPro2.Enabled = true;
                cbEquiOptPro3.Enabled = true;
                cbEquiOptPro4.Enabled = false;
                break;
            case 4:
                cbEquiOpt1.Enabled = true;
                cbEquiOpt2.Enabled = true;
                cbEquiOpt3.Enabled = true;
                cbEquiOpt4.Enabled = true;
                cbEquiOptPro1.Enabled = true;
                cbEquiOptPro2.Enabled = true;
                cbEquiOptPro3.Enabled = true;
                cbEquiOptPro4.Enabled = true;
                break;
        }
        calcItemIDOpt();
    }

    private void cbEquiMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
        calcItemIDOpt();
    }

    private void dupEquiUpgrade_SelectedItemChanged(object sender, EventArgs e)
    {
        calcItemIDOpt();
    }

    private void rbBind_CheckedChanged(object sender, EventArgs e)
    {
        calcItemIDOpt();
    }

    private void cbEquiOpt1_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<object> dataSource = ((cbEquiOpt1.SelectedIndex == 0) ? loadListSlotOption() : loadCraftOpt());
        cbEquiOptPro1.DataSource = dataSource;
        cbEquiOptPro1.DisplayMember = "Cont";
        cbEquiOptPro1.ValueMember = "ID";
    }

    private void cbEquiOpt2_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<object> dataSource = ((cbEquiOpt2.SelectedIndex == 0) ? loadListSlotOption() : loadCraftOpt());
        cbEquiOptPro2.DataSource = dataSource;
        cbEquiOptPro2.DisplayMember = "Cont";
        cbEquiOptPro2.ValueMember = "ID";
    }

    private void cbEquiOpt3_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<object> dataSource = ((cbEquiOpt3.SelectedIndex == 0) ? loadListSlotOption() : loadCraftOpt());
        cbEquiOptPro3.DataSource = dataSource;
        cbEquiOptPro3.DisplayMember = "Cont";
        cbEquiOptPro3.ValueMember = "ID";
    }

    private void cbEquiOpt4_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<object> dataSource = ((cbEquiOpt4.SelectedIndex == 0) ? loadListSlotOption() : loadCraftOpt());
        cbEquiOptPro4.DataSource = dataSource;
        cbEquiOptPro4.DisplayMember = "Cont";
        cbEquiOptPro4.ValueMember = "ID";
    }

    private void cbEquiOptPro_SelectedIndexChanged(object sender, EventArgs e)
    {
        calcItemIDOpt();
    }

    private string convertOpt(int i)
    {
        string result = "";
        switch (i)
        {
            case 1:
                result = "9";
                break;
            case 2:
                result = "A";
                break;
            case 3:
                result = "B";
                break;
            case 4:
                result = "C";
                break;
            case 5:
                result = "D";
                break;
            case 6:
                result = "E";
                break;
            case 7:
                result = "F";
                break;
        }
        return result;
    }

    public void calcItemIDOpt()
    {
        int decval = 0;
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        try
        {
            num = int.Parse((cbEquiMaterial.SelectedValue == null ? "0" : cbEquiMaterial.SelectedValue.ToString()));
            num2 = int.Parse(dupEquiUpgrade.Text) * 8192;
            if (rbBindNone.Checked)
            {
                num3 = 0;
            }
            else if (rbBindAcc.Checked)
            {
                num3 = 4096;
            }
            else if (rbBindCharNotUse.Checked)
            {
                num3 = 524288;
            }
            else if (rbBindCharUsed.Checked)
            {
                num3 = 1572864;
            }
            decval = num + num2 + num3;
        }
        catch (Exception)
        {
        }
        txEquiID.Text = decval.ToString();
        lbEquiID.Text = "(0x" + MyMath.dec2hex(decval, 8) + ")";
        string text = "";
        try
        {
            if (dupEquiSlot.Text.Equals("0"))
            {
                text = "00000000";
            }
            else
            {
                int num4 = int.Parse(dupEquiSlot.Text);
                text += dupEquiSlot.Text;
                text += cbEquiOptPro1.SelectedValue == null ? "0" : cbEquiOptPro1.SelectedValue.ToString();
                text = ((num4 < 2) ? (text + "0") : (text + ((cbEquiOpt2.SelectedIndex == 0) ? "1" : convertOpt(cbEquiOpt2.SelectedIndex))));
                text += cbEquiOptPro2.SelectedValue == null ? "0" : cbEquiOptPro2.SelectedValue.ToString();
                text = ((num4 < 3) ? (text + "0") : (text + ((cbEquiOpt3.SelectedIndex == 0) ? "1" : convertOpt(cbEquiOpt3.SelectedIndex))));
                text += cbEquiOptPro3.SelectedValue == null ? "0" : cbEquiOptPro3.SelectedValue.ToString();
                text = ((num4 < 4) ? (text + "0") : (text + ((cbEquiOpt4.SelectedIndex == 0) ? "1" : convertOpt(cbEquiOpt4.SelectedIndex))));
                text += cbEquiOptPro4.SelectedValue == null ? "0" : cbEquiOptPro4.SelectedValue.ToString();
            }
        }
        catch (Exception)
        {
        }
        lbEquiOpt.Text = "(0x" + text + ")";
        if (text.Length == 8)
        {
            txEquiOpt.Text = MyMath.hex2dec(text).ToString();
        }
    }

    private void btAddEquipment_Click(object sender, EventArgs e)
    {
        if (GlobalClass.isAccountLoaded())
        {
            calcItemIDOpt();
            int num = int.Parse(txEquiID.Text);
            int num2 = int.Parse(txEquiOpt.Text);
            int durationIdx = int.Parse(cbEquiDuration.SelectedValue.ToString());
            if (num <= 0 || num2 < 0)
            {
                MessageBox.Show("Equipment invalid, pls check it again");
                return;
            }
            UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, num, num2, durationIdx);
            MessageBox.Show("Success");
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
            SPLIT_EQUIPMENT(MyMath.ByteArrayToString(curMyChar.Equipment));
            loadPetName();
            //displayPetInfo();
        }
    }

    private void SPLIT_EQUIPMENT(string data)
    {
        listItems = new List<object>();
        int num = 0;
        while (num < 1800)
        {
            try
            {
                object[] item = new object[8]
                {
                    MyMath.DBO_BINTOINT(data.Substring(num, 8)),
                    MyMath.DBO_BINTOINT(data.Substring(num + 8, 8)),
                    MyMath.DBO_BINTOINT(data.Substring(num + 8 + 8, 8)),
                    MyMath.DBO_BINTOINT(data.Substring(num + 8 + 8 + 8, 4)),
                    MyMath.DBO_BINTOINT(data.Substring(num + 8 + 8 + 8 + 4, 8)),
                    null,
                    null,
                    num / 36
                };
                listItems.Add(item);
                num += 36;
            }
            catch (Exception)
            {
                break;
            }
        }
    }

    private void cbItemClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        cbItemType.DataSource = UtilityXML.loadItemTypes(cbItemClass.SelectedValue.ToString());
    }

    private void cbItemType_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<object> dataSource = UtilityXML.loadItems(cbItemClass.SelectedValue.ToString(), cbItemType.SelectedValue.ToString());
        cbItemName.DataSource = dataSource;
        cbItemName.DisplayMember = "Cont";
        cbItemName.ValueMember = "ID";
    }

    private void cbItemName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbItemName.SelectedValue == null)
        {
            return;
        }
        string text = cbItemName.SelectedValue.ToString();
        int itemClass = cbItemClass.SelectedIndex;
        int index = cbItemName.SelectedIndex;
        try
        {
            int num = int.Parse(text);
            txtItemID.Text = ((text == null) ? "0" : text);
        }
        catch (Exception)
        {
            txtItemID.Text = "0";
        }
        try
        {
            string text2 = UtilityXML.loadItemDesc(text);
            txItemDesc.Text = text2;
        }
        catch (Exception)
        {
            txItemDesc.Text = "";
        }
        try
        {
            string text3 = UtilityXML.loadItemOpt(text, itemClass, index);
            txtItemOpt.Text = text3;
        }
        catch (Exception)
        {
            txtItemOpt.Text = "0";
        }
    }

    private void btAddItem_Click(object sender, EventArgs e)
    {
        if (!GlobalClass.isAccountLoaded())
        {
            return;
        }
        int itemId = int.Parse(txtItemID.Text);
        int itemOpt = int.Parse(txtItemOpt.Text);
        int itemAmount = int.Parse(txtItemAmount.Text);
        int durationIdx = int.Parse(cbItemDuration.SelectedValue.ToString());
        int toItemId = int.Parse(txtMultiId.Text);
        int toItemOpt = int.Parse(txtMultiOpt.Text);
        if (itemId <= 0 || itemOpt < 0)
        {
            MessageBox.Show("Item invalid, pls check it again");
            return;
        }
        if (ckMultiId.Checked)
        {
            if(itemId >= toItemId)
            {
                MessageBox.Show("Item ID invalid, {To Item ID} must be larger than ITEM ID");
                txtMultiId.Focus();
                return;
            }
            else
            {
                for(int i=itemId; i < toItemId; i++)
                {
                    UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, i, itemOpt, durationIdx);
                }
            }
        }
        else if (ckMultiOpt.Checked)
        {
            if (itemOpt >= toItemOpt)
            {
                MessageBox.Show("Item Option invalid, {To Item Option} must be larger than ITEM Option");
                txtMultiOpt.Focus();
                return;
            }
            else
            {
                for(int i= itemOpt; i < toItemOpt; i++)
                {
                    UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, itemId, i, durationIdx);
                }
            }
        }
        else
        {
            for (int i = 0; i < itemAmount; i++)
            {
                UtilityDatabase.addItem2CashInventory(GlobalClass.UserNum, 1, 1, itemId, itemOpt, durationIdx);
            }
        }      
        MessageBox.Show("Success");
    }

    private void btAddItemToAll_Click(object sender, EventArgs e)
    {
        if (!GlobalClass.isAccountLoaded())
        {
            return;
        }
        int num = int.Parse(txtItemID.Text);
        int num2 = int.Parse(txtItemOpt.Text);
        int num3 = int.Parse(txtItemAmount.Text);
        int durationIdx = int.Parse(cbItemDuration.SelectedValue.ToString());
        if (num <= 0 || num2 < 0)
        {
            MessageBox.Show("Item invalid, pls check it again");
            return;
        }
        for (int i = 0; i < num3; i++)
        {
            UtilityDatabase.addItemToAll(num, num2, durationIdx, itemToOnlUser);
        }
        MessageBox.Show("Success");
    }

    /// <summary>
    /// Pet Info
    /// </summary>
    private void encryptPetOpt()
    {
        if (!(txPetID.Text == "0"))
        {
            string text = "";
            try
            {
                text += (cbPetSlot1.Enabled ? cbPetSlot1.SelectedValue.ToString() : "00");
                text += (cbPetSlot2.Enabled ? cbPetSlot2.SelectedValue.ToString() : "00");
                text += (cbPetSlot3.Enabled ? cbPetSlot3.SelectedValue.ToString() : "00");
                text += (cbPetSlot4.Enabled ? cbPetSlot4.SelectedValue.ToString() : "00");
                text += (cbPetSlot5.Enabled ? cbPetSlot5.SelectedValue.ToString() : "00");
                text += (cbPetSlot6.Enabled ? cbPetSlot6.SelectedValue.ToString() : "00");
                text += (cbPetSlot7.Enabled ? cbPetSlot7.SelectedValue.ToString() : "00");
                text += (cbPetSlot8.Enabled ? cbPetSlot8.SelectedValue.ToString() : "00");
                text += (cbPetSlot9.Enabled ? cbPetSlot9.SelectedValue.ToString() : "00");
                text += (cbPetSlot10.Enabled ? cbPetSlot10.SelectedValue.ToString() : "00");
                text += "00000000000000000000000000000000000000000000";
            }
            catch (Exception)
            {
                text = "0000000000000000000000000000000000000000000000000000000000000000";
            }
            txPetOpt.Text = text;
        }
    }

    private void decryptPetOpt(string petOpt)
    {
        petOpt = petOpt.Substring(0, 20);
        string[] array = new string[10];
        for (int i = 0; i < petOpt.Length / 2; i++)
        {
            array[i] = petOpt.Substring(i * 2, 2);
        }
        cbPetSlot1.SelectedValue = array[0];
        cbPetSlot2.SelectedValue = array[1];
        cbPetSlot3.SelectedValue = array[2];
        cbPetSlot4.SelectedValue = array[3];
        cbPetSlot5.SelectedValue = array[4];
        cbPetSlot6.SelectedValue = array[5];
        cbPetSlot7.SelectedValue = array[6];
        cbPetSlot8.SelectedValue = array[7];
        cbPetSlot9.SelectedValue = array[8];
        cbPetSlot10.SelectedValue = array[9];
    }

    private void cbPetSlot_SelectedIndexChanged(object sender, EventArgs e)
    {
        encryptPetOpt();
    }

    private void dupPetLv_SelectedItemChanged(object sender, EventArgs e)
    {
        int num = int.Parse(dupPetLv.Text);
        cbPetSlot1.Enabled = num >= 1;
        cbPetSlot2.Enabled = num >= 2;
        cbPetSlot3.Enabled = num >= 3;
        cbPetSlot4.Enabled = num >= 4;
        cbPetSlot5.Enabled = num >= 5;
        cbPetSlot6.Enabled = num >= 6;
        cbPetSlot7.Enabled = num >= 7;
        cbPetSlot8.Enabled = num >= 8;
        cbPetSlot9.Enabled = num >= 9;
        cbPetSlot10.Enabled = num >= 10;
    }

    private void loadPetOpt()
    {
        List<object> dataSource = UtilityXML.loadPetOpt();
        cbPetSlot1.DataSource = dataSource;
        cbPetSlot1.DisplayMember = "Name";
        cbPetSlot1.ValueMember = "Opt";
        dataSource = UtilityXML.loadPetOpt();
        cbPetSlot2.DataSource = dataSource;
        cbPetSlot2.DisplayMember = "Name";
        cbPetSlot2.ValueMember = "Opt";
        dataSource = UtilityXML.loadPetOpt();
        cbPetSlot3.DataSource = dataSource;
        cbPetSlot3.DisplayMember = "Name";
        cbPetSlot3.ValueMember = "Opt";
        dataSource = UtilityXML.loadPetOpt();
        cbPetSlot4.DataSource = dataSource;
        cbPetSlot4.DisplayMember = "Name";
        cbPetSlot4.ValueMember = "Opt";
        dataSource = UtilityXML.loadPetOpt();
        cbPetSlot5.DataSource = dataSource;
        cbPetSlot5.DisplayMember = "Name";
        cbPetSlot5.ValueMember = "Opt";
        dataSource = UtilityXML.loadPetOpt();
        cbPetSlot6.DataSource = dataSource;
        cbPetSlot6.DisplayMember = "Name";
        cbPetSlot6.ValueMember = "Opt";
        dataSource = UtilityXML.loadPetOpt();
        cbPetSlot7.DataSource = dataSource;
        cbPetSlot7.DisplayMember = "Name";
        cbPetSlot7.ValueMember = "Opt";
        dataSource = UtilityXML.loadPetOpt();
        cbPetSlot8.DataSource = dataSource;
        cbPetSlot8.DisplayMember = "Name";
        cbPetSlot8.ValueMember = "Opt";
        dataSource = UtilityXML.loadPetOpt();
        cbPetSlot9.DataSource = dataSource;
        cbPetSlot9.DisplayMember = "Name";
        cbPetSlot9.ValueMember = "Opt";
        dataSource = UtilityXML.loadPetOpt();
        cbPetSlot10.DataSource = dataSource;
        cbPetSlot10.DisplayMember = "Name";
        cbPetSlot10.ValueMember = "Opt";
    }

    public void loadPetName()
    {
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@PetSerial", "0"));
        arrayList.Add(new SqlParameter("@PetId", "0"));
        arrayList.Add(new SqlParameter("@charId", GlobalClass.CharNum));
        arrayList.Add(new SqlParameter("@kindIdx", "0"));
        DataTable dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_sp_get_charpet", arrayList);
        cbPetName.DataSource = dataTable;
        cbPetName.DisplayMember = "NickName";
        displayPetInfo();
    }

    public void displayPetInfo()
    {
        if (cbPetName.SelectedIndex < 0)
        {
            txPetID.Text = "0";
            txPetSerial.Text = "0";
            txPetItemIdx.Text = "0";
            txPetName.Text = "";
            string petOpt = "0000000000000000000000000000000000000000000000000000000000000000";
            txPetOpt.Text = petOpt;
            decryptPetOpt(petOpt);
            return;
        }
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@PetSerial", GlobalClass.PetId));
        arrayList.Add(new SqlParameter("@PetId", "0"));
        arrayList.Add(new SqlParameter("@charId", "0"));
        arrayList.Add(new SqlParameter("@kindIdx", "0"));
        DataTable dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_sp_get_petinfo", arrayList);
        int num1 = (int)dataTable.Rows[0][0];
        int num2 = (int)dataTable.Rows[0][1];
        int num3 = (int)dataTable.Rows[0][3];
        int num4 = (byte)dataTable.Rows[0][4];
        string text = (dataTable.Rows[0][7].ToString().Equals("") ? "" : ((string)dataTable.Rows[0][7]));
        byte[] pOpt = (byte[])dataTable.Rows[0][8];
        txPetSerial.Text = num1.ToString();
        txPetID.Text = num2.ToString();
        dupPetLv.SelectedItem = num4;
        txPetName.Text = text;
        txPetItemIdx.Text = num3.ToString();
        string petOpt2 = MyMath.ByteArrayToString(pOpt);
        txPetOpt.Text = petOpt2;
        decryptPetOpt(petOpt2);
    }

    private void btUpdatePet_Click(object sender, EventArgs e)
    {
        encryptPetOpt();
        if (GlobalClass.isAccountLoaded() && GlobalClass.isCharacterLoaded())
        {
            MyCharacter curMyChar = GlobalClass.CurMyChar;
            int num = int.Parse(txPetSerial.Text);
            if (num == 0)
            {
                MessageBox.Show("No pet weared");
                return;
            }
            int num2 = int.Parse(txPetID.Text);
            int num3 = int.Parse(txPetItemIdx.Text);
            int num4 = int.Parse(dupPetLv.Text);
            string value = txPetName.Text;
            byte[] value2 = MyMath.StringToByteArray(txPetOpt.Text);
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new SqlParameter("@PetSerial", num));
            arrayList.Add(new SqlParameter("@PetId", num2));
            arrayList.Add(new SqlParameter("@ownerId", curMyChar.CharNum));
            arrayList.Add(new SqlParameter("@itemIdx", num3));
            arrayList.Add(new SqlParameter("@level", num4));
            arrayList.Add(new SqlParameter("@exp", 100));
            arrayList.Add(new SqlParameter("@checked", "0"));
            arrayList.Add(new SqlParameter("@nickname", value));
            arrayList.Add(new SqlParameter("@option", value2));
            UtilityDatabase.execStoredPro(GlobalClass.SQLGameDB, "cabal_sp_set_petinfo", arrayList);
            MessageBox.Show("Success.");
        }
    }

    private void cbPetName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataRowView dataRowView = (DataRowView)cbPetName.SelectedItem;
        string[] array = dataRowView[0].ToString().Split('/');
        int petIdx = int.Parse(array[0]);
        GlobalClass.PetId = petIdx;
        displayPetInfo();
    }

    private void ckOnlineUser_CheckedChanged(object sender, EventArgs e)
    {
        if (ckOnlineUser.Checked)
        {
            itemToOnlUser = 1;
        }
        else
        {
            itemToOnlUser = 0;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void btnMailSend_Click(object sender, EventArgs e)
    {
        string content = "";
        string title = "";
        title = (txtMailTtl.Text.ToString() != "") ? txtMailTtl.Text : "Blank Title!";
        content = (txtMailCnt.Text.ToString() != "") ? txtMailCnt.Text : "Blank Content!";
        try
        {
            if (txtMailId.Text.ToString() == "" && mailToAllUser == 0)
            {
                MessageBox.Show("ERROR | Please fill in Character ID!");
            }
            else
            {
                int toCharId = int.Parse(txtMailId.Text.ToString()!="" ? txtMailId.Text: "0");
                int alzSend = int.Parse(txtMailAlz.Text.ToString());
                int itemId = int.Parse(txtMailItem.Text.ToString());
                int itemOpt = int.Parse(txtMailItemOpt.Text.ToString());
                int itemDuration = int.Parse(cbItemMailDuration.SelectedValue.ToString());
                if (!UtilityDatabase.sendMailItem(toCharId, title, content, alzSend, itemId, itemOpt, itemDuration, mailToAllUser))
                {
                    if (mailToAllUser == 0)
                    {
                        MessageBox.Show("ERROR | Can't send mail to SPECIFIED character!");
                    }
                    else
                    {
                        MessageBox.Show("ERROR | Can't send mail to ALL character!");
                    }
                }
                else
                {
                    if (mailToAllUser == 0)
                    {
                        MessageBox.Show("SUCCESS | Mail was sent to SPECIFIED character!");
                    }
                    else
                    {
                        MessageBox.Show("SUCCESS | Mail was sent to ALL character!");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("ERROR | An error occured while sending the mail. Please try againg after restarting the tool!");
        }
        txtMailAlz.Text = "0";
        txtMailItem.Text = "0";
        txtMailItemOpt.Text = "0";
    }

    private void txtDigit_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar)
            && e.KeyChar != '.')
        {
            e.Handled = true;
        }
    }

    private void txtMailAlz_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
        {
            e.Handled = true;
        }
    }

    private void ckMailToAll_CheckedChanged(object sender, EventArgs e)
    {
        if (ckMailToAll.Checked)
        {
            mailToAllUser = 1;
            txtMailId.Enabled = false;
            txtMailId.Text = "";
        }
        else
        {
            mailToAllUser = 0;
            txtMailId.Enabled = true;
        }
    }

    private void ckMultiId_CheckedChanged(object sender, EventArgs e)
    {
        if (ckMultiId.Checked)
        {
            txtMultiId.Enabled = true;
            ckMultiOpt.Enabled = false;
            multiId = true;
            txtItemAmount.Text = "1";
        }
        else
        {
            txtMultiId.Enabled = false;
            ckMultiOpt.Enabled = true;
            txtMultiId.Text = "0";
            multiId = false;
        }
    }

    private void ckMultiOpt_CheckedChanged(object sender, EventArgs e)
    {
        if (ckMultiOpt.Checked)
        {
            txtMultiOpt.Enabled = true;
            ckMultiId.Enabled = false;
            multiOpt = true;
            txtItemAmount.Text = "1";
        }
        else
        {
            txtMultiOpt.Enabled = false;
            ckMultiId.Enabled = true;
            txtMultiOpt.Text = "0";
            multiOpt = false;
        }
    }

    private void InitializeComponent()
    {
            this.btResetSkill = new System.Windows.Forms.Button();
            this.btAddGMSkill = new System.Windows.Forms.Button();
            this.btAddSkillBook = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbEquiClass = new System.Windows.Forms.ComboBox();
            this.cbEquiMaterial = new System.Windows.Forms.ComboBox();
            this.dupEquiUpgrade = new System.Windows.Forms.DomainUpDown();
            this.dupEquiSlot = new System.Windows.Forms.DomainUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cbEquiDuration = new System.Windows.Forms.ComboBox();
            this.btAddEquipment = new System.Windows.Forms.Button();
            this.txEquiID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbEquiOpt = new System.Windows.Forms.Label();
            this.lbEquiID = new System.Windows.Forms.Label();
            this.txEquiOpt = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbEquiOpt4 = new System.Windows.Forms.ComboBox();
            this.cbEquiOptPro4 = new System.Windows.Forms.ComboBox();
            this.cbEquiOpt3 = new System.Windows.Forms.ComboBox();
            this.cbEquiOptPro3 = new System.Windows.Forms.ComboBox();
            this.cbEquiOpt2 = new System.Windows.Forms.ComboBox();
            this.cbEquiOptPro2 = new System.Windows.Forms.ComboBox();
            this.cbEquiOpt1 = new System.Windows.Forms.ComboBox();
            this.cbEquiOptPro1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.rbBindNone = new System.Windows.Forms.RadioButton();
            this.rbBindCharUsed = new System.Windows.Forms.RadioButton();
            this.rbBindAcc = new System.Windows.Forms.RadioButton();
            this.rbBindCharNotUse = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.cbEquiType = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckMultiOpt = new System.Windows.Forms.CheckBox();
            this.ckMultiId = new System.Windows.Forms.CheckBox();
            this.txtMultiOpt = new System.Windows.Forms.TextBox();
            this.txtMultiId = new System.Windows.Forms.TextBox();
            this.ckOnlineUser = new System.Windows.Forms.CheckBox();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.txItemDesc = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbItemDuration = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtItemOpt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btAddItemToAll = new System.Windows.Forms.Button();
            this.btAddItem = new System.Windows.Forms.Button();
            this.txtItemAmount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbItemName = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbItemClass = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txPetItemIdx = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txPetSerial = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txPetName = new System.Windows.Forms.TextBox();
            this.txPetOpt = new System.Windows.Forms.TextBox();
            this.txPetID = new System.Windows.Forms.TextBox();
            this.cbPetSlot10 = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.cbPetSlot9 = new System.Windows.Forms.ComboBox();
            this.cbPetSlot8 = new System.Windows.Forms.ComboBox();
            this.cbPetSlot7 = new System.Windows.Forms.ComboBox();
            this.cbPetSlot6 = new System.Windows.Forms.ComboBox();
            this.cbPetSlot5 = new System.Windows.Forms.ComboBox();
            this.cbPetSlot4 = new System.Windows.Forms.ComboBox();
            this.cbPetSlot3 = new System.Windows.Forms.ComboBox();
            this.cbPetSlot2 = new System.Windows.Forms.ComboBox();
            this.cbPetSlot1 = new System.Windows.Forms.ComboBox();
            this.dupPetLv = new System.Windows.Forms.DomainUpDown();
            this.cbPetName = new System.Windows.Forms.ComboBox();
            this.btUpdatePet = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ckMailToAll = new System.Windows.Forms.CheckBox();
            this.txtMailAlz = new System.Windows.Forms.MaskedTextBox();
            this.cbItemMailDuration = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.txtMailItemOpt = new System.Windows.Forms.TextBox();
            this.txtMailItem = new System.Windows.Forms.TextBox();
            this.txtMailId = new System.Windows.Forms.TextBox();
            this.btnMailSend = new System.Windows.Forms.Button();
            this.txtMailCnt = new System.Windows.Forms.TextBox();
            this.txtMailTtl = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btResetSkill
            // 
            this.btResetSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btResetSkill.Location = new System.Drawing.Point(15, 29);
            this.btResetSkill.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btResetSkill.Name = "btResetSkill";
            this.btResetSkill.Size = new System.Drawing.Size(105, 36);
            this.btResetSkill.TabIndex = 0;
            this.btResetSkill.Text = "Reset skill";
            this.btResetSkill.UseVisualStyleBackColor = true;
            this.btResetSkill.Click += new System.EventHandler(this.btReset_Click);
            // 
            // btAddGMSkill
            // 
            this.btAddGMSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btAddGMSkill.Location = new System.Drawing.Point(15, 71);
            this.btAddGMSkill.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btAddGMSkill.Name = "btAddGMSkill";
            this.btAddGMSkill.Size = new System.Drawing.Size(105, 36);
            this.btAddGMSkill.TabIndex = 2;
            this.btAddGMSkill.Text = "Add GM skill";
            this.btAddGMSkill.UseVisualStyleBackColor = true;
            this.btAddGMSkill.Click += new System.EventHandler(this.btAddGMSkill_Click);
            // 
            // btAddSkillBook
            // 
            this.btAddSkillBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btAddSkillBook.Location = new System.Drawing.Point(135, 29);
            this.btAddSkillBook.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btAddSkillBook.Name = "btAddSkillBook";
            this.btAddSkillBook.Size = new System.Drawing.Size(129, 36);
            this.btAddSkillBook.TabIndex = 117;
            this.btAddSkillBook.Text = "Add skill book";
            this.btAddSkillBook.UseVisualStyleBackColor = true;
            this.btAddSkillBook.Click += new System.EventHandler(this.btAddSkillBook_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.btAddSkillBook);
            this.groupBox1.Controls.Add(this.btResetSkill);
            this.groupBox1.Controls.Add(this.btAddGMSkill);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(281, 123);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Skill";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(14, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Option:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(5, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Material:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(298, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Upgrade:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(200, 152);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "Duration:";
            // 
            // cbEquiClass
            // 
            this.cbEquiClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbEquiClass.FormattingEnabled = true;
            this.cbEquiClass.Location = new System.Drawing.Point(72, 29);
            this.cbEquiClass.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiClass.Name = "cbEquiClass";
            this.cbEquiClass.Size = new System.Drawing.Size(180, 25);
            this.cbEquiClass.TabIndex = 0;
            this.cbEquiClass.SelectedIndexChanged += new System.EventHandler(this.cbEquiClass_SelectedIndexChanged);
            // 
            // cbEquiMaterial
            // 
            this.cbEquiMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbEquiMaterial.FormattingEnabled = true;
            this.cbEquiMaterial.Location = new System.Drawing.Point(72, 73);
            this.cbEquiMaterial.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiMaterial.Name = "cbEquiMaterial";
            this.cbEquiMaterial.Size = new System.Drawing.Size(180, 25);
            this.cbEquiMaterial.TabIndex = 2;
            this.cbEquiMaterial.SelectedIndexChanged += new System.EventHandler(this.cbEquiMaterial_SelectedIndexChanged);
            // 
            // dupEquiUpgrade
            // 
            this.dupEquiUpgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dupEquiUpgrade.Items.Add("20");
            this.dupEquiUpgrade.Items.Add("19");
            this.dupEquiUpgrade.Items.Add("18");
            this.dupEquiUpgrade.Items.Add("17");
            this.dupEquiUpgrade.Items.Add("15");
            this.dupEquiUpgrade.Items.Add("15");
            this.dupEquiUpgrade.Items.Add("14");
            this.dupEquiUpgrade.Items.Add("13");
            this.dupEquiUpgrade.Items.Add("12");
            this.dupEquiUpgrade.Items.Add("11");
            this.dupEquiUpgrade.Items.Add("10");
            this.dupEquiUpgrade.Items.Add("9");
            this.dupEquiUpgrade.Items.Add("8");
            this.dupEquiUpgrade.Items.Add("7");
            this.dupEquiUpgrade.Items.Add("6");
            this.dupEquiUpgrade.Items.Add("5");
            this.dupEquiUpgrade.Items.Add("4");
            this.dupEquiUpgrade.Items.Add("3");
            this.dupEquiUpgrade.Items.Add("2");
            this.dupEquiUpgrade.Items.Add("1");
            this.dupEquiUpgrade.Items.Add("0");
            this.dupEquiUpgrade.Location = new System.Drawing.Point(361, 75);
            this.dupEquiUpgrade.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dupEquiUpgrade.Name = "dupEquiUpgrade";
            this.dupEquiUpgrade.ReadOnly = true;
            this.dupEquiUpgrade.Size = new System.Drawing.Size(91, 23);
            this.dupEquiUpgrade.TabIndex = 3;
            this.dupEquiUpgrade.Text = "20";
            this.dupEquiUpgrade.SelectedItemChanged += new System.EventHandler(this.dupEquiUpgrade_SelectedItemChanged);
            // 
            // dupEquiSlot
            // 
            this.dupEquiSlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dupEquiSlot.Items.Add("4");
            this.dupEquiSlot.Items.Add("3");
            this.dupEquiSlot.Items.Add("2");
            this.dupEquiSlot.Items.Add("1");
            this.dupEquiSlot.Items.Add("0");
            this.dupEquiSlot.Location = new System.Drawing.Point(72, 147);
            this.dupEquiSlot.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dupEquiSlot.Name = "dupEquiSlot";
            this.dupEquiSlot.ReadOnly = true;
            this.dupEquiSlot.Size = new System.Drawing.Size(91, 23);
            this.dupEquiSlot.TabIndex = 8;
            this.dupEquiSlot.Text = "4";
            this.dupEquiSlot.SelectedItemChanged += new System.EventHandler(this.dupEquiSlot_SelectedItemChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(40, 416);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "ID:";
            // 
            // cbEquiDuration
            // 
            this.cbEquiDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbEquiDuration.FormattingEnabled = true;
            this.cbEquiDuration.Items.AddRange(new object[] {
            "No Duration",
            "1 Hour",
            "2 Hours",
            "3 Hours",
            "5 Hours",
            "12 Hours",
            "1 Day",
            "2 Days",
            "7 Days",
            "15 Days",
            "30 Days",
            "60 Days",
            "90 Days",
            "180 Days",
            "365 Days"});
            this.cbEquiDuration.Location = new System.Drawing.Point(272, 147);
            this.cbEquiDuration.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiDuration.Name = "cbEquiDuration";
            this.cbEquiDuration.Size = new System.Drawing.Size(180, 25);
            this.cbEquiDuration.TabIndex = 20;
            // 
            // btAddEquipment
            // 
            this.btAddEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btAddEquipment.Location = new System.Drawing.Point(272, 409);
            this.btAddEquipment.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btAddEquipment.Name = "btAddEquipment";
            this.btAddEquipment.Size = new System.Drawing.Size(182, 72);
            this.btAddEquipment.TabIndex = 99;
            this.btAddEquipment.Text = "Add Equipment";
            this.btAddEquipment.UseVisualStyleBackColor = true;
            this.btAddEquipment.Click += new System.EventHandler(this.btAddEquipment_Click);
            // 
            // txEquiID
            // 
            this.txEquiID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txEquiID.Location = new System.Drawing.Point(72, 411);
            this.txEquiID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txEquiID.Name = "txEquiID";
            this.txEquiID.ReadOnly = true;
            this.txEquiID.Size = new System.Drawing.Size(91, 23);
            this.txEquiID.TabIndex = 25;
            this.txEquiID.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.lbEquiOpt);
            this.groupBox2.Controls.Add(this.lbEquiID);
            this.groupBox2.Controls.Add(this.txEquiOpt);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.rbBindNone);
            this.groupBox2.Controls.Add(this.rbBindCharUsed);
            this.groupBox2.Controls.Add(this.rbBindAcc);
            this.groupBox2.Controls.Add(this.rbBindCharNotUse);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cbEquiType);
            this.groupBox2.Controls.Add(this.txEquiID);
            this.groupBox2.Controls.Add(this.btAddEquipment);
            this.groupBox2.Controls.Add(this.cbEquiDuration);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.dupEquiSlot);
            this.groupBox2.Controls.Add(this.dupEquiUpgrade);
            this.groupBox2.Controls.Add(this.cbEquiClass);
            this.groupBox2.Controls.Add(this.cbEquiMaterial);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(297, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Size = new System.Drawing.Size(475, 511);
            this.groupBox2.TabIndex = 119;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Equipments";
            // 
            // lbEquiOpt
            // 
            this.lbEquiOpt.AutoSize = true;
            this.lbEquiOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbEquiOpt.Location = new System.Drawing.Point(165, 456);
            this.lbEquiOpt.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbEquiOpt.Name = "lbEquiOpt";
            this.lbEquiOpt.Size = new System.Drawing.Size(96, 17);
            this.lbEquiOpt.TabIndex = 38;
            this.lbEquiOpt.Text = "(0x00000000)";
            // 
            // lbEquiID
            // 
            this.lbEquiID.AutoSize = true;
            this.lbEquiID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbEquiID.Location = new System.Drawing.Point(165, 416);
            this.lbEquiID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbEquiID.Name = "lbEquiID";
            this.lbEquiID.Size = new System.Drawing.Size(96, 17);
            this.lbEquiID.TabIndex = 37;
            this.lbEquiID.Text = "(0x00000000)";
            // 
            // txEquiOpt
            // 
            this.txEquiOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txEquiOpt.Location = new System.Drawing.Point(72, 451);
            this.txEquiOpt.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txEquiOpt.Name = "txEquiOpt";
            this.txEquiOpt.ReadOnly = true;
            this.txEquiOpt.Size = new System.Drawing.Size(91, 23);
            this.txEquiOpt.TabIndex = 36;
            this.txEquiOpt.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbEquiOpt4);
            this.groupBox3.Controls.Add(this.cbEquiOptPro4);
            this.groupBox3.Controls.Add(this.cbEquiOpt3);
            this.groupBox3.Controls.Add(this.cbEquiOptPro3);
            this.groupBox3.Controls.Add(this.cbEquiOpt2);
            this.groupBox3.Controls.Add(this.cbEquiOptPro2);
            this.groupBox3.Controls.Add(this.cbEquiOpt1);
            this.groupBox3.Controls.Add(this.cbEquiOptPro1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(8, 189);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox3.Size = new System.Drawing.Size(459, 212);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Option(s)";
            // 
            // cbEquiOpt4
            // 
            this.cbEquiOpt4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiOpt4.FormattingEnabled = true;
            this.cbEquiOpt4.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbEquiOpt4.Location = new System.Drawing.Point(64, 160);
            this.cbEquiOpt4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiOpt4.Name = "cbEquiOpt4";
            this.cbEquiOpt4.Size = new System.Drawing.Size(180, 25);
            this.cbEquiOpt4.TabIndex = 15;
            this.cbEquiOpt4.SelectedIndexChanged += new System.EventHandler(this.cbEquiOpt4_SelectedIndexChanged);
            // 
            // cbEquiOptPro4
            // 
            this.cbEquiOptPro4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiOptPro4.FormattingEnabled = true;
            this.cbEquiOptPro4.Location = new System.Drawing.Point(264, 161);
            this.cbEquiOptPro4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiOptPro4.Name = "cbEquiOptPro4";
            this.cbEquiOptPro4.Size = new System.Drawing.Size(180, 25);
            this.cbEquiOptPro4.TabIndex = 16;
            this.cbEquiOptPro4.SelectedIndexChanged += new System.EventHandler(this.cbEquiOptPro_SelectedIndexChanged);
            // 
            // cbEquiOpt3
            // 
            this.cbEquiOpt3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiOpt3.FormattingEnabled = true;
            this.cbEquiOpt3.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbEquiOpt3.Location = new System.Drawing.Point(64, 119);
            this.cbEquiOpt3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiOpt3.Name = "cbEquiOpt3";
            this.cbEquiOpt3.Size = new System.Drawing.Size(180, 25);
            this.cbEquiOpt3.TabIndex = 13;
            this.cbEquiOpt3.SelectedIndexChanged += new System.EventHandler(this.cbEquiOpt3_SelectedIndexChanged);
            // 
            // cbEquiOptPro3
            // 
            this.cbEquiOptPro3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiOptPro3.FormattingEnabled = true;
            this.cbEquiOptPro3.Location = new System.Drawing.Point(264, 120);
            this.cbEquiOptPro3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiOptPro3.Name = "cbEquiOptPro3";
            this.cbEquiOptPro3.Size = new System.Drawing.Size(180, 25);
            this.cbEquiOptPro3.TabIndex = 14;
            this.cbEquiOptPro3.SelectedIndexChanged += new System.EventHandler(this.cbEquiOptPro_SelectedIndexChanged);
            // 
            // cbEquiOpt2
            // 
            this.cbEquiOpt2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiOpt2.FormattingEnabled = true;
            this.cbEquiOpt2.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbEquiOpt2.Location = new System.Drawing.Point(64, 77);
            this.cbEquiOpt2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiOpt2.Name = "cbEquiOpt2";
            this.cbEquiOpt2.Size = new System.Drawing.Size(180, 25);
            this.cbEquiOpt2.TabIndex = 11;
            this.cbEquiOpt2.SelectedIndexChanged += new System.EventHandler(this.cbEquiOpt2_SelectedIndexChanged);
            // 
            // cbEquiOptPro2
            // 
            this.cbEquiOptPro2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiOptPro2.FormattingEnabled = true;
            this.cbEquiOptPro2.Location = new System.Drawing.Point(264, 79);
            this.cbEquiOptPro2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiOptPro2.Name = "cbEquiOptPro2";
            this.cbEquiOptPro2.Size = new System.Drawing.Size(180, 25);
            this.cbEquiOptPro2.TabIndex = 12;
            this.cbEquiOptPro2.SelectedIndexChanged += new System.EventHandler(this.cbEquiOptPro_SelectedIndexChanged);
            // 
            // cbEquiOpt1
            // 
            this.cbEquiOpt1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiOpt1.Enabled = false;
            this.cbEquiOpt1.FormattingEnabled = true;
            this.cbEquiOpt1.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbEquiOpt1.Location = new System.Drawing.Point(64, 36);
            this.cbEquiOpt1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiOpt1.Name = "cbEquiOpt1";
            this.cbEquiOpt1.Size = new System.Drawing.Size(180, 25);
            this.cbEquiOpt1.TabIndex = 9;
            this.cbEquiOpt1.SelectedIndexChanged += new System.EventHandler(this.cbEquiOpt1_SelectedIndexChanged);
            // 
            // cbEquiOptPro1
            // 
            this.cbEquiOptPro1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiOptPro1.FormattingEnabled = true;
            this.cbEquiOptPro1.Location = new System.Drawing.Point(264, 37);
            this.cbEquiOptPro1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiOptPro1.Name = "cbEquiOptPro1";
            this.cbEquiOptPro1.Size = new System.Drawing.Size(180, 25);
            this.cbEquiOptPro1.TabIndex = 10;
            this.cbEquiOptPro1.SelectedIndexChanged += new System.EventHandler(this.cbEquiOptPro_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 167);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 17);
            this.label8.TabIndex = 37;
            this.label8.Text = "Opt 4:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 124);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 36;
            this.label7.Text = "Opt 3:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 35;
            this.label6.Text = "Opt 2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 41);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Opt 1:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(8, 116);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 17);
            this.label14.TabIndex = 33;
            this.label14.Text = "Binding:";
            // 
            // rbBindNone
            // 
            this.rbBindNone.AutoSize = true;
            this.rbBindNone.Checked = true;
            this.rbBindNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbBindNone.Location = new System.Drawing.Point(73, 112);
            this.rbBindNone.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbBindNone.Name = "rbBindNone";
            this.rbBindNone.Size = new System.Drawing.Size(67, 21);
            this.rbBindNone.TabIndex = 4;
            this.rbBindNone.TabStop = true;
            this.rbBindNone.Text = "None;";
            this.rbBindNone.UseVisualStyleBackColor = true;
            this.rbBindNone.CheckedChanged += new System.EventHandler(this.rbBind_CheckedChanged);
            // 
            // rbBindCharUsed
            // 
            this.rbBindCharUsed.AutoSize = true;
            this.rbBindCharUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbBindCharUsed.Location = new System.Drawing.Point(337, 112);
            this.rbBindCharUsed.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbBindCharUsed.Name = "rbBindCharUsed";
            this.rbBindCharUsed.Size = new System.Drawing.Size(122, 21);
            this.rbBindCharUsed.TabIndex = 7;
            this.rbBindCharUsed.Text = "Char (Unused)";
            this.rbBindCharUsed.UseVisualStyleBackColor = true;
            this.rbBindCharUsed.CheckedChanged += new System.EventHandler(this.rbBind_CheckedChanged);
            // 
            // rbBindAcc
            // 
            this.rbBindAcc.AutoSize = true;
            this.rbBindAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbBindAcc.Location = new System.Drawing.Point(151, 112);
            this.rbBindAcc.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbBindAcc.Name = "rbBindAcc";
            this.rbBindAcc.Size = new System.Drawing.Size(56, 21);
            this.rbBindAcc.TabIndex = 5;
            this.rbBindAcc.Text = "Acc;";
            this.rbBindAcc.UseVisualStyleBackColor = true;
            this.rbBindAcc.CheckedChanged += new System.EventHandler(this.rbBind_CheckedChanged);
            // 
            // rbBindCharNotUse
            // 
            this.rbBindCharNotUse.AutoSize = true;
            this.rbBindCharNotUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbBindCharNotUse.Location = new System.Drawing.Point(218, 112);
            this.rbBindCharNotUse.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbBindCharNotUse.Name = "rbBindCharNotUse";
            this.rbBindCharNotUse.Size = new System.Drawing.Size(110, 21);
            this.rbBindCharNotUse.TabIndex = 6;
            this.rbBindCharNotUse.Text = "Char (Used);";
            this.rbBindCharNotUse.UseVisualStyleBackColor = true;
            this.rbBindCharNotUse.CheckedChanged += new System.EventHandler(this.rbBind_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(14, 456);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 17);
            this.label13.TabIndex = 28;
            this.label13.Text = "Option:";
            // 
            // cbEquiType
            // 
            this.cbEquiType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquiType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbEquiType.FormattingEnabled = true;
            this.cbEquiType.Location = new System.Drawing.Point(272, 29);
            this.cbEquiType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbEquiType.Name = "cbEquiType";
            this.cbEquiType.Size = new System.Drawing.Size(180, 25);
            this.cbEquiType.TabIndex = 1;
            this.cbEquiType.SelectedIndexChanged += new System.EventHandler(this.cbEquiType_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Controls.Add(this.ckMultiOpt);
            this.groupBox4.Controls.Add(this.ckMultiId);
            this.groupBox4.Controls.Add(this.txtMultiOpt);
            this.groupBox4.Controls.Add(this.txtMultiId);
            this.groupBox4.Controls.Add(this.ckOnlineUser);
            this.groupBox4.Controls.Add(this.cbItemType);
            this.groupBox4.Controls.Add(this.txItemDesc);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.cbItemDuration);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.txtItemOpt);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtItemID);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.btAddItemToAll);
            this.groupBox4.Controls.Add(this.btAddItem);
            this.groupBox4.Controls.Add(this.txtItemAmount);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.cbItemName);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cbItemClass);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(297, 531);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox4.Size = new System.Drawing.Size(475, 341);
            this.groupBox4.TabIndex = 120;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Other Items";
            // 
            // ckMultiOpt
            // 
            this.ckMultiOpt.AutoSize = true;
            this.ckMultiOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ckMultiOpt.Location = new System.Drawing.Point(185, 257);
            this.ckMultiOpt.Name = "ckMultiOpt";
            this.ckMultiOpt.Size = new System.Drawing.Size(92, 21);
            this.ckMultiOpt.TabIndex = 54;
            this.ckMultiOpt.Text = "to Option:";
            this.ckMultiOpt.UseVisualStyleBackColor = true;
            this.ckMultiOpt.CheckedChanged += new System.EventHandler(this.ckMultiOpt_CheckedChanged);
            // 
            // ckMultiId
            // 
            this.ckMultiId.AutoSize = true;
            this.ckMultiId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ckMultiId.Location = new System.Drawing.Point(185, 223);
            this.ckMultiId.Name = "ckMultiId";
            this.ckMultiId.Size = new System.Drawing.Size(63, 21);
            this.ckMultiId.TabIndex = 53;
            this.ckMultiId.Text = "to ID:";
            this.ckMultiId.UseVisualStyleBackColor = true;
            this.ckMultiId.CheckedChanged += new System.EventHandler(this.ckMultiId_CheckedChanged);
            // 
            // txtMultiOpt
            // 
            this.txtMultiOpt.Enabled = false;
            this.txtMultiOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMultiOpt.Location = new System.Drawing.Point(298, 255);
            this.txtMultiOpt.Name = "txtMultiOpt";
            this.txtMultiOpt.Size = new System.Drawing.Size(105, 23);
            this.txtMultiOpt.TabIndex = 52;
            this.txtMultiOpt.Text = "0";
            // 
            // txtMultiId
            // 
            this.txtMultiId.Enabled = false;
            this.txtMultiId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMultiId.Location = new System.Drawing.Point(298, 221);
            this.txtMultiId.Name = "txtMultiId";
            this.txtMultiId.Size = new System.Drawing.Size(105, 23);
            this.txtMultiId.TabIndex = 49;
            this.txtMultiId.Text = "0";
            // 
            // ckOnlineUser
            // 
            this.ckOnlineUser.AutoSize = true;
            this.ckOnlineUser.Location = new System.Drawing.Point(343, 302);
            this.ckOnlineUser.Name = "ckOnlineUser";
            this.ckOnlineUser.Size = new System.Drawing.Size(116, 21);
            this.ckOnlineUser.TabIndex = 48;
            this.ckOnlineUser.Text = "Online User";
            this.ckOnlineUser.UseVisualStyleBackColor = true;
            this.ckOnlineUser.CheckedChanged += new System.EventHandler(this.ckOnlineUser_CheckedChanged);
            // 
            // cbItemType
            // 
            this.cbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.Location = new System.Drawing.Point(272, 21);
            this.cbItemType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(180, 25);
            this.cbItemType.TabIndex = 47;
            this.cbItemType.SelectedIndexChanged += new System.EventHandler(this.cbItemType_SelectedIndexChanged);
            // 
            // txItemDesc
            // 
            this.txItemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txItemDesc.Location = new System.Drawing.Point(72, 90);
            this.txItemDesc.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txItemDesc.Multiline = true;
            this.txItemDesc.Name = "txItemDesc";
            this.txItemDesc.ReadOnly = true;
            this.txItemDesc.Size = new System.Drawing.Size(380, 83);
            this.txItemDesc.TabIndex = 46;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(25, 95);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 17);
            this.label19.TabIndex = 45;
            this.label19.Text = "Desc:";
            // 
            // cbItemDuration
            // 
            this.cbItemDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbItemDuration.FormattingEnabled = true;
            this.cbItemDuration.Items.AddRange(new object[] {
            "No Duration",
            "1 Hour",
            "2 Hours",
            "3 Hours",
            "5 Hours",
            "12 Hours",
            "1 Day",
            "2 Days",
            "7 Days",
            "15 Days",
            "30 Days",
            "60 Days",
            "90 Days",
            "180 Days",
            "365 Days"});
            this.cbItemDuration.Location = new System.Drawing.Point(272, 186);
            this.cbItemDuration.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbItemDuration.Name = "cbItemDuration";
            this.cbItemDuration.Size = new System.Drawing.Size(180, 25);
            this.cbItemDuration.TabIndex = 43;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(209, 190);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 17);
            this.label18.TabIndex = 44;
            this.label18.Text = "Duration:";
            // 
            // txtItemOpt
            // 
            this.txtItemOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtItemOpt.Location = new System.Drawing.Point(72, 255);
            this.txtItemOpt.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtItemOpt.Name = "txtItemOpt";
            this.txtItemOpt.Size = new System.Drawing.Size(91, 23);
            this.txtItemOpt.TabIndex = 40;
            this.txtItemOpt.Text = "0";
            this.txtItemOpt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(22, 258);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 17);
            this.label16.TabIndex = 39;
            this.label16.Text = "Option:";
            // 
            // txtItemID
            // 
            this.txtItemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtItemID.Location = new System.Drawing.Point(72, 221);
            this.txtItemID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(91, 23);
            this.txtItemID.TabIndex = 38;
            this.txtItemID.Text = "0";
            this.txtItemID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(48, 224);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 17);
            this.label17.TabIndex = 37;
            this.label17.Text = "ID:";
            // 
            // btAddItemToAll
            // 
            this.btAddItemToAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btAddItemToAll.Location = new System.Drawing.Point(192, 293);
            this.btAddItemToAll.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btAddItemToAll.Name = "btAddItemToAll";
            this.btAddItemToAll.Size = new System.Drawing.Size(136, 37);
            this.btAddItemToAll.TabIndex = 28;
            this.btAddItemToAll.Text = "Add Item To All";
            this.btAddItemToAll.UseVisualStyleBackColor = true;
            this.btAddItemToAll.Click += new System.EventHandler(this.btAddItemToAll_Click);
            // 
            // btAddItem
            // 
            this.btAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btAddItem.Location = new System.Drawing.Point(57, 293);
            this.btAddItem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(106, 37);
            this.btAddItem.TabIndex = 28;
            this.btAddItem.Text = "Add Item";
            this.btAddItem.UseVisualStyleBackColor = true;
            this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
            // 
            // txtItemAmount
            // 
            this.txtItemAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtItemAmount.Location = new System.Drawing.Point(72, 187);
            this.txtItemAmount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtItemAmount.Name = "txtItemAmount";
            this.txtItemAmount.Size = new System.Drawing.Size(91, 23);
            this.txtItemAmount.TabIndex = 27;
            this.txtItemAmount.Text = "1";
            this.txtItemAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(10, 190);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 17);
            this.label15.TabIndex = 26;
            this.label15.Text = "Amount:";
            // 
            // cbItemName
            // 
            this.cbItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbItemName.FormattingEnabled = true;
            this.cbItemName.Location = new System.Drawing.Point(72, 56);
            this.cbItemName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbItemName.Name = "cbItemName";
            this.cbItemName.Size = new System.Drawing.Size(380, 25);
            this.cbItemName.TabIndex = 3;
            this.cbItemName.SelectedIndexChanged += new System.EventHandler(this.cbItemName_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(22, 62);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Name:";
            // 
            // cbItemClass
            // 
            this.cbItemClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbItemClass.FormattingEnabled = true;
            this.cbItemClass.Location = new System.Drawing.Point(72, 21);
            this.cbItemClass.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbItemClass.Name = "cbItemClass";
            this.cbItemClass.Size = new System.Drawing.Size(180, 25);
            this.cbItemClass.TabIndex = 1;
            this.cbItemClass.SelectedIndexChanged += new System.EventHandler(this.cbItemClass_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(26, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Type:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 139);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(282, 733);
            this.tabControl1.TabIndex = 121;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(274, 700);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pet Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox5.Controls.Add(this.txPetItemIdx);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.txPetSerial);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Controls.Add(this.txPetName);
            this.groupBox5.Controls.Add(this.txPetOpt);
            this.groupBox5.Controls.Add(this.txPetID);
            this.groupBox5.Controls.Add(this.cbPetSlot10);
            this.groupBox5.Controls.Add(this.label36);
            this.groupBox5.Controls.Add(this.cbPetSlot9);
            this.groupBox5.Controls.Add(this.cbPetSlot8);
            this.groupBox5.Controls.Add(this.cbPetSlot7);
            this.groupBox5.Controls.Add(this.cbPetSlot6);
            this.groupBox5.Controls.Add(this.cbPetSlot5);
            this.groupBox5.Controls.Add(this.cbPetSlot4);
            this.groupBox5.Controls.Add(this.cbPetSlot3);
            this.groupBox5.Controls.Add(this.cbPetSlot2);
            this.groupBox5.Controls.Add(this.cbPetSlot1);
            this.groupBox5.Controls.Add(this.dupPetLv);
            this.groupBox5.Controls.Add(this.cbPetName);
            this.groupBox5.Controls.Add(this.btUpdatePet);
            this.groupBox5.Controls.Add(this.label35);
            this.groupBox5.Controls.Add(this.label32);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox5.Location = new System.Drawing.Point(5, 5);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(270, 688);
            this.groupBox5.TabIndex = 124;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Pet";
            // 
            // txPetItemIdx
            // 
            this.txPetItemIdx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txPetItemIdx.Location = new System.Drawing.Point(208, 149);
            this.txPetItemIdx.Margin = new System.Windows.Forms.Padding(5);
            this.txPetItemIdx.Name = "txPetItemIdx";
            this.txPetItemIdx.ReadOnly = true;
            this.txPetItemIdx.Size = new System.Drawing.Size(55, 23);
            this.txPetItemIdx.TabIndex = 112;
            this.txPetItemIdx.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.Location = new System.Drawing.Point(155, 153);
            this.label20.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 17);
            this.label20.TabIndex = 111;
            this.label20.Text = "itemIdx:";
            // 
            // txPetSerial
            // 
            this.txPetSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txPetSerial.Location = new System.Drawing.Point(64, 108);
            this.txPetSerial.Margin = new System.Windows.Forms.Padding(5);
            this.txPetSerial.Name = "txPetSerial";
            this.txPetSerial.ReadOnly = true;
            this.txPetSerial.Size = new System.Drawing.Size(55, 23);
            this.txPetSerial.TabIndex = 99;
            this.txPetSerial.Text = "0";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label33.Location = new System.Drawing.Point(11, 111);
            this.label33.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(48, 17);
            this.label33.TabIndex = 110;
            this.label33.Text = "Serial:";
            // 
            // txPetName
            // 
            this.txPetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txPetName.Location = new System.Drawing.Point(64, 68);
            this.txPetName.Margin = new System.Windows.Forms.Padding(5);
            this.txPetName.Name = "txPetName";
            this.txPetName.Size = new System.Drawing.Size(199, 23);
            this.txPetName.TabIndex = 1;
            // 
            // txPetOpt
            // 
            this.txPetOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txPetOpt.Location = new System.Drawing.Point(64, 603);
            this.txPetOpt.Margin = new System.Windows.Forms.Padding(5);
            this.txPetOpt.Name = "txPetOpt";
            this.txPetOpt.ReadOnly = true;
            this.txPetOpt.Size = new System.Drawing.Size(199, 23);
            this.txPetOpt.TabIndex = 104;
            this.txPetOpt.Text = "0";
            // 
            // txPetID
            // 
            this.txPetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txPetID.Location = new System.Drawing.Point(208, 108);
            this.txPetID.Margin = new System.Windows.Forms.Padding(5);
            this.txPetID.Name = "txPetID";
            this.txPetID.ReadOnly = true;
            this.txPetID.Size = new System.Drawing.Size(55, 23);
            this.txPetID.TabIndex = 102;
            this.txPetID.Text = "0";
            // 
            // cbPetSlot10
            // 
            this.cbPetSlot10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPetSlot10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPetSlot10.FormattingEnabled = true;
            this.cbPetSlot10.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbPetSlot10.Location = new System.Drawing.Point(64, 563);
            this.cbPetSlot10.Margin = new System.Windows.Forms.Padding(5);
            this.cbPetSlot10.Name = "cbPetSlot10";
            this.cbPetSlot10.Size = new System.Drawing.Size(199, 25);
            this.cbPetSlot10.TabIndex = 12;
            this.cbPetSlot10.SelectedIndexChanged += new System.EventHandler(this.cbPetSlot_SelectedIndexChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label36.Location = new System.Drawing.Point(158, 111);
            this.label36.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(50, 17);
            this.label36.TabIndex = 101;
            this.label36.Text = "Pet ID:";
            // 
            // cbPetSlot9
            // 
            this.cbPetSlot9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPetSlot9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPetSlot9.FormattingEnabled = true;
            this.cbPetSlot9.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbPetSlot9.Location = new System.Drawing.Point(64, 520);
            this.cbPetSlot9.Margin = new System.Windows.Forms.Padding(5);
            this.cbPetSlot9.Name = "cbPetSlot9";
            this.cbPetSlot9.Size = new System.Drawing.Size(199, 25);
            this.cbPetSlot9.TabIndex = 11;
            this.cbPetSlot9.SelectedIndexChanged += new System.EventHandler(this.cbPetSlot_SelectedIndexChanged);
            // 
            // cbPetSlot8
            // 
            this.cbPetSlot8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPetSlot8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPetSlot8.FormattingEnabled = true;
            this.cbPetSlot8.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbPetSlot8.Location = new System.Drawing.Point(64, 477);
            this.cbPetSlot8.Margin = new System.Windows.Forms.Padding(5);
            this.cbPetSlot8.Name = "cbPetSlot8";
            this.cbPetSlot8.Size = new System.Drawing.Size(199, 25);
            this.cbPetSlot8.TabIndex = 10;
            this.cbPetSlot8.SelectedIndexChanged += new System.EventHandler(this.cbPetSlot_SelectedIndexChanged);
            // 
            // cbPetSlot7
            // 
            this.cbPetSlot7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPetSlot7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPetSlot7.FormattingEnabled = true;
            this.cbPetSlot7.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbPetSlot7.Location = new System.Drawing.Point(64, 437);
            this.cbPetSlot7.Margin = new System.Windows.Forms.Padding(5);
            this.cbPetSlot7.Name = "cbPetSlot7";
            this.cbPetSlot7.Size = new System.Drawing.Size(199, 25);
            this.cbPetSlot7.TabIndex = 9;
            this.cbPetSlot7.SelectedIndexChanged += new System.EventHandler(this.cbPetSlot_SelectedIndexChanged);
            // 
            // cbPetSlot6
            // 
            this.cbPetSlot6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPetSlot6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPetSlot6.FormattingEnabled = true;
            this.cbPetSlot6.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbPetSlot6.Location = new System.Drawing.Point(64, 395);
            this.cbPetSlot6.Margin = new System.Windows.Forms.Padding(5);
            this.cbPetSlot6.Name = "cbPetSlot6";
            this.cbPetSlot6.Size = new System.Drawing.Size(199, 25);
            this.cbPetSlot6.TabIndex = 8;
            this.cbPetSlot6.SelectedIndexChanged += new System.EventHandler(this.cbPetSlot_SelectedIndexChanged);
            // 
            // cbPetSlot5
            // 
            this.cbPetSlot5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPetSlot5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPetSlot5.FormattingEnabled = true;
            this.cbPetSlot5.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbPetSlot5.Location = new System.Drawing.Point(64, 355);
            this.cbPetSlot5.Margin = new System.Windows.Forms.Padding(5);
            this.cbPetSlot5.Name = "cbPetSlot5";
            this.cbPetSlot5.Size = new System.Drawing.Size(199, 25);
            this.cbPetSlot5.TabIndex = 7;
            this.cbPetSlot5.SelectedIndexChanged += new System.EventHandler(this.cbPetSlot_SelectedIndexChanged);
            // 
            // cbPetSlot4
            // 
            this.cbPetSlot4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPetSlot4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPetSlot4.FormattingEnabled = true;
            this.cbPetSlot4.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbPetSlot4.Location = new System.Drawing.Point(64, 312);
            this.cbPetSlot4.Margin = new System.Windows.Forms.Padding(5);
            this.cbPetSlot4.Name = "cbPetSlot4";
            this.cbPetSlot4.Size = new System.Drawing.Size(199, 25);
            this.cbPetSlot4.TabIndex = 6;
            this.cbPetSlot4.SelectedIndexChanged += new System.EventHandler(this.cbPetSlot_SelectedIndexChanged);
            // 
            // cbPetSlot3
            // 
            this.cbPetSlot3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPetSlot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPetSlot3.FormattingEnabled = true;
            this.cbPetSlot3.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbPetSlot3.Location = new System.Drawing.Point(64, 271);
            this.cbPetSlot3.Margin = new System.Windows.Forms.Padding(5);
            this.cbPetSlot3.Name = "cbPetSlot3";
            this.cbPetSlot3.Size = new System.Drawing.Size(199, 25);
            this.cbPetSlot3.TabIndex = 5;
            this.cbPetSlot3.SelectedIndexChanged += new System.EventHandler(this.cbPetSlot_SelectedIndexChanged);
            // 
            // cbPetSlot2
            // 
            this.cbPetSlot2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPetSlot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPetSlot2.FormattingEnabled = true;
            this.cbPetSlot2.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbPetSlot2.Location = new System.Drawing.Point(64, 229);
            this.cbPetSlot2.Margin = new System.Windows.Forms.Padding(5);
            this.cbPetSlot2.Name = "cbPetSlot2";
            this.cbPetSlot2.Size = new System.Drawing.Size(199, 25);
            this.cbPetSlot2.TabIndex = 4;
            this.cbPetSlot2.SelectedIndexChanged += new System.EventHandler(this.cbPetSlot_SelectedIndexChanged);
            // 
            // cbPetSlot1
            // 
            this.cbPetSlot1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPetSlot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPetSlot1.FormattingEnabled = true;
            this.cbPetSlot1.Items.AddRange(new object[] {
            "Slot",
            "Craft Level 1",
            "Craft Level 2",
            "Craft Level 3",
            "Craft Level 4",
            "Craft Level 5",
            "Craft Level 6",
            "Craft Level 7 (Max)"});
            this.cbPetSlot1.Location = new System.Drawing.Point(64, 188);
            this.cbPetSlot1.Margin = new System.Windows.Forms.Padding(5);
            this.cbPetSlot1.Name = "cbPetSlot1";
            this.cbPetSlot1.Size = new System.Drawing.Size(199, 25);
            this.cbPetSlot1.TabIndex = 3;
            this.cbPetSlot1.SelectedIndexChanged += new System.EventHandler(this.cbPetSlot_SelectedIndexChanged);
            // 
            // dupPetLv
            // 
            this.dupPetLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dupPetLv.Items.Add("10");
            this.dupPetLv.Items.Add("9");
            this.dupPetLv.Items.Add("8");
            this.dupPetLv.Items.Add("7");
            this.dupPetLv.Items.Add("6");
            this.dupPetLv.Items.Add("5");
            this.dupPetLv.Items.Add("4");
            this.dupPetLv.Items.Add("3");
            this.dupPetLv.Items.Add("2");
            this.dupPetLv.Items.Add("1");
            this.dupPetLv.Location = new System.Drawing.Point(64, 149);
            this.dupPetLv.Margin = new System.Windows.Forms.Padding(5);
            this.dupPetLv.Name = "dupPetLv";
            this.dupPetLv.ReadOnly = true;
            this.dupPetLv.Size = new System.Drawing.Size(56, 23);
            this.dupPetLv.TabIndex = 2;
            this.dupPetLv.Text = "10";
            this.dupPetLv.SelectedItemChanged += new System.EventHandler(this.dupPetLv_SelectedItemChanged);
            // 
            // cbPetName
            // 
            this.cbPetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPetName.FormattingEnabled = true;
            this.cbPetName.Location = new System.Drawing.Point(64, 27);
            this.cbPetName.Margin = new System.Windows.Forms.Padding(5);
            this.cbPetName.Name = "cbPetName";
            this.cbPetName.Size = new System.Drawing.Size(199, 25);
            this.cbPetName.TabIndex = 0;
            this.cbPetName.SelectedIndexChanged += new System.EventHandler(this.cbPetName_SelectedIndexChanged);
            // 
            // btUpdatePet
            // 
            this.btUpdatePet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btUpdatePet.Location = new System.Drawing.Point(155, 643);
            this.btUpdatePet.Margin = new System.Windows.Forms.Padding(5);
            this.btUpdatePet.Name = "btUpdatePet";
            this.btUpdatePet.Size = new System.Drawing.Size(104, 35);
            this.btUpdatePet.TabIndex = 15;
            this.btUpdatePet.Text = "Update Pet";
            this.btUpdatePet.UseVisualStyleBackColor = true;
            this.btUpdatePet.Click += new System.EventHandler(this.btUpdatePet_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label35.Location = new System.Drawing.Point(5, 605);
            this.label35.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(54, 17);
            this.label35.TabIndex = 103;
            this.label35.Text = "Option:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label32.Location = new System.Drawing.Point(8, 29);
            this.label32.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(51, 17);
            this.label32.TabIndex = 100;
            this.label32.Text = "Select:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label27.Location = new System.Drawing.Point(3, 565);
            this.label27.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 17);
            this.label27.TabIndex = 54;
            this.label27.Text = "Slot 10:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label28.Location = new System.Drawing.Point(11, 524);
            this.label28.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 17);
            this.label28.TabIndex = 52;
            this.label28.Text = "Slot 9:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label29.Location = new System.Drawing.Point(11, 483);
            this.label29.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(48, 17);
            this.label29.TabIndex = 50;
            this.label29.Text = "Slot 8:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label30.Location = new System.Drawing.Point(11, 441);
            this.label30.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(48, 17);
            this.label30.TabIndex = 48;
            this.label30.Text = "Slot 7:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label31.Location = new System.Drawing.Point(11, 400);
            this.label31.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 17);
            this.label31.TabIndex = 46;
            this.label31.Text = "Slot 6:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label26.Location = new System.Drawing.Point(11, 357);
            this.label26.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 17);
            this.label26.TabIndex = 44;
            this.label26.Text = "Slot 5:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label25.Location = new System.Drawing.Point(11, 316);
            this.label25.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 17);
            this.label25.TabIndex = 42;
            this.label25.Text = "Slot 4:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label24.Location = new System.Drawing.Point(11, 275);
            this.label24.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 17);
            this.label24.TabIndex = 40;
            this.label24.Text = "Slot 3:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.Location = new System.Drawing.Point(11, 233);
            this.label23.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 17);
            this.label23.TabIndex = 38;
            this.label23.Text = "Slot 2:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label22.Location = new System.Drawing.Point(11, 192);
            this.label22.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 17);
            this.label22.TabIndex = 36;
            this.label22.Text = "Slot 1:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(13, 153);
            this.label21.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 17);
            this.label21.TabIndex = 9;
            this.label21.Text = "Level:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label34.Location = new System.Drawing.Point(10, 72);
            this.label34.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(49, 17);
            this.label34.TabIndex = 2;
            this.label34.Text = "Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ckMailToAll);
            this.tabPage2.Controls.Add(this.txtMailAlz);
            this.tabPage2.Controls.Add(this.cbItemMailDuration);
            this.tabPage2.Controls.Add(this.label41);
            this.tabPage2.Controls.Add(this.label40);
            this.tabPage2.Controls.Add(this.label44);
            this.tabPage2.Controls.Add(this.label39);
            this.tabPage2.Controls.Add(this.label43);
            this.tabPage2.Controls.Add(this.txtMailItemOpt);
            this.tabPage2.Controls.Add(this.txtMailItem);
            this.tabPage2.Controls.Add(this.txtMailId);
            this.tabPage2.Controls.Add(this.btnMailSend);
            this.tabPage2.Controls.Add(this.txtMailCnt);
            this.tabPage2.Controls.Add(this.txtMailTtl);
            this.tabPage2.Controls.Add(this.label38);
            this.tabPage2.Controls.Add(this.label37);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(274, 700);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Send Mail";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ckMailToAll
            // 
            this.ckMailToAll.AutoSize = true;
            this.ckMailToAll.Location = new System.Drawing.Point(117, 363);
            this.ckMailToAll.Name = "ckMailToAll";
            this.ckMailToAll.Size = new System.Drawing.Size(102, 24);
            this.ckMailToAll.TabIndex = 45;
            this.ckMailToAll.Text = "To All User";
            this.ckMailToAll.UseVisualStyleBackColor = true;
            this.ckMailToAll.CheckedChanged += new System.EventHandler(this.ckMailToAll_CheckedChanged);
            // 
            // txtMailAlz
            // 
            this.txtMailAlz.Location = new System.Drawing.Point(118, 404);
            this.txtMailAlz.Name = "txtMailAlz";
            this.txtMailAlz.Size = new System.Drawing.Size(153, 27);
            this.txtMailAlz.TabIndex = 5;
            this.txtMailAlz.Text = "0";
            this.txtMailAlz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMailAlz_KeyPress);
            // 
            // cbItemMailDuration
            // 
            this.cbItemMailDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemMailDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbItemMailDuration.FormattingEnabled = true;
            this.cbItemMailDuration.Items.AddRange(new object[] {
            "No Duration",
            "1 Hour",
            "2 Hours",
            "3 Hours",
            "5 Hours",
            "12 Hours",
            "1 Day",
            "2 Days",
            "7 Days",
            "15 Days",
            "30 Days",
            "60 Days",
            "90 Days",
            "180 Days",
            "365 Days"});
            this.cbItemMailDuration.Location = new System.Drawing.Point(118, 549);
            this.cbItemMailDuration.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbItemMailDuration.Name = "cbItemMailDuration";
            this.cbItemMailDuration.Size = new System.Drawing.Size(150, 25);
            this.cbItemMailDuration.TabIndex = 8;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(7, 501);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(104, 20);
            this.label41.TabIndex = 44;
            this.label41.Text = "Item opt send:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(17, 455);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(94, 20);
            this.label40.TabIndex = 44;
            this.label40.Text = "Item Id send:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(27, 319);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(82, 20);
            this.label44.TabIndex = 44;
            this.label44.Text = "Send to ID:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(43, 407);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(68, 20);
            this.label39.TabIndex = 44;
            this.label39.Text = "Alz send:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label43.Location = new System.Drawing.Point(43, 555);
            this.label43.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(66, 17);
            this.label43.TabIndex = 44;
            this.label43.Text = "Duration:";
            // 
            // txtMailItemOpt
            // 
            this.txtMailItemOpt.Location = new System.Drawing.Point(119, 499);
            this.txtMailItemOpt.Name = "txtMailItemOpt";
            this.txtMailItemOpt.Size = new System.Drawing.Size(153, 27);
            this.txtMailItemOpt.TabIndex = 7;
            this.txtMailItemOpt.Text = "0";
            // 
            // txtMailItem
            // 
            this.txtMailItem.Location = new System.Drawing.Point(119, 452);
            this.txtMailItem.Name = "txtMailItem";
            this.txtMailItem.Size = new System.Drawing.Size(153, 27);
            this.txtMailItem.TabIndex = 6;
            this.txtMailItem.Text = "0";
            // 
            // txtMailId
            // 
            this.txtMailId.Location = new System.Drawing.Point(117, 316);
            this.txtMailId.Name = "txtMailId";
            this.txtMailId.Size = new System.Drawing.Size(153, 27);
            this.txtMailId.TabIndex = 4;
            // 
            // btnMailSend
            // 
            this.btnMailSend.Location = new System.Drawing.Point(152, 633);
            this.btnMailSend.Name = "btnMailSend";
            this.btnMailSend.Size = new System.Drawing.Size(117, 61);
            this.btnMailSend.TabIndex = 9;
            this.btnMailSend.Text = "Send mail";
            this.btnMailSend.UseVisualStyleBackColor = true;
            this.btnMailSend.Click += new System.EventHandler(this.btnMailSend_Click);
            // 
            // txtMailCnt
            // 
            this.txtMailCnt.Location = new System.Drawing.Point(11, 117);
            this.txtMailCnt.Multiline = true;
            this.txtMailCnt.Name = "txtMailCnt";
            this.txtMailCnt.Size = new System.Drawing.Size(257, 176);
            this.txtMailCnt.TabIndex = 3;
            // 
            // txtMailTtl
            // 
            this.txtMailTtl.Location = new System.Drawing.Point(11, 36);
            this.txtMailTtl.Name = "txtMailTtl";
            this.txtMailTtl.Size = new System.Drawing.Size(257, 27);
            this.txtMailTtl.TabIndex = 2;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(11, 89);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(97, 20);
            this.label38.TabIndex = 1;
            this.label38.Text = "Mail Content:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(11, 13);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(74, 20);
            this.label37.TabIndex = 0;
            this.label37.Text = "Mail Title:";
            // 
            // FUC_CharacterAddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FUC_CharacterAddItem";
            this.Size = new System.Drawing.Size(782, 877);
            this.Load += new System.EventHandler(this.FUC_CharacterAddItem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

    }

    public static implicit operator FUC_CharacterAddItem(CabalGM1.FUC_CharacterAddItem v)
    {
        throw new NotImplementedException();
    }
    private Button btAddItemToAll;
    private CheckBox ckOnlineUser;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private GroupBox groupBox5;
    private TextBox txPetItemIdx;
    private Label label20;
    private TextBox txPetSerial;
    private Label label33;
    private TextBox txPetName;
    private TextBox txPetOpt;
    private TextBox txPetID;
    private ComboBox cbPetSlot10;
    private Label label36;
    private ComboBox cbPetSlot9;
    private ComboBox cbPetSlot8;
    private ComboBox cbPetSlot7;
    private ComboBox cbPetSlot6;
    private ComboBox cbPetSlot5;
    private ComboBox cbPetSlot4;
    private ComboBox cbPetSlot3;
    private ComboBox cbPetSlot2;
    private ComboBox cbPetSlot1;
    private DomainUpDown dupPetLv;
    private ComboBox cbPetName;
    private Button btUpdatePet;
    private Label label35;
    private Label label32;
    private Label label27;
    private Label label28;
    private Label label29;
    private Label label30;
    private Label label31;
    private Label label26;
    private Label label25;
    private Label label24;
    private Label label23;
    private Label label22;
    private Label label21;
    private Label label34;
    private TabPage tabPage2;
    private TextBox txtMailCnt;
    private TextBox txtMailTtl;
    private Label label38;
    private Label label37;
    private Button btnMailSend;
    private ComboBox cbItemMailDuration;
    private Label label42;
    private Label label41;
    private Label label40;
    private Label label39;
    private Label label43;
    private TextBox txtMailItemOpt;
    private TextBox txtMailItem;
    private Label label44;
    private TextBox txtMailId;
    private MaskedTextBox txtMailAlz;
    private CheckBox ckMailToAll;
    private TextBox txtMultiOpt;
    private TextBox txtMultiId;
    private CheckBox ckMultiOpt;
    private CheckBox ckMultiId;
}
