using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library
{
    public static class ConfigHelper
    {
        public static decimal GetTaxRate()
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
