using System;
using System.IO;

namespace MicroSimulator
{
    partial class SimulatorForm
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.ListBox CmdInput;

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
        public void InitializeComponent()
        {
            this.CmdInput = new System.Windows.Forms.ListBox();
            this.btn_convert = new System.Windows.Forms.Button();
            this.text_Literal = new System.Windows.Forms.TextBox();
            this.label_Literal = new System.Windows.Forms.Label();
            this.label_W = new System.Windows.Forms.Label();
            this.text_W = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CmdInput
            // 
            this.CmdInput.FormattingEnabled = true;
            this.CmdInput.ItemHeight = 20;
            this.CmdInput.Location = new System.Drawing.Point(12, 111);
            this.CmdInput.Name = "CmdInput";
            this.CmdInput.Size = new System.Drawing.Size(120, 84);
            this.CmdInput.TabIndex = 0;
            this.CmdInput.SelectedIndexChanged += new System.EventHandler(this.CmdInput_SelectedIndexChanged);
            // 
            // btn_convert
            // 
            this.btn_convert.Location = new System.Drawing.Point(138, 138);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(87, 28);
            this.btn_convert.TabIndex = 1;
            this.btn_convert.Text = "Convert";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // text_Literal
            // 
            this.text_Literal.Location = new System.Drawing.Point(242, 111);
            this.text_Literal.Name = "text_Literal";
            this.text_Literal.Size = new System.Drawing.Size(100, 26);
            this.text_Literal.TabIndex = 2;
            // 
            // label_Literal
            // 
            this.label_Literal.AutoSize = true;
            this.label_Literal.Location = new System.Drawing.Point(242, 85);
            this.label_Literal.Name = "label_Literal";
            this.label_Literal.Size = new System.Drawing.Size(52, 20);
            this.label_Literal.TabIndex = 3;
            this.label_Literal.Text = "Literal";
            // 
            // label_W
            // 
            this.label_W.AutoSize = true;
            this.label_W.Location = new System.Drawing.Point(242, 154);
            this.label_W.Name = "label_W";
            this.label_W.Size = new System.Drawing.Size(24, 20);
            this.label_W.TabIndex = 5;
            this.label_W.Text = "W";
            // 
            // text_W
            // 
            this.text_W.Location = new System.Drawing.Point(242, 180);
            this.text_W.Name = "text_W";
            this.text_W.Size = new System.Drawing.Size(100, 26);
            this.text_W.TabIndex = 4;
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.label_W);
            this.Controls.Add(this.text_W);
            this.Controls.Add(this.label_Literal);
            this.Controls.Add(this.text_Literal);
            this.Controls.Add(this.btn_convert);
            this.Controls.Add(this.CmdInput);
            this.Name = "SimulatorForm";
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.Simulator_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.TextBox text_Literal;
        private System.Windows.Forms.Label label_Literal;
        private System.Windows.Forms.Label label_W;
        private System.Windows.Forms.TextBox text_W;
    }
}

