using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsuarioMVC.ServicioUsuario;

namespace UsuarioMVC.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        UsuarioServiceClient srvUsuarios = new UsuarioServiceClient();
        public ActionResult Index()
        {
            return View(srvUsuarios.Consultar()); 
            
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string Nombre)
        {
            var usuario = srvUsuarios.Buscar(Nombre);
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create([Bind(Include="Nombre,FechaNacimiento,sexo")] Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                srvUsuarios.Agregar(usuario.nombre, usuario.FechaNacimiento?.ToString("yyyy-MM-ddT00:00:00"), usuario.sexo); 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string Nombre)
        {
            var usuario = srvUsuarios.Buscar(Nombre);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Nombre,FechaNacimiento,sexo")] Usuario usuario)
        {
            try
            {
                srvUsuarios.Actualizar(usuario.nombre, usuario.FechaNacimiento?.ToString("yyyy-MM-ddT00:00:00"), usuario.sexo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string Nombre)
        {
            var usuario = srvUsuarios.Buscar(Nombre);
            return View(usuario);   
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(string Nombre, FormCollection collection)
        {
            try
            {
                srvUsuarios.Eliminar(Nombre);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
