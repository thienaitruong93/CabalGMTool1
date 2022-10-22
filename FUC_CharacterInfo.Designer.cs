using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using CabalGM1;

public class FUC_CharacterInfo : UserControl
{
    private IContainer components = null;

    private GroupBox groupBox2;

    private ComboBox cbWarpCode;

    private ComboBox cbMapCode;

    private Label label28;

    private ComboBox cbClassName;

    private ComboBox cbGender;

    private TextBox txRP;

    private Label label21;

    private TextBox txWExp;

    private Label label20;

    private TextBox txAP;

    private Label label18;

    private TextBox txDP;

    private Label label19;

    private TextBox txSP;

    private Label label17;

    private TextBox txMP;

    private Label label15;

    private TextBox txHP;

    private Label label14;

    private Button btSaveCharInfo;

    private TextBox txAlz;

    private Label label12;

    private TextBox txHonour;

    private Label label11;

    private TextBox txUnusedPoint;

    private Label label10;

    private TextBox txDEX;

    private Label label9;

    private TextBox txINT;

    private Label label8;

    private TextBox txSTR;

    private Label label7;

    private TextBox txCharNum;

    private ComboBox cbNation;

    private Label label4;

    private TextBox txLevel;

    private Label label3;

    private ComboBox cbCharName;

    private Label label2;

    private ComboBox cbServer;

    private Label label1;

    private GroupBox groupBox1;

    private RadioButton rbUserName;

    private RadioButton rbUserNum;

    private Button btSearch;

    private TextBox txUserName;

    private TextBox txUserNum;

    private ComboBox cbClassRank;

    private Label label30;

    private TextBox txGuildName;

    private TextBox txGuildGrade;

    private TextBox txGuildIndex;

    private Label label6;

    private Label label29;

    private CheckBox chbPremium;

    private Label label16;

    private TextBox txSwordPoint;

    private TextBox txMagicPoint;

    private ComboBox cbSkillRank;

    private ComboBox cbAura;

    private Label label24;

    private Label label22;

    private Label label25;

    private Label label23;

    private Label label33;

    private ComboBox cbHair;

    private Label lbHair;

    private ComboBox cbHairColor;

    private Label lbHairColor;

    private ComboBox cbFace;

    private Label label27;

    private DateTimePicker dtpCharPrimium;

    private TextBox txPremiumType;

    private TextBox txPremiumSerKind;

    private GroupBox groupBox3;

    private Button btUpdateAccount;

    private TextBox txECoin;

    private Label label26;

    private Button bt_APMaxSword;

    private Button bt_APMaxMagic;

    private Label label5;

    private Panel panel4;

    private Panel panel3;

    private Panel panel2;

    private Panel panel1;

