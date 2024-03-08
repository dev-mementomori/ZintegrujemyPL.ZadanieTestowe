using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Base;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Entities.Inventories
{
    public class Inventory : Entity
    {
        public string SKU { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal ShippingCost { get; set; }
        public string ShippingTime { get; set; }
    }
}
