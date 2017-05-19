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
            this.text_Tmr0 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Timer_Takt = new System.Windows.Forms.Timer(this.components);
            this.text_Runtime = new System.Windows.Forms.TextBox();
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
            this.groupBox_SpecialRegs = new System.Windows.Forms.GroupBox();
            this.groupBox_Flags = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_Prescaler = new System.Windows.Forms.TextBox();
            this.button_B0 = new System.Windows.Forms.Button();
            this.button_bit_A7 = new System.Windows.Forms.Button();
            this.button_B6 = new System.Windows.Forms.Button();
            this.button_bit_A1 = new System.Windows.Forms.Button();
            this.button_B5 = new System.Windows.Forms.Button();
            this.button_bit_A2 = new System.Windows.Forms.Button();
            this.button_B4 = new System.Windows.Forms.Button();
            this.button_bit_A3 = new System.Windows.Forms.Button();
            this.button_B3 = new System.Windows.Forms.Button();
            this.button_bit_A4 = new System.Windows.Forms.Button();
            this.button_B2 = new System.Windows.Forms.Button();
            this.button_bit_A5 = new System.Windows.Forms.Button();
            this.button_B1 = new System.Windows.Forms.Button();
            this.button_bit_A6 = new System.Windows.Forms.Button();
            this.button_B7 = new System.Windows.Forms.Button();
            this.button_bit_A0 = new System.Windows.Forms.Button();
            this.button_bit_B0 = new System.Windows.Forms.Button();
            this.button_A7 = new System.Windows.Forms.Button();
            this.button_bit_B6 = new System.Windows.Forms.Button();
            this.button_A1 = new System.Windows.Forms.Button();
            this.button_bit_B5 = new System.Windows.Forms.Button();
            this.button_A2 = new System.Windows.Forms.Button();
            this.button_bit_B4 = new System.Windows.Forms.Button();
            this.button_A3 = new System.Windows.Forms.Button();
            this.button_bit_B3 = new System.Windows.Forms.Button();
            this.button_A5 = new System.Windows.Forms.Button();
            this.button_bit_B2 = new System.Windows.Forms.Button();
            this.button_A6 = new System.Windows.Forms.Button();
            this.button_bit_B1 = new System.Windows.Forms.Button();
            this.button_A0 = new System.Windows.Forms.Button();
            this.button_bit_B7 = new System.Windows.Forms.Button();
            this.button_A4 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Register)).BeginInit();
            this.groupBox_SpecialRegs.SuspendLayout();
            this.groupBox_Flags.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.dataGridView_prog.Size = new System.Drawing.Size(362, 769);
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
            this.text_W.Location = new System.Drawing.Point(31, 39);
            this.text_W.Margin = new System.Windows.Forms.Padding(2);
            this.text_W.Name = "text_W";
            this.text_W.Size = new System.Drawing.Size(43, 20);
            this.text_W.TabIndex = 9;
            this.text_W.Text = "0";
            // 
            // label_W
            // 
            this.label_W.AutoSize = true;
            this.label_W.Location = new System.Drawing.Point(12, 42);
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
            this.text_Pc.Location = new System.Drawing.Point(31, 18);
            this.text_Pc.Margin = new System.Windows.Forms.Padding(2);
            this.text_Pc.Name = "text_Pc";
            this.text_Pc.Size = new System.Drawing.Size(43, 20);
            this.text_Pc.TabIndex = 34;
            this.text_Pc.Text = "0";
            // 
            // label_PC
            // 
            this.label_PC.AutoSize = true;
            this.label_PC.Location = new System.Drawing.Point(9, 18);
            this.label_PC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PC.Name = "label_PC";
            this.label_PC.Size = new System.Drawing.Size(21, 13);
            this.label_PC.TabIndex = 37;
            this.label_PC.Text = "PC";
            // 
            // textBox_CarryFlag
            // 
            this.textBox_CarryFlag.Location = new System.Drawing.Point(31, 18);
            this.textBox_CarryFlag.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CarryFlag.Name = "textBox_CarryFlag";
            this.textBox_CarryFlag.Size = new System.Drawing.Size(26, 20);
            this.textBox_CarryFlag.TabIndex = 39;
            this.textBox_CarryFlag.Text = "0";
            // 
            // textBox_ZeroFlag
            // 
            this.textBox_ZeroFlag.Location = new System.Drawing.Point(31, 66);
            this.textBox_ZeroFlag.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ZeroFlag.Name = "textBox_ZeroFlag";
            this.textBox_ZeroFlag.Size = new System.Drawing.Size(26, 20);
            this.textBox_ZeroFlag.TabIndex = 40;
            this.textBox_ZeroFlag.Text = "0";
            // 
            // label_CarryFlag
            // 
            this.label_CarryFlag.AutoSize = true;
            this.label_CarryFlag.Location = new System.Drawing.Point(13, 21);
            this.label_CarryFlag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CarryFlag.Name = "label_CarryFlag";
            this.label_CarryFlag.Size = new System.Drawing.Size(14, 13);
            this.label_CarryFlag.TabIndex = 41;
            this.label_CarryFlag.Text = "C";
            // 
            // label_ZeroFlag
            // 
            this.label_ZeroFlag.AutoSize = true;
            this.label_ZeroFlag.Location = new System.Drawing.Point(13, 68);
            this.label_ZeroFlag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ZeroFlag.Name = "label_ZeroFlag";
            this.label_ZeroFlag.Size = new System.Drawing.Size(14, 13);
            this.label_ZeroFlag.TabIndex = 42;
            this.label_ZeroFlag.Text = "Z";
            // 
            // text_DC
            // 
            this.text_DC.Location = new System.Drawing.Point(31, 42);
            this.text_DC.Margin = new System.Windows.Forms.Padding(2);
            this.text_DC.Name = "text_DC";
            this.text_DC.Size = new System.Drawing.Size(26, 20);
            this.text_DC.TabIndex = 47;
            this.text_DC.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 45);
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
            this.dataGridView_Register.Location = new System.Drawing.Point(381, 343);
            this.dataGridView_Register.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_Register.Name = "dataGridView_Register";
            this.dataGridView_Register.RowTemplate.Height = 28;
            this.dataGridView_Register.Size = new System.Drawing.Size(341, 467);
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
            this.textBox_Quarz.Location = new System.Drawing.Point(11, 61);
            this.textBox_Quarz.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Quarz.Name = "textBox_Quarz";
            this.textBox_Quarz.Size = new System.Drawing.Size(43, 20);
            this.textBox_Quarz.TabIndex = 52;
            this.textBox_Quarz.Text = "4000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 64);
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
            this.text_Tmr0.Location = new System.Drawing.Point(15, 31);
            this.text_Tmr0.Margin = new System.Windows.Forms.Padding(2);
            this.text_Tmr0.Name = "text_Tmr0";
            this.text_Tmr0.Size = new System.Drawing.Size(68, 20);
            this.text_Tmr0.TabIndex = 55;
            this.text_Tmr0.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 16);
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
            this.text_Runtime.Location = new System.Drawing.Point(11, 21);
            this.text_Runtime.Margin = new System.Windows.Forms.Padding(2);
            this.text_Runtime.Name = "text_Runtime";
            this.text_Runtime.Size = new System.Drawing.Size(63, 20);
            this.text_Runtime.TabIndex = 57;
            this.text_Runtime.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Quartz";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "h";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "h";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "b";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(78, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "µs";
            // 
            // text_Takt
            // 
            this.text_Takt.Location = new System.Drawing.Point(969, 17);
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
            this.label10.Location = new System.Drawing.Point(936, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Takt";
            // 
            // ms
            // 
            this.ms.AutoSize = true;
            this.ms.Location = new System.Drawing.Point(1016, 20);
            this.ms.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(20, 13);
            this.ms.TabIndex = 66;
            this.ms.Text = "ms";
            // 
            // text_WatchDogTimer
            // 
            this.text_WatchDogTimer.Location = new System.Drawing.Point(15, 115);
            this.text_WatchDogTimer.Margin = new System.Windows.Forms.Padding(2);
            this.text_WatchDogTimer.Name = "text_WatchDogTimer";
            this.text_WatchDogTimer.Size = new System.Drawing.Size(53, 20);
            this.text_WatchDogTimer.TabIndex = 67;
            this.text_WatchDogTimer.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 100);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 68;
            this.label11.Text = "WatchdogTimer";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(70, 118);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 69;
            this.label12.Text = "µs";
            // 
            // groupBox_SpecialRegs
            // 
            this.groupBox_SpecialRegs.Controls.Add(this.text_Pc);
            this.groupBox_SpecialRegs.Controls.Add(this.text_W);
            this.groupBox_SpecialRegs.Controls.Add(this.label_W);
            this.groupBox_SpecialRegs.Controls.Add(this.label_PC);
            this.groupBox_SpecialRegs.Controls.Add(this.label6);
            this.groupBox_SpecialRegs.Controls.Add(this.label7);
            this.groupBox_SpecialRegs.Location = new System.Drawing.Point(381, 266);
            this.groupBox_SpecialRegs.Name = "groupBox_SpecialRegs";
            this.groupBox_SpecialRegs.Size = new System.Drawing.Size(111, 72);
            this.groupBox_SpecialRegs.TabIndex = 70;
            this.groupBox_SpecialRegs.TabStop = false;
            this.groupBox_SpecialRegs.Text = "Special Registers";
            // 
            // groupBox_Flags
            // 
            this.groupBox_Flags.Controls.Add(this.textBox_CarryFlag);
            this.groupBox_Flags.Controls.Add(this.textBox_ZeroFlag);
            this.groupBox_Flags.Controls.Add(this.label_CarryFlag);
            this.groupBox_Flags.Controls.Add(this.label_ZeroFlag);
            this.groupBox_Flags.Controls.Add(this.text_DC);
            this.groupBox_Flags.Controls.Add(this.label3);
            this.groupBox_Flags.Location = new System.Drawing.Point(499, 244);
            this.groupBox_Flags.Name = "groupBox_Flags";
            this.groupBox_Flags.Size = new System.Drawing.Size(87, 94);
            this.groupBox_Flags.TabIndex = 71;
            this.groupBox_Flags.TabStop = false;
            this.groupBox_Flags.Text = "Flags";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.text_Runtime);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox_Quarz);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(382, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 100);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Runtime";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.text_Prescaler);
            this.groupBox2.Controls.Add(this.text_Tmr0);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.text_WatchDogTimer);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(592, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 148);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "Tmr0 Prescaler";
            // 
            // text_Prescaler
            // 
            this.text_Prescaler.Location = new System.Drawing.Point(15, 70);
            this.text_Prescaler.Name = "text_Prescaler";
            this.text_Prescaler.Size = new System.Drawing.Size(53, 20);
            this.text_Prescaler.TabIndex = 70;
            this.text_Prescaler.Text = "0";
            // 
            // button_B0
            // 
            this.button_B0.Location = new System.Drawing.Point(1059, 178);
            this.button_B0.Margin = new System.Windows.Forms.Padding(0);
            this.button_B0.Name = "button_B0";
            this.button_B0.Size = new System.Drawing.Size(40, 40);
            this.button_B0.TabIndex = 90;
            this.button_B0.UseVisualStyleBackColor = true;
            this.button_B0.Click += new System.EventHandler(this.button_B0_Click);
            // 
            // button_bit_A7
            // 
            this.button_bit_A7.Location = new System.Drawing.Point(779, 103);
            this.button_bit_A7.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_A7.Name = "button_bit_A7";
            this.button_bit_A7.Size = new System.Drawing.Size(40, 40);
            this.button_bit_A7.TabIndex = 89;
            this.button_bit_A7.Text = "0";
            this.button_bit_A7.UseVisualStyleBackColor = true;
            this.button_bit_A7.Click += new System.EventHandler(this.button_bit_A7_Click);
            // 
            // button_B6
            // 
            this.button_B6.Location = new System.Drawing.Point(819, 178);
            this.button_B6.Margin = new System.Windows.Forms.Padding(0);
            this.button_B6.Name = "button_B6";
            this.button_B6.Size = new System.Drawing.Size(40, 40);
            this.button_B6.TabIndex = 91;
            this.button_B6.UseVisualStyleBackColor = true;
            this.button_B6.Click += new System.EventHandler(this.button_B6_Click);
            // 
            // button_bit_A1
            // 
            this.button_bit_A1.Location = new System.Drawing.Point(1019, 103);
            this.button_bit_A1.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_A1.Name = "button_bit_A1";
            this.button_bit_A1.Size = new System.Drawing.Size(40, 40);
            this.button_bit_A1.TabIndex = 88;
            this.button_bit_A1.Text = "0";
            this.button_bit_A1.UseVisualStyleBackColor = true;
            this.button_bit_A1.Click += new System.EventHandler(this.button_bit_A1_Click);
            // 
            // button_B5
            // 
            this.button_B5.Location = new System.Drawing.Point(859, 178);
            this.button_B5.Margin = new System.Windows.Forms.Padding(0);
            this.button_B5.Name = "button_B5";
            this.button_B5.Size = new System.Drawing.Size(40, 40);
            this.button_B5.TabIndex = 92;
            this.button_B5.UseVisualStyleBackColor = true;
            this.button_B5.Click += new System.EventHandler(this.button_B5_Click);
            // 
            // button_bit_A2
            // 
            this.button_bit_A2.Location = new System.Drawing.Point(979, 103);
            this.button_bit_A2.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_A2.Name = "button_bit_A2";
            this.button_bit_A2.Size = new System.Drawing.Size(40, 40);
            this.button_bit_A2.TabIndex = 87;
            this.button_bit_A2.Text = "0";
            this.button_bit_A2.UseVisualStyleBackColor = true;
            this.button_bit_A2.Click += new System.EventHandler(this.button_bit_A2_Click);
            // 
            // button_B4
            // 
            this.button_B4.Location = new System.Drawing.Point(899, 178);
            this.button_B4.Margin = new System.Windows.Forms.Padding(0);
            this.button_B4.Name = "button_B4";
            this.button_B4.Size = new System.Drawing.Size(40, 40);
            this.button_B4.TabIndex = 93;
            this.button_B4.UseVisualStyleBackColor = true;
            this.button_B4.Click += new System.EventHandler(this.button_B4_Click);
            // 
            // button_bit_A3
            // 
            this.button_bit_A3.Location = new System.Drawing.Point(939, 103);
            this.button_bit_A3.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_A3.Name = "button_bit_A3";
            this.button_bit_A3.Size = new System.Drawing.Size(40, 40);
            this.button_bit_A3.TabIndex = 86;
            this.button_bit_A3.Text = "0";
            this.button_bit_A3.UseVisualStyleBackColor = true;
            this.button_bit_A3.Click += new System.EventHandler(this.button_bit_A3_Click);
            // 
            // button_B3
            // 
            this.button_B3.Location = new System.Drawing.Point(939, 178);
            this.button_B3.Margin = new System.Windows.Forms.Padding(0);
            this.button_B3.Name = "button_B3";
            this.button_B3.Size = new System.Drawing.Size(40, 40);
            this.button_B3.TabIndex = 94;
            this.button_B3.UseVisualStyleBackColor = true;
            this.button_B3.Click += new System.EventHandler(this.button_B3_Click);
            // 
            // button_bit_A4
            // 
            this.button_bit_A4.Location = new System.Drawing.Point(899, 103);
            this.button_bit_A4.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_A4.Name = "button_bit_A4";
            this.button_bit_A4.Size = new System.Drawing.Size(40, 40);
            this.button_bit_A4.TabIndex = 85;
            this.button_bit_A4.Text = "0";
            this.button_bit_A4.UseVisualStyleBackColor = true;
            this.button_bit_A4.Click += new System.EventHandler(this.button_bit_A4_Click);
            // 
            // button_B2
            // 
            this.button_B2.Location = new System.Drawing.Point(979, 178);
            this.button_B2.Margin = new System.Windows.Forms.Padding(0);
            this.button_B2.Name = "button_B2";
            this.button_B2.Size = new System.Drawing.Size(40, 40);
            this.button_B2.TabIndex = 95;
            this.button_B2.UseVisualStyleBackColor = true;
            this.button_B2.Click += new System.EventHandler(this.button_B2_Click);
            // 
            // button_bit_A5
            // 
            this.button_bit_A5.Location = new System.Drawing.Point(859, 103);
            this.button_bit_A5.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_A5.Name = "button_bit_A5";
            this.button_bit_A5.Size = new System.Drawing.Size(40, 40);
            this.button_bit_A5.TabIndex = 84;
            this.button_bit_A5.Text = "0";
            this.button_bit_A5.UseVisualStyleBackColor = true;
            this.button_bit_A5.Click += new System.EventHandler(this.button_bit_A5_Click);
            // 
            // button_B1
            // 
            this.button_B1.Location = new System.Drawing.Point(1019, 178);
            this.button_B1.Margin = new System.Windows.Forms.Padding(0);
            this.button_B1.Name = "button_B1";
            this.button_B1.Size = new System.Drawing.Size(40, 40);
            this.button_B1.TabIndex = 96;
            this.button_B1.UseVisualStyleBackColor = true;
            this.button_B1.Click += new System.EventHandler(this.button_B1_Click);
            // 
            // button_bit_A6
            // 
            this.button_bit_A6.Location = new System.Drawing.Point(819, 103);
            this.button_bit_A6.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_A6.Name = "button_bit_A6";
            this.button_bit_A6.Size = new System.Drawing.Size(40, 40);
            this.button_bit_A6.TabIndex = 83;
            this.button_bit_A6.Text = "0";
            this.button_bit_A6.UseVisualStyleBackColor = true;
            this.button_bit_A6.Click += new System.EventHandler(this.button_bit_A6_Click);
            // 
            // button_B7
            // 
            this.button_B7.Location = new System.Drawing.Point(779, 178);
            this.button_B7.Margin = new System.Windows.Forms.Padding(0);
            this.button_B7.Name = "button_B7";
            this.button_B7.Size = new System.Drawing.Size(40, 40);
            this.button_B7.TabIndex = 97;
            this.button_B7.UseVisualStyleBackColor = true;
            this.button_B7.Click += new System.EventHandler(this.button_B7_Click);
            // 
            // button_bit_A0
            // 
            this.button_bit_A0.Location = new System.Drawing.Point(1059, 103);
            this.button_bit_A0.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_A0.Name = "button_bit_A0";
            this.button_bit_A0.Size = new System.Drawing.Size(40, 40);
            this.button_bit_A0.TabIndex = 82;
            this.button_bit_A0.Text = "0";
            this.button_bit_A0.UseVisualStyleBackColor = true;
            this.button_bit_A0.Click += new System.EventHandler(this.button_bit_A0_Click);
            // 
            // button_bit_B0
            // 
            this.button_bit_B0.Location = new System.Drawing.Point(1059, 218);
            this.button_bit_B0.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_B0.Name = "button_bit_B0";
            this.button_bit_B0.Size = new System.Drawing.Size(40, 40);
            this.button_bit_B0.TabIndex = 98;
            this.button_bit_B0.Text = "0";
            this.button_bit_B0.UseVisualStyleBackColor = true;
            this.button_bit_B0.Click += new System.EventHandler(this.button_bit_B0_Click);
            // 
            // button_A7
            // 
            this.button_A7.Location = new System.Drawing.Point(779, 63);
            this.button_A7.Margin = new System.Windows.Forms.Padding(0);
            this.button_A7.Name = "button_A7";
            this.button_A7.Size = new System.Drawing.Size(40, 40);
            this.button_A7.TabIndex = 81;
            this.button_A7.UseVisualStyleBackColor = true;
            this.button_A7.Click += new System.EventHandler(this.button_A7_Click);
            // 
            // button_bit_B6
            // 
            this.button_bit_B6.Location = new System.Drawing.Point(819, 218);
            this.button_bit_B6.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_B6.Name = "button_bit_B6";
            this.button_bit_B6.Size = new System.Drawing.Size(40, 40);
            this.button_bit_B6.TabIndex = 99;
            this.button_bit_B6.Text = "0";
            this.button_bit_B6.UseVisualStyleBackColor = true;
            this.button_bit_B6.Click += new System.EventHandler(this.button_bit_B6_Click);
            // 
            // button_A1
            // 
            this.button_A1.Location = new System.Drawing.Point(1019, 63);
            this.button_A1.Margin = new System.Windows.Forms.Padding(0);
            this.button_A1.Name = "button_A1";
            this.button_A1.Size = new System.Drawing.Size(40, 40);
            this.button_A1.TabIndex = 80;
            this.button_A1.UseVisualStyleBackColor = true;
            this.button_A1.Click += new System.EventHandler(this.button_A1_Click);
            // 
            // button_bit_B5
            // 
            this.button_bit_B5.Location = new System.Drawing.Point(859, 218);
            this.button_bit_B5.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_B5.Name = "button_bit_B5";
            this.button_bit_B5.Size = new System.Drawing.Size(40, 40);
            this.button_bit_B5.TabIndex = 100;
            this.button_bit_B5.Text = "0";
            this.button_bit_B5.UseVisualStyleBackColor = true;
            this.button_bit_B5.Click += new System.EventHandler(this.button_bit_B5_Click);
            // 
            // button_A2
            // 
            this.button_A2.Location = new System.Drawing.Point(979, 63);
            this.button_A2.Margin = new System.Windows.Forms.Padding(0);
            this.button_A2.Name = "button_A2";
            this.button_A2.Size = new System.Drawing.Size(40, 40);
            this.button_A2.TabIndex = 79;
            this.button_A2.UseVisualStyleBackColor = true;
            this.button_A2.Click += new System.EventHandler(this.button_A2_Click);
            // 
            // button_bit_B4
            // 
            this.button_bit_B4.Location = new System.Drawing.Point(899, 218);
            this.button_bit_B4.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_B4.Name = "button_bit_B4";
            this.button_bit_B4.Size = new System.Drawing.Size(40, 40);
            this.button_bit_B4.TabIndex = 101;
            this.button_bit_B4.Text = "0";
            this.button_bit_B4.UseVisualStyleBackColor = true;
            this.button_bit_B4.Click += new System.EventHandler(this.button_bit_B4_Click);
            // 
            // button_A3
            // 
            this.button_A3.Location = new System.Drawing.Point(939, 63);
            this.button_A3.Margin = new System.Windows.Forms.Padding(0);
            this.button_A3.Name = "button_A3";
            this.button_A3.Size = new System.Drawing.Size(40, 40);
            this.button_A3.TabIndex = 78;
            this.button_A3.UseVisualStyleBackColor = true;
            this.button_A3.Click += new System.EventHandler(this.button_A3_Click);
            // 
            // button_bit_B3
            // 
            this.button_bit_B3.Location = new System.Drawing.Point(939, 218);
            this.button_bit_B3.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_B3.Name = "button_bit_B3";
            this.button_bit_B3.Size = new System.Drawing.Size(40, 40);
            this.button_bit_B3.TabIndex = 102;
            this.button_bit_B3.Text = "0";
            this.button_bit_B3.UseVisualStyleBackColor = true;
            this.button_bit_B3.Click += new System.EventHandler(this.button_bit_B3_Click);
            // 
            // button_A5
            // 
            this.button_A5.Location = new System.Drawing.Point(859, 63);
            this.button_A5.Margin = new System.Windows.Forms.Padding(0);
            this.button_A5.Name = "button_A5";
            this.button_A5.Size = new System.Drawing.Size(40, 40);
            this.button_A5.TabIndex = 76;
            this.button_A5.UseVisualStyleBackColor = true;
            this.button_A5.Click += new System.EventHandler(this.button_A5_Click);
            // 
            // button_bit_B2
            // 
            this.button_bit_B2.Location = new System.Drawing.Point(979, 218);
            this.button_bit_B2.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_B2.Name = "button_bit_B2";
            this.button_bit_B2.Size = new System.Drawing.Size(40, 40);
            this.button_bit_B2.TabIndex = 103;
            this.button_bit_B2.Text = "0";
            this.button_bit_B2.UseVisualStyleBackColor = true;
            this.button_bit_B2.Click += new System.EventHandler(this.button_bit_B2_Click);
            // 
            // button_A6
            // 
            this.button_A6.Location = new System.Drawing.Point(819, 63);
            this.button_A6.Margin = new System.Windows.Forms.Padding(0);
            this.button_A6.Name = "button_A6";
            this.button_A6.Size = new System.Drawing.Size(40, 40);
            this.button_A6.TabIndex = 75;
            this.button_A6.UseVisualStyleBackColor = true;
            this.button_A6.Click += new System.EventHandler(this.button_A6_Click);
            // 
            // button_bit_B1
            // 
            this.button_bit_B1.Location = new System.Drawing.Point(1019, 218);
            this.button_bit_B1.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_B1.Name = "button_bit_B1";
            this.button_bit_B1.Size = new System.Drawing.Size(40, 40);
            this.button_bit_B1.TabIndex = 104;
            this.button_bit_B1.Text = "0";
            this.button_bit_B1.UseVisualStyleBackColor = true;
            this.button_bit_B1.Click += new System.EventHandler(this.button_bit_B1_Click);
            // 
            // button_A0
            // 
            this.button_A0.Location = new System.Drawing.Point(1059, 63);
            this.button_A0.Margin = new System.Windows.Forms.Padding(0);
            this.button_A0.Name = "button_A0";
            this.button_A0.Size = new System.Drawing.Size(40, 40);
            this.button_A0.TabIndex = 74;
            this.button_A0.UseVisualStyleBackColor = true;
            this.button_A0.Click += new System.EventHandler(this.button_A0_Click);
            // 
            // button_bit_B7
            // 
            this.button_bit_B7.Location = new System.Drawing.Point(779, 218);
            this.button_bit_B7.Margin = new System.Windows.Forms.Padding(0);
            this.button_bit_B7.Name = "button_bit_B7";
            this.button_bit_B7.Size = new System.Drawing.Size(40, 40);
            this.button_bit_B7.TabIndex = 105;
            this.button_bit_B7.Text = "0";
            this.button_bit_B7.UseVisualStyleBackColor = true;
            this.button_bit_B7.Click += new System.EventHandler(this.button_bit_B7_Click);
            // 
            // button_A4
            // 
            this.button_A4.Location = new System.Drawing.Point(899, 63);
            this.button_A4.Margin = new System.Windows.Forms.Padding(0);
            this.button_A4.Name = "button_A4";
            this.button_A4.Size = new System.Drawing.Size(40, 40);
            this.button_A4.TabIndex = 77;
            this.button_A4.UseVisualStyleBackColor = true;
            this.button_A4.Click += new System.EventHandler(this.button_A4_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(742, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 106;
            this.label13.Text = "Tris A";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(742, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 107;
            this.label14.Text = "Port A";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(742, 193);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 108;
            this.label15.Text = "Tris B";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(742, 232);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 13);
            this.label16.TabIndex = 109;
            this.label16.Text = "Port B";
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1264, 821);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button_A4);
            this.Controls.Add(this.button_bit_B7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_A0);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_bit_B1);
            this.Controls.Add(this.groupBox_Flags);
            this.Controls.Add(this.button_A6);
            this.Controls.Add(this.groupBox_SpecialRegs);
            this.Controls.Add(this.button_bit_B2);
            this.Controls.Add(this.ms);
            this.Controls.Add(this.button_A5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_bit_B3);
            this.Controls.Add(this.text_Takt);
            this.Controls.Add(this.button_A3);
            this.Controls.Add(this.Button_Help);
            this.Controls.Add(this.button_bit_B4);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_A2);
            this.Controls.Add(this.dataGridView_Register);
            this.Controls.Add(this.button_bit_B5);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.button_A1);
            this.Controls.Add(this.button_bit_B6);
            this.Controls.Add(this.button_A7);
            this.Controls.Add(this.button_bit_B0);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.button_bit_A0);
            this.Controls.Add(this.btn_Step);
            this.Controls.Add(this.button_B7);
            this.Controls.Add(this.dataGridView_prog);
            this.Controls.Add(this.button_bit_A6);
            this.Controls.Add(this.Btn_Open);
            this.Controls.Add(this.button_B1);
            this.Controls.Add(this.text_path);
            this.Controls.Add(this.button_bit_A5);
            this.Controls.Add(this.button_B0);
            this.Controls.Add(this.button_B2);
            this.Controls.Add(this.button_bit_A7);
            this.Controls.Add(this.button_bit_A4);
            this.Controls.Add(this.button_B6);
            this.Controls.Add(this.button_B3);
            this.Controls.Add(this.button_bit_A1);
            this.Controls.Add(this.button_bit_A3);
            this.Controls.Add(this.button_B5);
            this.Controls.Add(this.button_B4);
            this.Controls.Add(this.button_bit_A2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SimulatorForm";
            this.Text = "Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Register)).EndInit();
            this.groupBox_SpecialRegs.ResumeLayout(false);
            this.groupBox_SpecialRegs.PerformLayout();
            this.groupBox_Flags.ResumeLayout(false);
            this.groupBox_Flags.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private TextBox text_Tmr0;
        private Label label2;
        private Timer Timer_Takt;
        private TextBox text_Runtime;
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
        private GroupBox groupBox_SpecialRegs;
        private GroupBox groupBox_Flags;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox text_Prescaler;
        private Button button_B0;
        private Button button_bit_A7;
        private Button button_B6;
        private Button button_bit_A1;
        private Button button_B5;
        private Button button_bit_A2;
        private Button button_B4;
        private Button button_bit_A3;
        private Button button_B3;
        private Button button_bit_A4;
        private Button button_B2;
        private Button button_bit_A5;
        private Button button_B1;
        private Button button_bit_A6;
        private Button button_B7;
        private Button button_bit_A0;
        private Button button_bit_B0;
        private Button button_A7;
        private Button button_bit_B6;
        private Button button_A1;
        private Button button_bit_B5;
        private Button button_A2;
        private Button button_bit_B4;
        private Button button_A3;
        private Button button_bit_B3;
        private Button button_A5;
        private Button button_bit_B2;
        private Button button_A6;
        private Button button_bit_B1;
        private Button button_A0;
        private Button button_bit_B7;
        private Button button_A4;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
    }
}

