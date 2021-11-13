using Microsoft.AspNetCore.Authentication.Cookies;
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

        [BindProperties ]
        public async Task<IActionResult> Log(tbl_User User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new JObject()
                {

                    {"  StatusCode",400 },

                    {"Message", "Error"}
                });
            }
            else
            {
                var Result = await db.tbl_User.Where(x => x.correoU == User.correoU).SingleOrDefaultAsync();

                if (Result==null)
                {
                    return NotFound(new JObject()
                    {

                    {"  StatusCode",404 },

                    {"Message", "Usuario no encontrado"}

                    });
                }
                else
                {
                    if (HashHelper.CheckHash(User.contraU, Result.contraU, Result.encryptionU))
                    {
                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, Result.IdUsuario.ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.Name, result.Nombre));
                        identity.AddClaim(new Claim(ClaimTypes.Email, "jose.jairo.fuentes@gmail.com"));
                        identity.AddClaim(new Claim("Dato", "Valor"));
                    }
                }

            }



        }
           




        [BindProperty]
        public tbl_User user { get; set; }
        [HttpPost]
        public async Task<IActionResult> Succes()
        {
            var result = await db.tbl_User.Where(x => x.correoU == user.correoU).SingleOrDefaultAsync();
            if (result != null)
            {
                return BadRequest(new JObject() {
                    { "StatusCode", 400 },
                    { "Message", "El usuario ya existe, seleccione otro." }
                });
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
                    return /*Created($"/Usuarios/{user.usuario_id}", user)*/ Redirect("/Authentication/LogIn");
                }
            }
        }


    }
}
