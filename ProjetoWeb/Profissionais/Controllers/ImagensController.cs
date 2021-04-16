using Microsoft.AspNetCore.Mvc;
using Profissionais.Models.ModelsDb;
using Profissionais.Repositorios;
using System.IO;
using System.Threading.Tasks;

namespace Profissionais.Controllers
{
    public class ImagensController : Controller
    {
        private readonly IProfissionaisRepository profissionaisRepository;

        public ImagensController(IProfissionaisRepository profissionaisRepository)
        {
            this.profissionaisRepository = profissionaisRepository;
        }
        [HttpGet]
        public async Task<FileStreamResult> VerImagem(int? id)
        {
            ProfissionaisT profissional = await profissionaisRepository.Get(id);
            MemoryStream mst = new MemoryStream(profissional.imagem);
            return new FileStreamResult(mst, profissional.ContentType);
        }
    }
}
