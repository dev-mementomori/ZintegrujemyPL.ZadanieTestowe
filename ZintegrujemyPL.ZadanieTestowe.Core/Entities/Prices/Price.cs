using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Base;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Entities.Prices
{
    public class Price : Entity
    {
        public string ProductSKU { get; set; }
        public decimal NettProductPriceAfterDiscountForProductLogisticUnit { get; set; }
    }
}
