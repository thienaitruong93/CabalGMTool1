public partial class FormMain : Form
{
    public FormMain()
    {
        InitializeComponent();
        Text = GlobalClass.appName;
        fuc_CharacterInfo1.setFormMain(this);
    }
}