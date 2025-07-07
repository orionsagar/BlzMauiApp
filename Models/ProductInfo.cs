namespace BlzMauiApp.Models
{
    public class ProductInfo
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public decimal ProductPrice { get; set; } 
        public int Qty { get; set; }
        public int BensQty { get; set; }
        public int TotalQty { get; set; }
        public string Unit { get; set; }
        public int UnitID { get; set; }
        public string Barcode { get; set; }
        public decimal Amount { get; set; }
        public int CurrentStock { get; set; }

    }
}
