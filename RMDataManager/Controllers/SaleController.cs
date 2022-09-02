using Microsoft.AspNet.Identity;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        [HttpPost]
        public void Post(SaleModel sale)
        {
            SaleData saleData = new SaleData();
            string cashierId = RequestContext.Principal.Identity.GetUserId();
            saleData.SaveSale(sale, cashierId);
        }

        [HttpGet]
        [Route("GetSalesReport")]
        public List<SaleReportModel> GetSalesReport()
        {
            SaleData data = new SaleData();
            return data.GetSalesReport();
        }
    }
}
