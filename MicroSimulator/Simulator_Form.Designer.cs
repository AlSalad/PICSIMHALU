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
            this.Column_Op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Literal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.text_W = new System.Windows.Forms.TextBox();
            this.a_bit_7 = new System.Windows.Forms.Button();
            this.a_bit_5 = new System.Windows.Forms.Button();
            this.a_bit_1 = new System.Windows.Forms.Button();
            this.a_bit_6 = new System.Windows.Forms.Button();
            this.a_bit_4 = new System.Windows.Forms.Button();
            this.a_bit_0 = new System.Windows.Forms.Button();
            this.a_bit_2 = new System.Windows.Forms.Button();
            this.a_bit_3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.b_bit_2 = new System.Windows.Forms.Button();
            this.b_bit_3 = new System.Windows.Forms.Button();
            this.b_bit_4 = new System.Windows.Forms.Button();
            this.b_bit_0 = new System.Windows.Forms.Button();
            this.b_bit_1 = new System.Windows.Forms.Button();
            this.b_bit_6 = new System.Windows.Forms.Button();
            this.b_bit_5 = new System.Windows.Forms.Button();
            this.b_bit_7 = new System.Windows.Forms.Button();
            this.label_W = new System.Windows.Forms.Label();
            this.btn_Step = new System.Windows.Forms.Button();
            this.btn_execute = new System.Windows.Forms.Button();
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
            this.dataGridView_prog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_prog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_prog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ID,
            this.Column_Cmd,
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
            this.text_W.Location = new System.Drawing.Point(647, 134);
            this.text_W.Name = "text_W";
            this.text_W.Size = new System.Drawing.Size(100, 26);
            this.text_W.TabIndex = 9;
            this.text_W.Text = "00h";
            // 
            // a_bit_7
            // 
            this.a_bit_7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.a_bit_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.a_bit_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a_bit_7.Location = new System.Drawing.Point(647, 62);
            this.a_bit_7.Name = "a_bit_7";
            this.a_bit_7.Size = new System.Drawing.Size(30, 30);
            this.a_bit_7.TabIndex = 10;
            this.a_bit_7.TabStop = false;
            this.a_bit_7.UseVisualStyleBackColor = false;
            // 
            // a_bit_5
            // 
            this.a_bit_5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.a_bit_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.a_bit_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a_bit_5.Location = new System.Drawing.Point(719, 62);
            this.a_bit_5.Name = "a_bit_5";
            this.a_bit_5.Size = new System.Drawing.Size(30, 30);
            this.a_bit_5.TabIndex = 11;
            this.a_bit_5.TabStop = false;
            this.a_bit_5.UseVisualStyleBackColor = false;
            // 
            // a_bit_1
            // 
            this.a_bit_1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.a_bit_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.a_bit_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a_bit_1.Location = new System.Drawing.Point(863, 62);
            this.a_bit_1.Name = "a_bit_1";
            this.a_bit_1.Size = new System.Drawing.Size(30, 30);
            this.a_bit_1.TabIndex = 13;
            this.a_bit_1.TabStop = false;
            this.a_bit_1.UseVisualStyleBackColor = false;
            // 
            // a_bit_6
            // 
            this.a_bit_6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.a_bit_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.a_bit_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a_bit_6.Location = new System.Drawing.Point(683, 62);
            this.a_bit_6.Name = "a_bit_6";
            this.a_bit_6.Size = new System.Drawing.Size(30, 30);
            this.a_bit_6.TabIndex = 12;
            this.a_bit_6.TabStop = false;
            this.a_bit_6.UseVisualStyleBackColor = false;
            // 
            // a_bit_4
            // 
            this.a_bit_4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.a_bit_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.a_bit_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a_bit_4.Location = new System.Drawing.Point(755, 62);
            this.a_bit_4.Name = "a_bit_4";
            this.a_bit_4.Size = new System.Drawing.Size(30, 30);
            this.a_bit_4.TabIndex = 15;
            this.a_bit_4.TabStop = false;
            this.a_bit_4.UseVisualStyleBackColor = false;
            // 
            // a_bit_0
            // 
            this.a_bit_0.BackColor = System.Drawing.Color.WhiteSmoke;
            this.a_bit_0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.a_bit_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a_bit_0.Location = new System.Drawing.Point(899, 62);
            this.a_bit_0.Name = "a_bit_0";
            this.a_bit_0.Size = new System.Drawing.Size(30, 30);
            this.a_bit_0.TabIndex = 14;
            this.a_bit_0.TabStop = false;
            this.a_bit_0.UseVisualStyleBackColor = false;
            // 
            // a_bit_2
            // 
            this.a_bit_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.a_bit_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.a_bit_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a_bit_2.Location = new System.Drawing.Point(827, 62);
            this.a_bit_2.Name = "a_bit_2";
            this.a_bit_2.Size = new System.Drawing.Size(30, 30);
            this.a_bit_2.TabIndex = 17;
            this.a_bit_2.TabStop = false;
            this.a_bit_2.UseVisualStyleBackColor = false;
            // 
            // a_bit_3
            // 
            this.a_bit_3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.a_bit_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.a_bit_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.a_bit_3.Location = new System.Drawing.Point(791, 62);
            this.a_bit_3.Name = "a_bit_3";
            this.a_bit_3.Size = new System.Drawing.Size(30, 30);
            this.a_bit_3.TabIndex = 16;
            this.a_bit_3.TabStop = false;
            this.a_bit_3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(590, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Port A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(590, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Port B";
            // 
            // b_bit_2
            // 
            this.b_bit_2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.b_bit_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_bit_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_bit_2.Location = new System.Drawing.Point(827, 98);
            this.b_bit_2.Name = "b_bit_2";
            this.b_bit_2.Size = new System.Drawing.Size(30, 30);
            this.b_bit_2.TabIndex = 26;
            this.b_bit_2.TabStop = false;
            this.b_bit_2.UseVisualStyleBackColor = false;
            // 
            // b_bit_3
            // 
            this.b_bit_3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.b_bit_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_bit_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_bit_3.Location = new System.Drawing.Point(791, 98);
            this.b_bit_3.Name = "b_bit_3";
            this.b_bit_3.Size = new System.Drawing.Size(30, 30);
            this.b_bit_3.TabIndex = 25;
            this.b_bit_3.TabStop = false;
            this.b_bit_3.UseVisualStyleBackColor = false;
            // 
            // b_bit_4
            // 
            this.b_bit_4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.b_bit_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_bit_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_bit_4.Location = new System.Drawing.Point(755, 98);
            this.b_bit_4.Name = "b_bit_4";
            this.b_bit_4.Size = new System.Drawing.Size(30, 30);
            this.b_bit_4.TabIndex = 24;
            this.b_bit_4.TabStop = false;
            this.b_bit_4.UseVisualStyleBackColor = false;
            // 
            // b_bit_0
            // 
            this.b_bit_0.BackColor = System.Drawing.Color.WhiteSmoke;
            this.b_bit_0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_bit_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_bit_0.Location = new System.Drawing.Point(899, 98);
            this.b_bit_0.Name = "b_bit_0";
            this.b_bit_0.Size = new System.Drawing.Size(30, 30);
            this.b_bit_0.TabIndex = 23;
            this.b_bit_0.TabStop = false;
            this.b_bit_0.UseVisualStyleBackColor = false;
            // 
            // b_bit_1
            // 
            this.b_bit_1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.b_bit_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_bit_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_bit_1.Location = new System.Drawing.Point(863, 98);
            this.b_bit_1.Name = "b_bit_1";
            this.b_bit_1.Size = new System.Drawing.Size(30, 30);
            this.b_bit_1.TabIndex = 22;
            this.b_bit_1.TabStop = false;
            this.b_bit_1.UseVisualStyleBackColor = false;
            // 
            // b_bit_6
            // 
            this.b_bit_6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.b_bit_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_bit_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_bit_6.Location = new System.Drawing.Point(683, 98);
            this.b_bit_6.Name = "b_bit_6";
            this.b_bit_6.Size = new System.Drawing.Size(30, 30);
            this.b_bit_6.TabIndex = 21;
            this.b_bit_6.TabStop = false;
            this.b_bit_6.UseVisualStyleBackColor = false;
            // 
            // b_bit_5
            // 
            this.b_bit_5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.b_bit_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_bit_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_bit_5.Location = new System.Drawing.Point(719, 98);
            this.b_bit_5.Name = "b_bit_5";
            this.b_bit_5.Size = new System.Drawing.Size(30, 30);
            this.b_bit_5.TabIndex = 20;
            this.b_bit_5.TabStop = false;
            this.b_bit_5.UseVisualStyleBackColor = false;
            // 
            // b_bit_7
            // 
            this.b_bit_7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.b_bit_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.b_bit_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_bit_7.Location = new System.Drawing.Point(647, 98);
            this.b_bit_7.Name = "b_bit_7";
            this.b_bit_7.Size = new System.Drawing.Size(30, 30);
            this.b_bit_7.TabIndex = 19;
            this.b_bit_7.TabStop = false;
            this.b_bit_7.UseVisualStyleBackColor = false;
            // 
            // label_W
            // 
            this.label_W.AutoSize = true;
            this.label_W.Location = new System.Drawing.Point(619, 137);
            this.label_W.Name = "label_W";
            this.label_W.Size = new System.Drawing.Size(24, 20);
            this.label_W.TabIndex = 31;
            this.label_W.Text = "W";
            // 
            // btn_Step
            // 
            this.btn_Step.Location = new System.Drawing.Point(509, 63);
            this.btn_Step.Name = "btn_Step";
            this.btn_Step.Size = new System.Drawing.Size(75, 29);
            this.btn_Step.TabIndex = 32;
            this.btn_Step.Text = "Next";
            this.btn_Step.UseVisualStyleBackColor = true;
            this.btn_Step.Click += new System.EventHandler(this.btn_Step_Click);
            // 
            // btn_execute
            // 
            this.btn_execute.Location = new System.Drawing.Point(509, 98);
            this.btn_execute.Name = "btn_execute";
            this.btn_execute.Size = new System.Drawing.Size(75, 29);
            this.btn_execute.TabIndex = 33;
            this.btn_execute.Text = "Execute";
            this.btn_execute.UseVisualStyleBackColor = true;
            this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1258, 944);
            this.Controls.Add(this.btn_execute);
            this.Controls.Add(this.btn_Step);
            this.Controls.Add(this.label_W);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.b_bit_2);
            this.Controls.Add(this.b_bit_3);
            this.Controls.Add(this.b_bit_4);
            this.Controls.Add(this.b_bit_0);
            this.Controls.Add(this.b_bit_1);
            this.Controls.Add(this.b_bit_6);
            this.Controls.Add(this.b_bit_5);
            this.Controls.Add(this.b_bit_7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.a_bit_2);
            this.Controls.Add(this.a_bit_3);
            this.Controls.Add(this.a_bit_4);
            this.Controls.Add(this.a_bit_0);
            this.Controls.Add(this.a_bit_1);
            this.Controls.Add(this.a_bit_6);
            this.Controls.Add(this.a_bit_5);
            this.Controls.Add(this.a_bit_7);
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
        private System.Windows.Forms.DataGridView dataGridView_prog;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox text_W;
        private System.Windows.Forms.Label reg_W;
        private System.Windows.Forms.Button a_bit_7;
        private System.Windows.Forms.Button a_bit_5;
        private System.Windows.Forms.Button a_bit_1;
        private System.Windows.Forms.Button a_bit_6;
        private System.Windows.Forms.Button a_bit_4;
        private System.Windows.Forms.Button a_bit_0;
        private System.Windows.Forms.Button a_bit_2;
        private System.Windows.Forms.Button a_bit_3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Cmd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Op;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Literal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_bit_2;
        private System.Windows.Forms.Button b_bit_3;
        private System.Windows.Forms.Button b_bit_4;
        private System.Windows.Forms.Button b_bit_0;
        private System.Windows.Forms.Button b_bit_1;
        private System.Windows.Forms.Button b_bit_6;
        private System.Windows.Forms.Button b_bit_5;
        private System.Windows.Forms.Button b_bit_7;
        private System.Windows.Forms.Label label_W;
        private System.Windows.Forms.Button btn_Step;
        private System.Windows.Forms.Button btn_execute;
    }
}

