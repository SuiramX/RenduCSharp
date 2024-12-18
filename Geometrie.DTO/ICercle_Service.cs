using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DTO
{
    public interface ICercle_Service : IService<Cercle_DTO>
    {
        public double CalculAireCercles(string IP, params Cercle_DTO[] cercles);
        double CalculerAire(Cercle_DTO cercle);
        double CalculerPerimetre(Cercle_DTO cercle);
    }
}
