using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;

namespace ChangeMachine.Core.Processors {
    abstract class BaseProcessor: IProcessor {

        public Tuple<int, Dictionary<string, int>> CalculateChange(int value, CashType cashType) {

            Dictionary<string, int> Cashes = new Dictionary<string, int>();

            foreach (var cash in cashType.Itens) {
                int cashQtt = value / cash.AmountInCents;
                value = value % cash.AmountInCents;
                if (cashQtt != 0)
                    Cashes.Add(cash.Description, cashQtt);
                if (value == 0) {
                    return new Tuple<int, Dictionary < string, int>> (0, Cashes);
                }
            }
            return new Tuple<int, Dictionary<string, int>>(value, Cashes);
        }
    }
}
