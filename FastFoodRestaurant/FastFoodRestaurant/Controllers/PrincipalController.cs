using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodRestaurant.Service;
using FastFoodRestaurant.Entidades;

namespace FastFoodRestaurant.Controllers
{
    public class PrincipalController : Controller
    {

        private IUsuario iusuario;

        public PrincipalController(IUsuario iusuario)
        {

            this.iusuario = iusuario;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(tbl_User u) 
        {
            tbl_User user = new tbl_User();
            user.nombreU = u.nombreU;
            user.apellidoU = u.apellidoU;
            user.telefonoU = u.telefonoU;
            user.correoU = u.correoU;
            user.contraU = u.contraU;

            iusuario.Insert(user);

            return Redirect("/Principal/Index");
        }
    }
}
