using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aula37E_Players_AspNETCore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Aula37E_Players_AspNETCore.Controllers
{
    public class NoticiasController : Controller
    {
        Noticias noticiasModel = new Noticias();
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias novaNoticia = new Noticias();
            novaNoticia.IdNoticias = Int32.Parse(form["IdNoticias"]);
            novaNoticia.Titulo = form["Titulo"];
            var file = form.Files[0];
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if (file != null){
                if (!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create)){
                    file.CopyTo(stream);
                }
                novaNoticia.Imagem = file.FileName;
            }else{
                novaNoticia.Imagem = "padrao.png";
            }

            noticiasModel.Create(novaNoticia);
            ViewBag.Noticias = noticiasModel.ReadAll();

            return LocalRedirect("~/Noticias");
        }

        [Route("Noticias/{id}")]
        public IActionResult Excluir(int id){
            noticiasModel.Delete(id);
            return LocalRedirect("~/Noticias");
        }
    }
}
