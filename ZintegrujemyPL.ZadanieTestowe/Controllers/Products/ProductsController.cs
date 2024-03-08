using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZintegrujemyPL.ZadanieTestowe.Controllers.Products.Models;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Products;

namespace ZintegrujemyPL.ZadanieTestowe.Controllers.Products
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProductInformation")]
        public async Task<IActionResult> GetProductInformation(GetProductInformationRequestModel getProductInformationRequestModel)
        {
            var productInformation = await _productService.GetProductInformation(getProductInformationRequestModel.SKU);
           
            if (productInformation != null)
            {
                return Ok(productInformation);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
