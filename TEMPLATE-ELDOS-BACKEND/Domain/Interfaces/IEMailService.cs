namespace TEMPLATE_ELDOS_BACKEND.Domain.Interfaces
{
    public interface IEMailService
    {
        Task SendMailKit(int fileCount);
    }
}
