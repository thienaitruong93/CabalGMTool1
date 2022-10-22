using System.Globalization;
using System.Text;

internal class MyMath
{
    public static string dec2hex(int decval, bool pad)
    {
        string text = "00000000";
        if (pad)
        {
            text += decval.ToString("X");
            return text.Substring(text.Length - 8, 8);
        }
        return decval.ToString("X");
    }

    public static string dec2hex(int decval, int padNum)
    {
        string text = "00000000";
        text += decval.ToString("X");
        return text.Substring(text.Length - padNum, padNum);
    }

    public static string doubledec2hex(int decval1, int decval2)
    {
        string text = "0000";
        string text2 = "";
        string text3 = "";
        text2 = text + decval1.ToString("X");
        text2 = text2.Substring(text2.Length - 4, 4);
        text3 = text + decval2.ToString("X");
        text3 = text3.Substring(text3.Length - 4, 4);
        return text2 + text3;
    }

    public static int hex2dec(string hexval)
    {
        return int.Parse(hexval, NumberStyles.HexNumber);
    }

    public static string ByteArrayToString(byte[] ba)
    {
        string text = BitConverter.ToString(ba);
        return text.Replace("-", "");
    }

    public static byte[] StringToByteArray(string hex)
    {
        int length = hex.Length;
        byte[] array = new byte[length / 2];
        for (int i = 0; i < length; i += 2)
        {
            array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return array;
    }

    public static int DBO_BINTOINT(string hex)
    {
        string text = "";
        for (int num = hex.Length; num > 0; num -= 2)
        {
            text += hex.Substring(num - 2, 2);
        }
        return hex2dec(text);
    }

    public static bool IsValidNumeric(string inputStr)
    {
        if (string.IsNullOrEmpty(inputStr))
            return false;
        for (int i = 0; i < inputStr.Length; i++)
        {
            if (!(char.IsNumber(inputStr[i])))
                return false;
        }
        return true;
    }

    public static string BytesToHex(byte[] bytes)
    {
        StringBuilder hexString = new StringBuilder(bytes.Length);
        for (int i = 0; i < bytes.Length; i++)
        {
            hexString.Append(bytes[i].ToString("X2"));
        }
        return hexString.ToString();
    }
}
