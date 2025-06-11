namespace Figura.SpeedwayRider.Model.DAO;

public partial class Rider
{
    public Guid Id { get; set; } = Guid.Empty;

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string Nationality { get; set; } = string.Empty;

    public DateOnly DoB { get; set; } = new DateOnly();

    public string PictureUrl { get; set; } = string.Empty;
}
