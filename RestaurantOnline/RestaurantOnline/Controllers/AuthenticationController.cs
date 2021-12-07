using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RestaurantOnline.Data;
using RestaurantOnline.Entidades;
using RestaurantOnline.Helper;
using RestaurantOnline.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using RestaurantOnline.Service;

namespace RestaurantOnline.Controllers
{
    public class AuthenticationController : Controller
    {
        private ApplicationDbContext db;
        private IUsuario iuser;

        public AuthenticationController(ApplicationDbContext db, IUsuario iuser)
        {
            this.db = db;
            this.iuser = iuser;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public async Task<IActionResult> Log(LogInViewModels users)
        {
            if (ModelState.IsValid)
            {
                var log = await db.tbl_User.Include(x => x.TblRolUsuario).Where(a => a.correoU.Equals(users.correoUser)).FirstOrDefaultAsync();

                if (log != null)
                {
                    if (HashHelper.CheckHash(users.contraUser, log.contraU, log.encryptionU))
                    {
                        var nameUser = log.nombreU + " " + log.apellidoU;
                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, log.usuario_id.ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.Name, nameUser));
                        identity.AddClaim(new Claim(ClaimTypes.Email, log.correoU));
                        identity.AddClaim(new Claim(ClaimTypes.Role, log.TblRolUsuario.nombreRol));
                        identity.AddClaim(new Claim("Dato", "Valor"));

                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                            new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(1), IsPersistent = true });

                        var typeUser = log.TblRolUsuario.nombreRol;

                        if (typeUser == "Administrador")
                        {
                            return Redirect("/Administracion/Index");
                        }
                        else
                        {
                            return Redirect("/Home/Index");
                        }
                    }
                    else
                    {
                        ViewBag.MLog = "Usuario o password incorrectas";

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
            else
            {
                return View("LogIn");
            }
        }

        public async Task<IActionResult> LogOt()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Authentication/LogIn");
        }

        [HttpPost]
        public async Task<IActionResult> Succes(LogInViewModels user)
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
                    var tblUser = new tbl_User();

                    tblUser.nombreU = user.nombreU;
                    tblUser.apellidoU = user.apellidoU;
                    tblUser.telefonoU = user.telefonoU;
                    tblUser.correoU = user.correoU;
                    var hash = HashHelper.Hash(user.contraU);
                    tblUser.contraU = hash.Password;
                    tblUser.encryptionU = hash.Salt;
                    tblUser.rolUser_Fk = 1;
                    iuser.Insert(tblUser);
                    //db.tbl_User.Add(tblUser);
                    //await db.SaveChangesAsync();
                    //user.Clave = "";
                    //user.Sal = "";
                    return Created($"/Usuarios/{tblUser.usuario_id}", tblUser);
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