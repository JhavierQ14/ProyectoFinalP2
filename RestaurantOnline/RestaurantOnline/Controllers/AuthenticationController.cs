using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantOnline.Controllers
{
    public class AuthenticationController : Controller
    {
        private ApplicationDbContext db;

        public AuthenticationController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public async Task<IActionResult> Log(tbl_User users)
        {
            var log = await db.tbl_User.Where(a => a.correoU.Equals(users.correoU)).FirstOrDefaultAsync();

            if (log != null)
            {
                if (HashHelper.CheckHash(users.contraU, log.contraU, log.encryptionU))
                {
                    var nameUser = log.nombreU + log.apellidoU;
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, log.usuario_id.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, nameUser));
                    identity.AddClaim(new Claim(ClaimTypes.Email, log.correoU));
                    identity.AddClaim(new Claim("Dato", "Valor"));
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, 
                        new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(1), IsPersistent = true });

                    return /*Ok(log);*/  Redirect("/Home/Index");
                }
                else
                {

                    return View("LogIn");
                }

            }
            else
            {
                string mens = "El usuario no existe";
                ViewBag.alert1 = mens;
                return View("LogIn");
            }
        }

        public async Task<IActionResult> LogOt()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Authentication/LogIn");
        }


        [BindProperty]
        public tbl_User user { get; set; }
        [HttpPost]
        public async Task<IActionResult> Succes()
        {
            var result = await db.tbl_User.Where(x => x.correoU == user.correoU).SingleOrDefaultAsync();
            if (result != null)
            {
                return BadRequest(new JObject(){{ "StatusCode", 400 },{ "Message", "El usuario ya existe, seleccione otro." }});
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)).ToList());
                }
                else
                {
                    var hash = HashHelper.Hash(user.contraU);
                    user.contraU = hash.Password;
                    user.encryptionU = hash.Salt;
                    user.rolUser_Fk = 1;
                    db.tbl_User.Add(user);
                    await db.SaveChangesAsync();
                    //user.Clave = "";
                    //user.Sal = "";
                    return Created($"/Usuarios/{user.usuario_id}", user) /*Redirect("/Authentication/LogIn")*/;
                }
            }
        }
    }
}

//[BindProperty]
//public tbl_User users { get; set; }
//public async Task<IActionResult> Log()
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest(new JObject()
//        {
//            {"StatusCode", 400 },
//            {"Message", "El usuario Existe"}
//        });
//    }
//    else
//    {
//        var result = await db.tbl_User.Where(x => x.correoU == users.correoU).SingleOrDefaultAsync();

//        if (result == null)
//        {
//            return NotFound(new JObject()
//            {
//                {"StatusCode", 404},
//                {"Message", "Usuario no encontrado"}

//            });
//        }
//        else
//        {
//            if (HashHelper.CheckHash(users.contraU, result.contraU, result.encryptionU))
//            {
//                //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
//                //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.IdUsuario.ToString()));
//                //identity.AddClaim(new Claim(ClaimTypes.Name, result.Nombre));
//                //identity.AddClaim(new Claim(ClaimTypes.Email, "jose.jairo.fuentes@gmail.com"));
//                //identity.AddClaim(new Claim("Dato", "Valor"));
//                //var principal = new ClaimsPrincipal(identity);
//                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
//                //    new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(2), IsPersistent = true });
//                return Ok(/*result) /*Redirect("/Home/Index")*/;
//            }
//            else
//            {
//                var response = new JObject() {
//                    { "StatusCode", 403 },
//                    { "Message", "Usuario o contraseña no válida." }
//                };
//                return StatusCode(403, response);
//            }
//        }
//    }

//}