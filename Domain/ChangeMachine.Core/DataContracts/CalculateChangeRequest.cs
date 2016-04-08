using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.DataContracts {
    public class CalculateChangeRequest {

        public int ProductValue { get; set; }
        public int PaidValue { get; set; }
        public bool ValuesAreValid { get {
                return Validate();
            } }
        public OperationReport OperationReport { get; set; }

        private bool Validate() 
        {
            bool IsValid = true;
            this.OperationReport = new OperationReport();
            if (this.PaidValue <= 0) 
            {
                IsValid = false;
                this.OperationReport.Messages.Add("Valor pago é inválido.");
            }
            if (this.ProductValue <= 0) {
                IsValid = false;
                this.OperationReport.Messages.Add("Valor da compra é inválido.");
            }
            if (this.PaidValue < this.ProductValue) {
                IsValid = false;
                this.OperationReport.Messages.Add("Valor pago insuficiente.");
            }
            return IsValid;
        }
    }
}
