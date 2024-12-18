using Geometrie.DTO;
using Geometrie.Service;
using Microsoft.AspNetCore.Mvc;

namespace Geometrie.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Cercle_Controller : Controller
    {
        private ICercle_Service service;

        public Cercle_Controller(ICercle_Service service)
        {
            this.service = service;
        }

        // Ajouter un cercle
        [HttpPost]
        public Cercle_DTO Add(Cercle_DTO cercle)
        {
            return service.Add(cercle);
        }

        // Supprimer un cercle par son ID
        [HttpPost]
        [ActionName("DeleteById")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }

        // Récupérer tous les cercles
        [HttpGet]
        public IEnumerable<Cercle_DTO> GetAll()
        {
            return service.GetAll();
        }

        // Récupérer un cercle par son ID
        [HttpGet]
        public Cercle_DTO? GetById(int id)
        {
            return service.GetById(id);
        }

        // Mettre à jour un cercle
        [HttpPost]
        public Cercle_DTO Update(Cercle_DTO cercle)
        {
            return service.Update(cercle);
        }

        // Calculer le périmètre d'un cercle
        [HttpPost]
        [ActionName("CalculerPerimetre")]
        public double CalculerPerimetre(Cercle_DTO cercle)
        {
            return service.CalculerPerimetre(cercle);
        }

        // Calculer l'aire d'un cercle
        [HttpPost]
        [ActionName("CalculerAire")]
        public double CalculerAire(Cercle_DTO cercle)
        {
            return service.CalculerAire(cercle);
        }
    }
}
