using CsvHelper.Configuration.Attributes;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Models.Csv.Products
{
    public class ProductCsvModel
    {

        [Name("SKU")]
        public string SKU { get; set; }

        [Name("name")]
        public string Name { get; set; }

        [Name("EAN")]
        public string EAN { get; set; }

        [Name("producer_name")]
        public string ProducerName { get; set; }

        [Name("category")]
        public string Category { get; set; }

        [Name("default_image")]
        public string DefaultImage { get; set; }

        [Name("is_wire")]
        public bool IsWire { get; set; }
    }
}
