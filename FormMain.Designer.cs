using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CabalGM1;

public partial class FormMain : Form
{
    private IContainer components = null;

    private StatusStrip statusStrip1;

    private ToolStripStatusLabel tsConStatLabel;

    private MenuStrip menuStrip1;

    private ToolStripMenuItem fileToolStripMenuItem;

    private ToolStripSeparator toolStripMenuItem2;

    private ToolStripMenuItem exitToolStripMenuItem;

    private ToolStripMenuItem connectionToolStripMenuItem;

    private ToolStripMenuItem aboutToolStripMenuItem;

    private ToolStripSeparator toolStripMenuItem1;

    private ToolStripMenuItem helpToolStripMenuItem;

    private ToolStripMenuItem sQLConnectionToolStripMenuItem;

    private ToolStripMenuItem newAccountToolStripMenuItem;

    private ToolStripMenuItem setGMIPToolStripMenuItem;

    private TabControl tabControl1;

    private TabPage tabPage1;

    private TabPage tabPage2;

    private TabPage tabPage3;

    private FUC_CharacterInfo fuc_CharacterInfo1;

    private TabControl tabControl2;

    private TabPage tabPage4;

    private TabPage tabPage5;

    private FUC_CharacterAddItem fUC_CharacterAddItem;

    private FUC_CharacterEquipment fuC_CharacterEquipment;

    private ToolStripMenuItem VersionChangesToolStripMenuItem;

