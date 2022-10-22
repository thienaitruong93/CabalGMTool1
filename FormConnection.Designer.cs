using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CabalGM1;

public partial class FormConnection : Form
{
    private IContainer components = null;

    private Label label1;

    private TextBox txIPAddress;

    private Label label2;

    private TextBox txPort;

    private Label label3;

    private TextBox txPassword;

    private Label label4;

    private TextBox txUserName;

    private Label label5;

    private Label label6;

    private TextBox txAccount;

    private Label label7;

    private TextBox txAuthentication;

    private Label label8;

    private TextBox txCabalCash;

    private Label label9;

    private TextBox txCabalGuild;

    private Label label10;

    private TextBox txGameDB;

    private Label label11;

    private TextBox txNetCafe;

    private Label label12;

    private TextBox txEventData;

    private Label label13;

    private TextBox txCabalManager;

    private Label label14;

    private Panel panel1;

    private Button bnConnect;

    private Button btExit;

    private TextBox txCashShop;

    private Label label15;

    private PictureBox pictureBox1;

    private Panel panel2;

    private Panel panel3;


    private void bnConnect_Click(object sender, EventArgs e)
    {
        saveConfigConnection();
        
        if (UtilityDatabase.testConnection())
        {
            Close();
        }
    }

    private void saveConfigConnection()
    {
        try
        {
            string[] array = new string[17];
            GlobalClass.SQLServerIP = txIPAddress.Text;
            array[0] = "SQLServerIP:" + GlobalClass.SQLServerIP;
            GlobalClass.SQLPort = txPort.Text;
            array[1] = "SQLPort:" + GlobalClass.SQLPort;
            GlobalClass.SQLUser = txUserName.Text;
            array[2] = "SQLUser:" + GlobalClass.SQLUser;
            GlobalClass.SQLPass = txPassword.Text;
            array[3] = "SQLPass:" + GlobalClass.SQLPass;
            GlobalClass.SQLAccountDB = txAccount.Text;
            array[4] = "SQLAccountDB:" + GlobalClass.SQLAccountDB;
            GlobalClass.SQlAuthDB = txAuthentication.Text;
            array[5] = "SQLAuthDB:" + GlobalClass.SQlAuthDB;
            GlobalClass.SQLCabalCashDB = txCabalCash.Text;
            array[6] = "SQLCabalCashDB:" + GlobalClass.SQLCabalCashDB;
            GlobalClass.SQLCashShopDB = txCashShop.Text;
            array[7] = "SQLCashShopDB:" + GlobalClass.SQLCashShopDB;
            GlobalClass.SQLCabalGuildDB = txCabalGuild.Text;
            array[8] = "SQLCabalGuildDB:" + GlobalClass.SQLCabalGuildDB;
            GlobalClass.SQLManagerDB = txCabalManager.Text;
            array[9] = "SQLManagerDB:" + GlobalClass.SQLManagerDB;
            GlobalClass.SQLEventDataDB = txEventData.Text;
            array[10] = "SQLEventDataDB:" + GlobalClass.SQLEventDataDB;
            GlobalClass.SQLNetCafeDB = txNetCafe.Text;
            array[11] = "SQLNetCafeDB:" + GlobalClass.SQLNetCafeDB;
            GlobalClass.SQLGameDB = txGameDB.Text;
            array[12] = "SQLGameDB:" + GlobalClass.SQLGameDB;
            GlobalClass.gServerIp = "";
            array[13] = "GAMESERVER:" + GlobalClass.gServerIp;
            GlobalClass.gServPort = 0;
            array[14] = "GAMEPORT:" + Convert.ToString(GlobalClass.gServPort);
            GlobalClass.gServerUser = "";
            array[15] = "GAMEUSER:" + GlobalClass.gServerUser;
            GlobalClass.gServUPass = "";
            array[16] = "GAMEPASS:" + GlobalClass.gServUPass;
            using StreamWriter streamWriter = new StreamWriter("ConfigConnection.ini", append: false);
            string[] array2 = array;
            foreach (string value in array2)
            {
                streamWriter.WriteLine(value);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error Creating ConfigConnection.ini file. \r\n \r\n" + ex.Message.ToString(), "Config.ini error");
        }
    }

    private void btExit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void FormConnection_Load(object sender, EventArgs e)
    {
        txIPAddress.Text = GlobalClass.SQLServerIP;
        txPort.Text = GlobalClass.SQLPort;
        txUserName.Text = GlobalClass.SQLUser;
        txPassword.Text = GlobalClass.SQLPass;
        txAccount.Text = GlobalClass.SQLAccountDB;
        txAuthentication.Text = GlobalClass.SQlAuthDB;
        txCabalCash.Text = GlobalClass.SQLCabalCashDB;
        txCashShop.Text = GlobalClass.SQLCashShopDB;
        txCabalGuild.Text = GlobalClass.SQLCabalGuildDB;
        txCabalManager.Text = GlobalClass.SQLManagerDB;
        txEventData.Text = GlobalClass.SQLEventDataDB;
        txNetCafe.Text = GlobalClass.SQLNetCafeDB;
        txGameDB.Text = GlobalClass.SQLGameDB;
        Text = GlobalClass.appName + " Database Connection ";
    }

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
            this.label1 = new System.Windows.Forms.Label();
            this.txIPAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txAccount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txAuthentication = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txCabalCash = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txCabalGuild = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txGameDB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txNetCafe = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txEventData = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txCabalManager = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExit = new System.Windows.Forms.Button();
            this.bnConnect = new System.Windows.Forms.Button();
            this.txCashShop = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Address:";
            // 
            // txIPAddress
            // 
            this.txIPAddress.Location = new System.Drawing.Point(428, 58);
            this.txIPAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txIPAddress.Name = "txIPAddress";
            this.txIPAddress.Size = new System.Drawing.Size(132, 27);
            this.txIPAddress.TabIndex = 1;
            this.txIPAddress.Text = "192.168.1.200";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(324, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server Information";
            // 
            // txPort
            // 
            this.txPort.Location = new System.Drawing.Point(707, 58);
            this.txPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txPort.Name = "txPort";
            this.txPort.Size = new System.Drawing.Size(132, 27);
            this.txPort.TabIndex = 5;
            this.txPort.Text = "1433";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(660, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port:";
            // 
            // txPassword
            // 
            this.txPassword.Location = new System.Drawing.Point(707, 112);
            this.txPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txPassword.Name = "txPassword";
            this.txPassword.Size = new System.Drawing.Size(132, 27);
            this.txPassword.TabIndex = 9;
            this.txPassword.Text = "123456";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(624, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password:";
            // 
            // txUserName
            // 
            this.txUserName.Location = new System.Drawing.Point(428, 112);
            this.txUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txUserName.Name = "txUserName";
            this.txUserName.Size = new System.Drawing.Size(132, 27);
            this.txUserName.TabIndex = 7;
            this.txUserName.Text = "sa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "User Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(324, 198);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Database Name";
            // 
            // txAccount
            // 
            this.txAccount.Location = new System.Drawing.Point(428, 240);
            this.txAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txAccount.Name = "txAccount";
            this.txAccount.Size = new System.Drawing.Size(132, 27);
            this.txAccount.TabIndex = 12;
            this.txAccount.Text = "Account";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 245);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Account:";
            // 
            // txAuthentication
            // 
            this.txAuthentication.Location = new System.Drawing.Point(428, 280);
            this.txAuthentication.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txAuthentication.Name = "txAuthentication";
            this.txAuthentication.Size = new System.Drawing.Size(132, 27);
            this.txAuthentication.TabIndex = 14;
            this.txAuthentication.Text = "Authentication";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(310, 285);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Authentication:";
            // 
            // txCabalCash
            // 
            this.txCabalCash.Location = new System.Drawing.Point(428, 320);
            this.txCabalCash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txCabalCash.Name = "txCabalCash";
            this.txCabalCash.Size = new System.Drawing.Size(132, 27);
            this.txCabalCash.TabIndex = 16;
            this.txCabalCash.Text = "CabalCash";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(334, 325);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Cabal Cash:";
            // 
            // txCabalGuild
            // 
            this.txCabalGuild.Location = new System.Drawing.Point(428, 400);
            this.txCabalGuild.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txCabalGuild.Name = "txCabalGuild";
            this.txCabalGuild.Size = new System.Drawing.Size(132, 27);
            this.txCabalGuild.TabIndex = 18;
            this.txCabalGuild.Text = "CabalGuild";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(330, 405);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Cabal Guild:";
            // 
            // txGameDB
            // 
            this.txGameDB.Location = new System.Drawing.Point(707, 360);
            this.txGameDB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txGameDB.Name = "txGameDB";
            this.txGameDB.Size = new System.Drawing.Size(132, 27);
            this.txGameDB.TabIndex = 26;
            this.txGameDB.Text = "Server01";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(584, 365);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Game Database:";
            // 
            // txNetCafe
            // 
            this.txNetCafe.Location = new System.Drawing.Point(707, 320);
            this.txNetCafe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txNetCafe.Name = "txNetCafe";
            this.txNetCafe.Size = new System.Drawing.Size(132, 27);
            this.txNetCafe.TabIndex = 24;
            this.txNetCafe.Text = "NetCafeBilling";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(632, 325);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "Net Cafe:";
            // 
            // txEventData
            // 
            this.txEventData.Location = new System.Drawing.Point(707, 280);
            this.txEventData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txEventData.Name = "txEventData";
            this.txEventData.Size = new System.Drawing.Size(132, 27);
            this.txEventData.TabIndex = 22;
            this.txEventData.Text = "EventData";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(618, 285);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "Event Data:";
            // 
            // txCabalManager
            // 
            this.txCabalManager.Location = new System.Drawing.Point(707, 240);
            this.txCabalManager.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txCabalManager.Name = "txCabalManager";
            this.txCabalManager.Size = new System.Drawing.Size(132, 27);
            this.txCabalManager.TabIndex = 20;
            this.txCabalManager.Text = "cabalmanager";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(589, 245);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 20);
            this.label14.TabIndex = 19;
            this.label14.Text = "Cabal Manager:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Controls.Add(this.bnConnect);
            this.panel1.Location = new System.Drawing.Point(-8, 457);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 91);
            this.panel1.TabIndex = 27;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(764, 12);
            this.btExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(84, 35);
            this.btExit.TabIndex = 1;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // bnConnect
            // 
            this.bnConnect.Location = new System.Drawing.Point(635, 12);
            this.bnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnConnect.Name = "bnConnect";
            this.bnConnect.Size = new System.Drawing.Size(113, 35);
            this.bnConnect.TabIndex = 0;
            this.bnConnect.Text = "Connect";
            this.bnConnect.UseVisualStyleBackColor = true;
            this.bnConnect.Click += new System.EventHandler(this.bnConnect_Click);
            // 
            // txCashShop
            // 
            this.txCashShop.Location = new System.Drawing.Point(428, 360);
            this.txCashShop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txCashShop.Name = "txCashShop";
            this.txCashShop.Size = new System.Drawing.Size(132, 27);
            this.txCashShop.TabIndex = 17;
            this.txCashShop.Text = "CashShop";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(338, 365);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 20);
            this.label15.TabIndex = 28;
            this.label15.Text = "Cash Shop:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CabalGM1.Properties.Resources.hacker;
            this.pictureBox1.Location = new System.Drawing.Point(19, 72);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 315);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(315, 43);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 2);
            this.panel2.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Location = new System.Drawing.Point(315, 223);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 2);
            this.panel3.TabIndex = 31;
            // 
            // FormConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(861, 518);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txCashShop);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txGameDB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txNetCafe);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txEventData);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txCabalManager);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txCabalGuild);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txCabalCash);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txAuthentication);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txAccount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txIPAddress);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConnection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection";
            this.Load += new System.EventHandler(this.FormConnection_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
