using Newtonsoft.Json.Linq;

namespace CriticalNotify.Helper;

public class UStore
{
    public static string GetUStore(string ConfigurationStirng, string type)
    {
        if (ConfigurationStirng == "")
        {
            using (StreamReader streamReader = new StreamReader("ap.json"))
            {
                string json = streamReader.ReadToEnd();
                dynamic val = JArray.Parse(json);
                dynamic val2 = val[0];

                foreach (var p in val2)
                {
                    if (type == p.Name)
                    {
                        return p.Value;
                    }
                }
            }
        }
        return ConfigurationStirng;
    }

    public static string GetConn(IConfiguration _IConf, string name)
    {
        // ConfigurationStirng = 

        if (_IConf.GetConnectionString(name) == "")
        {
            var account = Cipher.Decrypt(GetUStore("", "account"));
            var mima = Cipher.Decrypt(GetUStore("", "mima"));
            var conn = GetUStore("", name);
            conn = conn.Replace("xxxx", account);
            conn = conn.Replace("yyyy", mima);
            return conn;
        }
        else
        {
            var account = Cipher.Decrypt(_IConf.GetConnectionString("account"));
            var mima = Cipher.Decrypt(_IConf.GetConnectionString("mima"));
            var conn = _IConf.GetConnectionString(name);
            conn = conn.Replace("xxxx", account);
            conn = conn.Replace("yyyy", mima);
            return conn;
        }

    }

    

}