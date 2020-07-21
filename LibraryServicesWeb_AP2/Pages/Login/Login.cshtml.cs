using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibraryServicesWeb_AP2.BLL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryServicesWeb_AP2.Pages.Login
{
    public class LoginModel : PageModel
    {
        public string ReturnUrl { get; set; }

        public async Task<IActionResult>

            OnGetAsync(string paramUsername, string paramPassword)

        {

            string returnUrl = Url.Content("~/");

            try

            {


                await HttpContext

                    .SignOutAsync(

                    CookieAuthenticationDefaults.AuthenticationScheme);

            }

            catch { }


            if (UsuariosBLL.InicioSesion(paramUsername, paramPassword))
            {



                var claims = new List<Claim>

            {

                new Claim(ClaimTypes.Name, paramUsername),

                new Claim(ClaimTypes.Role, "Administrador"),
                new Claim(ClaimTypes.Role, "Usuario"),


            };

                var claimsIdentity = new ClaimsIdentity(

                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties

                {

                    IsPersistent = true,

                    RedirectUri = this.Request.Host.Value

                };

                try

                {

                    await HttpContext.SignInAsync(

                    CookieAuthenticationDefaults.AuthenticationScheme,

                    new ClaimsPrincipal(claimsIdentity),

                    authProperties);

                }

                catch (Exception ex)

                {

                    string error = ex.Message;

                }

            }
            return LocalRedirect(returnUrl);
        }
    }
}
