using CreditSuisseBusiness.Interfaces;
using CreditSuisseBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisseBusiness.Category
{
    public class ExpiredCategory : ITrade
    {

        public string ClassificateTrade(TradeModel trade)
        {
            var diferença = trade.ReferenceDate - trade.NextPaymentDate;

            if (diferença.Days>30)
            {
                return "Expirado";
            }
            return null;
        }
    }
}
