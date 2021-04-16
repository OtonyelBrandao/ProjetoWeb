using Microsoft.AspNetCore.Http;
using Profissionais.Data;
using System;
using System.Collections.Generic;

namespace Profissionais.Repositorios
{
    public interface IGaleriaRepository
    {
        List<Byte[]> GetImagens();
    }
    public class GaleriaRepository : IGaleriaRepository
    {
        private readonly AplicationDbContext db;

        public IFormFile Foto { get; set; }
        public GaleriaRepository(AplicationDbContext db)
        {
            this.db = db;
        }

        public List<byte[]> GetImagens()
        {

            //using (MemoryStream mStream = new MemoryStream())
            //{
            //    img.Save(mStream, Image.RawFormat);
            //    return mStream.ToArray();
            //}
            //var imagens = db.Galeria.ToList();

            throw new NotImplementedException();
        }
    }
}
