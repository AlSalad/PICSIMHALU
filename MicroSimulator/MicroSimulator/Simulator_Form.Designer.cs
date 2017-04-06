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
            this.btn_convert = new System.Windows.Forms.Button();
            this.label_Literal = new System.Windows.Forms.Label();
            this.label_W = new System.Windows.Forms.Label();
            this.text_W = new System.Windows.Forms.TextBox();
            this.text_path = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.text_Literal = new System.Windows.Forms.TextBox();
            this.dataGridView_prog = new System.Windows.Forms.DataGridView();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Cmd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prog)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_convert
            // 
            this.btn_convert.Location = new System.Drawing.Point(640, 63);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(94, 38);
            this.btn_convert.TabIndex = 1;
            this.btn_convert.Text = "Convert";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // label_Literal
            // 
            this.label_Literal.AutoSize = true;
            this.label_Literal.Location = new System.Drawing.Point(815, 40);
            this.label_Literal.Name = "label_Literal";
            this.label_Literal.Size = new System.Drawing.Size(52, 20);
            this.label_Literal.TabIndex = 3;
            this.label_Literal.Text = "Literal";
            // 
            // label_W
            // 
            this.label_W.AutoSize = true;
            this.label_W.Location = new System.Drawing.Point(815, 119);
            this.label_W.Name = "label_W";
            this.label_W.Size = new System.Drawing.Size(24, 20);
            this.label_W.TabIndex = 5;
            this.label_W.Text = "W";
            // 
            // text_W
            // 
            this.text_W.Location = new System.Drawing.Point(819, 142);
            this.text_W.Name = "text_W";
            this.text_W.Size = new System.Drawing.Size(100, 26);
            this.text_W.TabIndex = 4;
            // 
            // text_path
            // 
            this.text_path.Location = new System.Drawing.Point(23, 12);
            this.text_path.Name = "text_path";
            this.text_path.Size = new System.Drawing.Size(520, 26);
            this.text_path.TabIndex = 6;
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(549, 9);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 33);
            this.btn_Open.TabIndex = 7;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // text_Literal
            // 
            this.text_Literal.Location = new System.Drawing.Point(819, 63);
            this.text_Literal.Name = "text_Literal";
            this.text_Literal.Size = new System.Drawing.Size(100, 26);
            this.text_Literal.TabIndex = 2;
            // 
            // dataGridView_prog
            // 
            this.dataGridView_prog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_prog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ID,
            this.Column_Cmd,
            this.Column_Op});
            this.dataGridView_prog.Location = new System.Drawing.Point(23, 63);
            this.dataGridView_prog.Name = "dataGridView_prog";
            this.dataGridView_prog.RowTemplate.Height = 28;
            this.dataGridView_prog.Size = new System.Drawing.Size(492, 869);
            this.dataGridView_prog.TabIndex = 8;
            this.dataGridView_prog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column_ID
            // 
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            // 
            // Column_Cmd
            // 
            this.Column_Cmd.HeaderText = "Hexa";
            this.Column_Cmd.Name = "Column_Cmd";
            // 
            // Column_Op
            // 
            this.Column_Op.HeaderText = "Operator";
            this.Column_Op.Name = "Column_Op";
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 944);
            this.Controls.Add(this.dataGridView_prog);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.text_path);
            this.Controls.Add(this.label_W);
            this.Controls.Add(this.text_W);
            this.Controls.Add(this.label_Literal);
            this.Controls.Add(this.text_Literal);
            this.Controls.Add(this.btn_convert);
            this.Name = "SimulatorForm";
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.Simulator_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.Label label_Literal;
        private System.Windows.Forms.Label label_W;
        private System.Windows.Forms.TextBox text_W;
        private System.Windows.Forms.TextBox text_path;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.TextBox text_Literal;
        private System.Windows.Forms.DataGridView dataGridView_prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Cmd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Op;
    }
}

