namespace JogoDosAnimais
{
    partial class FrmAnimais
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPense = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPense
            // 
            this.lblPense.AutoSize = true;
            this.lblPense.Location = new System.Drawing.Point(81, 9);
            this.lblPense.Name = "lblPense";
            this.lblPense.Size = new System.Drawing.Size(104, 13);
            this.lblPense.TabIndex = 0;
            this.lblPense.Text = "Pense em um animal";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(95, 34);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmAnimais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 85);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPense);
            this.MaximizeBox = false;
            this.Name = "FrmAnimais";
            this.Text = "Animais";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPense;
        private System.Windows.Forms.Button btnOk;
    }
}

