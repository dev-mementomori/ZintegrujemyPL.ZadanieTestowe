using ZintegrujemyPL.ZadanieTestowe.Core.Entities.Base;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Entities.Products
{
    public class Product : Entity
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string EAN { get; set; }
        public string ProducerName { get; set; }
        public string Category { get; set; }
        public string DefaultImage { get; set; }
        public bool IsWire { get; set; }
    }
}
