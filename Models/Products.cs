using Newtonsoft.Json;

namespace BlzMauiApp.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string PageTitle { get; set; }
        public string SearchTitle { get; set; }

        public string SKU { get; set; }

        public long[] CatID { get; set; }
        public string CatName { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string ProductCode { get; set; }
        public string OwnCode { get; set; }
        public int CurrentStock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MrpPrice { get; set; }
        public int Unit { get; set; }
        public string UnitName { get; set; }
        public int UnitID { get; set; }
        public int WholeUnitID { get; set; }
        public decimal ConversionValue { get; set; }
        public string Origin { get; set; }
        public int SupplierID { get; set; }
        public double Commission { get; set; }
        public string TagWords { get; set; }
        public string TagLine { get; set; }
        public string ProductDetails { get; set; }
        public string AdditionalInfo { get; set; }
        public string SmallDesc { get; set; }
        public bool Featured { get; set; }
        public bool FreeShipping { get; set; }
        public bool NewArrival { get; set; }
        public bool BestSelling { get; set; }
        public string CashbackStatus { get; set; }
        public double Cashback { get; set; }
        public string Febric { get; set; }
        public string Meterial { get; set; }
        public string ProductType { get; set; }
        public string DiscountType { get; set; }
        public double DiscountPercent { get; set; }
        public double DiscountAmt { get; set; }
        public int UserID { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public bool IsStatus { get; set; }
        public string TaxRules { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public string SmallImg { get; set; }
    }

    public class ProductList
    {
        [JsonProperty("items")]
        public List<Products> Items { get; set; }

        [JsonProperty("TotalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("previousPage")]
        public string PreviousPage { get; set; }

        [JsonProperty("nextPage")]
        public string NextPage { get; set; }
    }
}
