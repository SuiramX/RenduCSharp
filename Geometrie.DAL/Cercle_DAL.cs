using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DAL
{
    public class Cercle_DAL(int rayon)
    {
        private global::Point_DTO centre;

        public int? Id { get; set; }
        public double Rayon { get; set; } = rayon;
        public int CentreX { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime? DateDeModification { get; set; }

        public Cercle_DAL(int id, int rayon, double rayon1)
            : this(rayon)
        {
            Id = id;
        }

        public Cercle_DAL(global::Point_DTO centre, double rayon)
        {
            this.centre = centre;
            Rayon = rayon;
        }
    }
}
