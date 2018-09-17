namespace InfoSystem.Infrastructure.Interfaces
{
    public interface IProduct
    {
        string Title { get; }
        string Category { get; }
        double Cost { get; }
        string Manufacturer { get; }
        string ManufacturerOrigin { get; }
    }
}