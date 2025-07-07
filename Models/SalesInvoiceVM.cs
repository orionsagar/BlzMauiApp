using BlzMauiApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenvuestringMauiApp.Models
{
    public class SalesInvoiceVM
    {
        public string InvID { get; set; }
        public string InvNo { get; set; }
        public string SubTotal { get; set; }
        public string DelvCharge { get; set; }
        public string DiscAmnt { get; set; }
        public string BonousAmnt { get; set; }
        public double DisPercent { get; set; }
        public string DiscountType { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryType { get; set; }
        public string NetAmnt { get; set; }
        public string InvAmnt { get; set; }
        public string TotalAmount { get; set; }
        public string TotalPaid { get; set; }
        public string ReceivableAmnt { get; set; }
        public string CourrierCharge { get; set; }
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
        public string DiscID { get; set; }
        public string TotalQty { get; set; }
        public string DOQty { get; set; }
        public string? BuyerID { get; set; }
        public string? BranchID { get; set; }
        public string? SelectedBranchID { get; set; }
        public string? SelectedRepresentativeId { get; set; }
        public string? ZoneID { get; set; }
        public string? AreaID { get; set; }
        public string? CusID { get; set; }
        public string? ContactID { get; set; } // refer person
        public string ReferPersonID { get; set; }
        public string? RepresentativeId { get; set; }
        public string SRID { get; set; }
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
        public string DCityID { get; set; }
        public string DNote { get; set; }
        public string AffiliateID { get; set; }
        public string AffiliateComm { get; set; }
        public string CardNo { get; set; }
        public string CardOwner { get; set; }
        public string CardType { get; set; }
        public double GatewayCharge { get; set; }
        public string BankName { get; set; }
        public string GatewayTransID { get; set; }
        public string BKashNo { get; set; }
        public string? Operator { get; set; }
        public string OldInvDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AcceptDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DeliveryDate { get; set; }
        public string DeliveryBy { get; set; }
        public string Comment { get; set; }
        public string CountryID { get; set; }
        public string ContactNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EntryDate { get; set; }
        public string? DCountryID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }
        public DateTime InActiveDate { get; set; }
        public string CourierID { get; set; }
        public string CourrierName { get; set; }
        public string District { get; set; }
        public string DDistrict { get; set; }
        public string Advance { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Saledate { get; set; }
        public string CD_Date { get; set; }
        public string CDMID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string OrderDate { get; set; }
        public string UserName { get; set; }
        public string Vat { get; set; }
        public string? LocationID { get; set; }
        public string BKashTransactionID { get; set; }
        public string Balance { get; set; }
        public string? UserId { get; set; }
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
        public string CompID { get; set; }
        public string RoleId { get; set; }
        public string UpdatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdatedDate { get; set; }
        public string Vid { get; set; }
        public string PaidVId { get; set; }
        public string InsertType { get; set; }
        public string message { get; set; }
        public string CusPayID { get; set; }
        public string SaleReturnVid { get; set; }
        public string ReturnCashVid { get; set; }
        public string TOTALCOUNT { get; set; }
        public List<PrintInvoice> SDVMS { get; set; }
        public List<SalesDetail> sdvm { get; set; }
    }
}
