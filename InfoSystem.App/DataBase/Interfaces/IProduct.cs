namespace InfoSystem.App.DataBase.Interfaces
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