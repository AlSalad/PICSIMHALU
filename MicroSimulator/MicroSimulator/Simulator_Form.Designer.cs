using System;
using System.IO;
using System.Windows.Forms;

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
            this.Column_loop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.text_W = new System.Windows.Forms.TextBox();
            this.label_W = new System.Windows.Forms.Label();
            this.btn_Step = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.text_Pc = new System.Windows.Forms.TextBox();
            this.RegA_Bit0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegA_Bit1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegA_Bit2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegA_Bit3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegA_Bit4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegA_Bit5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegA_Bit6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reg1_bit7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_RegA = new System.Windows.Forms.DataGridView();
            this.dataGridView_RegB = new System.Windows.Forms.DataGridView();
            this.RegB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegB_Bit7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegB_Bit6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegB_Bit5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegB_Bit4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegB_Bit3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegB_Bit2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegB_Bit1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegB_Bit0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_PC = new System.Windows.Forms.Label();
            this.textBox_CarryFlag = new System.Windows.Forms.TextBox();
            this.textBox_ZeroFlag = new System.Windows.Forms.TextBox();
            this.label_CarryFlag = new System.Windows.Forms.Label();
            this.label_ZeroFlag = new System.Windows.Forms.Label();
            this.text_Wert1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_Wert2 = new System.Windows.Forms.TextBox();
            this.text_DC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegB)).BeginInit();
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
            this.Column_Op,
            this.Column_loop});
            this.dataGridView_prog.Location = new System.Drawing.Point(23, 63);
            this.dataGridView_prog.Name = "dataGridView_prog";
            this.dataGridView_prog.RowTemplate.Height = 28;
            this.dataGridView_prog.Size = new System.Drawing.Size(485, 869);
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
            // Column_loop
            // 
            this.Column_loop.HeaderText = "Loop";
            this.Column_loop.Name = "Column_loop";
            // 
            // text_W
            // 
            this.text_W.Location = new System.Drawing.Point(841, 342);
            this.text_W.Name = "text_W";
            this.text_W.Size = new System.Drawing.Size(100, 26);
            this.text_W.TabIndex = 9;
            this.text_W.Text = "00h";
            // 
            // label_W
            // 
            this.label_W.AutoSize = true;
            this.label_W.Location = new System.Drawing.Point(816, 345);
            this.label_W.Name = "label_W";
            this.label_W.Size = new System.Drawing.Size(24, 20);
            this.label_W.TabIndex = 31;
            this.label_W.Text = "W";
            // 
            // btn_Step
            // 
            this.btn_Step.Location = new System.Drawing.Point(544, 98);
            this.btn_Step.Name = "btn_Step";
            this.btn_Step.Size = new System.Drawing.Size(75, 29);
            this.btn_Step.TabIndex = 32;
            this.btn_Step.Text = "Next";
            this.btn_Step.UseVisualStyleBackColor = true;
            this.btn_Step.Click += new System.EventHandler(this.btn_Step_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(544, 63);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 29);
            this.btn_Start.TabIndex = 33;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // text_Pc
            // 
            this.text_Pc.Location = new System.Drawing.Point(841, 374);
            this.text_Pc.Name = "text_Pc";
            this.text_Pc.Size = new System.Drawing.Size(100, 26);
            this.text_Pc.TabIndex = 34;
            this.text_Pc.Text = "00h";
            this.text_Pc.TextChanged += new System.EventHandler(this.text_Pc_TextChanged);
            // 
            // RegA_Bit0
            // 
            this.RegA_Bit0.HeaderText = "0";
            this.RegA_Bit0.Name = "RegA_Bit0";
            this.RegA_Bit0.ReadOnly = true;
            this.RegA_Bit0.Width = 25;
            // 
            // RegA_Bit1
            // 
            this.RegA_Bit1.HeaderText = "1";
            this.RegA_Bit1.Name = "RegA_Bit1";
            this.RegA_Bit1.ReadOnly = true;
            this.RegA_Bit1.Width = 25;
            // 
            // RegA_Bit2
            // 
            this.RegA_Bit2.HeaderText = "2";
            this.RegA_Bit2.Name = "RegA_Bit2";
            this.RegA_Bit2.ReadOnly = true;
            this.RegA_Bit2.Width = 25;
            // 
            // RegA_Bit3
            // 
            this.RegA_Bit3.HeaderText = "3";
            this.RegA_Bit3.Name = "RegA_Bit3";
            this.RegA_Bit3.ReadOnly = true;
            this.RegA_Bit3.Width = 25;
            // 
            // RegA_Bit4
            // 
            this.RegA_Bit4.HeaderText = "4";
            this.RegA_Bit4.Name = "RegA_Bit4";
            this.RegA_Bit4.ReadOnly = true;
            this.RegA_Bit4.Width = 25;
            // 
            // RegA_Bit5
            // 
            this.RegA_Bit5.HeaderText = "5";
            this.RegA_Bit5.Name = "RegA_Bit5";
            this.RegA_Bit5.ReadOnly = true;
            this.RegA_Bit5.Width = 25;
            // 
            // RegA_Bit6
            // 
            this.RegA_Bit6.HeaderText = "6";
            this.RegA_Bit6.Name = "RegA_Bit6";
            this.RegA_Bit6.ReadOnly = true;
            this.RegA_Bit6.Width = 25;
            // 
            // Reg1_bit7
            // 
            this.Reg1_bit7.HeaderText = "7";
            this.Reg1_bit7.Name = "Reg1_bit7";
            this.Reg1_bit7.ReadOnly = true;
            this.Reg1_bit7.Width = 25;
            // 
            // RegA
            // 
            this.RegA.HeaderText = "RA";
            this.RegA.Name = "RegA";
            this.RegA.ReadOnly = true;
            this.RegA.Width = 60;
            // 
            // dataGridView_RegA
            // 
            this.dataGridView_RegA.AllowUserToAddRows = false;
            this.dataGridView_RegA.AllowUserToDeleteRows = false;
            this.dataGridView_RegA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RegA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegA,
            this.Reg1_bit7,
            this.RegA_Bit6,
            this.RegA_Bit5,
            this.RegA_Bit4,
            this.RegA_Bit3,
            this.RegA_Bit2,
            this.RegA_Bit1,
            this.RegA_Bit0});
            this.dataGridView_RegA.Location = new System.Drawing.Point(791, 63);
            this.dataGridView_RegA.Name = "dataGridView_RegA";
            this.dataGridView_RegA.ReadOnly = true;
            this.dataGridView_RegA.RowTemplate.Height = 28;
            this.dataGridView_RegA.Size = new System.Drawing.Size(455, 122);
            this.dataGridView_RegA.TabIndex = 35;
            // 
            // dataGridView_RegB
            // 
            this.dataGridView_RegB.AllowUserToAddRows = false;
            this.dataGridView_RegB.AllowUserToDeleteRows = false;
            this.dataGridView_RegB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RegB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegB,
            this.RegB_Bit7,
            this.RegB_Bit6,
            this.RegB_Bit5,
            this.RegB_Bit4,
            this.RegB_Bit3,
            this.RegB_Bit2,
            this.RegB_Bit1,
            this.RegB_Bit0});
            this.dataGridView_RegB.Location = new System.Drawing.Point(791, 191);
            this.dataGridView_RegB.Name = "dataGridView_RegB";
            this.dataGridView_RegB.ReadOnly = true;
            this.dataGridView_RegB.RowTemplate.Height = 28;
            this.dataGridView_RegB.Size = new System.Drawing.Size(455, 122);
            this.dataGridView_RegB.TabIndex = 36;
            // 
            // RegB
            // 
            this.RegB.HeaderText = "RB";
            this.RegB.Name = "RegB";
            this.RegB.ReadOnly = true;
            this.RegB.Width = 60;
            // 
            // RegB_Bit7
            // 
            this.RegB_Bit7.HeaderText = "7";
            this.RegB_Bit7.Name = "RegB_Bit7";
            this.RegB_Bit7.ReadOnly = true;
            this.RegB_Bit7.Width = 25;
            // 
            // RegB_Bit6
            // 
            this.RegB_Bit6.HeaderText = "6";
            this.RegB_Bit6.Name = "RegB_Bit6";
            this.RegB_Bit6.ReadOnly = true;
            this.RegB_Bit6.Width = 25;
            // 
            // RegB_Bit5
            // 
            this.RegB_Bit5.HeaderText = "5";
            this.RegB_Bit5.Name = "RegB_Bit5";
            this.RegB_Bit5.ReadOnly = true;
            this.RegB_Bit5.Width = 25;
            // 
            // RegB_Bit4
            // 
            this.RegB_Bit4.HeaderText = "4";
            this.RegB_Bit4.Name = "RegB_Bit4";
            this.RegB_Bit4.ReadOnly = true;
            this.RegB_Bit4.Width = 25;
            // 
            // RegB_Bit3
            // 
            this.RegB_Bit3.HeaderText = "3";
            this.RegB_Bit3.Name = "RegB_Bit3";
            this.RegB_Bit3.ReadOnly = true;
            this.RegB_Bit3.Width = 25;
            // 
            // RegB_Bit2
            // 
            this.RegB_Bit2.HeaderText = "2";
            this.RegB_Bit2.Name = "RegB_Bit2";
            this.RegB_Bit2.ReadOnly = true;
            this.RegB_Bit2.Width = 25;
            // 
            // RegB_Bit1
            // 
            this.RegB_Bit1.HeaderText = "1";
            this.RegB_Bit1.Name = "RegB_Bit1";
            this.RegB_Bit1.ReadOnly = true;
            this.RegB_Bit1.Width = 25;
            // 
            // RegB_Bit0
            // 
            this.RegB_Bit0.HeaderText = "0";
            this.RegB_Bit0.Name = "RegB_Bit0";
            this.RegB_Bit0.ReadOnly = true;
            this.RegB_Bit0.Width = 25;
            // 
            // label_PC
            // 
            this.label_PC.AutoSize = true;
            this.label_PC.Location = new System.Drawing.Point(811, 377);
            this.label_PC.Name = "label_PC";
            this.label_PC.Size = new System.Drawing.Size(30, 20);
            this.label_PC.TabIndex = 37;
            this.label_PC.Text = "PC";
            // 
            // textBox_CarryFlag
            // 
            this.textBox_CarryFlag.Location = new System.Drawing.Point(841, 406);
            this.textBox_CarryFlag.Name = "textBox_CarryFlag";
            this.textBox_CarryFlag.Size = new System.Drawing.Size(100, 26);
            this.textBox_CarryFlag.TabIndex = 39;
            this.textBox_CarryFlag.Text = "0";
            // 
            // textBox_ZeroFlag
            // 
            this.textBox_ZeroFlag.Location = new System.Drawing.Point(841, 473);
            this.textBox_ZeroFlag.Name = "textBox_ZeroFlag";
            this.textBox_ZeroFlag.Size = new System.Drawing.Size(100, 26);
            this.textBox_ZeroFlag.TabIndex = 40;
            this.textBox_ZeroFlag.Text = "0";
            // 
            // label_CarryFlag
            // 
            this.label_CarryFlag.AutoSize = true;
            this.label_CarryFlag.Location = new System.Drawing.Point(815, 412);
            this.label_CarryFlag.Name = "label_CarryFlag";
            this.label_CarryFlag.Size = new System.Drawing.Size(20, 20);
            this.label_CarryFlag.TabIndex = 41;
            this.label_CarryFlag.Text = "C";
            // 
            // label_ZeroFlag
            // 
            this.label_ZeroFlag.AutoSize = true;
            this.label_ZeroFlag.Location = new System.Drawing.Point(822, 476);
            this.label_ZeroFlag.Name = "label_ZeroFlag";
            this.label_ZeroFlag.Size = new System.Drawing.Size(19, 20);
            this.label_ZeroFlag.TabIndex = 42;
            this.label_ZeroFlag.Text = "Z";
            // 
            // text_Wert1
            // 
            this.text_Wert1.Location = new System.Drawing.Point(841, 505);
            this.text_Wert1.Name = "text_Wert1";
            this.text_Wert1.Size = new System.Drawing.Size(100, 26);
            this.text_Wert1.TabIndex = 43;
            this.text_Wert1.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(784, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Wert 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(784, 540);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Wert 2";
            // 
            // text_Wert2
            // 
            this.text_Wert2.Location = new System.Drawing.Point(841, 537);
            this.text_Wert2.Name = "text_Wert2";
            this.text_Wert2.Size = new System.Drawing.Size(100, 26);
            this.text_Wert2.TabIndex = 46;
            this.text_Wert2.Text = "0";
            // 
            // text_DC
            // 
            this.text_DC.Location = new System.Drawing.Point(841, 441);
            this.text_DC.Name = "text_DC";
            this.text_DC.Size = new System.Drawing.Size(100, 26);
            this.text_DC.TabIndex = 47;
            this.text_DC.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(803, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "DC";
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1258, 944);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_DC);
            this.Controls.Add(this.text_Wert2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_Wert1);
            this.Controls.Add(this.label_ZeroFlag);
            this.Controls.Add(this.label_CarryFlag);
            this.Controls.Add(this.textBox_ZeroFlag);
            this.Controls.Add(this.textBox_CarryFlag);
            this.Controls.Add(this.label_PC);
            this.Controls.Add(this.dataGridView_RegB);
            this.Controls.Add(this.dataGridView_RegA);
            this.Controls.Add(this.text_Pc);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegB)).EndInit();
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
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Cmd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Op;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_loop;
        private System.Windows.Forms.TextBox text_Pc;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegA_Bit0;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegA_Bit1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegA_Bit2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegA_Bit3;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegA_Bit4;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegA_Bit5;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegA_Bit6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reg1_bit7;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegA;
        private System.Windows.Forms.DataGridView dataGridView_RegA;
        private System.Windows.Forms.DataGridView dataGridView_RegB;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegB;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegB_Bit7;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegB_Bit6;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegB_Bit5;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegB_Bit4;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegB_Bit3;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegB_Bit2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegB_Bit1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegB_Bit0;
        private System.Windows.Forms.Label label_PC;
        private TextBox textBox_CarryFlag;
        private TextBox textBox_ZeroFlag;
        private System.Windows.Forms.Label label_CarryFlag;
        private System.Windows.Forms.Label label_ZeroFlag;
        private TextBox text_Wert1;
        private Label label1;
        private Label label2;
        private TextBox text_Wert2;
        private TextBox text_DC;
        private Label label3;
    }
}

