using System.ComponentModel.DataAnnotations;

namespace ZintegrujemyPL.ZadanieTestowe.Controllers.Products.Models
{
    public class GetProductInformationRequestModel
    {
        [Required]
        public string SKU { get; set; }
    }
}
