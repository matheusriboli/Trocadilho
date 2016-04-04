using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;

namespace ChangeMachine.Core.Factories {
    class CoinCashTypeFactory {

        public static CashType GetCashType() {
            var cashType = new CashType();
            cashType.Name = "Coin";
            cashType.Itens.Add(new CashItem() { AmountInCents = 100, Description = "1" });
            cashType.Itens.Add(new CashItem() { AmountInCents = 50, Description = "50 Cents" });
            cashType.Itens.Add(new CashItem() { AmountInCents = 25, Description = "25 Cents" });
            cashType.Itens.Add(new CashItem() { AmountInCents = 10, Description = "10 Cents" });
            cashType.Itens.Add(new CashItem() { AmountInCents = 5, Description = "5 Cents" });
            return cashType;
        }
    }
}
