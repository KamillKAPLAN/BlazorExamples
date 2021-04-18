using System.ComponentModel.DataAnnotations;

namespace AdoNetCRUD.Data.AdoNet_SP
{
    public class CustomerInfo
    {
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
