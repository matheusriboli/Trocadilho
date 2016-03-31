using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChangeMachine.Core;
using ChangeMachine.Core.DataContracts;

namespace ChangeMachine.UI {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void Execute_Click(object sender, EventArgs e) {


            var changeMachineManager = new ChangeMachineManager();

            var request = new CalculateChangeRequest() {
                ProductValue = int.Parse(txtDueValue.Text),
                PaidValue = int.Parse(txtPaidValue.Text)
            };

            var response = changeMachineManager.CalculateChange(request);

            var changeMessage = new System.Text.StringBuilder();

            if (response.Success) {
                foreach (var coin in response.CoinDict) {
                    var textCoin = $"{coin.Value }  de {coin.Key.ToString()} ";
                    changeMessage.AppendLine(textCoin);
                }
                if (response.CoinDict.Count == 0) {
                    changeMessage.AppendLine("Não há troco!");
                }
            }
            else {
                foreach (var message in response.OperationReport.Messages) {
                    changeMessage.AppendLine(message);
                }
            }


            this.lblChange.Text = changeMessage.ToString();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
