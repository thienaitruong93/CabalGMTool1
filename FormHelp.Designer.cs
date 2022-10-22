using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CabalGM1;

public class FormHelp : Form
{
    private IContainer components = null;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CabalGM1.FormHelp));
        base.SuspendLayout();
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        base.ClientSize = new System.Drawing.Size(712, 389);
        base.Name = "FormHelp";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "FormHelp";
        base.ResumeLayout(false);
    }

    public FormHelp()
    {
        InitializeComponent();
    }
}
