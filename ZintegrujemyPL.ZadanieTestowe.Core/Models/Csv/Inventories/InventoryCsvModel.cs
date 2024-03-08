namespace ZintegrujemyPL.ZadanieTestowe.Core.Models.Csv.Inventories
{
    public class InventoryCsvModel
    {
        public string SKU { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal ShippingCost { get; set; }
        public string ShippingTime { get; set; }
    }
}
