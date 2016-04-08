﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.DataContracts {
    public class OperationReport {

        public List<string> Messages { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public OperationReport() {
            this.Messages = new List<string>();
            
        }
    }
}
