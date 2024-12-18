using Geometrie.BLL;
using Geometrie.BLL.Depots;
using Geometrie.DAL;
using Geometrie.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometrie.Service
{
    public class Cercle_Service : ICercle_Service
    {
        private readonly GeometrieContext _context;
        private readonly IDepot<Cercle_DTO> _cercleDepot;

        public Cercle_Service(GeometrieContext context, IDepot<Cercle_DTO> cercleDepot)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _cercleDepot = cercleDepot ?? throw new ArgumentNullException(nameof(cercleDepot));
        }

        // Ajouter un cercle
        public Cercle_DTO Add(Cercle_DTO element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            var cercle_DAL = new Cercle_DAL(element.Centre.X, element.Centre.Y, element.Rayon);
            cercle_DAL = _cercleDepot.Add(cercle_DAL);
            return new Cercle_DTO(cercle_DAL.Id, new Point_DTO { X = cercle_DAL.CentreX }, cercle_DAL.Rayon)
            {
                DateDeCreation = cercle_DAL.DateDeCreation,
                DateDeModification = cercle_DAL.DateDeModification
            };
        }

        // Calculer le périmètre
        public double CalculerPerimetre(Cercle_DTO cercle)
        {
            return 2 * Math.PI * cercle.Rayon;
        }

        // Calculer l'aire
        public double CalculerAire(Cercle_DTO cercle)
        {
            return Math.PI * Math.Pow(cercle.Rayon, 2);
        }

        // Récupérer un cercle par ID
        public Cercle_DTO GetById(int id)
        {
            var cercle_DAL = _cercleDepot.GetById(id);
            if (cercle_DAL == null)
                return null;

            return new Cercle_DTO(cercle_DAL.Id, new Point_DTO { X = cercle_DAL.CentreX }, cercle_DAL.Rayon)
            {
                DateDeCreation = cercle_DAL.DateDeCreation,
                DateDeModification = cercle_DAL.DateDeModification
            };
        }

        // Récupérer tous les cercles
        public IEnumerable<Cercle_DTO> GetAll()
        {
            var cercles_DAL = _cercleDepot.GetAll();
            return cercles_DAL.Select(cercle_DAL => new Cercle_DTO(cercle_DAL.Id, new Point_DTO { X = cercle_DAL.CentreX }, cercle_DAL.Rayon)
            {
                DateDeCreation = cercle_DAL.DateDeCreation,
                DateDeModification = cercle_DAL.DateDeModification
            });
        }

        // Mettre à jour un cercle
        public Cercle_DTO Update(Cercle_DTO element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            var cercle_DAL = new Cercle_DAL(element.Centre.X, element.Centre.Y, element.Rayon)
            {
                Id = element.Id ?? throw new ArgumentNullException(nameof(element.Id))
            };

            cercle_DAL = _cercleDepot.Update(cercle_DAL);
            return new Cercle_DTO(cercle_DAL.Id, new Point_DTO { X = cercle_DAL.CentreX }, cercle_DAL.Rayon)
            {
                DateDeCreation = cercle_DAL.DateDeCreation,
                DateDeModification = cercle_DAL.DateDeModification
            };
        }

        // Supprimer un cercle
        public void Delete(int id)
        {
            _cercleDepot.Delete(id);
        }

        public double CalculAireCercles(string IP, params Cercle_DTO[] cercles)
        {
            if (cercles == null)
                throw new ArgumentNullException(nameof(cercles));
            double aire = 0;
            foreach (var cercle in cercles)
            {
                aire += CalculerAire(cercle);
            }
            return aire;
        }

        public IService<Cercle_DTO> Delete(Cercle_DTO element)
        {
            throw new NotImplementedException();
        }

        IService<Cercle_DTO> IService<Cercle_DTO>.Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
