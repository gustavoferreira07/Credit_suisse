using CreditSuisseBusiness.Interfaces;
using CreditSuisseBusiness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisseBusiness.Category
{
    public class MediumRiskCategory : ITrade
    {
        public string ClassificateTrade(TradeModel trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector=="Publico")
            {
                return "Risco médio";
            }
            return null;
        }
    }
}
