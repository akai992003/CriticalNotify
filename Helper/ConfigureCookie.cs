using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace CriticalNotify.Helper;

internal class ConfigureCookie : IConfigureNamedOptions<CookieAuthenticationOptions>                     

{
public ConfigureCookie() { }

        public void Configure(string name, CookieAuthenticationOptions options)
        {
            // Only configure the schemes you want

            if (name == "Cookies")
            {
                // options.LoginPath = "/someotherpath";
            }
       
        }

        public void Configure(CookieAuthenticationOptions options) => Configure(Options.DefaultName, options);
}
