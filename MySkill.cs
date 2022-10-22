internal class MySkill
{
    public const int swordSkill = 0;

    public const int magicSkill = 20;

    public const int upgradeSkill = 52;

    public static string encryptedSkill(int skNum, int skLv, int skSlot)
    {
        string text = "";
        text += MyMath.dec2hex(skNum, 4);
        text = text.Substring(2, 2) + text.Substring(0, 2);
        text += MyMath.dec2hex(skLv, 2);
        text += MyMath.dec2hex(skSlot, 2);
        return text + "00";
    }
}
