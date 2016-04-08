using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;
using ChangeMachine.Core.Processors;

namespace ChangeMachine.Core.Test {
    internal class StubProcessor : IProcessor {
        public Tuple<int, Dictionary<string, int>> CalculateChange(int value, CashType cashType) {
            if (value == 1)
                return null;
            if (value == 13)
                return new Tuple<int, Dictionary<string, int>>(0, null);
            return new Tuple<int, Dictionary<string, int>>(0, null);
        }
    }
}
