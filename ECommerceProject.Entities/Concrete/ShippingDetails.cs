using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Entities.Concrete;
public class ShippingDetails
{
    [Required]
    public string ? Firstname { get; set; }

    [Required]
    public string ? Lastname { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string ? Email { get; set; }

    [Required]
    public string ? City { get; set; }

    [Required]
    public string ? Address { get; set; }

    [Required]
    [Range(18,75)]
    public int Age { get; set; }
}