    private ToolStripMenuItem aboutToolStripMenuItem1;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsConStatLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGMIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.fUC_CharacterAddItem = new FUC_CharacterAddItem();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.fuC_CharacterEquipment = new FUC_CharacterEquipment();
            this.fuc_CharacterInfo1 = new FUC_CharacterInfo();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsConStatLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 736);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1043, 22);
            this.statusStrip1.TabIndex = 308;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsConStatLabel
            // 
            this.tsConStatLabel.ForeColor = System.Drawing.Color.Red;
            this.tsConStatLabel.Name = "tsConStatLabel";
            this.tsConStatLabel.Size = new System.Drawing.Size(79, 17);
            this.tsConStatLabel.Text = "Disconnected";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1043, 24);
            this.menuStrip1.TabIndex = 309;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sQLConnectionToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // sQLConnectionToolStripMenuItem
            // 
            this.sQLConnectionToolStripMenuItem.Name = "sQLConnectionToolStripMenuItem";
            this.sQLConnectionToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.sQLConnectionToolStripMenuItem.Text = "Connect Database";
            this.sQLConnectionToolStripMenuItem.Click += new System.EventHandler(this.sQLConnectionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAccountToolStripMenuItem,
            this.setGMIPToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.connectionToolStripMenuItem.Text = "&Tool";
            // 
            // newAccountToolStripMenuItem
            // 
            this.newAccountToolStripMenuItem.Name = "newAccountToolStripMenuItem";
            this.newAccountToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newAccountToolStripMenuItem.Text = "New Account";
            this.newAccountToolStripMenuItem.Click += new System.EventHandler(this.newAccountToolStripMenuItem_Click);
            // 
            // setGMIPToolStripMenuItem
            // 
            this.setGMIPToolStripMenuItem.Name = "setGMIPToolStripMenuItem";
            this.setGMIPToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.setGMIPToolStripMenuItem.Text = "Set GM IP";
            this.setGMIPToolStripMenuItem.Click += new System.EventHandler(this.setGMIPToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.VersionChangesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.helpToolStripMenuItem.Text = "&View Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // VersionChangesToolStripMenuItem
            // 
            this.VersionChangesToolStripMenuItem.Name = "VersionChangesToolStripMenuItem";
            this.VersionChangesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.VersionChangesToolStripMenuItem.Text = "&Version Changes";
            this.VersionChangesToolStripMenuItem.Click += new System.EventHandler(this.VersionChangesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.aboutToolStripMenuItem1.Text = "&About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 26);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1056, 739);
            this.tabControl1.TabIndex = 310;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.fuc_CharacterInfo1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1048, 711);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Account & Character";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(336, 4);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(690, 698);
            this.tabControl2.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.fUC_CharacterAddItem);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(682, 670);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Add Items";
            // 
            // fuC_CharacterSkill1
            // 
            this.fUC_CharacterAddItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fUC_CharacterAddItem.Location = new System.Drawing.Point(0, 0);
            this.fUC_CharacterAddItem.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fUC_CharacterAddItem.Name = "fuC_CharacterSkill1";
            this.fUC_CharacterAddItem.Size = new System.Drawing.Size(678, 662);
            this.fUC_CharacterAddItem.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.fuC_CharacterEquipment);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage5.Size = new System.Drawing.Size(192, 72);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Equiment";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // fuC_CharacterEquipment
            // 
            this.fuC_CharacterEquipment.Location = new System.Drawing.Point(0, 0);
            this.fuC_CharacterEquipment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fuC_CharacterEquipment.Name = "fuC_CharacterEquipment";
            this.fuC_CharacterEquipment.Size = new System.Drawing.Size(678, 660);
            this.fuC_CharacterEquipment.TabIndex = 0;
            // 
            // fuc_CharacterInfo1
            // 
            this.fuc_CharacterInfo1.Location = new System.Drawing.Point(4, 10);
            this.fuc_CharacterInfo1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fuc_CharacterInfo1.Name = "fuc_CharacterInfo1";
            this.fuc_CharacterInfo1.Size = new System.Drawing.Size(325, 688);
            this.fuc_CharacterInfo1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1048, 711);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "System Control";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1048, 711);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Skill";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 758);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void FormMain_Load(object sender, EventArgs e)
    {
        loadConfig();
        testConnection();
    }

    private void loadConfig()
    {
        if (!File.Exists("ConfigConnection.ini"))
        {
            return;
        }
        TextReader textReader = new StreamReader("ConfigConnection.ini");
        for (string text = textReader.ReadLine(); text != null; text = textReader.ReadLine())
        {
            if (text.Length > 1 && text.Substring(1, 1) != ";")
            {
                string[] array = new string[13];
                array = text.Split(":".ToCharArray());
                switch (array[0])
                {
                    case "SQLServerIP":
                        GlobalClass.SQLServerIP = array[1];
                        break;
                    case "SQLPort":
                        GlobalClass.SQLPort = array[1];
                        break;
                    case "SQLUser":
                        GlobalClass.SQLUser = array[1];
                        break;
                    case "SQLPass":
                        GlobalClass.SQLPass = array[1];
                        break;
                    case "SQLAccountDB":
                        GlobalClass.SQLAccountDB = array[1];
                        break;
                    case "SQLAuthDB":
                        GlobalClass.SQlAuthDB = array[1];
                        break;
                    case "SQLCabalCashDB":
                        GlobalClass.SQLCabalCashDB = array[1];
                        break;
                    case "SQLCashShopDB":
                        GlobalClass.SQLCashShopDB = array[1];
                        break;
                    case "SQLCabalGuildDB":
                        GlobalClass.SQLCabalGuildDB = array[1];
                        break;
                    case "SQLManagerDB":
                        GlobalClass.SQLManagerDB = array[1];
                        break;
                    case "SQLEventDataDB":
                        GlobalClass.SQLEventDataDB = array[1];
                        break;
                    case "SQLNetCafeDB":
                        GlobalClass.SQLNetCafeDB = array[1];
                        break;
                    case "SQLGameDB":
                        GlobalClass.SQLGameDB = array[1];
                        break;
                    case "GAMESERVER":
                        GlobalClass.gServerIp = array[1];
                        break;
                    case "GAMEPORT":
                        GlobalClass.gServPort = Convert.ToInt32(array[1]);
                        break;
                    case "GAMEUSER":
                        GlobalClass.gServerUser = array[1];
                        break;
                    case "GAMEPASS":
                        GlobalClass.gServUPass = array[1];
                        break;
                }
            }
        }
        textReader.Close();
    }

    private void testConnection()
    {
        FormConnection formConnection = new FormConnection();
        formConnection.ShowInTaskbar = true;
        formConnection.ShowDialog();
        tsConStatLabel.ForeColor = Color.Blue;
        tsConStatLabel.Text = "Server Connection Successful - " + GlobalClass.SQLServerIP + ":" + GlobalClass.SQLPort;
        loadListServer();
    }

    private void loadListServer()
    {
        if (GlobalClass.DBConnected)
        {
            ArrayList arrayList = new ArrayList();
            string query = "SELECT * FROM ServerList WHERE Enabled = 1";
            GlobalClass.ListServer = UtilityDatabase.selectQuery(GlobalClass.SQLAccountDB, query);
        }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void sQLConnectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FormConnection formConnection = new FormConnection();
        formConnection.ShowDialog();
    }

    private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FormAccount formAccount = new FormAccount();
        formAccount.ShowDialog();
    }

    private void setGMIPToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FormGM formGM = new FormGM();
        formGM.ShowDialog();
    }

    public void loadCharacterEquipment()
    {
        fUC_CharacterAddItem.loadEquipment();
        fuC_CharacterEquipment.loadEquipment();
    }
    public void loadCharacterInventory()
    {
        fuC_CharacterEquipment.loadInventory();
    }
    public void loadCharacterWarehouse()
    {
        fuC_CharacterEquipment.loadWarehouse();
    }

    public void loadCharacterTitle()
    {
        fuC_CharacterEquipment.loadTitle();
    }

    public void loadCharacterSkill()
    {
        fuC_CharacterEquipment.loadSkill();
    }

    private void VersionChangesToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        new FormAbout().ShowDialog();
    }

    private void helpToolStripMenuItem_Click(object sender, EventArgs e)
    {
        new FormHelp().Show();
    }
}
