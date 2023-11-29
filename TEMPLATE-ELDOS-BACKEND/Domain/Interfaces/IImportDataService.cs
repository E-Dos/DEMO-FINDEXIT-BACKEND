namespace TEMPLATE_ELDOS_BACKEND.Domain.Interfaces
{
    public interface IImportDataService
    {
        Task ParsingData(IFormFile files);
    }
}
