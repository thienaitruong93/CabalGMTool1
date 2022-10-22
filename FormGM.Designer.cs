using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using CabalGM1;

public class FormGM : Form
{
    private IContainer components = null;

    private TextBox txtGMipAddress;

    private Label label1;

    private Label label4;

    private Button btnGMIpReg;

    private TextBox txtGMIpTo;

    private Label label2;

    private Label label5;

    private Panel panel1;

    private Panel panel4;

    public FormGM()
    {
        InitializeComponent();
    }

    private void btnGMIpReg_Click(object sender, EventArgs e)
    {
        string text = txtGMipAddress.Text;
        string text2 = txtGMIpTo.Text;
        if (text == "" || text2 == "")
        {
            MessageBox.Show("IP is NOT correct", "Error");
            return;
        }
        if (!checkValidIP(text) || !checkValidIP(text2))
        {
            MessageBox.Show("Please enter a valid IP Address for GM Access");
            return;
        }
        ArrayList arrayList = new ArrayList();
        arrayList.Add(new SqlParameter("@fromip", text));
        arrayList.Add(new SqlParameter("@toip", text2));
        if (UtilityDatabase.execStoredPro(GlobalClass.SQLAccountDB, "cabal_addgmip", arrayList))
        {
            MessageBox.Show("GM Ip Address was successfully added to the database.", "Success");
        }
    }

    private bool checkValidIP(string IP)
    {
        if (IPAddress.TryParse(IP, out var address))
        {
            AddressFamily addressFamily = address.AddressFamily;
            if (addressFamily == AddressFamily.InterNetwork)
            {
                return true;
            }
            return false;
        }
        return false;
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
            this.txtGMipAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGMIpReg = new System.Windows.Forms.Button();
            this.txtGMIpTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGMipAddress
            // 
            this.txtGMipAddress.Location = new System.Drawing.Point(133, 54);
            this.txtGMipAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGMipAddress.Name = "txtGMipAddress";
            this.txtGMipAddress.Size = new System.Drawing.Size(171, 27);
            this.txtGMipAddress.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Beginning IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 315);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 12;
            // 
            // btnGMIpReg
            // 
            this.btnGMIpReg.Location = new System.Drawing.Point(180, 11);
            this.btnGMIpReg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGMIpReg.Name = "btnGMIpReg";
            this.btnGMIpReg.Size = new System.Drawing.Size(133, 35);
            this.btnGMIpReg.TabIndex = 13;
            this.btnGMIpReg.Text = "Add GM IP";
            this.btnGMIpReg.UseVisualStyleBackColor = true;
            this.btnGMIpReg.Click += new System.EventHandler(this.btnGMIpReg_Click);
            // 
            // txtGMIpTo
            // 
            this.txtGMIpTo.Location = new System.Drawing.Point(133, 95);
            this.txtGMIpTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGMIpTo.Name = "txtGMIpTo";
            this.txtGMIpTo.Size = new System.Drawing.Size(171, 27);
            this.txtGMIpTo.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ending IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(20, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Set GM IP Address";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnGMIpReg);
            this.panel1.Location = new System.Drawing.Point(-9, 151);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 72);
            this.panel1.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Location = new System.Drawing.Point(17, 38);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(288, 2);
            this.panel4.TabIndex = 120;
            // 
            // FormGM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 205);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGMIpTo);
            this.Controls.Add(this.txtGMipAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGM";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".:: Set GM IP ::.";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
