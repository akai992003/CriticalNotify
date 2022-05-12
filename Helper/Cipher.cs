namespace CriticalNotify.Helper;

public class Cipher
{
    public static string Encryption(string s)
    {
        var _Encryption = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(s)).Replace("+", "% 2B");
        return _Encryption;
    }

    public static string Decrypt(string s)
    {
        var _Decrypt = System.Text.Encoding.Default.GetString(Convert.FromBase64String(s.ToString().Replace("+", "% 2B")));
        return _Decrypt;
    }
}