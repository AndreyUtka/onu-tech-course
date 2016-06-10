namespace DormitoryProject
{
    partial class UserForm
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.lbValues = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPatr = new System.Windows.Forms.TextBox();
            this.tbSerial = new System.Windows.Forms.TextBox();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbKurs = new System.Windows.Forms.TextBox();
            this.tbFacult = new System.Windows.Forms.TextBox();
            this.tbGroup = new System.Windows.Forms.TextBox();
            this.tbSpec = new System.Windows.Forms.TextBox();
            this.tbRoom = new System.Windows.Forms.TextBox();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.cbDays = new System.Windows.Forms.ComboBox();
            this.listBoxWD = new System.Windows.Forms.ListBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.rbResettle = new System.Windows.Forms.RadioButton();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.rbSearch = new System.Windows.Forms.RadioButton();
            this.lbRoom = new System.Windows.Forms.Label();
            this.lbSpec = new System.Windows.Forms.Label();
            this.lbGroup = new System.Windows.Forms.Label();
            this.lbFacult = new System.Windows.Forms.Label();
            this.lbKurs = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbSerial = new System.Windows.Forms.Label();
            this.lbPatr = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСтудентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокРаботниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.gbMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 28);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(553, 294);
            this.DGV.TabIndex = 0;
            this.DGV.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_RowHeaderMouseClick);
            // 
            // lbValues
            // 
            this.lbValues.AutoSize = true;
            this.lbValues.Location = new System.Drawing.Point(5, 268);
            this.lbValues.Name = "lbValues";
            this.lbValues.Size = new System.Drawing.Size(58, 13);
            this.lbValues.TabIndex = 1;
            this.lbValues.Text = "Значений:";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(67, 50);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(100, 20);
            this.tbLastName.TabIndex = 2;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(67, 80);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 3;
            // 
            // tbPatr
            // 
            this.tbPatr.Location = new System.Drawing.Point(67, 108);
            this.tbPatr.Name = "tbPatr";
            this.tbPatr.Size = new System.Drawing.Size(100, 20);
            this.tbPatr.TabIndex = 4;
            // 
            // tbSerial
            // 
            this.tbSerial.Location = new System.Drawing.Point(67, 137);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.Size = new System.Drawing.Size(100, 20);
            this.tbSerial.TabIndex = 5;
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(67, 163);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(100, 20);
            this.tbNumber.TabIndex = 6;
            // 
            // tbKurs
            // 
            this.tbKurs.Location = new System.Drawing.Point(259, 50);
            this.tbKurs.Name = "tbKurs";
            this.tbKurs.Size = new System.Drawing.Size(100, 20);
            this.tbKurs.TabIndex = 7;
            // 
            // tbFacult
            // 
            this.tbFacult.Location = new System.Drawing.Point(259, 80);
            this.tbFacult.Name = "tbFacult";
            this.tbFacult.Size = new System.Drawing.Size(100, 20);
            this.tbFacult.TabIndex = 8;
            // 
            // tbGroup
            // 
            this.tbGroup.Location = new System.Drawing.Point(259, 108);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(100, 20);
            this.tbGroup.TabIndex = 9;
            // 
            // tbSpec
            // 
            this.tbSpec.Location = new System.Drawing.Point(259, 137);
            this.tbSpec.Name = "tbSpec";
            this.tbSpec.Size = new System.Drawing.Size(100, 20);
            this.tbSpec.TabIndex = 10;
            // 
            // tbRoom
            // 
            this.tbRoom.Location = new System.Drawing.Point(259, 163);
            this.tbRoom.Name = "tbRoom";
            this.tbRoom.Size = new System.Drawing.Size(30, 20);
            this.tbRoom.TabIndex = 11;
            // 
            // gbMenu
            // 
            this.gbMenu.Controls.Add(this.cbDays);
            this.gbMenu.Controls.Add(this.listBoxWD);
            this.gbMenu.Controls.Add(this.btnReload);
            this.gbMenu.Controls.Add(this.btnClear);
            this.gbMenu.Controls.Add(this.btnApply);
            this.gbMenu.Controls.Add(this.rbResettle);
            this.gbMenu.Controls.Add(this.rbDelete);
            this.gbMenu.Controls.Add(this.rbAdd);
            this.gbMenu.Controls.Add(this.rbSearch);
            this.gbMenu.Controls.Add(this.lbRoom);
            this.gbMenu.Controls.Add(this.lbSpec);
            this.gbMenu.Controls.Add(this.lbGroup);
            this.gbMenu.Controls.Add(this.tbRoom);
            this.gbMenu.Controls.Add(this.lbFacult);
            this.gbMenu.Controls.Add(this.tbSpec);
            this.gbMenu.Controls.Add(this.lbKurs);
            this.gbMenu.Controls.Add(this.tbGroup);
            this.gbMenu.Controls.Add(this.lbNumber);
            this.gbMenu.Controls.Add(this.lbSerial);
            this.gbMenu.Controls.Add(this.lbPatr);
            this.gbMenu.Controls.Add(this.tbFacult);
            this.gbMenu.Controls.Add(this.lbName);
            this.gbMenu.Controls.Add(this.tbKurs);
            this.gbMenu.Controls.Add(this.lbLastName);
            this.gbMenu.Controls.Add(this.tbNumber);
            this.gbMenu.Controls.Add(this.lbValues);
            this.gbMenu.Controls.Add(this.tbSerial);
            this.gbMenu.Controls.Add(this.tbLastName);
            this.gbMenu.Controls.Add(this.tbPatr);
            this.gbMenu.Controls.Add(this.tbName);
            this.gbMenu.Location = new System.Drawing.Point(575, 29);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(366, 293);
            this.gbMenu.TabIndex = 12;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "Поиск";
            // 
            // cbDays
            // 
            this.cbDays.FormattingEnabled = true;
            this.cbDays.Location = new System.Drawing.Point(259, 107);
            this.cbDays.Name = "cbDays";
            this.cbDays.Size = new System.Drawing.Size(100, 21);
            this.cbDays.TabIndex = 23;
            // 
            // listBoxWD
            // 
            this.listBoxWD.FormattingEnabled = true;
            this.listBoxWD.Location = new System.Drawing.Point(173, 134);
            this.listBoxWD.Name = "listBoxWD";
            this.listBoxWD.Size = new System.Drawing.Size(186, 147);
            this.listBoxWD.TabIndex = 22;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(8, 189);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 37);
            this.btnReload.TabIndex = 21;
            this.btnReload.Text = "Обновить";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(89, 189);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 37);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Очистить поля";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(8, 228);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 37);
            this.btnApply.TabIndex = 19;
            this.btnApply.Text = "Выполнить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // rbResettle
            // 
            this.rbResettle.AutoSize = true;
            this.rbResettle.Location = new System.Drawing.Point(227, 20);
            this.rbResettle.Name = "rbResettle";
            this.rbResettle.Size = new System.Drawing.Size(86, 17);
            this.rbResettle.TabIndex = 18;
            this.rbResettle.TabStop = true;
            this.rbResettle.Text = "Переселить";
            this.rbResettle.UseVisualStyleBackColor = true;
            this.rbResettle.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Location = new System.Drawing.Point(153, 20);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(68, 17);
            this.rbDelete.TabIndex = 17;
            this.rbDelete.TabStop = true;
            this.rbDelete.Text = "Удалить";
            this.rbDelete.UseVisualStyleBackColor = true;
            this.rbDelete.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbAdd
            // 
            this.rbAdd.AutoSize = true;
            this.rbAdd.Location = new System.Drawing.Point(71, 20);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(75, 17);
            this.rbAdd.TabIndex = 16;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "Добавить";
            this.rbAdd.UseVisualStyleBackColor = true;
            this.rbAdd.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rbSearch
            // 
            this.rbSearch.AutoSize = true;
            this.rbSearch.Location = new System.Drawing.Point(7, 20);
            this.rbSearch.Name = "rbSearch";
            this.rbSearch.Size = new System.Drawing.Size(57, 17);
            this.rbSearch.TabIndex = 15;
            this.rbSearch.TabStop = true;
            this.rbSearch.Text = "Поиск";
            this.rbSearch.UseVisualStyleBackColor = true;
            this.rbSearch.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // lbRoom
            // 
            this.lbRoom.AutoSize = true;
            this.lbRoom.Location = new System.Drawing.Point(202, 166);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(51, 13);
            this.lbRoom.TabIndex = 14;
            this.lbRoom.Text = "Комната";
            // 
            // lbSpec
            // 
            this.lbSpec.AutoSize = true;
            this.lbSpec.Location = new System.Drawing.Point(173, 140);
            this.lbSpec.Name = "lbSpec";
            this.lbSpec.Size = new System.Drawing.Size(85, 13);
            this.lbSpec.TabIndex = 13;
            this.lbSpec.Text = "Специальность";
            // 
            // lbGroup
            // 
            this.lbGroup.AutoSize = true;
            this.lbGroup.Location = new System.Drawing.Point(211, 111);
            this.lbGroup.Name = "lbGroup";
            this.lbGroup.Size = new System.Drawing.Size(42, 13);
            this.lbGroup.TabIndex = 12;
            this.lbGroup.Text = "Группа";
            // 
            // lbFacult
            // 
            this.lbFacult.AutoSize = true;
            this.lbFacult.Location = new System.Drawing.Point(190, 83);
            this.lbFacult.Name = "lbFacult";
            this.lbFacult.Size = new System.Drawing.Size(63, 13);
            this.lbFacult.TabIndex = 10;
            this.lbFacult.Text = "Факультет";
            // 
            // lbKurs
            // 
            this.lbKurs.AutoSize = true;
            this.lbKurs.Location = new System.Drawing.Point(222, 53);
            this.lbKurs.Name = "lbKurs";
            this.lbKurs.Size = new System.Drawing.Size(31, 13);
            this.lbKurs.TabIndex = 9;
            this.lbKurs.Text = "Курс";
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(18, 166);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(41, 13);
            this.lbNumber.TabIndex = 6;
            this.lbNumber.Text = "Номер";
            // 
            // lbSerial
            // 
            this.lbSerial.AutoSize = true;
            this.lbSerial.Location = new System.Drawing.Point(21, 140);
            this.lbSerial.Name = "lbSerial";
            this.lbSerial.Size = new System.Drawing.Size(38, 13);
            this.lbSerial.TabIndex = 5;
            this.lbSerial.Text = "Серия";
            // 
            // lbPatr
            // 
            this.lbPatr.AutoSize = true;
            this.lbPatr.Location = new System.Drawing.Point(7, 111);
            this.lbPatr.Name = "lbPatr";
            this.lbPatr.Size = new System.Drawing.Size(54, 13);
            this.lbPatr.TabIndex = 4;
            this.lbPatr.Text = "Отчество";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(30, 83);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(29, 13);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Имя";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(5, 53);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(56, 13);
            this.lbLastName.TabIndex = 2;
            this.lbLastName.Text = "Фамилия";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(953, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокСтудентовToolStripMenuItem,
            this.списокРаботниковToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // списокСтудентовToolStripMenuItem
            // 
            this.списокСтудентовToolStripMenuItem.Name = "списокСтудентовToolStripMenuItem";
            this.списокСтудентовToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.списокСтудентовToolStripMenuItem.Text = "Список студентов";
            this.списокСтудентовToolStripMenuItem.Click += new System.EventHandler(this.списокСтудентовToolStripMenuItem_Click);
            // 
            // списокРаботниковToolStripMenuItem
            // 
            this.списокРаботниковToolStripMenuItem.Name = "списокРаботниковToolStripMenuItem";
            this.списокРаботниковToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.списокРаботниковToolStripMenuItem.Text = "Список работников";
            this.списокРаботниковToolStripMenuItem.Click += new System.EventHandler(this.списокРаботниковToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 356);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.gbMenu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserForm";
            this.Text = "UserForm";
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.gbMenu.ResumeLayout(false);
            this.gbMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label lbValues;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbPatr;
        private System.Windows.Forms.TextBox tbSerial;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbKurs;
        private System.Windows.Forms.TextBox tbFacult;
        private System.Windows.Forms.TextBox tbGroup;
        private System.Windows.Forms.TextBox tbSpec;
        private System.Windows.Forms.TextBox tbRoom;
        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.Label lbFacult;
        private System.Windows.Forms.Label lbKurs;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbSerial;
        private System.Windows.Forms.Label lbPatr;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbGroup;
        private System.Windows.Forms.RadioButton rbResettle;
        private System.Windows.Forms.RadioButton rbDelete;
        private System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.RadioButton rbSearch;
        private System.Windows.Forms.Label lbRoom;
        private System.Windows.Forms.Label lbSpec;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСтудентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокРаботниковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.ListBox listBoxWD;
        private System.Windows.Forms.ComboBox cbDays;
    }
}