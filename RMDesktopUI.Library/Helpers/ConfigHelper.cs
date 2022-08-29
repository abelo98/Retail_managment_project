using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {
            string textRate = ConfigurationManager.AppSettings["taxRate"];

            bool isValidTaxRate = decimal.TryParse(textRate, out decimal taxRate);

            if (!isValidTaxRate)
            {
                throw new ConfigurationErrorsException("The tax rate is not set up properly");
            }

            return taxRate;
        }
    }
}
