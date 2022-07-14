using System.Diagnostics;
using CriticalNotify.Data;
using CriticalNotify.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CriticalNotify.Controllers;


public class LoginController : Controller
{

    private readonly I人事資料檔Service I人事資料;


    public LoginController(ILogger<LoginController> logger, I人事資料檔Service _I人事資料)
    {
        I人事資料 = _I人事資料;
    }

    [HttpPost]
    public async Task<IActionResult> Auth(LoginAuth dto)
    {
        var q = await I人事資料.Get人事資料檔ByID(dto.id);
        if (q.counter > 0)
        {
            // 建立 Claim，寫到 Cookie 的內容
            var claims = new[] {
                new Claim ("UserId", q.counter.ToString ()),
                new Claim ("UserName", q.姓名),
                new Claim ("Role", q.電話.ToString())
            };

            ClaimsIdentity claimsIdentity = new(claims, "Cookies");
            ClaimsPrincipal principal = new(claimsIdentity);
            await HttpContext.SignInAsync(principal, new AuthenticationProperties()
            {
                // 是否可以被更新
                AllowRefresh = true,
                // IsPersistent = false，瀏覽器關閉即刻登出
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30)
            });
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return RedirectToAction("Auth", "Login");
        }

    }
    [HttpGet]
    public IActionResult Auth()
    {
        var q = new LoginAuth();
        return View(q);
    }
}
