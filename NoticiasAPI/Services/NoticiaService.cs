using Microsoft.EntityFrameworkCore;
using NoticiasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI.Services
{
    public class NoticiaService
    {
        private readonly NoticiasDBContext _noticiaDBContext;

        public NoticiaService(NoticiasDBContext noticiaDBContext)
        {
            this._noticiaDBContext = noticiaDBContext;
        }

        public List<Noticia> Obtener(){
            var resultado = _noticiaDBContext.Noticia.Include(x=>x.Autor).ToList();
            return resultado;
        }

        public bool AgregarNoticia(Noticia _noticia)
        {
            try
            {
                this._noticiaDBContext.Noticia.Add(_noticia);
                this._noticiaDBContext.SaveChanges();


                return true;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
                return false;
            }
            
        }
               
        public bool EditarNoticia(Noticia _noticia)
        {
            try
            {
                var NoticiaDB = this._noticiaDBContext.Noticia.Where(x => x.NoticiaID == _noticia.NoticiaID).FirstOrDefault();
                NoticiaDB.Titulo = _noticia.Titulo;
                NoticiaDB.Descripcion = _noticia.Descripcion;
                NoticiaDB.Contenido = _noticia.Contenido;
                NoticiaDB.Fecha = _noticia.Fecha;
                NoticiaDB.AutorID = _noticia.AutorID;

                this._noticiaDBContext.SaveChanges();

                return true;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
                return false;
            }
        }
    }
}
