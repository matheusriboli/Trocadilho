namespace ChangeMachine.UI {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.Button Execute;
            this.txtDueValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaidValue = new System.Windows.Forms.TextBox();
            this.lblChange = new System.Windows.Forms.Label();
            Execute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDueValue
            // 
            this.txtDueValue.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDueValue.Location = new System.Drawing.Point(26, 32);
            this.txtDueValue.Name = "txtDueValue";
            this.txtDueValue.Size = new System.Drawing.Size(200, 59);
            this.txtDueValue.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor do Produto";
            // 
            // Execute
            // 
            Execute.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Execute.Location = new System.Drawing.Point(26, 245);
            Execute.Name = "Execute";
            Execute.Size = new System.Drawing.Size(200, 43);
            Execute.TabIndex = 6;
            Execute.Text = "Trocar dilho";
            Execute.UseVisualStyleBackColor = true;
            Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Valor Pago";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtPaidValue
            // 
            this.txtPaidValue.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidValue.Location = new System.Drawing.Point(26, 153);
            this.txtPaidValue.Name = "txtPaidValue";
            this.txtPaidValue.Size = new System.Drawing.Size(200, 59);
            this.txtPaidValue.TabIndex = 7;
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(296, 32);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(38, 15);
            this.lblChange.TabIndex = 9;
            this.lblChange.Text = "label3";
            this.lblChange.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 366);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaidValue);
            this.Controls.Add(Execute);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDueValue);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Trocadilho";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDueValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaidValue;
        private System.Windows.Forms.Label lblChange;
    }
}

