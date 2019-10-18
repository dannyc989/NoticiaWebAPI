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



    }
}
