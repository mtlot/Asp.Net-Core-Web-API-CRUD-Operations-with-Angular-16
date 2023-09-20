using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }

        [Required] 
        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(16)")]
        public string CardNumber { get; set; } = "";


        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public string ExpirationDate { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(3)")]
        public string SecurityCode { get; set; } = "";

    }
}