using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.DataContracts {
    public class CalculateChangeRequest {

        public int ProductValue { get; set; }
        public int PaidValue { get; set; }
        public bool ValuesAreValid { get; set; }
        public OperationReport OperationReport { get; set; }

        public void Validate() 
        {
            this.ValuesAreValid = true;
            this.OperationReport = new OperationReport();
            if (this.PaidValue <= 0) 
            {
                this.ValuesAreValid = false;
                this.OperationReport.Messages.Add("Valor pago é inválido.");
            }
            if (this.ProductValue <= 0) {
                this.ValuesAreValid = false;
                this.OperationReport.Messages.Add("Valor da compra é inválido.");
            }
            if (this.PaidValue < this.ProductValue) {
                this.ValuesAreValid = false;
                this.OperationReport.Messages.Add("Valor pago insuficiente.");
            }
        }
    }
}
