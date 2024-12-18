namespace Geometrie.DTO

public class Cercle_DTO
{
    public int? Id { get; set; }
    public Point_DTO Centre { get; set; }
    public double Rayon { get; set; }
    public DateTime? DateDeCreation { get; set; }
    public DateTime? DateDeModification { get; set; }
    public Cercle_DTO()
    {
    }
    public Cercle_DTO(int? id, Point_DTO centre, double rayon)
    {
        Id = id;
        Centre = centre;
        Rayon = rayon;
    }
}
}