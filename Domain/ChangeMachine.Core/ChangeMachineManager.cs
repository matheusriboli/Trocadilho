using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.DataContracts;
using ChangeMachine.Core.Entities;
using ChangeMachine.Core.Factories;
using ChangeMachine.Core.Processors;

namespace ChangeMachine.Core {
    public class ChangeMachineManager {

        public CalculateChangeResponse CalculateChange(CalculateChangeRequest request) {
            // TODO logar request
            try {
                request.Validate();
                if (!request.ValuesAreValid) {
                    return new CalculateChangeResponse() {
                        OperationReport = request.OperationReport,
                        Success = false
                    };
                }
                int valuesDifference = request.PaidValue - request.ProductValue;

                if (valuesDifference == 0)
                    return new CalculateChangeResponse() {
                        Success = true
                    };
                Dictionary<IProcessor, CashType> processorsDict = ProcessorFactory.GetProcessors();
                Tuple<int, Dictionary<string, int>> result;
                CalculateChangeResponse response = new CalculateChangeResponse();
                foreach (var processor  in processorsDict) {
                    result = processor.Key.CalculateChange(valuesDifference, processor.Value);
                    valuesDifference = result.Item1;
                    response.CashDict = response.CashDict.Union(result.Item2).ToDictionary(k => k.Key, v => v.Value);
                    if (valuesDifference == 0) {
                        break;
                    }
                }
                response.Success = true;
                // TODO logar a resposta
                return response;                
            }
            catch (Exception e) {
                // TODO logar exception
                var response =new CalculateChangeResponse() {
                    Success = false
                };
                response.OperationReport.Messages.Add(e.Message);
                return response;
            }
            
        }

    }
}
