using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.DataContracts;
using ChangeMachine.Core.Entities;
using ChangeMachine.Core.Factories;
using ChangeMachine.Core.Processors;
using ChangeMachine.Core.Utilities;
using Dlp.Framework.Container;

namespace ChangeMachine.Core {
    public class ChangeMachineManager {

        public ChangeMachineManager() {
            IocFactory.Register(
                Component.For<ILogger>().ImplementedBy<EventViewerLogger>("Event_viewer").IsSingleton(),
                Component.For<ILogger>().ImplementedBy<FileLogger>("Log_file").IsSingleton(),
                Component.For<IProcessor>().ImplementedBy<BasicChangeProcessor>()
                );
        }

        public CalculateChangeResponse CalculateChange(CalculateChangeRequest request) {
            ILogger log = LoggerFactory.GetLogger();
            log.LogInfo(CategoryEnum.Request, request);
            CalculateChangeResponse response;
            try {
                if (!request.ValuesAreValid) {
                    response = new CalculateChangeResponse() {
                        OperationReport = request.OperationReport,
                        Success = false
                    };
                    response.OperationReport.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    log.LogInfo(CategoryEnum.Response, response);
                    return response;
                }
                int valuesDifference = request.PaidValue - request.ProductValue;

                if (valuesDifference == 0) {
                    response = new CalculateChangeResponse() {
                        Success = true
                    };
                    response.OperationReport.StatusCode = System.Net.HttpStatusCode.OK;
                    log.LogInfo(CategoryEnum.Response, response);
                    return response;
                }                 
                Dictionary<IProcessor, CashType> processorsDict = ProcessorFactory.GetProcessors();
                Tuple<int, Dictionary<string, int>> result;
                response = new CalculateChangeResponse();
                foreach (var processor in processorsDict) {
                    result = processor.Key.CalculateChange(valuesDifference, processor.Value);
                    valuesDifference = result.Item1;
                    response.CashDict = response.CashDict.Union(result.Item2).ToDictionary(k => k.Key, v => v.Value);
                    if (valuesDifference == 0) {
                        break;
                    }
                }
                response.Success = true;
                response.OperationReport.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception e) {
                log.LogException(e);
                response = new CalculateChangeResponse() {
                    Success = false
                };
                response.OperationReport.Messages.Add(e.Message);
                response.OperationReport.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            log.LogInfo(CategoryEnum.Response, response);
            return response;            
            
        }

    }
}
