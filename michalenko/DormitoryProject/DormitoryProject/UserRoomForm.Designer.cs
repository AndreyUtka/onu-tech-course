namespace DormitoryProject
{
    partial class UserRoomForm
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
            this.lbInfo = new System.Windows.Forms.Label();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.btnJournals = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(103, 12);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(107, 13);
            this.lbInfo.TabIndex = 0;
            this.lbInfo.Text = "Информация о Вас:";
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(12, 161);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(97, 41);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Список пользователей";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.Location = new System.Drawing.Point(218, 161);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(97, 41);
            this.btnRooms.TabIndex = 3;
            this.btnRooms.Text = "Список комнат";
            this.btnRooms.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(218, 208);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(97, 41);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Location = new System.Drawing.Point(12, 208);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(97, 41);
            this.btnChangePwd.TabIndex = 5;
            this.btnChangePwd.Text = "Изменить пароль";
            this.btnChangePwd.UseVisualStyleBackColor = true;
            // 
            // btnJournals
            // 
            this.btnJournals.Location = new System.Drawing.Point(115, 161);
            this.btnJournals.Name = "btnJournals";
            this.btnJournals.Size = new System.Drawing.Size(97, 41);
            this.btnJournals.TabIndex = 6;
            this.btnJournals.Text = "Журналы ремонтов";
            this.btnJournals.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "Изменить профиль";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // UserRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnJournals);
            this.Controls.Add(this.btnChangePwd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRooms);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.lbInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserRoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Личный кабинет";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserRoomForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.Button btnJournals;
        private System.Windows.Forms.Button button1;
    }
}