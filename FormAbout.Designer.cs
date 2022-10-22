using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class FormAbout : Form
{
    private IContainer components = null;

    private PictureBox pictureBox1;

    private Label label1;

    private Label label2;

    private Label label3;

    private Label label4;

    private PictureBox pictureBox2;

    private Button btClose;

    private Label label5;

    private Label label6;

    private Label label7;

    private Label label9;

    private Label label10;

    private Label label8;

    private Label label11;

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
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.pictureBox2 = new System.Windows.Forms.PictureBox();
        this.btClose = new System.Windows.Forms.Button();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.label7 = new System.Windows.Forms.Label();
        this.label9 = new System.Windows.Forms.Label();
        this.label10 = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this.label11 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
        base.SuspendLayout();
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label1.Location = new System.Drawing.Point(596, 193);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(224, 20);
        this.label1.TabIndex = 1;
        this.label1.Text = "Copyright © 2022 - ATruong";
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label2.Location = new System.Drawing.Point(602, 355);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(213, 20);
        this.label2.TabIndex = 2;
        this.label2.Text = "Email: thienaitruong93@gmail.com";
        this.label3.AutoSize = true;
        this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label3.Location = new System.Drawing.Point(650, 253);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(116, 20);
        this.label3.TabIndex = 3;
        this.label3.Text = "License: FREE";
        this.label4.AutoSize = true;
        this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label4.Location = new System.Drawing.Point(662, 224);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(93, 20);
        this.label4.TabIndex = 4;
        this.label4.Text = "Version: 1.0";
        this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        this.pictureBox1.Image = null;
        this.pictureBox1.Location = new System.Drawing.Point(-19, 1);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(927, 160);
        this.pictureBox1.TabIndex = 0;
        this.pictureBox1.TabStop = false;
        this.pictureBox2.Image = null;
        this.pictureBox2.Location = new System.Drawing.Point(32, 189);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(200, 205);
        this.pictureBox2.TabIndex = 30;
        this.pictureBox2.TabStop = false;
        this.btClose.Location = new System.Drawing.Point(778, 454);
        this.btClose.Name = "btClose";
        this.btClose.Size = new System.Drawing.Size(75, 23);
        this.btClose.TabIndex = 31;
        this.btClose.Text = "Close";
        this.btClose.UseVisualStyleBackColor = true;
        this.btClose.Click += new System.EventHandler(btClose_Click);
        this.label5.AutoSize = true;
        this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label5.Location = new System.Drawing.Point(340, 193);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(178, 20);
        this.label5.TabIndex = 32;
        this.label5.Text = "IDE: Visual Studio 2010";
        this.label6.AutoSize = true;
        this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label6.Location = new System.Drawing.Point(296, 224);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(109, 20);
        this.label6.TabIndex = 33;
        this.label6.Text = "Language: C#";
        this.label7.AutoSize = true;
        this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label7.Location = new System.Drawing.Point(290, 253);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(151, 20);
        this.label7.TabIndex = 34;
        this.label7.Text = "Framework: .Net 4.0";
        this.label9.AutoSize = true;
        this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label9.Location = new System.Drawing.Point(376, 411);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(370, 20);
        this.label9.TabIndex = 37;
        this.label9.Text = "Thanks all members of Ragezone forum for sharing";
        this.label10.AutoSize = true;
        this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label10.Location = new System.Drawing.Point(264, 329);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(117, 20);
        this.label10.TabIndex = 38;
        this.label10.Text = "Special thanks:";
        this.label8.AutoSize = true;
        this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label8.Location = new System.Drawing.Point(264, 355);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(266, 20);
        this.label8.TabIndex = 38;
        this.label8.Text = " MisterMinister ( The Divinity Project )";
        this.label11.AutoSize = true;
        this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.label11.Location = new System.Drawing.Point(300, 282);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(161, 20);
        this.label11.TabIndex = 39;
        this.label11.Text = "Work with: Cabal EP8";
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        base.ClientSize = new System.Drawing.Size(865, 489);
        base.Controls.Add(this.label11);
        base.Controls.Add(this.label8);
        base.Controls.Add(this.label10);
        base.Controls.Add(this.label9);
        base.Controls.Add(this.label7);
        base.Controls.Add(this.label6);
        base.Controls.Add(this.label5);
        base.Controls.Add(this.btClose);
        base.Controls.Add(this.pictureBox2);
        base.Controls.Add(this.pictureBox1);
        base.Controls.Add(this.label4);
        base.Controls.Add(this.label3);
        base.Controls.Add(this.label2);
        base.Controls.Add(this.label1);
        base.MaximizeBox = false;
        base.MinimizeBox = false;
        base.Name = "FormAbout";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "FormAbout";
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
        base.ResumeLayout(false);
        base.PerformLayout();
    }

    public FormAbout()
    {
        InitializeComponent();
    }

    private void btClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
