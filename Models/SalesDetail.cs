namespace BlzMauiApp.Models
{
    public class SalesDetail
    {
        public int InvDeID { get; set; }
        public int InvID { get; set; }
        public int ProductID { get; set; }
        public int StoreID { get; set; }
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public int Quantity { get; set; }
        public int BonousQty { get; set; }
        public int TotalQty { get; set; }
        public double Price { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        public double PackageSalePrice { get; set; }
        public double PackageDiscountAmt { get; set; }
        public int PackageConversionValue { get; set; }
        public int PackageDiscountPercent { get; set; }
        public string PackageDiscountType { get; set; }
        public int SuppID { get; set; }
        public string SuppStatus { get; set; }
        public string DAddress { get; set; }
        public double CommAmnt { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string UnitName { get; set; }
        public string UnitID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int BranchID { get; set; }
        public int ChallanID { get; set; }
        public int Vid { get; set; }
        public int DebitHead { get; set; }
        public int CreditHead { get; set; }
        public string BranchName { get; set; }
    }
}