    private FormMain fmain;

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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bt_APMaxSword = new System.Windows.Forms.Button();
            this.bt_APMaxMagic = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCharName = new System.Windows.Forms.ComboBox();
            this.txCharNum = new System.Windows.Forms.TextBox();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cbHair = new System.Windows.Forms.ComboBox();
            this.lbHair = new System.Windows.Forms.Label();
            this.cbHairColor = new System.Windows.Forms.ComboBox();
            this.lbHairColor = new System.Windows.Forms.Label();
            this.cbFace = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cbNation = new System.Windows.Forms.ComboBox();
            this.txSwordPoint = new System.Windows.Forms.TextBox();
            this.txMagicPoint = new System.Windows.Forms.TextBox();
            this.cbSkillRank = new System.Windows.Forms.ComboBox();
            this.cbAura = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txUnusedPoint = new System.Windows.Forms.TextBox();
            this.txDEX = new System.Windows.Forms.TextBox();
            this.txINT = new System.Windows.Forms.TextBox();
            this.txSTR = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txGuildName = new System.Windows.Forms.TextBox();
            this.txGuildGrade = new System.Windows.Forms.TextBox();
            this.txGuildIndex = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbClassRank = new System.Windows.Forms.ComboBox();
            this.cbWarpCode = new System.Windows.Forms.ComboBox();
            this.cbMapCode = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cbClassName = new System.Windows.Forms.ComboBox();
            this.txRP = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txWExp = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txAP = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txDP = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txSP = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txMP = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txHP = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btSaveCharInfo = new System.Windows.Forms.Button();
            this.txAlz = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txHonour = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txLevel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chbPremium = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txUserName = new System.Windows.Forms.TextBox();
            this.txUserNum = new System.Windows.Forms.TextBox();
            this.rbUserName = new System.Windows.Forms.RadioButton();
            this.rbUserNum = new System.Windows.Forms.RadioButton();
            this.btSearch = new System.Windows.Forms.Button();
            this.txPremiumType = new System.Windows.Forms.TextBox();
            this.dtpCharPrimium = new System.Windows.Forms.DateTimePicker();
            this.txPremiumSerKind = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btUpdateAccount = new System.Windows.Forms.Button();
            this.txECoin = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.bt_APMaxSword);
            this.groupBox2.Controls.Add(this.bt_APMaxMagic);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbCharName);
            this.groupBox2.Controls.Add(this.txCharNum);
            this.groupBox2.Controls.Add(this.cbGender);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.cbHair);
            this.groupBox2.Controls.Add(this.lbHair);
            this.groupBox2.Controls.Add(this.cbHairColor);
            this.groupBox2.Controls.Add(this.lbHairColor);
            this.groupBox2.Controls.Add(this.cbFace);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.cbNation);
            this.groupBox2.Controls.Add(this.txSwordPoint);
            this.groupBox2.Controls.Add(this.txMagicPoint);
            this.groupBox2.Controls.Add(this.cbSkillRank);
            this.groupBox2.Controls.Add(this.cbAura);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.txUnusedPoint);
            this.groupBox2.Controls.Add(this.txDEX);
            this.groupBox2.Controls.Add(this.txINT);
            this.groupBox2.Controls.Add(this.txSTR);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txGuildName);
            this.groupBox2.Controls.Add(this.txGuildGrade);
            this.groupBox2.Controls.Add(this.txGuildIndex);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbClassRank);
            this.groupBox2.Controls.Add(this.cbWarpCode);
            this.groupBox2.Controls.Add(this.cbMapCode);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.cbClassName);
            this.groupBox2.Controls.Add(this.txRP);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.txWExp);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txAP);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txDP);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txSP);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txMP);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txHP);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.btSaveCharInfo);
            this.groupBox2.Controls.Add(this.txAlz);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txHonour);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txLevel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbServer);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(5, 179);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Size = new System.Drawing.Size(362, 719);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Character Info";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Location = new System.Drawing.Point(7, 648);
            this.panel3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(346, 1);
            this.panel3.TabIndex = 122;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(7, 412);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 1);
            this.panel2.TabIndex = 121;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(8, 289);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 1);
            this.panel1.TabIndex = 120;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Location = new System.Drawing.Point(9, 168);
            this.panel4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(346, 1);
            this.panel4.TabIndex = 119;
            // 
            // bt_APMaxSword
            // 
            this.bt_APMaxSword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_APMaxSword.Location = new System.Drawing.Point(74, 668);
            this.bt_APMaxSword.Margin = new System.Windows.Forms.Padding(0);
            this.bt_APMaxSword.Name = "bt_APMaxSword";
            this.bt_APMaxSword.Size = new System.Drawing.Size(59, 36);
            this.bt_APMaxSword.TabIndex = 117;
            this.bt_APMaxSword.Text = "Sword";
            this.bt_APMaxSword.UseVisualStyleBackColor = true;
            this.bt_APMaxSword.Click += new System.EventHandler(this.bt_APMaxSword_Click);
            // 
            // bt_APMaxMagic
            // 
            this.bt_APMaxMagic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_APMaxMagic.Location = new System.Drawing.Point(135, 668);
            this.bt_APMaxMagic.Margin = new System.Windows.Forms.Padding(0);
            this.bt_APMaxMagic.Name = "bt_APMaxMagic";
            this.bt_APMaxMagic.Size = new System.Drawing.Size(58, 36);
            this.bt_APMaxMagic.TabIndex = 118;
            this.bt_APMaxMagic.Text = "Magic";
            this.bt_APMaxMagic.UseVisualStyleBackColor = true;
            this.bt_APMaxMagic.Click += new System.EventHandler(this.bt_APMaxMagic_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(7, 676);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 116;
            this.label5.Text = "MaxRune:";
            // 
            // cbCharName
            // 
            this.cbCharName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCharName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbCharName.FormattingEnabled = true;
            this.cbCharName.Location = new System.Drawing.Point(126, 60);
            this.cbCharName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbCharName.Name = "cbCharName";
            this.cbCharName.Size = new System.Drawing.Size(138, 25);
            this.cbCharName.TabIndex = 3;
            this.cbCharName.SelectedIndexChanged += new System.EventHandler(this.cbCharName_SelectedIndexChanged);
            // 
            // txCharNum
            // 
            this.txCharNum.Enabled = false;
            this.txCharNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txCharNum.Location = new System.Drawing.Point(78, 61);
            this.txCharNum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txCharNum.Name = "txCharNum";
            this.txCharNum.Size = new System.Drawing.Size(44, 23);
            this.txCharNum.TabIndex = 2;
            this.txCharNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Male 2",
            "Female 2",
            "Male 3",
            "Female 3"});
            this.cbGender.Location = new System.Drawing.Point(78, 97);
            this.cbGender.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(115, 25);
            this.cbGender.TabIndex = 5;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label33.Location = new System.Drawing.Point(22, 101);
            this.label33.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(60, 17);
            this.label33.TabIndex = 112;
            this.label33.Text = "Gender:";
            // 
            // cbHair
            // 
            this.cbHair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbHair.FormattingEnabled = true;
            this.cbHair.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cbHair.Location = new System.Drawing.Point(78, 135);
            this.cbHair.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbHair.Name = "cbHair";
            this.cbHair.Size = new System.Drawing.Size(115, 25);
            this.cbHair.TabIndex = 7;
            // 
            // lbHair
            // 
            this.lbHair.AutoSize = true;
            this.lbHair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbHair.Location = new System.Drawing.Point(42, 139);
            this.lbHair.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbHair.Name = "lbHair";
            this.lbHair.Size = new System.Drawing.Size(38, 17);
            this.lbHair.TabIndex = 110;
            this.lbHair.Text = "Hair:";
            // 
            // cbHairColor
            // 
            this.cbHairColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHairColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbHairColor.FormattingEnabled = true;
            this.cbHairColor.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbHairColor.Location = new System.Drawing.Point(238, 135);
            this.cbHairColor.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbHairColor.Name = "cbHairColor";
            this.cbHairColor.Size = new System.Drawing.Size(115, 25);
            this.cbHairColor.TabIndex = 8;
            // 
            // lbHairColor
            // 
            this.lbHairColor.AutoSize = true;
            this.lbHairColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbHairColor.Location = new System.Drawing.Point(194, 139);
            this.lbHairColor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbHairColor.Name = "lbHairColor";
            this.lbHairColor.Size = new System.Drawing.Size(45, 17);
            this.lbHairColor.TabIndex = 108;
            this.lbHairColor.Text = "Color:";
            // 
            // cbFace
            // 
            this.cbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbFace.FormattingEnabled = true;
            this.cbFace.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbFace.Location = new System.Drawing.Point(238, 97);
            this.cbFace.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbFace.Name = "cbFace";
            this.cbFace.Size = new System.Drawing.Size(115, 25);
            this.cbFace.TabIndex = 6;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label27.Location = new System.Drawing.Point(194, 101);
            this.label27.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(43, 17);
            this.label27.TabIndex = 106;
            this.label27.Text = "Face:";
            // 
            // cbNation
            // 
            this.cbNation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbNation.FormattingEnabled = true;
            this.cbNation.Items.AddRange(new object[] {
            "None",
            "Capella",
            "Procyon",
            "Game Master"});
            this.cbNation.Location = new System.Drawing.Point(75, 499);
            this.cbNation.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbNation.Name = "cbNation";
            this.cbNation.Size = new System.Drawing.Size(117, 25);
            this.cbNation.TabIndex = 28;
            // 
            // txSwordPoint
            // 
            this.txSwordPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txSwordPoint.Location = new System.Drawing.Point(278, 426);
            this.txSwordPoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txSwordPoint.Name = "txSwordPoint";
            this.txSwordPoint.Size = new System.Drawing.Size(75, 23);
            this.txSwordPoint.TabIndex = 26;
            this.txSwordPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txMagicPoint
            // 
            this.txMagicPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txMagicPoint.Location = new System.Drawing.Point(278, 463);
            this.txMagicPoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txMagicPoint.Name = "txMagicPoint";
            this.txMagicPoint.Size = new System.Drawing.Size(75, 23);
            this.txMagicPoint.TabIndex = 27;
            this.txMagicPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbSkillRank
            // 
            this.cbSkillRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkillRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbSkillRank.FormattingEnabled = true;
            this.cbSkillRank.Items.AddRange(new object[] {
            "Novice",
            "Apprentice",
            "Regular",
            "Expert",
            "A. Expret",
            "Master",
            "A. Master",
            "G. Master",
            "Completer",
            "Transcender"});
            this.cbSkillRank.Location = new System.Drawing.Point(75, 462);
            this.cbSkillRank.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbSkillRank.Name = "cbSkillRank";
            this.cbSkillRank.Size = new System.Drawing.Size(117, 25);
            this.cbSkillRank.TabIndex = 25;
            // 
            // cbAura
            // 
            this.cbAura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbAura.FormattingEnabled = true;
            this.cbAura.Items.AddRange(new object[] {
            "None",
            "Earth",
            "Water",
            "Wind",
            "Fire",
            "Ice",
            "Thunder"});
            this.cbAura.Location = new System.Drawing.Point(75, 425);
            this.cbAura.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbAura.Name = "cbAura";
            this.cbAura.Size = new System.Drawing.Size(117, 25);
            this.cbAura.TabIndex = 24;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label24.Location = new System.Drawing.Point(198, 429);
            this.label24.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 17);
            this.label24.TabIndex = 104;
            this.label24.Text = "Sword SkP:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label22.Location = new System.Drawing.Point(199, 466);
            this.label22.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 17);
            this.label22.TabIndex = 102;
            this.label22.Text = "Magic SkP:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label25.Location = new System.Drawing.Point(37, 429);
            this.label25.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 17);
            this.label25.TabIndex = 103;
            this.label25.Text = "Aura:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.Location = new System.Drawing.Point(5, 466);
            this.label23.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 17);
            this.label23.TabIndex = 101;
            this.label23.Text = "Skill Rank:";
            // 
            // txUnusedPoint
            // 
            this.txUnusedPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txUnusedPoint.Location = new System.Drawing.Point(278, 611);
            this.txUnusedPoint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txUnusedPoint.Name = "txUnusedPoint";
            this.txUnusedPoint.Size = new System.Drawing.Size(75, 23);
            this.txUnusedPoint.TabIndex = 35;
            this.txUnusedPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txUnusedPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // txDEX
            // 
            this.txDEX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txDEX.Location = new System.Drawing.Point(278, 574);
            this.txDEX.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txDEX.Name = "txDEX";
            this.txDEX.Size = new System.Drawing.Size(75, 23);
            this.txDEX.TabIndex = 34;
            this.txDEX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txDEX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // txINT
            // 
            this.txINT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txINT.Location = new System.Drawing.Point(278, 537);
            this.txINT.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txINT.Name = "txINT";
            this.txINT.Size = new System.Drawing.Size(75, 23);
            this.txINT.TabIndex = 33;
            this.txINT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txINT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // txSTR
            // 
            this.txSTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txSTR.Location = new System.Drawing.Point(278, 500);
            this.txSTR.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txSTR.Name = "txSTR";
            this.txSTR.Size = new System.Drawing.Size(75, 23);
            this.txSTR.TabIndex = 32;
            this.txSTR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txSTR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(218, 614);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Unused:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(239, 577);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "DEX:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(245, 540);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "INT:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(239, 503);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "STR:";
            // 
            // txGuildName
            // 
            this.txGuildName.Enabled = false;
            this.txGuildName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txGuildName.Location = new System.Drawing.Point(134, 258);
            this.txGuildName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txGuildName.Name = "txGuildName";
            this.txGuildName.Size = new System.Drawing.Size(162, 23);
            this.txGuildName.TabIndex = 14;
            // 
            // txGuildGrade
            // 
            this.txGuildGrade.Enabled = false;
            this.txGuildGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txGuildGrade.Location = new System.Drawing.Point(305, 258);
            this.txGuildGrade.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txGuildGrade.Name = "txGuildGrade";
            this.txGuildGrade.Size = new System.Drawing.Size(46, 23);
            this.txGuildGrade.TabIndex = 15;
            // 
            // txGuildIndex
            // 
            this.txGuildIndex.Enabled = false;
            this.txGuildIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txGuildIndex.Location = new System.Drawing.Point(78, 258);
            this.txGuildIndex.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txGuildIndex.Name = "txGuildIndex";
            this.txGuildIndex.Size = new System.Drawing.Size(46, 23);
            this.txGuildIndex.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(35, 261);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 82;
            this.label6.Text = "Guild:";
            // 
            // cbClassRank
            // 
            this.cbClassRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbClassRank.FormattingEnabled = true;
            this.cbClassRank.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbClassRank.Location = new System.Drawing.Point(304, 181);
            this.cbClassRank.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbClassRank.Name = "cbClassRank";
            this.cbClassRank.Size = new System.Drawing.Size(47, 25);
            this.cbClassRank.TabIndex = 10;
            // 
            // cbWarpCode
            // 
            this.cbWarpCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWarpCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbWarpCode.FormattingEnabled = true;
            this.cbWarpCode.Items.AddRange(new object[] {
            "Basic",
            "Port Lux",
            "Fort Ruina",
            "Lakeside",
            "Undead Ground",
            "Forgotten Ruin",
            "Mutant Forrest",
            "Pontus Ferrum",
            "Porta Inferno",
            "Arcane Trace"});
            this.cbWarpCode.Location = new System.Drawing.Point(78, 219);
            this.cbWarpCode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbWarpCode.Name = "cbWarpCode";
            this.cbWarpCode.Size = new System.Drawing.Size(115, 25);
            this.cbWarpCode.TabIndex = 11;
            // 
            // cbMapCode
            // 
            this.cbMapCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbMapCode.FormattingEnabled = true;
            this.cbMapCode.Items.AddRange(new object[] {
            "Basic",
            "Port Lux",
            "Fort Ruina",
            "Lakeside",
            "Undead Ground",
            "Forgotten Ruin",
            "Mutant Forrest",
            "Pontus Ferrum",
            "Porta Inferno",
            "Arcane Trace"});
            this.cbMapCode.Location = new System.Drawing.Point(238, 219);
            this.cbMapCode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbMapCode.Name = "cbMapCode";
            this.cbMapCode.Size = new System.Drawing.Size(115, 25);
            this.cbMapCode.TabIndex = 12;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label28.Location = new System.Drawing.Point(33, 223);
            this.label28.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(46, 17);
            this.label28.TabIndex = 66;
            this.label28.Text = "Warp:";
            // 
            // cbClassName
            // 
            this.cbClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbClassName.FormattingEnabled = true;
            this.cbClassName.Items.AddRange(new object[] {
            "None",
            "Warrior",
            "Blader",
            "Wizard",
            "Force Archer",
            "Force Shielder",
            "Force Blader"});
            this.cbClassName.Location = new System.Drawing.Point(78, 181);
            this.cbClassName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbClassName.Name = "cbClassName";
            this.cbClassName.Size = new System.Drawing.Size(143, 25);
            this.cbClassName.TabIndex = 9;
            // 
            // txRP
            // 
            this.txRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txRP.Location = new System.Drawing.Point(238, 341);
            this.txRP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txRP.Name = "txRP";
            this.txRP.Size = new System.Drawing.Size(115, 23);
            this.txRP.TabIndex = 19;
            this.txRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txRP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(207, 344);
            this.label21.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 17);
            this.label21.TabIndex = 43;
            this.label21.Text = "RP:";
            // 
            // txWExp
            // 
            this.txWExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txWExp.Location = new System.Drawing.Point(75, 574);
            this.txWExp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txWExp.Name = "txWExp";
            this.txWExp.Size = new System.Drawing.Size(115, 23);
            this.txWExp.TabIndex = 30;
            this.txWExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txWExp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.Location = new System.Drawing.Point(31, 577);
            this.label20.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 17);
            this.label20.TabIndex = 41;
            this.label20.Text = "WExp:";
            // 
            // txAP
            // 
            this.txAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txAP.Location = new System.Drawing.Point(238, 381);
            this.txAP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txAP.Name = "txAP";
            this.txAP.Size = new System.Drawing.Size(115, 23);
            this.txAP.TabIndex = 21;
            this.txAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txAP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(208, 384);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 17);
            this.label18.TabIndex = 39;
            this.label18.Text = "AP:";
            // 
            // txDP
            // 
            this.txDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txDP.Location = new System.Drawing.Point(78, 381);
            this.txDP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txDP.Name = "txDP";
            this.txDP.Size = new System.Drawing.Size(115, 23);
            this.txDP.TabIndex = 20;
            this.txDP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txDP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(48, 384);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 17);
            this.label19.TabIndex = 37;
            this.label19.Text = "DP:";
            // 
            // txSP
            // 
            this.txSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txSP.Location = new System.Drawing.Point(78, 341);
            this.txSP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txSP.Name = "txSP";
            this.txSP.Size = new System.Drawing.Size(115, 23);
            this.txSP.TabIndex = 18;
            this.txSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(49, 344);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 17);
            this.label17.TabIndex = 33;
            this.label17.Text = "SP:";
            // 
            // txMP
            // 
            this.txMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txMP.Location = new System.Drawing.Point(238, 301);
            this.txMP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txMP.Name = "txMP";
            this.txMP.ReadOnly = true;
            this.txMP.Size = new System.Drawing.Size(115, 23);
            this.txMP.TabIndex = 17;
            this.txMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(206, 304);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 17);
            this.label15.TabIndex = 31;
            this.label15.Text = "MP:";
            // 
            // txHP
            // 
            this.txHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txHP.Location = new System.Drawing.Point(78, 301);
            this.txHP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txHP.Name = "txHP";
            this.txHP.ReadOnly = true;
            this.txHP.Size = new System.Drawing.Size(115, 23);
            this.txHP.TabIndex = 16;
            this.txHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(48, 304);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 17);
            this.label14.TabIndex = 29;
            this.label14.Text = "HP:";
            // 
            // btSaveCharInfo
            // 
            this.btSaveCharInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btSaveCharInfo.Location = new System.Drawing.Point(238, 659);
            this.btSaveCharInfo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btSaveCharInfo.Name = "btSaveCharInfo";
            this.btSaveCharInfo.Size = new System.Drawing.Size(117, 53);
            this.btSaveCharInfo.TabIndex = 50;
            this.btSaveCharInfo.Text = "Update Char";
            this.btSaveCharInfo.UseVisualStyleBackColor = true;
            this.btSaveCharInfo.Click += new System.EventHandler(this.btSaveCharInfo_Click);
            // 
            // txAlz
            // 
            this.txAlz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txAlz.Location = new System.Drawing.Point(75, 611);
            this.txAlz.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txAlz.Name = "txAlz";
            this.txAlz.Size = new System.Drawing.Size(115, 23);
            this.txAlz.TabIndex = 31;
            this.txAlz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txAlz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(48, 614);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "Alz:";
            // 
            // txHonour
            // 
            this.txHonour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txHonour.Location = new System.Drawing.Point(75, 537);
            this.txHonour.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txHonour.Name = "txHonour";
            this.txHonour.Size = new System.Drawing.Size(115, 23);
            this.txHonour.TabIndex = 29;
            this.txHonour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txHonour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(20, 540);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Honour:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(26, 503);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nation:";
            // 
            // txLevel
            // 
            this.txLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txLevel.Location = new System.Drawing.Point(305, 61);
            this.txLevel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txLevel.Name = "txLevel";
            this.txLevel.Size = new System.Drawing.Size(46, 23);
            this.txLevel.TabIndex = 4;
            this.txLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(262, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Level:";
            // 
            // cbServer
            // 
            this.cbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Location = new System.Drawing.Point(78, 23);
            this.cbServer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(275, 25);
            this.cbServer.TabIndex = 1;
            this.cbServer.SelectedIndexChanged += new System.EventHandler(this.cbServer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(2, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "CharName:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label30.Location = new System.Drawing.Point(34, 185);
            this.label30.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(46, 17);
            this.label30.TabIndex = 75;
            this.label30.Text = "Class:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label29.Location = new System.Drawing.Point(223, 185);
            this.label29.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 17);
            this.label29.TabIndex = 85;
            this.label29.Text = "Class Rank:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(199, 223);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 17);
            this.label16.TabIndex = 88;
            this.label16.Text = "Map:";
            // 
            // chbPremium
            // 
            this.chbPremium.AutoSize = true;
            this.chbPremium.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chbPremium.Location = new System.Drawing.Point(9, 24);
            this.chbPremium.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chbPremium.Name = "chbPremium";
            this.chbPremium.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbPremium.Size = new System.Drawing.Size(85, 21);
            this.chbPremium.TabIndex = 1;
            this.chbPremium.Text = "Premium";
            this.chbPremium.UseVisualStyleBackColor = true;
            this.chbPremium.CheckedChanged += new System.EventHandler(this.chbPremium_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txUserName);
            this.groupBox1.Controls.Add(this.txUserNum);
            this.groupBox1.Controls.Add(this.rbUserName);
            this.groupBox1.Controls.Add(this.rbUserNum);
            this.groupBox1.Controls.Add(this.btSearch);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.Firebrick;
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(362, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Search";
            // 
            // txUserName
            // 
            this.txUserName.Enabled = false;
            this.txUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txUserName.Location = new System.Drawing.Point(198, 24);
            this.txUserName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txUserName.Name = "txUserName";
            this.txUserName.Size = new System.Drawing.Size(84, 23);
            this.txUserName.TabIndex = 4;
            // 
            // txUserNum
            // 
            this.txUserNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txUserNum.Location = new System.Drawing.Point(78, 24);
            this.txUserNum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txUserNum.Name = "txUserNum";
            this.txUserNum.Size = new System.Drawing.Size(44, 23);
            this.txUserNum.TabIndex = 3;
            // 
            // rbUserName
            // 
            this.rbUserName.AutoSize = true;
            this.rbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbUserName.Location = new System.Drawing.Point(127, 27);
            this.rbUserName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbUserName.Name = "rbUserName";
            this.rbUserName.Size = new System.Drawing.Size(70, 21);
            this.rbUserName.TabIndex = 3;
            this.rbUserName.Text = "Name:";
            this.rbUserName.UseVisualStyleBackColor = true;
            // 
            // rbUserNum
            // 
            this.rbUserNum.AutoSize = true;
            this.rbUserNum.Checked = true;
            this.rbUserNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbUserNum.Location = new System.Drawing.Point(16, 27);
            this.rbUserNum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbUserNum.Name = "rbUserNum";
            this.rbUserNum.Size = new System.Drawing.Size(62, 21);
            this.rbUserNum.TabIndex = 2;
            this.rbUserNum.TabStop = true;
            this.rbUserNum.Text = "Num:";
            this.rbUserNum.UseVisualStyleBackColor = true;
            this.rbUserNum.CheckedChanged += new System.EventHandler(this.rbUserNum_CheckedChanged);
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btSearch.Location = new System.Drawing.Point(287, 20);
            this.btSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(66, 40);
            this.btSearch.TabIndex = 5;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // txPremiumType
            // 
            this.txPremiumType.Enabled = false;
            this.txPremiumType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txPremiumType.Location = new System.Drawing.Point(288, 23);
            this.txPremiumType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txPremiumType.Name = "txPremiumType";
            this.txPremiumType.Size = new System.Drawing.Size(29, 23);
            this.txPremiumType.TabIndex = 3;
            this.txPremiumType.Text = "1";
            // 
            // dtpCharPrimium
            // 
            this.dtpCharPrimium.Enabled = false;
            this.dtpCharPrimium.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpCharPrimium.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCharPrimium.Location = new System.Drawing.Point(98, 23);
            this.dtpCharPrimium.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtpCharPrimium.Name = "dtpCharPrimium";
            this.dtpCharPrimium.Size = new System.Drawing.Size(185, 23);
            this.dtpCharPrimium.TabIndex = 2;
            // 
            // txPremiumSerKind
            // 
            this.txPremiumSerKind.Enabled = false;
            this.txPremiumSerKind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txPremiumSerKind.Location = new System.Drawing.Point(322, 23);
            this.txPremiumSerKind.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txPremiumSerKind.Name = "txPremiumSerKind";
            this.txPremiumSerKind.Size = new System.Drawing.Size(29, 23);
            this.txPremiumSerKind.TabIndex = 4;
            this.txPremiumSerKind.Text = "5";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btUpdateAccount);
            this.groupBox3.Controls.Add(this.txECoin);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.txPremiumType);
            this.groupBox3.Controls.Add(this.dtpCharPrimium);
            this.groupBox3.Controls.Add(this.txPremiumSerKind);
            this.groupBox3.Controls.Add(this.chbPremium);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(2, 81);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox3.Size = new System.Drawing.Size(362, 93);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Account Info";
            // 
            // btUpdateAccount
            // 
            this.btUpdateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btUpdateAccount.Location = new System.Drawing.Point(239, 50);
            this.btUpdateAccount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btUpdateAccount.Name = "btUpdateAccount";
            this.btUpdateAccount.Size = new System.Drawing.Size(114, 36);
            this.btUpdateAccount.TabIndex = 6;
            this.btUpdateAccount.Text = "Update Acc";
            this.btUpdateAccount.UseVisualStyleBackColor = true;
            this.btUpdateAccount.Click += new System.EventHandler(this.btUpdateAccount_Click);
            // 
            // txECoin
            // 
            this.txECoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txECoin.Location = new System.Drawing.Point(79, 57);
            this.txECoin.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txECoin.Name = "txECoin";
            this.txECoin.Size = new System.Drawing.Size(115, 23);
            this.txECoin.TabIndex = 5;
            this.txECoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txECoin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDigit_KeyPress);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label26.Location = new System.Drawing.Point(34, 60);
            this.label26.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(44, 17);
            this.label26.TabIndex = 118;
            this.label26.Text = "Cash:";
            // 
            // FUC_CharacterInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FUC_CharacterInfo";
            this.Size = new System.Drawing.Size(370, 901);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

    }

    public FUC_CharacterInfo()
    {
        InitializeComponent();
        dtpCharPrimium.Value = DateTime.Now.AddYears(10);
        dtpCharPrimium.CustomFormat = "MM/dd/yyyy - hh:mm:ss";
    }

    public void setFormMain(FormMain fmain)
    {
        this.fmain = fmain;
    }

    private void rbUserNum_CheckedChanged(object sender, EventArgs e)
    {
        if (rbUserName.Checked)
        {
            txUserName.Enabled = true;
            txUserNum.Enabled = false;
        }
        else
        {
            txUserName.Enabled = false;
            txUserNum.Enabled = true;
        }
    }

    private void btSearch_Click(object sender, EventArgs e)
    {
        ArrayList arrayList = new ArrayList();
        int num = -1;
        if (rbUserName.Checked)
        {
            string text = txUserName.Text;
            arrayList = new ArrayList();
            arrayList.Add(new SqlParameter("@ID", text));
            DataTable dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLAccountDB, "cabal_tool_GetUserNum", arrayList);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                MessageBox.Show("User Name does NOT exists");
                txUserName.Text = "";
                txUserName.Select();
                return;
            }
            num = int.Parse(dataTable.Rows[0][0].ToString());
            GlobalClass.UserName = text;
        }
        else
        {
            try
            {
                num = int.Parse(txUserNum.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid User Number", "Error");
                txUserNum.Text = "";
                txUserNum.Select();
                return;
            }
        }
        try
        {
            arrayList = new ArrayList();
            arrayList.Add(new SqlParameter("@usernum", num));
            DataTable dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLAccountDB, "cabal_sp_mych_server", arrayList);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                GlobalClass.UserNum = -1;
                MessageBox.Show("User ID does NOT exists");
                txUserNum.Text = "";
                txUserNum.Select();
                return;
            }
            if (GlobalClass.ListServer == null || GlobalClass.ListServer.Rows.Count == 0)
            {
                GlobalClass.UserNum = -1;
                MessageBox.Show("Server does NOT exists");
                txUserNum.Text = "";
                txUserNum.Select();
                return;
            }
            GlobalClass.UserNum = num;
            DataTable dataTable2 = new DataTable();
            for (int i = 0; i < GlobalClass.ListServer.Columns.Count; i++)
            {
                dataTable2.Columns.Add(GlobalClass.ListServer.Columns[i].ColumnName, GlobalClass.ListServer.Columns[i].DataType);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < GlobalClass.ListServer.Rows.Count; j++)
                {
                    if (dataTable.Rows[i][0].ToString() == GlobalClass.ListServer.Rows[j][0].ToString())
                    {
                        dataTable2.ImportRow(GlobalClass.ListServer.Rows[j]);
                    }
                }
            }
            cbServer.DataSource = dataTable2;
            cbServer.DisplayMember = "ServerName";
            cbServer.ValueMember = "ServerID";
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Error");
        }
    }

    private void cbServer_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataRowView dataRowView = (DataRowView)cbServer.SelectedItem;
        GlobalClass.ServerID = dataRowView[0].ToString();
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@linkedname", '0'));
        arrayList.Add(new SqlParameter("@servername", dataRowView[4].ToString()));
        arrayList.Add(new SqlParameter("@usernum", GlobalClass.UserNum));
        DataTable dataSource = UtilityDatabase.selectStoredPro(GlobalClass.SQLAccountDB, "sp_Get_characters", arrayList);
        cbCharName.DataSource = dataSource;
        cbCharName.DisplayMember = "CharacterName";
    }

    private void chbPremium_CheckedChanged(object sender, EventArgs e)
    {
        dtpCharPrimium.Enabled = chbPremium.Checked;
        txPremiumSerKind.Enabled = chbPremium.Checked;
        txPremiumType.Enabled = chbPremium.Checked;
    }

    private void cbCharName_SelectedIndexChanged(object sender, EventArgs e)
    {
        clearCharInfo();
        DataRowView dataRowView = (DataRowView)cbCharName.SelectedItem;
        string[] array = dataRowView[0].ToString().Split('/');
        int charNum = int.Parse(array[0]);       
        string charName = array[3];
        MyCharacter myCharacter2 = (GlobalClass.CurMyChar = new MyCharacter(charNum, charName));
        myCharacter2.LV = int.Parse(array[1]);
        myCharacter2.Nation = int.Parse(array[2]);
        myCharacter2.GuildGrade = int.Parse(array[4]);
        myCharacter2.GuildNum = int.Parse(array[5]);
        myCharacter2.GuildName = array[6];
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@CharacterIndex", myCharacter2.CharNum));
        DataTable dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_tool_GetCharacterInfo", arrayList);
        if (dataTable == null || dataTable.Rows.Count == 0)
        {
            return;
        }
        myCharacter2.LV = (int)dataTable.Rows[0][2];
        myCharacter2.EXP = (long)dataTable.Rows[0][3];
        myCharacter2.STR = (int)dataTable.Rows[0][4];
        myCharacter2.DEX = (int)dataTable.Rows[0][5];
        myCharacter2.INT = (int)dataTable.Rows[0][6];
        myCharacter2.UnusedPoint = (int)dataTable.Rows[0][7];
        myCharacter2.SkillRank = (int)dataTable.Rows[0][8];
        myCharacter2.Alz = (long)dataTable.Rows[0][9];
        myCharacter2.WorldIdx = (int)dataTable.Rows[0][10];
        myCharacter2.Position = (int)dataTable.Rows[0][11];
        myCharacter2.Style = (int)dataTable.Rows[0][12];
        myCharacter2.HPEncrypted = (int)dataTable.Rows[0][13];
        myCharacter2.MPEncrypted = (int)dataTable.Rows[0][14];
        myCharacter2.SwordPoint = (int)dataTable.Rows[0][15] / 65536;
        myCharacter2.MagicPoint = (int)dataTable.Rows[0][16] / 65536;
        myCharacter2.RankEXP = (int)dataTable.Rows[0][17];
        myCharacter2.Flag = (int)dataTable.Rows[0][18];
        myCharacter2.WarpCode = (int)dataTable.Rows[0][19];
        myCharacter2.MapCode = (int)dataTable.Rows[0][20];
        myCharacter2.SP = (int)dataTable.Rows[0][21];
        myCharacter2.PenaltyEXP = (dataTable.Rows[0][22].ToString().Equals("") ? (-1) : ((int)dataTable.Rows[0][22]));
        myCharacter2.LogoutTime = (dataTable.Rows[0][23].ToString().Equals("") ? DateTime.Now : ((DateTime)dataTable.Rows[0][23]));
        myCharacter2.RP = (int)dataTable.Rows[0][24];
        myCharacter2.Honour = (dataTable.Rows[0][25].ToString().Equals("") ? (-1) : ((int)dataTable.Rows[0][25]));
        myCharacter2.LoginTime = (dataTable.Rows[0][26].ToString().Equals("") ? DateTime.Now : ((DateTime)dataTable.Rows[0][26]));
        myCharacter2.PlayTime = (int)dataTable.Rows[0][27];
        myCharacter2.ChannelIdx = (int)dataTable.Rows[0][28];
        myCharacter2.PkPenalty = (int)dataTable.Rows[0][29];
        myCharacter2.Nation = (byte)dataTable.Rows[0][30];
        myCharacter2.CreateDate = (DateTime)dataTable.Rows[0][31];
        myCharacter2.Login = (int)dataTable.Rows[0][32];
        myCharacter2.GuildNum = (int)dataTable.Rows[0][33];
        myCharacter2.GuildName = dataTable.Rows[0][34].ToString();
        myCharacter2.GuildGroupPer = (int)dataTable.Rows[0][35];
        myCharacter2.WExp = (long)dataTable.Rows[0][36];
        myCharacter2.TitleIdx = (int)dataTable.Rows[0][37];
        myCharacter2.TotalWarPoint = (dataTable.Rows[0][38].ToString().Equals("") ? (-1) : Convert.ToInt32(dataTable.Rows[0][38]));
        myCharacter2.LastDayRank = (int)dataTable.Rows[0][39];
        myCharacter2.ToDayRank = (int)dataTable.Rows[0][40];
        myCharacter2.WarChannelType = (int)dataTable.Rows[0][41];
        arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@CharacterIndex", myCharacter2.CharNum));
        dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_tool_GetDungeonPoint", arrayList);
        try
        {
            myCharacter2.DP = (int)dataTable.Rows[0][1];
        }
        catch (Exception)
        {
            myCharacter2.DP = 0;
        }
        txDP.Text = myCharacter2.DP.ToString();
        arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@CharacterIdx", myCharacter2.CharNum));
        dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_tool_GetAbility", arrayList);
        myCharacter2.AP = (dataTable.Rows[0][1].ToString().Equals("") ? (-1) : ((int)dataTable.Rows[0][1]));
        myCharacter2.AP_Exp = (dataTable.Rows[0][2].ToString().Equals("") ? (-1) : ((int)dataTable.Rows[0][2]));
        myCharacter2.AP_PassiveData = (byte[])dataTable.Rows[0][3];
        myCharacter2.AP_BlendedData = (byte[])dataTable.Rows[0][4];
        myCharacter2.AP_Total = (int)dataTable.Rows[0][5];
        txAP.Text = myCharacter2.AP.ToString();
        arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@UserNum", GlobalClass.UserNum));
        dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLCabalCashDB, "up_GetUserCashInfo", arrayList);
        try
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                myCharacter2.ECoint = (int)dataTable.Rows[0][3];
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Can NOT load Cash Info\n\n" + ex.ToString(), "Can NOT load Cash Info");
        }
        arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@CharacterIdx", myCharacter2.CharNum));
        dataTable = UtilityDatabase.selectStoredPro(GlobalClass.SQLGameDB, "cabal_tool_GetSkill", arrayList);
        myCharacter2.Skill = MyMath.ByteArrayToString((byte[])dataTable.Rows[0][1]);
        displayCharInfo(myCharacter2);
    }

    private void displayCharInfo(MyCharacter myChar)
    {
        txLevel.Text = myChar.LV.ToString();
        txCharNum.Text = myChar.CharNum.ToString();
        txGuildGrade.Text = myChar.GuildGrade.ToString();
        txGuildIndex.Text = myChar.GuildNum.ToString();
        txGuildName.Text = myChar.GuildName;
        txLevel.Text = myChar.LV.ToString();
        txSTR.Text = myChar.STR.ToString();
        txDEX.Text = myChar.DEX.ToString();
        txINT.Text = myChar.INT.ToString();
        txUnusedPoint.Text = myChar.UnusedPoint.ToString();
        txAlz.Text = myChar.Alz.ToString();
        txHP.Text = myChar.HPCurMax[1].ToString();
        txMP.Text = myChar.MPCurMax[1].ToString();
        txSwordPoint.Text = myChar.SwordPoint.ToString();
        txMagicPoint.Text = myChar.MagicPoint.ToString();
        txSP.Text = myChar.SP.ToString();
        txRP.Text = myChar.RP.ToString();
        txHonour.Text = myChar.Honour.ToString();
        txWExp.Text = myChar.WExp.ToString();
        txECoin.Text = myChar.ECoint.ToString();
        try
        {
            cbGender.SelectedIndex = myChar.Gender;
        }
        catch (Exception)
        {
            cbGender.SelectedIndex = -1;
        }
        try
        {
            cbAura.SelectedIndex = ((myChar.Aura < 7) ? myChar.Aura : (-1));
        }
        catch (Exception)
        {
            cbAura.SelectedIndex = -1;
        }
        try
        {
            cbClassRank.SelectedItem = myChar.ClassRank.ToString();
        }
        catch (Exception)
        {
            cbClassRank.SelectedIndex = -1;
        }
        try
        {
            cbClassName.SelectedIndex = myChar.ClassName;
        }
        catch (Exception)
        {
            cbClassName.SelectedIndex = -1;
        }
        try
        {
            cbFace.SelectedIndex = myChar.Face;
        }
        catch (Exception)
        {
            cbFace.SelectedIndex = -1;
        }
        try
        {
            cbHair.SelectedIndex = myChar.Hair;
        }
        catch (Exception)
        {
            cbHair.SelectedIndex = -1;
        }
        try
        {
            cbHairColor.SelectedIndex = myChar.HairColor;
        }
        catch (Exception)
        {
            cbHairColor.SelectedIndex = -1;
        }
        try
        {
            cbSkillRank.SelectedIndex = myChar.SkillRank / 257 - 1;
        }
        catch (Exception)
        {
            cbSkillRank.SelectedIndex = -1;
        }
        try
        {
            cbMapCode.SelectedIndex = (int)Math.Log(double.Parse(myChar.MapCode.ToString()), 2.0) - 2;
        }
        catch (Exception)
        {
            cbMapCode.SelectedIndex = -1;
        }
        try
        {
            cbWarpCode.SelectedIndex = (int)Math.Log(double.Parse(myChar.WarpCode.ToString()), 2.0) - 2;
        }
        catch (Exception)
        {
            cbWarpCode.SelectedIndex = -1;
        }
        try
        {
            cbNation.SelectedIndex = myChar.Nation;
        }
        catch (Exception)
        {
            cbNation.SelectedIndex = -1;
        }
        if (fmain!=null)
        {
            GlobalClass.CharNum = myChar.CharNum.ToString();
            fmain.loadCharacterEquipment();
            fmain.loadCharacterInventory();
            fmain.loadCharacterWarehouse();
            fmain.loadCharacterTitle();
            fmain.loadCharacterSkill();
        }
    }

    private void clearCharInfo()
    {
        txAlz.Text = "-1";
        txAP.Text = "-1";
        txCharNum.Text = "-1";
        txDEX.Text = "-1";
        txDP.Text = "-1";
        txECoin.Text = "-1";
        txGuildGrade.Text = "-1";
        txGuildIndex.Text = "-1";
        txGuildName.Text = "-1";
        txHonour.Text = "-1";
        txHP.Text = "-1";
        txINT.Text = "-1";
        txLevel.Text = "-1";
        txMagicPoint.Text = "-1";
        txMP.Text = "-1";
        txRP.Text = "-1";
        txSP.Text = "-1";
        txSTR.Text = "-1";
        txSwordPoint.Text = "-1";
        txUnusedPoint.Text = "-1";
        txWExp.Text = "-1";
        cbAura.SelectedIndex = -1;
        cbClassName.SelectedIndex = -1;
        cbClassRank.SelectedIndex = -1;
        cbGender.SelectedIndex = -1;
        cbMapCode.SelectedIndex = -1;
        cbNation.SelectedIndex = -1;
        cbSkillRank.SelectedIndex = -1;
        cbWarpCode.SelectedIndex = -1;
        cbFace.SelectedIndex = -1;
        cbHair.SelectedIndex = -1;
        cbHairColor.SelectedIndex = -1;
    }

    private void btSaveCharInfo_Click(object sender, EventArgs e)
    {
        MyCharacter curMyChar = GlobalClass.CurMyChar;
        curMyChar.Alz = long.Parse(txAlz.Text);
        curMyChar.LV = int.Parse(txLevel.Text);
        curMyChar.STR = int.Parse(txSTR.Text);
        curMyChar.DEX = int.Parse(txDEX.Text);
        curMyChar.INT = int.Parse(txINT.Text);
        curMyChar.UnusedPoint = int.Parse(txUnusedPoint.Text);
        curMyChar.Honour = int.Parse(txHonour.Text);
        curMyChar.Nation = cbNation.SelectedIndex;
        curMyChar.SkillRank = (cbSkillRank.SelectedIndex + 1) * 257;
        curMyChar.DP = int.Parse(txDP.Text);
        curMyChar.AP = int.Parse(txAP.Text);
        curMyChar.Gender = cbGender.SelectedIndex;
        curMyChar.Aura = cbAura.SelectedIndex;
        curMyChar.Hair = cbHair.SelectedIndex;
        curMyChar.HairColor = cbHairColor.SelectedIndex;
        curMyChar.Face = cbFace.SelectedIndex;
        curMyChar.ClassRank = cbClassRank.SelectedIndex + 1;
        curMyChar.ClassName = cbClassName.SelectedIndex;
        curMyChar.MapCode = (int)Math.Pow(2.0, double.Parse((cbMapCode.SelectedIndex + 3).ToString())) - 1;
        curMyChar.WarpCode = (int)Math.Pow(2.0, double.Parse((cbWarpCode.SelectedIndex + 3).ToString())) - 1;
        curMyChar.SwordPoint = int.Parse(txSwordPoint.Text) * 65536;
        curMyChar.MagicPoint = int.Parse(txMagicPoint.Text) * 65536;
        curMyChar.SP = int.Parse(txSP.Text);
        curMyChar.RP = int.Parse(txRP.Text);
        curMyChar.WExp = long.Parse(txWExp.Text);
        if (!curMyChar.updateCharInfo())
        {
            MessageBox.Show("Can not save character info");
        }
    }

    private void btUpdateAccount_Click(object sender, EventArgs e)
    {
        MyCharacter curMyChar = GlobalClass.CurMyChar;
        curMyChar.ECoint = int.Parse(txECoin.Text);
        string query = "UPDATE CashAccount SET Cash = " + curMyChar.ECoint + " , CashBonus = 0 WHERE UserNum = " + GlobalClass.UserNum;
        bool flag = UtilityDatabase.updateQuery(GlobalClass.SQLCabalCashDB, query);
        if (chbPremium.Checked)
        {
            string text = txPremiumType.Text;
            string text2 = txPremiumSerKind.Text;
            DateTime value = dtpCharPrimium.Value;
            query = string.Concat("update cabal_charge_auth  set Type = ", text, " , ExpireDate = '", value, "',PayMinutes = 999999, ServiceKind =  ", text2, " WHere usernum = ", GlobalClass.UserNum);
            UtilityDatabase.updateQuery(GlobalClass.SQLAccountDB, query);
        }
    }

    public void bt_APMaxSword_Click(object sender, EventArgs e)
    {
        string queryEssen = "UPDATE [dbo].[cabal_soul_ability_table]  SET PassiveAbilityData=0xA606000003000C08A30600001E00CC0C9C0600000A00A7009D0600000A000C089F0600001400CC0C200200001400CC0C530B000014000C082102000014000C08230200001400CC0C540B00001400CC0C560B00001400CC0C970600001400CC0CB00E00000500CC0C980600001400CC0C990600000A00CC0C9A0600000A00CC0C9B0600000A00A700A80600000400CC0C240200000500CC0C570B00000500CC0C450900000300CC0C620B00000300CC0C630B00000300CC0C460900000500CC0C260200000700CC0C590B00000700CC0C610B000005000C08550D00000A008AE4 WHERE CharacterIdx= " + GlobalClass.CurMyChar.CharNum;
        UtilityDatabase.updateQuery(GlobalClass.SQLGameDB, queryEssen);
        string queryBlend = "UPDATE [dbo].[cabal_soul_ability_table]  SET BlendedAbilityData=0x5D0D00000000000000000000610D000000000000000000006A0D00000000000000000000 WHERE CharacterIdx= " + GlobalClass.CurMyChar.CharNum;
        UtilityDatabase.updateQuery(GlobalClass.SQLGameDB, queryBlend);
    }

    public void bt_APMaxMagic_Click(object sender, EventArgs e)
    {
        string queryEssen = "UPDATE [dbo].[cabal_soul_ability_table]  SET PassiveAbilityData=0xA606000003000C08A30600001E00CC0C9D0600000A000C089F0600001400CC0C200200001400CC0C530B000014000C08230200001400CC0C560B00001400CC0C970600001400CC0CB00E00000500CC0C980600001400CC0C990600000A00CC0C9A0600000A00CC0C9B0600000A00A700450900000300CC0C620B00000300CC0C630B00000300CC0C460900000500CC0C260200000700CC0C590B00000700CC0C610B000005000C08550D00000A008AE4A906000004000C08250200000500060C580B0000050020082202000014000C08550B00001400060CA20600000F00060C WHERE CharacterIdx= " + GlobalClass.CurMyChar.CharNum;
        UtilityDatabase.updateQuery(GlobalClass.SQLGameDB, queryEssen);
        string queryBlend = "UPDATE [dbo].[cabal_soul_ability_table]  SET BlendedAbilityData=0x6B0D00000100000000000000630D000000000000000000005F0D00000000000000000000 WHERE CharacterIdx= " + GlobalClass.CurMyChar.CharNum;
        UtilityDatabase.updateQuery(GlobalClass.SQLGameDB, queryBlend);
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

    public static implicit operator FUC_CharacterInfo(CabalGM1.FUC_CharacterInfo v)
    {
        throw new NotImplementedException();
    }
}
