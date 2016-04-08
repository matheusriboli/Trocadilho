using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Entities;
using ChangeMachine.Core.Processors;
using Dlp.Framework.Container;

namespace ChangeMachine.Core.Factories {
    class ProcessorFactory {
        public static Dictionary<IProcessor, CashType> GetProcessors() {
            var processors = new Dictionary<IProcessor, CashType>();
            processors.Add(IocFactory.Resolve<IProcessor>(), SilverBarCashTypeFactory.GetCashType());//SilverBarProcessor
            processors.Add(IocFactory.Resolve<IProcessor>(), BillCashTypeFactory.GetCashType());//BillProcessor
            processors.Add(IocFactory.Resolve<IProcessor>(), CoinCashTypeFactory.GetCashType());//CentProcessor
            processors.Add(IocFactory.Resolve<IProcessor>(), CandyCashTypeFactory.GetCashType());//CandyProcessor
            return processors;
        }
    }
}
