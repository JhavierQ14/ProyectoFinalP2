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
        public IActionResult Registro(string nombreU,string apellidoU, string correoU, string contraU) 
        {
            tbl_User user = new tbl_User();
            user.nombreU = nombreU;
            user.apellidoU = apellidoU;
            user.correoU = correoU;
            user.contraU = contraU;

            iusuario.Insert(user);

            return Redirect("/Index/Principal");
        }
    }
}
