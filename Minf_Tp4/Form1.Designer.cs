using System.IO.Ports;

namespace Minf_Tp4
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PortComDropDown = new ReaLTaiizor.Controls.DungeonComboBox();
            this.Send_Button = new ReaLTaiizor.Controls.Button();
            this.Continous_Send_Button = new ReaLTaiizor.Controls.Button();
            this.Frequency_TB = new ReaLTaiizor.Controls.CrownTextBox();
            this.Amplitude_TB = new ReaLTaiizor.Controls.CrownTextBox();
            this.Forme = new ReaLTaiizor.Controls.CrownLabel();
            this.Offset_TB = new ReaLTaiizor.Controls.CrownTextBox();
            this.Frequency_TrackB = new ReaLTaiizor.Controls.DungeonTrackBar();
            this.crownLabel1 = new ReaLTaiizor.Controls.CrownLabel();
            this.Amplitude_TrackB = new ReaLTaiizor.Controls.DungeonTrackBar();
            this.crownLabel2 = new ReaLTaiizor.Controls.CrownLabel();
            this.Save_Button = new ReaLTaiizor.Controls.Button();
            this.crownLabel3 = new ReaLTaiizor.Controls.CrownLabel();
            this.Transmission_TB = new ReaLTaiizor.Controls.ForeverTextBox();
            this.Offset_TrackB = new ReaLTaiizor.Controls.DungeonTrackBar();
            this.FormeDropDown = new ReaLTaiizor.Controls.DungeonComboBox();
            this.Transmission_GB = new ReaLTaiizor.Controls.CrownGroupBox();
            this.Reception_GB = new ReaLTaiizor.Controls.CrownGroupBox();
            this.Form_RB = new ReaLTaiizor.Controls.CrownTextBox();
            this.Recieve_RB = new ReaLTaiizor.Controls.ForeverTextBox();
            this.crownLabel4 = new ReaLTaiizor.Controls.CrownLabel();
            this.crownLabel5 = new ReaLTaiizor.Controls.CrownLabel();
            this.crownLabel6 = new ReaLTaiizor.Controls.CrownLabel();
            this.Offset_RB = new ReaLTaiizor.Controls.CrownTextBox();
            this.crownLabel7 = new ReaLTaiizor.Controls.CrownLabel();
            this.Amplitude_RB = new ReaLTaiizor.Controls.CrownTextBox();
            this.Frequency_RB = new ReaLTaiizor.Controls.CrownTextBox();
            this.crownLabel8 = new ReaLTaiizor.Controls.CrownLabel();
            this.Select_Button = new ReaLTaiizor.Controls.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.Transmission_GB.SuspendLayout();
            this.Reception_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortComDropDown
            // 
            this.PortComDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.PortComDropDown.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(132)))), ((int)(((byte)(85)))));
            this.PortComDropDown.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.PortComDropDown.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.PortComDropDown.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.PortComDropDown.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.PortComDropDown.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.PortComDropDown.ColorG = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(118)))));
            this.PortComDropDown.ColorH = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.PortComDropDown.ColorI = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.PortComDropDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PortComDropDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PortComDropDown.DropDownHeight = 100;
            this.PortComDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortComDropDown.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PortComDropDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(97)))));
            this.PortComDropDown.FormattingEnabled = true;
            this.PortComDropDown.HoverSelectionColor = System.Drawing.Color.Empty;
            this.PortComDropDown.IntegralHeight = false;
            this.PortComDropDown.ItemHeight = 20;
            this.PortComDropDown.Location = new System.Drawing.Point(408, 20);
            this.PortComDropDown.Name = "PortComDropDown";
            this.PortComDropDown.Size = new System.Drawing.Size(120, 26);
            this.PortComDropDown.StartIndex = 0;
            this.PortComDropDown.TabIndex = 3;
            this.PortComDropDown.DropDown += new System.EventHandler(this.PortComDropDown_DD);
            // 
            // Send_Button
            // 
            this.Send_Button.BackColor = System.Drawing.Color.DarkGray;
            this.Send_Button.BorderColor = System.Drawing.Color.White;
            this.Send_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Send_Button.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Send_Button.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.Send_Button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_Button.Image = null;
            this.Send_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Send_Button.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Send_Button.Location = new System.Drawing.Point(385, 83);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Send_Button.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Send_Button.Size = new System.Drawing.Size(133, 40);
            this.Send_Button.TabIndex = 32;
            this.Send_Button.Text = "Send";
            this.Send_Button.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // Continous_Send_Button
            // 
            this.Continous_Send_Button.BackColor = System.Drawing.Color.DarkGray;
            this.Continous_Send_Button.BorderColor = System.Drawing.Color.White;
            this.Continous_Send_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Continous_Send_Button.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Continous_Send_Button.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.Continous_Send_Button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continous_Send_Button.Image = null;
            this.Continous_Send_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Continous_Send_Button.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Continous_Send_Button.Location = new System.Drawing.Point(385, 161);
            this.Continous_Send_Button.Name = "Continous_Send_Button";
            this.Continous_Send_Button.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Continous_Send_Button.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Continous_Send_Button.Size = new System.Drawing.Size(133, 40);
            this.Continous_Send_Button.TabIndex = 37;
            this.Continous_Send_Button.Text = "Continous Send";
            this.Continous_Send_Button.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Continous_Send_Button.Click += new System.EventHandler(this.Continous_Send_Button_Click);
            // 
            // Frequency_TB
            // 
            this.Frequency_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Frequency_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Frequency_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Frequency_TB.Location = new System.Drawing.Point(290, 100);
            this.Frequency_TB.Name = "Frequency_TB";
            this.Frequency_TB.Size = new System.Drawing.Size(83, 20);
            this.Frequency_TB.TabIndex = 39;
            this.Frequency_TB.TextChanged += new System.EventHandler(this.Frequency_TB_TC);
            // 
            // Amplitude_TB
            // 
            this.Amplitude_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Amplitude_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Amplitude_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Amplitude_TB.Location = new System.Drawing.Point(290, 150);
            this.Amplitude_TB.Name = "Amplitude_TB";
            this.Amplitude_TB.Size = new System.Drawing.Size(83, 20);
            this.Amplitude_TB.TabIndex = 41;
            this.Amplitude_TB.TextChanged += new System.EventHandler(this.Amplitude_TB_TC);
            // 
            // Forme
            // 
            this.Forme.AutoSize = true;
            this.Forme.BackColor = System.Drawing.Color.Transparent;
            this.Forme.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.Forme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Forme.Location = new System.Drawing.Point(6, 39);
            this.Forme.Name = "Forme";
            this.Forme.Size = new System.Drawing.Size(52, 19);
            this.Forme.TabIndex = 0;
            this.Forme.Text = "Forme";
            // 
            // Offset_TB
            // 
            this.Offset_TB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Offset_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Offset_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Offset_TB.Location = new System.Drawing.Point(290, 204);
            this.Offset_TB.Name = "Offset_TB";
            this.Offset_TB.Size = new System.Drawing.Size(83, 20);
            this.Offset_TB.TabIndex = 42;
            this.Offset_TB.TextChanged += new System.EventHandler(this.Offset_TB_TC);
            // 
            // Frequency_TrackB
            // 
            this.Frequency_TrackB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Frequency_TrackB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Frequency_TrackB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Frequency_TrackB.DrawValueString = false;
            this.Frequency_TrackB.EmptyBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Frequency_TrackB.FillBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(99)))), ((int)(((byte)(50)))));
            this.Frequency_TrackB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Frequency_TrackB.JumpToMouse = false;
            this.Frequency_TrackB.Location = new System.Drawing.Point(108, 101);
            this.Frequency_TrackB.Maximum = 10;
            this.Frequency_TrackB.Minimum = 0;
            this.Frequency_TrackB.MinimumSize = new System.Drawing.Size(47, 22);
            this.Frequency_TrackB.Name = "Frequency_TrackB";
            this.Frequency_TrackB.Size = new System.Drawing.Size(173, 22);
            this.Frequency_TrackB.TabIndex = 43;
            this.Frequency_TrackB.Text = "dungeonTrackBar1";
            this.Frequency_TrackB.ThumbBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Frequency_TrackB.ThumbBorderColor = System.Drawing.Color.Silver;
            this.Frequency_TrackB.Value = 0;
            this.Frequency_TrackB.ValueDivison = ReaLTaiizor.Controls.DungeonTrackBar.ValueDivisor.By10;
            this.Frequency_TrackB.ValueToSet = 0F;
            this.Frequency_TrackB.ValueChanged += new ReaLTaiizor.Controls.DungeonTrackBar.ValueChangedEventHandler(this.Frequency_TrackB_VC);
            // 
            // crownLabel1
            // 
            this.crownLabel1.AutoSize = true;
            this.crownLabel1.BackColor = System.Drawing.Color.Transparent;
            this.crownLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.crownLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.crownLabel1.Location = new System.Drawing.Point(6, 104);
            this.crownLabel1.Name = "crownLabel1";
            this.crownLabel1.Size = new System.Drawing.Size(79, 19);
            this.crownLabel1.TabIndex = 1;
            this.crownLabel1.Text = "Frequency";
            // 
            // Amplitude_TrackB
            // 
            this.Amplitude_TrackB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Amplitude_TrackB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Amplitude_TrackB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Amplitude_TrackB.DrawValueString = false;
            this.Amplitude_TrackB.EmptyBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Amplitude_TrackB.FillBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(99)))), ((int)(((byte)(50)))));
            this.Amplitude_TrackB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Amplitude_TrackB.JumpToMouse = false;
            this.Amplitude_TrackB.Location = new System.Drawing.Point(108, 149);
            this.Amplitude_TrackB.Maximum = 10;
            this.Amplitude_TrackB.Minimum = 0;
            this.Amplitude_TrackB.MinimumSize = new System.Drawing.Size(47, 22);
            this.Amplitude_TrackB.Name = "Amplitude_TrackB";
            this.Amplitude_TrackB.Size = new System.Drawing.Size(173, 22);
            this.Amplitude_TrackB.TabIndex = 44;
            this.Amplitude_TrackB.Text = "dungeonTrackBar2";
            this.Amplitude_TrackB.ThumbBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Amplitude_TrackB.ThumbBorderColor = System.Drawing.Color.Silver;
            this.Amplitude_TrackB.Value = 0;
            this.Amplitude_TrackB.ValueDivison = ReaLTaiizor.Controls.DungeonTrackBar.ValueDivisor.By100;
            this.Amplitude_TrackB.ValueToSet = 0F;
            this.Amplitude_TrackB.ValueChanged += new ReaLTaiizor.Controls.DungeonTrackBar.ValueChangedEventHandler(this.Amplitude_TrackB_VC);
            // 
            // crownLabel2
            // 
            this.crownLabel2.AutoSize = true;
            this.crownLabel2.BackColor = System.Drawing.Color.Transparent;
            this.crownLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.crownLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.crownLabel2.Location = new System.Drawing.Point(6, 152);
            this.crownLabel2.Name = "crownLabel2";
            this.crownLabel2.Size = new System.Drawing.Size(77, 19);
            this.crownLabel2.TabIndex = 2;
            this.crownLabel2.Text = "Amplitude";
            // 
            // Save_Button
            // 
            this.Save_Button.BackColor = System.Drawing.Color.DarkGray;
            this.Save_Button.BorderColor = System.Drawing.Color.White;
            this.Save_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save_Button.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Save_Button.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.Save_Button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_Button.Image = null;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Save_Button.Location = new System.Drawing.Point(384, 240);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Save_Button.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Save_Button.Size = new System.Drawing.Size(133, 40);
            this.Save_Button.TabIndex = 38;
            this.Save_Button.Text = "Save";
            this.Save_Button.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // crownLabel3
            // 
            this.crownLabel3.AutoSize = true;
            this.crownLabel3.BackColor = System.Drawing.Color.Transparent;
            this.crownLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.crownLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.crownLabel3.Location = new System.Drawing.Point(6, 206);
            this.crownLabel3.Name = "crownLabel3";
            this.crownLabel3.Size = new System.Drawing.Size(51, 19);
            this.crownLabel3.TabIndex = 3;
            this.crownLabel3.Text = "Offset";
            // 
            // Transmission_TB
            // 
            this.Transmission_TB.BackColor = System.Drawing.Color.Transparent;
            this.Transmission_TB.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.Transmission_TB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.Transmission_TB.FocusOnHover = false;
            this.Transmission_TB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Transmission_TB.Location = new System.Drawing.Point(10, 266);
            this.Transmission_TB.MaxLength = 32767;
            this.Transmission_TB.Multiline = false;
            this.Transmission_TB.Name = "Transmission_TB";
            this.Transmission_TB.ReadOnly = true;
            this.Transmission_TB.Size = new System.Drawing.Size(355, 29);
            this.Transmission_TB.TabIndex = 40;
            this.Transmission_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Transmission_TB.UseSystemPasswordChar = false;
            // 
            // Offset_TrackB
            // 
            this.Offset_TrackB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Offset_TrackB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Offset_TrackB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Offset_TrackB.DrawValueString = false;
            this.Offset_TrackB.EmptyBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Offset_TrackB.FillBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(99)))), ((int)(((byte)(50)))));
            this.Offset_TrackB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Offset_TrackB.JumpToMouse = false;
            this.Offset_TrackB.Location = new System.Drawing.Point(108, 203);
            this.Offset_TrackB.Maximum = 10;
            this.Offset_TrackB.Minimum = 0;
            this.Offset_TrackB.MinimumSize = new System.Drawing.Size(47, 22);
            this.Offset_TrackB.Name = "Offset_TrackB";
            this.Offset_TrackB.Size = new System.Drawing.Size(173, 22);
            this.Offset_TrackB.TabIndex = 45;
            this.Offset_TrackB.Text = "dungeonTrackBar3";
            this.Offset_TrackB.ThumbBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Offset_TrackB.ThumbBorderColor = System.Drawing.Color.Silver;
            this.Offset_TrackB.Value = 0;
            this.Offset_TrackB.ValueDivison = ReaLTaiizor.Controls.DungeonTrackBar.ValueDivisor.By10;
            this.Offset_TrackB.ValueToSet = 0F;
            this.Offset_TrackB.ValueChanged += new ReaLTaiizor.Controls.DungeonTrackBar.ValueChangedEventHandler(this.Offset_TrackB_VC);
            // 
            // FormeDropDown
            // 
            this.FormeDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.FormeDropDown.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(132)))), ((int)(((byte)(85)))));
            this.FormeDropDown.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.FormeDropDown.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.FormeDropDown.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.FormeDropDown.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.FormeDropDown.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.FormeDropDown.ColorG = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(118)))));
            this.FormeDropDown.ColorH = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.FormeDropDown.ColorI = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.FormeDropDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormeDropDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FormeDropDown.DropDownHeight = 100;
            this.FormeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormeDropDown.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormeDropDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(97)))));
            this.FormeDropDown.FormattingEnabled = true;
            this.FormeDropDown.HoverSelectionColor = System.Drawing.Color.Empty;
            this.FormeDropDown.IntegralHeight = false;
            this.FormeDropDown.ItemHeight = 20;
            this.FormeDropDown.Items.AddRange(new object[] {
            "Sinus",
            "Carre",
            "Triangle",
            "Dent de scie"});
            this.FormeDropDown.Location = new System.Drawing.Point(108, 32);
            this.FormeDropDown.Name = "FormeDropDown";
            this.FormeDropDown.Size = new System.Drawing.Size(173, 26);
            this.FormeDropDown.StartIndex = 0;
            this.FormeDropDown.TabIndex = 46;
            // 
            // Transmission_GB
            // 
            this.Transmission_GB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Transmission_GB.Controls.Add(this.FormeDropDown);
            this.Transmission_GB.Controls.Add(this.Offset_TrackB);
            this.Transmission_GB.Controls.Add(this.Transmission_TB);
            this.Transmission_GB.Controls.Add(this.crownLabel3);
            this.Transmission_GB.Controls.Add(this.Save_Button);
            this.Transmission_GB.Controls.Add(this.crownLabel2);
            this.Transmission_GB.Controls.Add(this.Amplitude_TrackB);
            this.Transmission_GB.Controls.Add(this.crownLabel1);
            this.Transmission_GB.Controls.Add(this.Frequency_TrackB);
            this.Transmission_GB.Controls.Add(this.Offset_TB);
            this.Transmission_GB.Controls.Add(this.Forme);
            this.Transmission_GB.Controls.Add(this.Amplitude_TB);
            this.Transmission_GB.Controls.Add(this.Frequency_TB);
            this.Transmission_GB.Controls.Add(this.Continous_Send_Button);
            this.Transmission_GB.Controls.Add(this.Send_Button);
            this.Transmission_GB.Location = new System.Drawing.Point(12, 80);
            this.Transmission_GB.Name = "Transmission_GB";
            this.Transmission_GB.Size = new System.Drawing.Size(523, 322);
            this.Transmission_GB.TabIndex = 43;
            this.Transmission_GB.TabStop = false;
            this.Transmission_GB.Text = "Transmission";
            // 
            // Reception_GB
            // 
            this.Reception_GB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Reception_GB.Controls.Add(this.Form_RB);
            this.Reception_GB.Controls.Add(this.Recieve_RB);
            this.Reception_GB.Controls.Add(this.crownLabel4);
            this.Reception_GB.Controls.Add(this.crownLabel5);
            this.Reception_GB.Controls.Add(this.crownLabel6);
            this.Reception_GB.Controls.Add(this.Offset_RB);
            this.Reception_GB.Controls.Add(this.crownLabel7);
            this.Reception_GB.Controls.Add(this.Amplitude_RB);
            this.Reception_GB.Controls.Add(this.Frequency_RB);
            this.Reception_GB.Location = new System.Drawing.Point(551, 80);
            this.Reception_GB.Name = "Reception_GB";
            this.Reception_GB.Size = new System.Drawing.Size(391, 322);
            this.Reception_GB.TabIndex = 47;
            this.Reception_GB.TabStop = false;
            this.Reception_GB.Text = "Reception";
            // 
            // Form_RB
            // 
            this.Form_RB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Form_RB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Form_RB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Form_RB.Location = new System.Drawing.Point(169, 32);
            this.Form_RB.Name = "Form_RB";
            this.Form_RB.ReadOnly = true;
            this.Form_RB.Size = new System.Drawing.Size(120, 20);
            this.Form_RB.TabIndex = 43;
            // 
            // Recieve_RB
            // 
            this.Recieve_RB.BackColor = System.Drawing.Color.Transparent;
            this.Recieve_RB.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.Recieve_RB.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.Recieve_RB.FocusOnHover = false;
            this.Recieve_RB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Recieve_RB.Location = new System.Drawing.Point(19, 266);
            this.Recieve_RB.MaxLength = 32767;
            this.Recieve_RB.Multiline = false;
            this.Recieve_RB.Name = "Recieve_RB";
            this.Recieve_RB.ReadOnly = true;
            this.Recieve_RB.Size = new System.Drawing.Size(355, 29);
            this.Recieve_RB.TabIndex = 40;
            this.Recieve_RB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Recieve_RB.UseSystemPasswordChar = false;
            // 
            // crownLabel4
            // 
            this.crownLabel4.AutoSize = true;
            this.crownLabel4.BackColor = System.Drawing.Color.Transparent;
            this.crownLabel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.crownLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.crownLabel4.Location = new System.Drawing.Point(67, 191);
            this.crownLabel4.Name = "crownLabel4";
            this.crownLabel4.Size = new System.Drawing.Size(51, 19);
            this.crownLabel4.TabIndex = 3;
            this.crownLabel4.Text = "Offset";
            // 
            // crownLabel5
            // 
            this.crownLabel5.AutoSize = true;
            this.crownLabel5.BackColor = System.Drawing.Color.Transparent;
            this.crownLabel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.crownLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.crownLabel5.Location = new System.Drawing.Point(67, 135);
            this.crownLabel5.Name = "crownLabel5";
            this.crownLabel5.Size = new System.Drawing.Size(77, 19);
            this.crownLabel5.TabIndex = 2;
            this.crownLabel5.Text = "Amplitude";
            // 
            // crownLabel6
            // 
            this.crownLabel6.AutoSize = true;
            this.crownLabel6.BackColor = System.Drawing.Color.Transparent;
            this.crownLabel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.crownLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.crownLabel6.Location = new System.Drawing.Point(67, 81);
            this.crownLabel6.Name = "crownLabel6";
            this.crownLabel6.Size = new System.Drawing.Size(79, 19);
            this.crownLabel6.TabIndex = 1;
            this.crownLabel6.Text = "Frequency";
            // 
            // Offset_RB
            // 
            this.Offset_RB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Offset_RB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Offset_RB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Offset_RB.Location = new System.Drawing.Point(169, 193);
            this.Offset_RB.Name = "Offset_RB";
            this.Offset_RB.ReadOnly = true;
            this.Offset_RB.Size = new System.Drawing.Size(120, 20);
            this.Offset_RB.TabIndex = 42;
            // 
            // crownLabel7
            // 
            this.crownLabel7.AutoSize = true;
            this.crownLabel7.BackColor = System.Drawing.Color.Transparent;
            this.crownLabel7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.crownLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.crownLabel7.Location = new System.Drawing.Point(67, 33);
            this.crownLabel7.Name = "crownLabel7";
            this.crownLabel7.Size = new System.Drawing.Size(44, 19);
            this.crownLabel7.TabIndex = 0;
            this.crownLabel7.Text = "Form";
            // 
            // Amplitude_RB
            // 
            this.Amplitude_RB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Amplitude_RB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Amplitude_RB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Amplitude_RB.Location = new System.Drawing.Point(169, 137);
            this.Amplitude_RB.Name = "Amplitude_RB";
            this.Amplitude_RB.ReadOnly = true;
            this.Amplitude_RB.Size = new System.Drawing.Size(120, 20);
            this.Amplitude_RB.TabIndex = 41;
            // 
            // Frequency_RB
            // 
            this.Frequency_RB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Frequency_RB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Frequency_RB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Frequency_RB.Location = new System.Drawing.Point(169, 83);
            this.Frequency_RB.Name = "Frequency_RB";
            this.Frequency_RB.ReadOnly = true;
            this.Frequency_RB.Size = new System.Drawing.Size(120, 20);
            this.Frequency_RB.TabIndex = 39;
            // 
            // crownLabel8
            // 
            this.crownLabel8.AutoSize = true;
            this.crownLabel8.BackColor = System.Drawing.Color.Transparent;
            this.crownLabel8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.crownLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.crownLabel8.Location = new System.Drawing.Point(275, 22);
            this.crownLabel8.Name = "crownLabel8";
            this.crownLabel8.Size = new System.Drawing.Size(126, 19);
            this.crownLabel8.TabIndex = 47;
            this.crownLabel8.Text = "Com Port Control";
            // 
            // Select_Button
            // 
            this.Select_Button.BackColor = System.Drawing.Color.DarkGray;
            this.Select_Button.BorderColor = System.Drawing.Color.White;
            this.Select_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Select_Button.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Select_Button.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.Select_Button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_Button.Image = null;
            this.Select_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Select_Button.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.Select_Button.Location = new System.Drawing.Point(546, 20);
            this.Select_Button.Name = "Select_Button";
            this.Select_Button.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Select_Button.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Select_Button.Size = new System.Drawing.Size(108, 26);
            this.Select_Button.TabIndex = 48;
            this.Select_Button.Text = "Select";
            this.Select_Button.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Select_Button.Click += new System.EventHandler(this.Select_Button_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(954, 450);
            this.Controls.Add(this.Select_Button);
            this.Controls.Add(this.crownLabel8);
            this.Controls.Add(this.Reception_GB);
            this.Controls.Add(this.Transmission_GB);
            this.Controls.Add(this.PortComDropDown);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Transmission_GB.ResumeLayout(false);
            this.Transmission_GB.PerformLayout();
            this.Reception_GB.ResumeLayout(false);
            this.Reception_GB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ReaLTaiizor.Controls.CrownGroupBox Reception_GB;
        private ReaLTaiizor.Controls.ForeverTextBox Recieve_RB;
        private ReaLTaiizor.Controls.CrownLabel crownLabel4;
        private ReaLTaiizor.Controls.CrownLabel crownLabel5;
        private ReaLTaiizor.Controls.CrownLabel crownLabel6;
        private ReaLTaiizor.Controls.CrownTextBox Offset_RB;
        private ReaLTaiizor.Controls.CrownLabel crownLabel7;
        private ReaLTaiizor.Controls.CrownTextBox Amplitude_RB;
        private ReaLTaiizor.Controls.CrownTextBox Frequency_RB;
        private ReaLTaiizor.Controls.CrownGroupBox Transmission_GB;
        private ReaLTaiizor.Controls.DungeonComboBox FormeDropDown;
        private ReaLTaiizor.Controls.DungeonTrackBar Offset_TrackB;
        private ReaLTaiizor.Controls.ForeverTextBox Transmission_TB;
        private ReaLTaiizor.Controls.CrownLabel crownLabel3;
        private ReaLTaiizor.Controls.Button Save_Button;
        private ReaLTaiizor.Controls.CrownLabel crownLabel2;
        private ReaLTaiizor.Controls.DungeonTrackBar Amplitude_TrackB;
        private ReaLTaiizor.Controls.CrownLabel crownLabel1;
        private ReaLTaiizor.Controls.DungeonTrackBar Frequency_TrackB;
        private ReaLTaiizor.Controls.CrownTextBox Offset_TB;
        private ReaLTaiizor.Controls.CrownLabel Forme;
        private ReaLTaiizor.Controls.CrownTextBox Amplitude_TB;
        private ReaLTaiizor.Controls.CrownTextBox Frequency_TB;
        private ReaLTaiizor.Controls.Button Continous_Send_Button;
        private ReaLTaiizor.Controls.Button Send_Button;
        private ReaLTaiizor.Controls.DungeonComboBox PortComDropDown;
        private ReaLTaiizor.Controls.Button Select_Button;
        private ReaLTaiizor.Controls.CrownLabel crownLabel8;
        private ReaLTaiizor.Controls.CrownTextBox Form_RB;
        private System.Windows.Forms.Timer timer;
        private SerialPort serialPort;
    }
}

