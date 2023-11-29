namespace TEMPLATE_ELDOS_BACKEND.Models
{
    public abstract class BaseModel
    {
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
