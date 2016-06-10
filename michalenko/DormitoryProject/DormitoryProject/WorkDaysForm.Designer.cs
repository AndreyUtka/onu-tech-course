namespace DormitoryProject
{
    partial class WorkDaysForm
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
            this.chbMon = new System.Windows.Forms.CheckBox();
            this.chbTue = new System.Windows.Forms.CheckBox();
            this.chbWed = new System.Windows.Forms.CheckBox();
            this.chbThu = new System.Windows.Forms.CheckBox();
            this.chbFri = new System.Windows.Forms.CheckBox();
            this.chbSat = new System.Windows.Forms.CheckBox();
            this.chbSun = new System.Windows.Forms.CheckBox();
            this.cbMonStart = new System.Windows.Forms.ComboBox();
            this.cbMonEnd = new System.Windows.Forms.ComboBox();
            this.cbTueStart = new System.Windows.Forms.ComboBox();
            this.cbTueEnd = new System.Windows.Forms.ComboBox();
            this.cbWedStart = new System.Windows.Forms.ComboBox();
            this.cbWedEnd = new System.Windows.Forms.ComboBox();
            this.cbThuStart = new System.Windows.Forms.ComboBox();
            this.cbThuEnd = new System.Windows.Forms.ComboBox();
            this.cbFriStart = new System.Windows.Forms.ComboBox();
            this.cbFriEnd = new System.Windows.Forms.ComboBox();
            this.cbSatStart = new System.Windows.Forms.ComboBox();
            this.cbSatEnd = new System.Windows.Forms.ComboBox();
            this.cbSunStart = new System.Windows.Forms.ComboBox();
            this.cbSunEnd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbWS = new System.Windows.Forms.Label();
            this.lbWE = new System.Windows.Forms.Label();
            this.chbRestSun = new System.Windows.Forms.CheckBox();
            this.chbRestSat = new System.Windows.Forms.CheckBox();
            this.chbRestFri = new System.Windows.Forms.CheckBox();
            this.chbRestThu = new System.Windows.Forms.CheckBox();
            this.chbRestWed = new System.Windows.Forms.CheckBox();
            this.chbRestTue = new System.Windows.Forms.CheckBox();
            this.chbRestMon = new System.Windows.Forms.CheckBox();
            this.cbRestSunEnd = new System.Windows.Forms.ComboBox();
            this.cbRestSunStart = new System.Windows.Forms.ComboBox();
            this.cbRestSatEnd = new System.Windows.Forms.ComboBox();
            this.cbRestSatStart = new System.Windows.Forms.ComboBox();
            this.cbRestFriEnd = new System.Windows.Forms.ComboBox();
            this.cbRestFriStart = new System.Windows.Forms.ComboBox();
            this.cbRestThuEnd = new System.Windows.Forms.ComboBox();
            this.cbRestThuStart = new System.Windows.Forms.ComboBox();
            this.cbRestWedEnd = new System.Windows.Forms.ComboBox();
            this.cbRestWedStart = new System.Windows.Forms.ComboBox();
            this.cbRestTueEnd = new System.Windows.Forms.ComboBox();
            this.cbRestTueStart = new System.Windows.Forms.ComboBox();
            this.cbRestMonEnd = new System.Windows.Forms.ComboBox();
            this.cbRestMonStart = new System.Windows.Forms.ComboBox();
            this.lbRS = new System.Windows.Forms.Label();
            this.lbRE = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chbMon
            // 
            this.chbMon.AutoSize = true;
            this.chbMon.Location = new System.Drawing.Point(12, 46);
            this.chbMon.Name = "chbMon";
            this.chbMon.Size = new System.Drawing.Size(94, 17);
            this.chbMon.TabIndex = 0;
            this.chbMon.Text = "Понедельник";
            this.chbMon.UseVisualStyleBackColor = true;
            this.chbMon.CheckedChanged += new System.EventHandler(this.dayChecked);
            // 
            // chbTue
            // 
            this.chbTue.AutoSize = true;
            this.chbTue.Location = new System.Drawing.Point(12, 70);
            this.chbTue.Name = "chbTue";
            this.chbTue.Size = new System.Drawing.Size(68, 17);
            this.chbTue.TabIndex = 1;
            this.chbTue.Text = "Вторник";
            this.chbTue.UseVisualStyleBackColor = true;
            this.chbTue.CheckedChanged += new System.EventHandler(this.dayChecked);
            // 
            // chbWed
            // 
            this.chbWed.AutoSize = true;
            this.chbWed.Location = new System.Drawing.Point(12, 94);
            this.chbWed.Name = "chbWed";
            this.chbWed.Size = new System.Drawing.Size(57, 17);
            this.chbWed.TabIndex = 2;
            this.chbWed.Text = "Среда";
            this.chbWed.UseVisualStyleBackColor = true;
            this.chbWed.CheckedChanged += new System.EventHandler(this.dayChecked);
            // 
            // chbThu
            // 
            this.chbThu.AutoSize = true;
            this.chbThu.Location = new System.Drawing.Point(12, 118);
            this.chbThu.Name = "chbThu";
            this.chbThu.Size = new System.Drawing.Size(68, 17);
            this.chbThu.TabIndex = 3;
            this.chbThu.Text = "Четверг";
            this.chbThu.UseVisualStyleBackColor = true;
            this.chbThu.CheckedChanged += new System.EventHandler(this.dayChecked);
            // 
            // chbFri
            // 
            this.chbFri.AutoSize = true;
            this.chbFri.Location = new System.Drawing.Point(12, 142);
            this.chbFri.Name = "chbFri";
            this.chbFri.Size = new System.Drawing.Size(69, 17);
            this.chbFri.TabIndex = 4;
            this.chbFri.Text = "Пятница";
            this.chbFri.UseVisualStyleBackColor = true;
            this.chbFri.CheckedChanged += new System.EventHandler(this.dayChecked);
            // 
            // chbSat
            // 
            this.chbSat.AutoSize = true;
            this.chbSat.Location = new System.Drawing.Point(12, 166);
            this.chbSat.Name = "chbSat";
            this.chbSat.Size = new System.Drawing.Size(67, 17);
            this.chbSat.TabIndex = 5;
            this.chbSat.Text = "Суббота";
            this.chbSat.UseVisualStyleBackColor = true;
            this.chbSat.CheckedChanged += new System.EventHandler(this.dayChecked);
            // 
            // chbSun
            // 
            this.chbSun.AutoSize = true;
            this.chbSun.Location = new System.Drawing.Point(12, 190);
            this.chbSun.Name = "chbSun";
            this.chbSun.Size = new System.Drawing.Size(93, 17);
            this.chbSun.TabIndex = 6;
            this.chbSun.Text = "Воскресенье";
            this.chbSun.UseVisualStyleBackColor = true;
            this.chbSun.CheckedChanged += new System.EventHandler(this.dayChecked);
            // 
            // cbMonStart
            // 
            this.cbMonStart.FormattingEnabled = true;
            this.cbMonStart.Location = new System.Drawing.Point(128, 46);
            this.cbMonStart.Name = "cbMonStart";
            this.cbMonStart.Size = new System.Drawing.Size(58, 21);
            this.cbMonStart.TabIndex = 7;
            // 
            // cbMonEnd
            // 
            this.cbMonEnd.FormattingEnabled = true;
            this.cbMonEnd.Location = new System.Drawing.Point(214, 46);
            this.cbMonEnd.Name = "cbMonEnd";
            this.cbMonEnd.Size = new System.Drawing.Size(57, 21);
            this.cbMonEnd.TabIndex = 8;
            // 
            // cbTueStart
            // 
            this.cbTueStart.FormattingEnabled = true;
            this.cbTueStart.Location = new System.Drawing.Point(128, 70);
            this.cbTueStart.Name = "cbTueStart";
            this.cbTueStart.Size = new System.Drawing.Size(58, 21);
            this.cbTueStart.TabIndex = 9;
            // 
            // cbTueEnd
            // 
            this.cbTueEnd.FormattingEnabled = true;
            this.cbTueEnd.Location = new System.Drawing.Point(214, 70);
            this.cbTueEnd.Name = "cbTueEnd";
            this.cbTueEnd.Size = new System.Drawing.Size(57, 21);
            this.cbTueEnd.TabIndex = 10;
            // 
            // cbWedStart
            // 
            this.cbWedStart.FormattingEnabled = true;
            this.cbWedStart.Location = new System.Drawing.Point(128, 94);
            this.cbWedStart.Name = "cbWedStart";
            this.cbWedStart.Size = new System.Drawing.Size(58, 21);
            this.cbWedStart.TabIndex = 11;
            // 
            // cbWedEnd
            // 
            this.cbWedEnd.FormattingEnabled = true;
            this.cbWedEnd.Location = new System.Drawing.Point(214, 94);
            this.cbWedEnd.Name = "cbWedEnd";
            this.cbWedEnd.Size = new System.Drawing.Size(57, 21);
            this.cbWedEnd.TabIndex = 12;
            // 
            // cbThuStart
            // 
            this.cbThuStart.FormattingEnabled = true;
            this.cbThuStart.Location = new System.Drawing.Point(128, 118);
            this.cbThuStart.Name = "cbThuStart";
            this.cbThuStart.Size = new System.Drawing.Size(58, 21);
            this.cbThuStart.TabIndex = 13;
            // 
            // cbThuEnd
            // 
            this.cbThuEnd.FormattingEnabled = true;
            this.cbThuEnd.Location = new System.Drawing.Point(214, 118);
            this.cbThuEnd.Name = "cbThuEnd";
            this.cbThuEnd.Size = new System.Drawing.Size(57, 21);
            this.cbThuEnd.TabIndex = 14;
            // 
            // cbFriStart
            // 
            this.cbFriStart.FormattingEnabled = true;
            this.cbFriStart.Location = new System.Drawing.Point(128, 142);
            this.cbFriStart.Name = "cbFriStart";
            this.cbFriStart.Size = new System.Drawing.Size(58, 21);
            this.cbFriStart.TabIndex = 15;
            // 
            // cbFriEnd
            // 
            this.cbFriEnd.FormattingEnabled = true;
            this.cbFriEnd.Location = new System.Drawing.Point(214, 142);
            this.cbFriEnd.Name = "cbFriEnd";
            this.cbFriEnd.Size = new System.Drawing.Size(57, 21);
            this.cbFriEnd.TabIndex = 16;
            // 
            // cbSatStart
            // 
            this.cbSatStart.FormattingEnabled = true;
            this.cbSatStart.Location = new System.Drawing.Point(128, 166);
            this.cbSatStart.Name = "cbSatStart";
            this.cbSatStart.Size = new System.Drawing.Size(58, 21);
            this.cbSatStart.TabIndex = 17;
            // 
            // cbSatEnd
            // 
            this.cbSatEnd.FormattingEnabled = true;
            this.cbSatEnd.Location = new System.Drawing.Point(214, 166);
            this.cbSatEnd.Name = "cbSatEnd";
            this.cbSatEnd.Size = new System.Drawing.Size(57, 21);
            this.cbSatEnd.TabIndex = 18;
            // 
            // cbSunStart
            // 
            this.cbSunStart.FormattingEnabled = true;
            this.cbSunStart.Location = new System.Drawing.Point(128, 190);
            this.cbSunStart.Name = "cbSunStart";
            this.cbSunStart.Size = new System.Drawing.Size(58, 21);
            this.cbSunStart.TabIndex = 19;
            // 
            // cbSunEnd
            // 
            this.cbSunEnd.FormattingEnabled = true;
            this.cbSunEnd.Location = new System.Drawing.Point(214, 190);
            this.cbSunEnd.Name = "cbSunEnd";
            this.cbSunEnd.Size = new System.Drawing.Size(57, 21);
            this.cbSunEnd.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Рабочие дни:";
            // 
            // lbWS
            // 
            this.lbWS.AutoSize = true;
            this.lbWS.Location = new System.Drawing.Point(125, 9);
            this.lbWS.Name = "lbWS";
            this.lbWS.Size = new System.Drawing.Size(13, 13);
            this.lbWS.TabIndex = 22;
            this.lbWS.Text = "1";
            // 
            // lbWE
            // 
            this.lbWE.AutoSize = true;
            this.lbWE.Location = new System.Drawing.Point(211, 9);
            this.lbWE.Name = "lbWE";
            this.lbWE.Size = new System.Drawing.Size(13, 13);
            this.lbWE.TabIndex = 23;
            this.lbWE.Text = "2";
            // 
            // chbRestSun
            // 
            this.chbRestSun.AutoSize = true;
            this.chbRestSun.Location = new System.Drawing.Point(277, 192);
            this.chbRestSun.Name = "chbRestSun";
            this.chbRestSun.Size = new System.Drawing.Size(72, 17);
            this.chbRestSun.TabIndex = 30;
            this.chbRestSun.Text = "Перерыв";
            this.chbRestSun.UseVisualStyleBackColor = true;
            this.chbRestSun.CheckedChanged += new System.EventHandler(this.restChecked);
            // 
            // chbRestSat
            // 
            this.chbRestSat.AutoSize = true;
            this.chbRestSat.Location = new System.Drawing.Point(277, 168);
            this.chbRestSat.Name = "chbRestSat";
            this.chbRestSat.Size = new System.Drawing.Size(72, 17);
            this.chbRestSat.TabIndex = 29;
            this.chbRestSat.Text = "Перерыв";
            this.chbRestSat.UseVisualStyleBackColor = true;
            this.chbRestSat.CheckedChanged += new System.EventHandler(this.restChecked);
            // 
            // chbRestFri
            // 
            this.chbRestFri.AutoSize = true;
            this.chbRestFri.Location = new System.Drawing.Point(277, 144);
            this.chbRestFri.Name = "chbRestFri";
            this.chbRestFri.Size = new System.Drawing.Size(72, 17);
            this.chbRestFri.TabIndex = 28;
            this.chbRestFri.Text = "Перерыв";
            this.chbRestFri.UseVisualStyleBackColor = true;
            this.chbRestFri.CheckedChanged += new System.EventHandler(this.restChecked);
            // 
            // chbRestThu
            // 
            this.chbRestThu.AutoSize = true;
            this.chbRestThu.Location = new System.Drawing.Point(277, 120);
            this.chbRestThu.Name = "chbRestThu";
            this.chbRestThu.Size = new System.Drawing.Size(72, 17);
            this.chbRestThu.TabIndex = 27;
            this.chbRestThu.Text = "Перерыв";
            this.chbRestThu.UseVisualStyleBackColor = true;
            this.chbRestThu.CheckedChanged += new System.EventHandler(this.restChecked);
            // 
            // chbRestWed
            // 
            this.chbRestWed.AutoSize = true;
            this.chbRestWed.Location = new System.Drawing.Point(277, 96);
            this.chbRestWed.Name = "chbRestWed";
            this.chbRestWed.Size = new System.Drawing.Size(72, 17);
            this.chbRestWed.TabIndex = 26;
            this.chbRestWed.Text = "Перерыв";
            this.chbRestWed.UseVisualStyleBackColor = true;
            this.chbRestWed.CheckedChanged += new System.EventHandler(this.restChecked);
            // 
            // chbRestTue
            // 
            this.chbRestTue.AutoSize = true;
            this.chbRestTue.Location = new System.Drawing.Point(277, 72);
            this.chbRestTue.Name = "chbRestTue";
            this.chbRestTue.Size = new System.Drawing.Size(72, 17);
            this.chbRestTue.TabIndex = 25;
            this.chbRestTue.Text = "Перерыв";
            this.chbRestTue.UseVisualStyleBackColor = true;
            this.chbRestTue.CheckedChanged += new System.EventHandler(this.restChecked);
            // 
            // chbRestMon
            // 
            this.chbRestMon.AutoSize = true;
            this.chbRestMon.Location = new System.Drawing.Point(277, 48);
            this.chbRestMon.Name = "chbRestMon";
            this.chbRestMon.Size = new System.Drawing.Size(72, 17);
            this.chbRestMon.TabIndex = 24;
            this.chbRestMon.Text = "Перерыв";
            this.chbRestMon.UseVisualStyleBackColor = true;
            this.chbRestMon.CheckedChanged += new System.EventHandler(this.restChecked);
            // 
            // cbRestSunEnd
            // 
            this.cbRestSunEnd.FormattingEnabled = true;
            this.cbRestSunEnd.Location = new System.Drawing.Point(447, 190);
            this.cbRestSunEnd.Name = "cbRestSunEnd";
            this.cbRestSunEnd.Size = new System.Drawing.Size(58, 21);
            this.cbRestSunEnd.TabIndex = 44;
            // 
            // cbRestSunStart
            // 
            this.cbRestSunStart.FormattingEnabled = true;
            this.cbRestSunStart.Location = new System.Drawing.Point(361, 190);
            this.cbRestSunStart.Name = "cbRestSunStart";
            this.cbRestSunStart.Size = new System.Drawing.Size(57, 21);
            this.cbRestSunStart.TabIndex = 43;
            // 
            // cbRestSatEnd
            // 
            this.cbRestSatEnd.FormattingEnabled = true;
            this.cbRestSatEnd.Location = new System.Drawing.Point(447, 166);
            this.cbRestSatEnd.Name = "cbRestSatEnd";
            this.cbRestSatEnd.Size = new System.Drawing.Size(58, 21);
            this.cbRestSatEnd.TabIndex = 42;
            // 
            // cbRestSatStart
            // 
            this.cbRestSatStart.FormattingEnabled = true;
            this.cbRestSatStart.Location = new System.Drawing.Point(361, 166);
            this.cbRestSatStart.Name = "cbRestSatStart";
            this.cbRestSatStart.Size = new System.Drawing.Size(57, 21);
            this.cbRestSatStart.TabIndex = 41;
            // 
            // cbRestFriEnd
            // 
            this.cbRestFriEnd.FormattingEnabled = true;
            this.cbRestFriEnd.Location = new System.Drawing.Point(447, 142);
            this.cbRestFriEnd.Name = "cbRestFriEnd";
            this.cbRestFriEnd.Size = new System.Drawing.Size(58, 21);
            this.cbRestFriEnd.TabIndex = 40;
            // 
            // cbRestFriStart
            // 
            this.cbRestFriStart.FormattingEnabled = true;
            this.cbRestFriStart.Location = new System.Drawing.Point(361, 142);
            this.cbRestFriStart.Name = "cbRestFriStart";
            this.cbRestFriStart.Size = new System.Drawing.Size(57, 21);
            this.cbRestFriStart.TabIndex = 39;
            // 
            // cbRestThuEnd
            // 
            this.cbRestThuEnd.FormattingEnabled = true;
            this.cbRestThuEnd.Location = new System.Drawing.Point(447, 118);
            this.cbRestThuEnd.Name = "cbRestThuEnd";
            this.cbRestThuEnd.Size = new System.Drawing.Size(58, 21);
            this.cbRestThuEnd.TabIndex = 38;
            // 
            // cbRestThuStart
            // 
            this.cbRestThuStart.FormattingEnabled = true;
            this.cbRestThuStart.Location = new System.Drawing.Point(361, 118);
            this.cbRestThuStart.Name = "cbRestThuStart";
            this.cbRestThuStart.Size = new System.Drawing.Size(57, 21);
            this.cbRestThuStart.TabIndex = 37;
            // 
            // cbRestWedEnd
            // 
            this.cbRestWedEnd.FormattingEnabled = true;
            this.cbRestWedEnd.Location = new System.Drawing.Point(447, 94);
            this.cbRestWedEnd.Name = "cbRestWedEnd";
            this.cbRestWedEnd.Size = new System.Drawing.Size(58, 21);
            this.cbRestWedEnd.TabIndex = 36;
            // 
            // cbRestWedStart
            // 
            this.cbRestWedStart.FormattingEnabled = true;
            this.cbRestWedStart.Location = new System.Drawing.Point(361, 94);
            this.cbRestWedStart.Name = "cbRestWedStart";
            this.cbRestWedStart.Size = new System.Drawing.Size(57, 21);
            this.cbRestWedStart.TabIndex = 35;
            // 
            // cbRestTueEnd
            // 
            this.cbRestTueEnd.FormattingEnabled = true;
            this.cbRestTueEnd.Location = new System.Drawing.Point(447, 70);
            this.cbRestTueEnd.Name = "cbRestTueEnd";
            this.cbRestTueEnd.Size = new System.Drawing.Size(58, 21);
            this.cbRestTueEnd.TabIndex = 34;
            // 
            // cbRestTueStart
            // 
            this.cbRestTueStart.FormattingEnabled = true;
            this.cbRestTueStart.Location = new System.Drawing.Point(361, 70);
            this.cbRestTueStart.Name = "cbRestTueStart";
            this.cbRestTueStart.Size = new System.Drawing.Size(57, 21);
            this.cbRestTueStart.TabIndex = 33;
            // 
            // cbRestMonEnd
            // 
            this.cbRestMonEnd.FormattingEnabled = true;
            this.cbRestMonEnd.Location = new System.Drawing.Point(447, 46);
            this.cbRestMonEnd.Name = "cbRestMonEnd";
            this.cbRestMonEnd.Size = new System.Drawing.Size(58, 21);
            this.cbRestMonEnd.TabIndex = 32;
            // 
            // cbRestMonStart
            // 
            this.cbRestMonStart.FormattingEnabled = true;
            this.cbRestMonStart.Location = new System.Drawing.Point(361, 46);
            this.cbRestMonStart.Name = "cbRestMonStart";
            this.cbRestMonStart.Size = new System.Drawing.Size(57, 21);
            this.cbRestMonStart.TabIndex = 31;
            // 
            // lbRS
            // 
            this.lbRS.AutoSize = true;
            this.lbRS.Location = new System.Drawing.Point(358, 9);
            this.lbRS.Name = "lbRS";
            this.lbRS.Size = new System.Drawing.Size(13, 13);
            this.lbRS.TabIndex = 45;
            this.lbRS.Text = "3";
            // 
            // lbRE
            // 
            this.lbRE.AutoSize = true;
            this.lbRE.Location = new System.Drawing.Point(444, 9);
            this.lbRE.Name = "lbRE";
            this.lbRE.Size = new System.Drawing.Size(13, 13);
            this.lbRE.TabIndex = 46;
            this.lbRE.Text = "4";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(15, 226);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 23);
            this.btnConfirm.TabIndex = 47;
            this.btnConfirm.Text = "Подтвердить";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(111, 226);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 23);
            this.btnClear.TabIndex = 48;
            this.btnClear.Text = "Сброс";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(447, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // WorkDaysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lbRE);
            this.Controls.Add(this.lbRS);
            this.Controls.Add(this.cbRestSunEnd);
            this.Controls.Add(this.cbRestSunStart);
            this.Controls.Add(this.cbRestSatEnd);
            this.Controls.Add(this.cbRestSatStart);
            this.Controls.Add(this.cbRestFriEnd);
            this.Controls.Add(this.cbRestFriStart);
            this.Controls.Add(this.cbRestThuEnd);
            this.Controls.Add(this.cbRestThuStart);
            this.Controls.Add(this.cbRestWedEnd);
            this.Controls.Add(this.cbRestWedStart);
            this.Controls.Add(this.cbRestTueEnd);
            this.Controls.Add(this.cbRestTueStart);
            this.Controls.Add(this.cbRestMonEnd);
            this.Controls.Add(this.cbRestMonStart);
            this.Controls.Add(this.chbRestSun);
            this.Controls.Add(this.chbRestSat);
            this.Controls.Add(this.chbRestFri);
            this.Controls.Add(this.chbRestThu);
            this.Controls.Add(this.chbRestWed);
            this.Controls.Add(this.chbRestTue);
            this.Controls.Add(this.chbRestMon);
            this.Controls.Add(this.lbWE);
            this.Controls.Add(this.lbWS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSunEnd);
            this.Controls.Add(this.cbSunStart);
            this.Controls.Add(this.cbSatEnd);
            this.Controls.Add(this.cbSatStart);
            this.Controls.Add(this.cbFriEnd);
            this.Controls.Add(this.cbFriStart);
            this.Controls.Add(this.cbThuEnd);
            this.Controls.Add(this.cbThuStart);
            this.Controls.Add(this.cbWedEnd);
            this.Controls.Add(this.cbWedStart);
            this.Controls.Add(this.cbTueEnd);
            this.Controls.Add(this.cbTueStart);
            this.Controls.Add(this.cbMonEnd);
            this.Controls.Add(this.cbMonStart);
            this.Controls.Add(this.chbSun);
            this.Controls.Add(this.chbSat);
            this.Controls.Add(this.chbFri);
            this.Controls.Add(this.chbThu);
            this.Controls.Add(this.chbWed);
            this.Controls.Add(this.chbTue);
            this.Controls.Add(this.chbMon);
            this.Name = "WorkDaysForm";
            this.Text = "WorkDaysForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbMon;
        private System.Windows.Forms.CheckBox chbTue;
        private System.Windows.Forms.CheckBox chbWed;
        private System.Windows.Forms.CheckBox chbThu;
        private System.Windows.Forms.CheckBox chbFri;
        private System.Windows.Forms.CheckBox chbSat;
        private System.Windows.Forms.CheckBox chbSun;
        private System.Windows.Forms.ComboBox cbMonStart;
        private System.Windows.Forms.ComboBox cbMonEnd;
        private System.Windows.Forms.ComboBox cbTueStart;
        private System.Windows.Forms.ComboBox cbTueEnd;
        private System.Windows.Forms.ComboBox cbWedStart;
        private System.Windows.Forms.ComboBox cbWedEnd;
        private System.Windows.Forms.ComboBox cbThuStart;
        private System.Windows.Forms.ComboBox cbThuEnd;
        private System.Windows.Forms.ComboBox cbFriStart;
        private System.Windows.Forms.ComboBox cbFriEnd;
        private System.Windows.Forms.ComboBox cbSatStart;
        private System.Windows.Forms.ComboBox cbSatEnd;
        private System.Windows.Forms.ComboBox cbSunStart;
        private System.Windows.Forms.ComboBox cbSunEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbWS;
        private System.Windows.Forms.Label lbWE;
        private System.Windows.Forms.CheckBox chbRestSun;
        private System.Windows.Forms.CheckBox chbRestSat;
        private System.Windows.Forms.CheckBox chbRestFri;
        private System.Windows.Forms.CheckBox chbRestThu;
        private System.Windows.Forms.CheckBox chbRestWed;
        private System.Windows.Forms.CheckBox chbRestTue;
        private System.Windows.Forms.CheckBox chbRestMon;
        private System.Windows.Forms.ComboBox cbRestSunEnd;
        private System.Windows.Forms.ComboBox cbRestSunStart;
        private System.Windows.Forms.ComboBox cbRestSatEnd;
        private System.Windows.Forms.ComboBox cbRestSatStart;
        private System.Windows.Forms.ComboBox cbRestFriEnd;
        private System.Windows.Forms.ComboBox cbRestFriStart;
        private System.Windows.Forms.ComboBox cbRestThuEnd;
        private System.Windows.Forms.ComboBox cbRestThuStart;
        private System.Windows.Forms.ComboBox cbRestWedEnd;
        private System.Windows.Forms.ComboBox cbRestWedStart;
        private System.Windows.Forms.ComboBox cbRestTueEnd;
        private System.Windows.Forms.ComboBox cbRestTueStart;
        private System.Windows.Forms.ComboBox cbRestMonEnd;
        private System.Windows.Forms.ComboBox cbRestMonStart;
        private System.Windows.Forms.Label lbRS;
        private System.Windows.Forms.Label lbRE;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
    }
}