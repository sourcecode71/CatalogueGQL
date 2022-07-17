namespace Catalogue.Shared.Models
{
   public class BaseEntity 
    {
        public int SetUser { get; set; }
        public DateTime SetDate { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            SetDate = DateTime.Now;
            IsDeleted = false;
        }
    }
}
