using System;
using System.IO;
using System.Windows.Forms;

namespace MicroSimulator
{
    partial class SimulatorForm
    {

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
            this.components = new System.ComponentModel.Container();
            this.text_path = new System.Windows.Forms.TextBox();
            this.Btn_Open = new System.Windows.Forms.Button();
            this.dataGridView_prog = new System.Windows.Forms.DataGridView();
            this.Column_BreakPoint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.text_DC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Reset = new System.Windows.Forms.Button();
            this.dataGridView_Register = new System.Windows.Forms.DataGridView();
            this.Column_Register = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RegHex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Bank2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Stop = new System.Windows.Forms.Button();
            this.Timer_prog = new System.Windows.Forms.Timer(this.components);
            this.textBox_Quarz = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_Help = new System.Windows.Forms.Button();
            this.Timer_0 = new System.Windows.Forms.Timer(this.components);
            this.text_Tmr0 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Timer_Takt = new System.Windows.Forms.Timer(this.components);
            this.text_Runtime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.text_Takt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ms = new System.Windows.Forms.Label();
            this.text_WatchDogTimer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Register)).BeginInit();
            this.SuspendLayout();
            // 
            // text_path
            // 
            this.text_path.Location = new System.Drawing.Point(15, 8);
            this.text_path.Margin = new System.Windows.Forms.Padding(0);
            this.text_path.Name = "text_path";
            this.text_path.ReadOnly = true;
            this.text_path.Size = new System.Drawing.Size(348, 20);
            this.text_path.TabIndex = 0;
            // 
            // Btn_Open
            // 
            this.Btn_Open.Location = new System.Drawing.Point(363, 6);
            this.Btn_Open.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Open.Name = "Btn_Open";
            this.Btn_Open.Size = new System.Drawing.Size(50, 23);
            this.Btn_Open.TabIndex = 7;
            this.Btn_Open.Text = "Open";
            this.Btn_Open.UseVisualStyleBackColor = true;
            this.Btn_Open.Click += new System.EventHandler(this.Btn_Open_Click);
            // 
            // dataGridView_prog
            // 
            this.dataGridView_prog.AllowUserToAddRows = false;
            this.dataGridView_prog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_prog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_prog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_BreakPoint,
            this.Column_ID,
            this.Column_Cmd,
            this.Column_Op,
            this.Column_loop});
            this.dataGridView_prog.Location = new System.Drawing.Point(15, 41);
            this.dataGridView_prog.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_prog.Name = "dataGridView_prog";
            this.dataGridView_prog.RowTemplate.Height = 28;
            this.dataGridView_prog.Size = new System.Drawing.Size(362, 641);
            this.dataGridView_prog.TabIndex = 8;
            // 
            // Column_BreakPoint
            // 
            this.Column_BreakPoint.FillWeight = 30F;
            this.Column_BreakPoint.HeaderText = "BP";
            this.Column_BreakPoint.Name = "Column_BreakPoint";
            this.Column_BreakPoint.Width = 20;
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
            this.text_W.BackColor = System.Drawing.SystemColors.Info;
            this.text_W.Location = new System.Drawing.Point(712, 233);
            this.text_W.Margin = new System.Windows.Forms.Padding(2);
            this.text_W.Name = "text_W";
            this.text_W.Size = new System.Drawing.Size(43, 20);
            this.text_W.TabIndex = 9;
            this.text_W.Text = "0";
            // 
            // label_W
            // 
            this.label_W.AutoSize = true;
            this.label_W.Location = new System.Drawing.Point(693, 236);
            this.label_W.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_W.Name = "label_W";
            this.label_W.Size = new System.Drawing.Size(18, 13);
            this.label_W.TabIndex = 31;
            this.label_W.Text = "W";
            // 
            // btn_Step
            // 
            this.btn_Step.Location = new System.Drawing.Point(381, 100);
            this.btn_Step.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Step.Name = "btn_Step";
            this.btn_Step.Size = new System.Drawing.Size(65, 27);
            this.btn_Step.TabIndex = 32;
            this.btn_Step.Text = "Next";
            this.btn_Step.UseVisualStyleBackColor = true;
            this.btn_Step.Click += new System.EventHandler(this.Btn_Step_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(381, 41);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(65, 26);
            this.btn_Start.TabIndex = 33;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // text_Pc
            // 
            this.text_Pc.Location = new System.Drawing.Point(712, 209);
            this.text_Pc.Margin = new System.Windows.Forms.Padding(2);
            this.text_Pc.Name = "text_Pc";
            this.text_Pc.Size = new System.Drawing.Size(43, 20);
            this.text_Pc.TabIndex = 34;
            this.text_Pc.Text = "0";
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
            this.dataGridView_RegA.Location = new System.Drawing.Point(527, 41);
            this.dataGridView_RegA.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_RegA.Name = "dataGridView_RegA";
            this.dataGridView_RegA.ReadOnly = true;
            this.dataGridView_RegA.RowTemplate.Height = 28;
            this.dataGridView_RegA.Size = new System.Drawing.Size(303, 79);
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
            this.dataGridView_RegB.Location = new System.Drawing.Point(527, 124);
            this.dataGridView_RegB.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_RegB.Name = "dataGridView_RegB";
            this.dataGridView_RegB.ReadOnly = true;
            this.dataGridView_RegB.RowTemplate.Height = 28;
            this.dataGridView_RegB.Size = new System.Drawing.Size(303, 79);
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
            this.label_PC.Location = new System.Drawing.Point(690, 212);
            this.label_PC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PC.Name = "label_PC";
            this.label_PC.Size = new System.Drawing.Size(21, 13);
            this.label_PC.TabIndex = 37;
            this.label_PC.Text = "PC";
            // 
            // textBox_CarryFlag
            // 
            this.textBox_CarryFlag.Location = new System.Drawing.Point(712, 257);
            this.textBox_CarryFlag.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CarryFlag.Name = "textBox_CarryFlag";
            this.textBox_CarryFlag.Size = new System.Drawing.Size(26, 20);
            this.textBox_CarryFlag.TabIndex = 39;
            this.textBox_CarryFlag.Text = "0";
            // 
            // textBox_ZeroFlag
            // 
            this.textBox_ZeroFlag.Location = new System.Drawing.Point(712, 305);
            this.textBox_ZeroFlag.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ZeroFlag.Name = "textBox_ZeroFlag";
            this.textBox_ZeroFlag.Size = new System.Drawing.Size(26, 20);
            this.textBox_ZeroFlag.TabIndex = 40;
            this.textBox_ZeroFlag.Text = "0";
            // 
            // label_CarryFlag
            // 
            this.label_CarryFlag.AutoSize = true;
            this.label_CarryFlag.Location = new System.Drawing.Point(694, 260);
            this.label_CarryFlag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CarryFlag.Name = "label_CarryFlag";
            this.label_CarryFlag.Size = new System.Drawing.Size(14, 13);
            this.label_CarryFlag.TabIndex = 41;
            this.label_CarryFlag.Text = "C";
            // 
            // label_ZeroFlag
            // 
            this.label_ZeroFlag.AutoSize = true;
            this.label_ZeroFlag.Location = new System.Drawing.Point(694, 307);
            this.label_ZeroFlag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ZeroFlag.Name = "label_ZeroFlag";
            this.label_ZeroFlag.Size = new System.Drawing.Size(14, 13);
            this.label_ZeroFlag.TabIndex = 42;
            this.label_ZeroFlag.Text = "Z";
            // 
            // text_DC
            // 
            this.text_DC.Location = new System.Drawing.Point(712, 281);
            this.text_DC.Margin = new System.Windows.Forms.Padding(2);
            this.text_DC.Name = "text_DC";
            this.text_DC.Size = new System.Drawing.Size(26, 20);
            this.text_DC.TabIndex = 47;
            this.text_DC.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(689, 284);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "DC";
            // 
            // button_Reset
            // 
            this.button_Reset.Location = new System.Drawing.Point(381, 131);
            this.button_Reset.Margin = new System.Windows.Forms.Padding(2);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(65, 29);
            this.button_Reset.TabIndex = 49;
            this.button_Reset.Text = "Reset";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // dataGridView_Register
            // 
            this.dataGridView_Register.AllowUserToAddRows = false;
            this.dataGridView_Register.AllowUserToDeleteRows = false;
            this.dataGridView_Register.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Register.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Register,
            this.Column_RegHex,
            this.Column_Value,
            this.Column_Bank2});
            this.dataGridView_Register.Location = new System.Drawing.Point(475, 343);
            this.dataGridView_Register.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_Register.Name = "dataGridView_Register";
            this.dataGridView_Register.RowTemplate.Height = 28;
            this.dataGridView_Register.Size = new System.Drawing.Size(354, 339);
            this.dataGridView_Register.TabIndex = 50;
            // 
            // Column_Register
            // 
            this.Column_Register.HeaderText = "Register";
            this.Column_Register.Name = "Column_Register";
            // 
            // Column_RegHex
            // 
            this.Column_RegHex.HeaderText = "Hex";
            this.Column_RegHex.Name = "Column_RegHex";
            this.Column_RegHex.Width = 50;
            // 
            // Column_Value
            // 
            this.Column_Value.HeaderText = "Bank0";
            this.Column_Value.Name = "Column_Value";
            this.Column_Value.Width = 70;
            // 
            // Column_Bank2
            // 
            this.Column_Bank2.HeaderText = "Bank1";
            this.Column_Bank2.Name = "Column_Bank2";
            this.Column_Bank2.Width = 70;
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(381, 71);
            this.button_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(65, 25);
            this.button_Stop.TabIndex = 51;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // Timer_prog
            // 
            this.Timer_prog.Tick += new System.EventHandler(this.Timer_prog_Tick);
            // 
            // textBox_Quarz
            // 
            this.textBox_Quarz.Location = new System.Drawing.Point(559, 239);
            this.textBox_Quarz.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Quarz.Name = "textBox_Quarz";
            this.textBox_Quarz.Size = new System.Drawing.Size(43, 20);
            this.textBox_Quarz.TabIndex = 52;
            this.textBox_Quarz.Text = "4000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(602, 242);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Hz";
            // 
            // Button_Help
            // 
            this.Button_Help.Location = new System.Drawing.Point(415, 6);
            this.Button_Help.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Help.Name = "Button_Help";
            this.Button_Help.Size = new System.Drawing.Size(42, 23);
            this.Button_Help.TabIndex = 54;
            this.Button_Help.Text = "Help";
            this.Button_Help.UseVisualStyleBackColor = true;
            this.Button_Help.Click += new System.EventHandler(this.Button_Help_Click);
            // 
            // text_Tmr0
            // 
            this.text_Tmr0.Location = new System.Drawing.Point(559, 287);
            this.text_Tmr0.Margin = new System.Windows.Forms.Padding(2);
            this.text_Tmr0.Name = "text_Tmr0";
            this.text_Tmr0.Size = new System.Drawing.Size(68, 20);
            this.text_Tmr0.TabIndex = 55;
            this.text_Tmr0.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(528, 290);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Tmr0";
            // 
            // Timer_Takt
            // 
            this.Timer_Takt.Tick += new System.EventHandler(this.Timer_Takt_Tick);
            // 
            // text_Runtime
            // 
            this.text_Runtime.Location = new System.Drawing.Point(559, 215);
            this.text_Runtime.Margin = new System.Windows.Forms.Padding(2);
            this.text_Runtime.Name = "text_Runtime";
            this.text_Runtime.Size = new System.Drawing.Size(63, 20);
            this.text_Runtime.TabIndex = 57;
            this.text_Runtime.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 218);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "RunTime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(519, 242);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Quartz";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(759, 236);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "h";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(759, 212);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "h";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(626, 290);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "b";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(621, 218);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "µs";
            // 
            // text_Takt
            // 
            this.text_Takt.Location = new System.Drawing.Point(559, 263);
            this.text_Takt.Margin = new System.Windows.Forms.Padding(2);
            this.text_Takt.Name = "text_Takt";
            this.text_Takt.Size = new System.Drawing.Size(43, 20);
            this.text_Takt.TabIndex = 64;
            this.text_Takt.Text = "0";
            this.text_Takt.TextChanged += new System.EventHandler(this.text_Takt_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(528, 266);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Takt";
            // 
            // ms
            // 
            this.ms.AutoSize = true;
            this.ms.Location = new System.Drawing.Point(602, 266);
            this.ms.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(20, 13);
            this.ms.TabIndex = 66;
            this.ms.Text = "ms";
            // 
            // text_WatchDogTimer
            // 
            this.text_WatchDogTimer.Location = new System.Drawing.Point(559, 311);
            this.text_WatchDogTimer.Margin = new System.Windows.Forms.Padding(2);
            this.text_WatchDogTimer.Name = "text_WatchDogTimer";
            this.text_WatchDogTimer.Size = new System.Drawing.Size(63, 20);
            this.text_WatchDogTimer.TabIndex = 67;
            this.text_WatchDogTimer.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(524, 314);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 68;
            this.label11.Text = "WDT";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(621, 314);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 69;
            this.label12.Text = "ms";
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(839, 693);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.text_WatchDogTimer);
            this.Controls.Add(this.ms);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.text_Takt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_Runtime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_Tmr0);
            this.Controls.Add(this.Button_Help);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Quarz);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.dataGridView_Register);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_DC);
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
            this.Controls.Add(this.Btn_Open);
            this.Controls.Add(this.text_path);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SimulatorForm";
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.SimulatorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RegB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Register)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox text_path;
        private System.Windows.Forms.Button Btn_Open;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox text_W;
        private System.Windows.Forms.Label reg_W;
        private System.Windows.Forms.Label label_W;
        private System.Windows.Forms.Button btn_Step;
        private System.Windows.Forms.DataGridView dataGridView_prog;
        private System.Windows.Forms.Button btn_Start;
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
        private TextBox text_DC;
        private Label label3;
        private Button button_Reset;
        private DataGridView dataGridView_Register;
        private Button button_Stop;
        private System.ComponentModel.IContainer components;
        private Timer Timer_prog;
        private DataGridViewCheckBoxColumn Column_BreakPoint;
        private DataGridViewTextBoxColumn Column_ID;
        private DataGridViewTextBoxColumn Column_Cmd;
        private DataGridViewTextBoxColumn Column_Op;
        private DataGridViewTextBoxColumn Column_loop;
        private TextBox textBox_Quarz;
        private Label label1;
        private Button Button_Help;
        private Timer Timer_0;
        private TextBox text_Tmr0;
        private Label label2;
        private Timer Timer_Takt;
        private TextBox text_Runtime;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private DataGridViewTextBoxColumn Column_Register;
        private DataGridViewTextBoxColumn Column_RegHex;
        private DataGridViewTextBoxColumn Column_Value;
        private DataGridViewTextBoxColumn Column_Bank2;
        private TextBox text_Takt;
        private Label label10;
        private Label ms;
        private TextBox text_WatchDogTimer;
        private Label label11;
        private Label label12;
    }
}

