namespace Mahwous.Core.Models
{
    public class StatusCategories
    {
        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
