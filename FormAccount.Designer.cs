using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using CabalGM1;

public class FormAccount : Form
{
    private IContainer components = null;

    private Label lblUser;

    private Label lblPass;

    private Button btnAccntCreate;

    private TextBox txtUser;

    private TextBox txtPass;

    private TextBox txtPassVerify;

    private Label label3;

    private Label label5;

    private Label label6;

    private TextBox txtEmail;

    private Label label1;

    private Label label2;

    private TextBox txtAnswer;

    private Panel panel1;

    private ComboBox cbQuestion;

    private Panel panel4;

    public FormAccount()
    {
        InitializeComponent();
    }

    private void btnAccntCreate_Click(object sender, EventArgs e)
    {
        if (txtUser.Text == "")
        {
            MessageBox.Show("UserName is NOT correct", "Error");
        }
        else if (txtPass.Text == "")
        {
            MessageBox.Show("Password is NOT correct", "Error");
        }
        else if (txtPass.Text != txtPassVerify.Text)
        {
            MessageBox.Show("Please re-type password and Verify Password again.", "Error");
        }
        else if (txtPass.Text == txtPassVerify.Text && txtPass.Text != "" && txtUser.Text != "")
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new SqlParameter("@id", txtUser.Text));
            arrayList.Add(new SqlParameter("@password", txtPassVerify.Text));
            arrayList.Add(new SqlParameter("@email", txtEmail.Text));
            arrayList.Add(new SqlParameter("@question", cbQuestion.SelectedItem));
            arrayList.Add(new SqlParameter("@answer", txtAnswer.Text));
            arrayList.Add(new SqlParameter("@ip", "192.168.1.99"));
            if (UtilityDatabase.execStoredPro(GlobalClass.SQLAccountDB, "cabal_tool_registerAccount_web", arrayList))
            {
                MessageBox.Show("Account Created Successfully!", "Success.");
                Close();
            }
        }
    }

    private void FormAccount_Load(object sender, EventArgs e)
    {
        ArrayList arrayList = new ArrayList();
        arrayList.Add("What is the name of your best friend from childhood?");
        arrayList.Add("What was the name of your first stuffed animal?");
        arrayList.Add("What is your oldest sibling's middle name?");
        arrayList.Add("What school did you attend for sixth grade?");
        cbQuestion.DataSource = arrayList;
        cbQuestion.SelectedIndex = 0;
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
        this.lblUser = new System.Windows.Forms.Label();
        this.lblPass = new System.Windows.Forms.Label();
        this.btnAccntCreate = new System.Windows.Forms.Button();
        this.txtUser = new System.Windows.Forms.TextBox();
        this.txtPass = new System.Windows.Forms.TextBox();
        this.txtPassVerify = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.txtEmail = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.txtAnswer = new System.Windows.Forms.TextBox();
        this.panel1 = new System.Windows.Forms.Panel();
        this.cbQuestion = new System.Windows.Forms.ComboBox();
        this.panel4 = new System.Windows.Forms.Panel();
        this.panel1.SuspendLayout();
        base.SuspendLayout();
        this.lblUser.AutoSize = true;
        this.lblUser.Location = new System.Drawing.Point(38, 36);
        this.lblUser.Name = "lblUser";
        this.lblUser.Size = new System.Drawing.Size(55, 13);
        this.lblUser.TabIndex = 0;
        this.lblUser.Text = "Username";
        this.lblPass.AutoSize = true;
        this.lblPass.Location = new System.Drawing.Point(40, 62);
        this.lblPass.Name = "lblPass";
        this.lblPass.Size = new System.Drawing.Size(53, 13);
        this.lblPass.TabIndex = 1;
        this.lblPass.Text = "Password";
        this.btnAccntCreate.Location = new System.Drawing.Point(177, 9);
        this.btnAccntCreate.Name = "btnAccntCreate";
        this.btnAccntCreate.Size = new System.Drawing.Size(100, 23);
        this.btnAccntCreate.TabIndex = 7;
        this.btnAccntCreate.Text = "Create Account";
        this.btnAccntCreate.UseVisualStyleBackColor = true;
        this.btnAccntCreate.Click += new System.EventHandler(btnAccntCreate_Click);
        this.txtUser.Location = new System.Drawing.Point(99, 33);
        this.txtUser.Name = "txtUser";
        this.txtUser.Size = new System.Drawing.Size(169, 20);
        this.txtUser.TabIndex = 1;
        this.txtPass.Location = new System.Drawing.Point(99, 59);
        this.txtPass.Name = "txtPass";
        this.txtPass.PasswordChar = '*';
        this.txtPass.Size = new System.Drawing.Size(169, 20);
        this.txtPass.TabIndex = 2;
        this.txtPassVerify.Location = new System.Drawing.Point(99, 85);
        this.txtPassVerify.Name = "txtPassVerify";
        this.txtPassVerify.PasswordChar = '*';
        this.txtPassVerify.Size = new System.Drawing.Size(169, 20);
        this.txtPassVerify.TabIndex = 3;
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(11, 88);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(82, 13);
        this.label3.TabIndex = 8;
        this.label3.Text = "Verify Password";
        this.label5.AutoSize = true;
        this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.label5.Location = new System.Drawing.Point(15, 9);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(33, 13);
        this.label5.TabIndex = 15;
        this.label5.Text = "User";
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(61, 114);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(32, 13);
        this.label6.TabIndex = 17;
        this.label6.Text = "Email";
        this.txtEmail.Location = new System.Drawing.Point(98, 111);
        this.txtEmail.Name = "txtEmail";
        this.txtEmail.Size = new System.Drawing.Size(169, 20);
        this.txtEmail.TabIndex = 4;
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(44, 140);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(49, 13);
        this.label1.TabIndex = 19;
        this.label1.Text = "Question";
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(51, 166);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(42, 13);
        this.label2.TabIndex = 21;
        this.label2.Text = "Answer";
        this.txtAnswer.Location = new System.Drawing.Point(97, 163);
        this.txtAnswer.Name = "txtAnswer";
        this.txtAnswer.Size = new System.Drawing.Size(169, 20);
        this.txtAnswer.TabIndex = 6;
        this.panel1.BackColor = System.Drawing.SystemColors.Control;
        this.panel1.Controls.Add(this.btnAccntCreate);
        this.panel1.Location = new System.Drawing.Point(-11, 207);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(313, 49);
        this.panel1.TabIndex = 22;
        this.cbQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbQuestion.FormattingEnabled = true;
        this.cbQuestion.Location = new System.Drawing.Point(97, 136);
        this.cbQuestion.Name = "cbQuestion";
        this.cbQuestion.Size = new System.Drawing.Size(169, 21);
        this.cbQuestion.TabIndex = 5;
        this.panel4.BackColor = System.Drawing.Color.DimGray;
        this.panel4.Location = new System.Drawing.Point(8, 25);
        this.panel4.Name = "panel4";
        this.panel4.Size = new System.Drawing.Size(260, 1);
        this.panel4.TabIndex = 120;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.ClientSize = new System.Drawing.Size(282, 247);
        base.Controls.Add(this.panel4);
        base.Controls.Add(this.cbQuestion);
        base.Controls.Add(this.panel1);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.txtAnswer);
        base.Controls.Add(this.label1);
        base.Controls.Add(this.label6);
        base.Controls.Add(this.txtEmail);
        base.Controls.Add(this.label5);
        base.Controls.Add(this.label3);
        base.Controls.Add(this.txtPassVerify);
        base.Controls.Add(this.txtPass);
        base.Controls.Add(this.txtUser);
        base.Controls.Add(this.lblPass);
        base.Controls.Add(this.lblUser);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        base.MaximizeBox = false;
        base.MinimizeBox = false;
        base.Name = "FormAccount";
        base.ShowInTaskbar = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = ".:: New Account ::.";
        base.Load += new System.EventHandler(FormAccount_Load);
        this.panel1.ResumeLayout(false);
        base.ResumeLayout(false);
        base.PerformLayout();
    }
}
