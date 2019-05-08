namespace MasterMindUI
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdGuess = new System.Windows.Forms.Button();
            this.cbPeg1 = new System.Windows.Forms.ComboBox();
            this.cbPeg2 = new System.Windows.Forms.ComboBox();
            this.cbPeg3 = new System.Windows.Forms.ComboBox();
            this.cbPeg4 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(61, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 547);
            this.panel1.TabIndex = 0;
            // 
            // cmdGuess
            // 
            this.cmdGuess.Location = new System.Drawing.Point(618, 590);
            this.cmdGuess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdGuess.Name = "cmdGuess";
            this.cmdGuess.Size = new System.Drawing.Size(103, 40);
            this.cmdGuess.TabIndex = 1;
            this.cmdGuess.Text = "Guess";
            this.cmdGuess.UseVisualStyleBackColor = true;
            this.cmdGuess.Click += new System.EventHandler(this.CmdGuess_Click);
            // 
            // cbPeg1
            // 
            this.cbPeg1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeg1.FormattingEnabled = true;
            this.cbPeg1.Location = new System.Drawing.Point(61, 593);
            this.cbPeg1.Name = "cbPeg1";
            this.cbPeg1.Size = new System.Drawing.Size(121, 36);
            this.cbPeg1.TabIndex = 2;
            // 
            // cbPeg2
            // 
            this.cbPeg2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeg2.FormattingEnabled = true;
            this.cbPeg2.Location = new System.Drawing.Point(197, 593);
            this.cbPeg2.Name = "cbPeg2";
            this.cbPeg2.Size = new System.Drawing.Size(121, 36);
            this.cbPeg2.TabIndex = 3;
            // 
            // cbPeg3
            // 
            this.cbPeg3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeg3.FormattingEnabled = true;
            this.cbPeg3.Location = new System.Drawing.Point(336, 593);
            this.cbPeg3.Name = "cbPeg3";
            this.cbPeg3.Size = new System.Drawing.Size(121, 36);
            this.cbPeg3.TabIndex = 4;
            // 
            // cbPeg4
            // 
            this.cbPeg4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeg4.FormattingEnabled = true;
            this.cbPeg4.Location = new System.Drawing.Point(473, 593);
            this.cbPeg4.Name = "cbPeg4";
            this.cbPeg4.Size = new System.Drawing.Size(121, 36);
            this.cbPeg4.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 657);
            this.Controls.Add(this.cbPeg4);
            this.Controls.Add(this.cbPeg3);
            this.Controls.Add(this.cbPeg2);
            this.Controls.Add(this.cbPeg1);
            this.Controls.Add(this.cmdGuess);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Mastermind";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdGuess;
        private System.Windows.Forms.ComboBox cbPeg1;
        private System.Windows.Forms.ComboBox cbPeg2;
        private System.Windows.Forms.ComboBox cbPeg3;
        private System.Windows.Forms.ComboBox cbPeg4;
    }
}

