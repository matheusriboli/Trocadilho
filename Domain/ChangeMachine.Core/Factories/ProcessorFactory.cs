using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;
using ChangeMachine.Core.Processors;

namespace ChangeMachine.Core.Factories {
    class ProcessorFactory {
        public static Dictionary<IProcessor, CashType> GetProcessors() {
            var processors = new Dictionary<IProcessor, CashType>();
            processors.Add(new BasicChangeProcessor(), SilverBarCashTypeFactory.GetCashType());//SilverBarProcessor
            processors.Add(new BasicChangeProcessor(), BillCashTypeFactory.GetCashType());//BillProcessor
            processors.Add(new BasicChangeProcessor(), CoinCashTypeFactory.GetCashType());//CentProcessor
            processors.Add(new BasicChangeProcessor(), CandyCashTypeFactory.GetCashType());//CandyProcessor
            return processors;
        }
    }
}
