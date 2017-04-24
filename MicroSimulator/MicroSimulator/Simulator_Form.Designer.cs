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
            this.text_path = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.dataGridView_prog = new System.Windows.Forms.DataGridView();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Cmd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Literal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.text_W = new System.Windows.Forms.TextBox();
            this.label_W = new System.Windows.Forms.Label();
            this.btn_Step = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prog)).BeginInit();
            this.SuspendLayout();
            // 
            // text_path
            // 
            this.text_path.Location = new System.Drawing.Point(23, 12);
            this.text_path.Margin = new System.Windows.Forms.Padding(0);
            this.text_path.Name = "text_path";
            this.text_path.ReadOnly = true;
            this.text_path.Size = new System.Drawing.Size(520, 26);
            this.text_path.TabIndex = 0;
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(544, 10);
            this.btn_Open.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 35);
            this.btn_Open.TabIndex = 7;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // dataGridView_prog
            // 
            this.dataGridView_prog.AllowUserToAddRows = false;
            this.dataGridView_prog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_prog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_prog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ID,
            this.Column_Cmd,
            this.col_bin,
            this.Column_Op,
            this.Column_Literal});
            this.dataGridView_prog.Location = new System.Drawing.Point(23, 63);
            this.dataGridView_prog.Name = "dataGridView_prog";
            this.dataGridView_prog.RowTemplate.Height = 28;
            this.dataGridView_prog.Size = new System.Drawing.Size(479, 869);
            this.dataGridView_prog.TabIndex = 8;
            // 
            // Column_ID
            // 
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.Width = 40;
            // 
            // Column_Cmd
            // 
            this.Column_Cmd.HeaderText = "Hex";
            this.Column_Cmd.Name = "Column_Cmd";
            this.Column_Cmd.Width = 40;
            // 
            // col_bin
            // 
            this.col_bin.HeaderText = "Binary";
            this.col_bin.Name = "col_bin";
            // 
            // Column_Op
            // 
            this.Column_Op.HeaderText = "Operator";
            this.Column_Op.Name = "Column_Op";
            // 
            // Column_Literal
            // 
            this.Column_Literal.HeaderText = "Literal";
            this.Column_Literal.Name = "Column_Literal";
            // 
            // text_W
            // 
            this.text_W.Location = new System.Drawing.Point(644, 305);
            this.text_W.Name = "text_W";
            this.text_W.Size = new System.Drawing.Size(100, 26);
            this.text_W.TabIndex = 9;
            this.text_W.Text = "00h";
            // 
            // label_W
            // 
            this.label_W.AutoSize = true;
            this.label_W.Location = new System.Drawing.Point(616, 308);
            this.label_W.Name = "label_W";
            this.label_W.Size = new System.Drawing.Size(24, 20);
            this.label_W.TabIndex = 31;
            this.label_W.Text = "W";
            // 
            // btn_Step
            // 
            this.btn_Step.Location = new System.Drawing.Point(509, 94);
            this.btn_Step.Name = "btn_Step";
            this.btn_Step.Size = new System.Drawing.Size(75, 29);
            this.btn_Step.TabIndex = 32;
            this.btn_Step.Text = "Next";
            this.btn_Step.UseVisualStyleBackColor = true;
            this.btn_Step.Click += new System.EventHandler(this.btn_Step_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(509, 63);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 29);
            this.btn_Start.TabIndex = 33;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1258, 944);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_Step);
            this.Controls.Add(this.label_W);
            this.Controls.Add(this.text_W);
            this.Controls.Add(this.dataGridView_prog);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.text_path);
            this.Name = "SimulatorForm";
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.SimulatorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox text_path;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox text_W;
        private System.Windows.Forms.Label reg_W;
        private System.Windows.Forms.Label label_W;
        private System.Windows.Forms.Button btn_Step;
        private System.Windows.Forms.DataGridView dataGridView_prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Cmd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Op;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Literal;
        private System.Windows.Forms.Button btn_Start;
    }
}

