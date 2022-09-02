using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class SaleData
    {
        public void SaveSale(SaleModel saleInfo, string CashierId)
        {
            //TODO: Make this SOLID/DRY/Better
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData();
            var taxRate = ConfigHelper.GetTaxRate() / 100;

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

                var productInfo = products.GetProductById(detail.ProductId);

                if (productInfo == null)
                {
                    throw new Exception($"The product id of {detail.ProductId} could not be found in the database");
                }

                detail.PurchasePrice = productInfo.RetailPrice * detail.Quantity;

                if (productInfo.IsTaxable)
                {
                    detail.Tax = taxRate * detail.PurchasePrice;
                }

                details.Add(detail);
            }

            SaleDBModel sale = new SaleDBModel
            {
                Subtotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = CashierId

            };

            sale.Total = sale.Tax + sale.Subtotal;

            using (SqlDataAccess sql = new SqlDataAccess())
            {
                try
                {
                    sql.StartTransaction("RMData");
                    sql.SaveDataInTransaction("dbo.spSale_Insert", sale);

                    sale.Id = sql.LoadDataInTransaction<int, dynamic>("dbo.spSale_Lookup", new { sale.CashierId, sale.SaleDate })
                        .FirstOrDefault();

                    foreach (var item in details)
                    {
                        item.SaleId = sale.Id;
                        sql.SaveDataInTransaction("dbo.spSaleDetail_Insert", item);
                    }

                    sql.CommitTransaction();
                }
                catch
                {
                    sql.RollBackTransaction();
                    throw;
                }
            }
        }
        public List<SaleReportModel> GetSalesReport()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var output = sql.LoadData<SaleReportModel, dynamic>("dbo.spSale_SaleReport", new { }, "RMData");

            return output;
        }
    }
}
