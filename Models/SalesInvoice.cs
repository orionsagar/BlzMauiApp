using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzMauiApp.Models
{
    public class SalesInvoice
    {
        public int InvID { get; set; }
        public string InvNo { get; set; }
        public double SubTotal { get; set; }
        public double DelvCharge { get; set; }
        public double DiscAmnt { get; set; }
        public double BonousAmnt { get; set; }
        public int DisPercent { get; set; }
        public string DiscountType { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryType { get; set; }
        public double NetAmnt { get; set; }
        public double InvAmnt { get; set; }
        public double TotalAmount { get; set; }
        public double TotalPaid { get; set; }
        public double ReceivableAmnt { get; set; }
        public double CourrierCharge { get; set; }
        public string InvStatus { get; set; }
        public string PayType { get; set; }
        public string ContactName { get; set; }
        public string InvStatusforBuyer { get; set; }
        public string PaymentType { get; set; }
        public string MemberType { get; set; }
        public string AreaName { get; set; }
        public string ZoneName { get; set; }
        public string BranchName { get; set; }
        public string ChallanDate { get; set; }
        public int DiscID { get; set; }
        public int TotalQty { get; set; }
        public int DOQty { get; set; }
        public int? BuyerID { get; set; }
        public int? BranchID { get; set; }
        public int? SelectedBranchID { get; set; }
        public int? SelectedRepresentativeId { get; set; }
        public int? ZoneID { get; set; }
        public int? AreaID { get; set; }
        public int? CusID { get; set; }
        public int? ContactID { get; set; } // refer person
        public int ReferPersonID { get; set; }
        public int? RepresentativeId { get; set; }
        public int SRID { get; set; }
        public string RepresentativeName { get; set; }
        public string MRName { get; set; }
        public string SRName { get; set; }
        public string BuyerFName { get; set; }
        public string BuyerLName { get; set; }
        public string Address { get; set; }
        public string BCity { get; set; }
        public string BEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string BPhone1 { get; set; }
        public string BPhone2 { get; set; }
        public string BNote { get; set; }
        public bool DelvDiff { get; set; }
        public string DFname { get; set; }
        public string DLname { get; set; }
        public string DAddress { get; set; }
        public string DCity { get; set; }
        public string DEmail { get; set; }
        public string DPhone1 { get; set; }
        public string DPhone2 { get; set; }
        public int DCityID { get; set; }
        public string DNote { get; set; }
        public int AffiliateID { get; set; }
        public double AffiliateComm { get; set; }
        public string CardNo { get; set; }
        public string CardOwner { get; set; }
        public string CardType { get; set; }
        public double GatewayCharge { get; set; }
        public string BankName { get; set; }
        public string GatewayTransID { get; set; }
        public string BKashNo { get; set; }
        public int? Operator { get; set; }
        public string OldInvDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AcceptDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DeliveryDate { get; set; }
        public string DeliveryBy { get; set; }
        public string Comment { get; set; }
        public int CountryID { get; set; }
        public int ContactNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EntryDate { get; set; }
        public int? DCountryID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }
        public DateTime InActiveDate { get; set; }
        public int CourierID { get; set; }
        public string CourrierName { get; set; }
        public string District { get; set; }
        public string DDistrict { get; set; }
        public double Advance { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Saledate { get; set; }
        public string CD_Date { get; set; }
        public int CDMID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string OrderDate { get; set; }
        public string UserName { get; set; }
        public double Vat { get; set; }
        public int? LocationID { get; set; }
        public string BKashTransactionID { get; set; }
        public double Balance { get; set; }
        public int? UserId { get; set; }
        public string BuyerName { get; set; }
        public string InvoiceDate { get; set; }
        public bool IsCheck { get; set; }
        public bool IsChallan { get; set; }
        public string error { get; set; }
        public string BirthDate { get; set; }
        public string Project { get; set; }
        public string Barcode { get; set; }
        public string ContactPerson { get; set; }
        public string Approve1 { get; set; }
        public string Approve2 { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DtApprove1 { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DtApprove2 { get; set; }
        public int CompID { get; set; }
        public int RoleId { get; set; }
        public int UpdatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdatedDate { get; set; }
        public int Vid { get; set; }
        public int PaidVId { get; set; }
        public string InsertType { get; set; }
        public string message { get; set; }
        public int CusPayID { get; set; }
        public int SaleReturnVid { get; set; }
        public string ReturnCashVid { get; set; }
        public int TOTALCOUNT { get; set; }
        public List<PrintInvoice> SDVMS { get; set; }
        public List<SalesDetail> sdvm { get; set; }
    }
    public class SalesInvoiceList
    {
        [JsonProperty("items")]
        public List<SalesInvoice> items { get; set; }
        //public PagingParameterModel parameterModel { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("pageSize")]
        public int pageSize { get; set; }

        [JsonProperty("currentPage")]
        public int currentPage { get; set; }

        [JsonProperty("previousPage")]
        public string previousPage { get; set; }

        [JsonProperty("nextPage")]
        public string nextPage { get; set; }
    }
}
