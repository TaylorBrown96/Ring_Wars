
namespace WinUI_Game
{
    partial class Form1
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
            this.PB_PlayerHealth = new System.Windows.Forms.ProgressBar();
            this.PB_EnemyHealth = new System.Windows.Forms.ProgressBar();
            this.LB_PlayerInv = new System.Windows.Forms.ListBox();
            this.LB_RoomInv = new System.Windows.Forms.ListBox();
            this.Btn_North = new System.Windows.Forms.Button();
            this.Btn_East = new System.Windows.Forms.Button();
            this.Btn_West = new System.Windows.Forms.Button();
            this.Btn_South = new System.Windows.Forms.Button();
            this.Btn_Attack = new System.Windows.Forms.Button();
            this.Btn_UseItem = new System.Windows.Forms.Button();
            this.Btn_ExamineItem = new System.Windows.Forms.Button();
            this.Btn_PlayerToRoom = new System.Windows.Forms.Button();
            this.Btn_RoomToPlayer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.L_EnemyName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.L_NExit = new System.Windows.Forms.Label();
            this.L_SExit = new System.Windows.Forms.Label();
            this.L_WExit = new System.Windows.Forms.Label();
            this.L_EExit = new System.Windows.Forms.Label();
            this.TB_Dialog = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PB_PlayerHealth
            // 
            this.PB_PlayerHealth.ForeColor = System.Drawing.Color.Red;
            this.PB_PlayerHealth.Location = new System.Drawing.Point(12, 364);
            this.PB_PlayerHealth.Name = "PB_PlayerHealth";
            this.PB_PlayerHealth.Size = new System.Drawing.Size(240, 23);
            this.PB_PlayerHealth.TabIndex = 1;
            // 
            // PB_EnemyHealth
            // 
            this.PB_EnemyHealth.ForeColor = System.Drawing.Color.Chartreuse;
            this.PB_EnemyHealth.Location = new System.Drawing.Point(12, 409);
            this.PB_EnemyHealth.Name = "PB_EnemyHealth";
            this.PB_EnemyHealth.Size = new System.Drawing.Size(240, 23);
            this.PB_EnemyHealth.TabIndex = 2;
            // 
            // LB_PlayerInv
            // 
            this.LB_PlayerInv.FormattingEnabled = true;
            this.LB_PlayerInv.Location = new System.Drawing.Point(422, 167);
            this.LB_PlayerInv.Name = "LB_PlayerInv";
            this.LB_PlayerInv.Size = new System.Drawing.Size(156, 147);
            this.LB_PlayerInv.TabIndex = 3;
            // 
            // LB_RoomInv
            // 
            this.LB_RoomInv.FormattingEnabled = true;
            this.LB_RoomInv.Location = new System.Drawing.Point(662, 167);
            this.LB_RoomInv.Name = "LB_RoomInv";
            this.LB_RoomInv.Size = new System.Drawing.Size(156, 147);
            this.LB_RoomInv.TabIndex = 4;
            // 
            // Btn_North
            // 
            this.Btn_North.Location = new System.Drawing.Point(60, 21);
            this.Btn_North.Name = "Btn_North";
            this.Btn_North.Size = new System.Drawing.Size(25, 23);
            this.Btn_North.TabIndex = 5;
            this.Btn_North.Text = "↑";
            this.Btn_North.UseVisualStyleBackColor = true;
            this.Btn_North.Click += new System.EventHandler(this.Btn_North_Click_1);
            // 
            // Btn_East
            // 
            this.Btn_East.Location = new System.Drawing.Point(82, 42);
            this.Btn_East.Name = "Btn_East";
            this.Btn_East.Size = new System.Drawing.Size(31, 23);
            this.Btn_East.TabIndex = 6;
            this.Btn_East.Text = "→";
            this.Btn_East.UseVisualStyleBackColor = true;
            this.Btn_East.Click += new System.EventHandler(this.Btn_East_Click_1);
            // 
            // Btn_West
            // 
            this.Btn_West.Location = new System.Drawing.Point(32, 42);
            this.Btn_West.Name = "Btn_West";
            this.Btn_West.Size = new System.Drawing.Size(31, 23);
            this.Btn_West.TabIndex = 7;
            this.Btn_West.Text = "←";
            this.Btn_West.UseVisualStyleBackColor = true;
            this.Btn_West.Click += new System.EventHandler(this.Btn_West_Click);
            // 
            // Btn_South
            // 
            this.Btn_South.Location = new System.Drawing.Point(60, 63);
            this.Btn_South.Name = "Btn_South";
            this.Btn_South.Size = new System.Drawing.Size(25, 23);
            this.Btn_South.TabIndex = 8;
            this.Btn_South.Text = "↓";
            this.Btn_South.UseVisualStyleBackColor = true;
            this.Btn_South.Click += new System.EventHandler(this.Btn_South_Click_1);
            // 
            // Btn_Attack
            // 
            this.Btn_Attack.Location = new System.Drawing.Point(276, 383);
            this.Btn_Attack.Name = "Btn_Attack";
            this.Btn_Attack.Size = new System.Drawing.Size(75, 23);
            this.Btn_Attack.TabIndex = 9;
            this.Btn_Attack.Text = "Attack";
            this.Btn_Attack.UseVisualStyleBackColor = true;
            this.Btn_Attack.Click += new System.EventHandler(this.Btn_Attack_Click_1);
            // 
            // Btn_UseItem
            // 
            this.Btn_UseItem.Location = new System.Drawing.Point(582, 215);
            this.Btn_UseItem.Name = "Btn_UseItem";
            this.Btn_UseItem.Size = new System.Drawing.Size(75, 23);
            this.Btn_UseItem.TabIndex = 13;
            this.Btn_UseItem.Text = "Inspect";
            this.Btn_UseItem.UseVisualStyleBackColor = true;
            this.Btn_UseItem.Click += new System.EventHandler(this.Btn_UseItem_Click_1);
            // 
            // Btn_ExamineItem
            // 
            this.Btn_ExamineItem.Location = new System.Drawing.Point(581, 186);
            this.Btn_ExamineItem.Name = "Btn_ExamineItem";
            this.Btn_ExamineItem.Size = new System.Drawing.Size(75, 23);
            this.Btn_ExamineItem.TabIndex = 14;
            this.Btn_ExamineItem.Text = "Use Item";
            this.Btn_ExamineItem.UseVisualStyleBackColor = true;
            this.Btn_ExamineItem.Click += new System.EventHandler(this.Btn_ExamineItem_Click_1);
            // 
            // Btn_PlayerToRoom
            // 
            this.Btn_PlayerToRoom.Location = new System.Drawing.Point(582, 244);
            this.Btn_PlayerToRoom.Name = "Btn_PlayerToRoom";
            this.Btn_PlayerToRoom.Size = new System.Drawing.Size(75, 23);
            this.Btn_PlayerToRoom.TabIndex = 15;
            this.Btn_PlayerToRoom.Text = "→";
            this.Btn_PlayerToRoom.UseVisualStyleBackColor = true;
            this.Btn_PlayerToRoom.Click += new System.EventHandler(this.Btn_PlayerToRoom_Click_1);
            // 
            // Btn_RoomToPlayer
            // 
            this.Btn_RoomToPlayer.Location = new System.Drawing.Point(582, 273);
            this.Btn_RoomToPlayer.Name = "Btn_RoomToPlayer";
            this.Btn_RoomToPlayer.Size = new System.Drawing.Size(75, 23);
            this.Btn_RoomToPlayer.TabIndex = 16;
            this.Btn_RoomToPlayer.Text = "←";
            this.Btn_RoomToPlayer.UseVisualStyleBackColor = true;
            this.Btn_RoomToPlayer.Click += new System.EventHandler(this.Btn_RoomToPlayer_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_East);
            this.groupBox1.Controls.Add(this.Btn_North);
            this.groupBox1.Controls.Add(this.Btn_West);
            this.groupBox1.Controls.Add(this.Btn_South);
            this.groupBox1.Location = new System.Drawing.Point(422, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 107);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movement";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Player Health";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Enemy: ";
            // 
            // L_EnemyName
            // 
            this.L_EnemyName.AutoSize = true;
            this.L_EnemyName.Location = new System.Drawing.Point(51, 393);
            this.L_EnemyName.Name = "L_EnemyName";
            this.L_EnemyName.Size = new System.Drawing.Size(33, 13);
            this.L_EnemyName.TabIndex = 20;
            this.L_EnemyName.Text = "name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(645, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "North:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(645, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "South:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(645, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "East:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(645, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "West:";
            // 
            // L_NExit
            // 
            this.L_NExit.AutoSize = true;
            this.L_NExit.Location = new System.Drawing.Point(681, 49);
            this.L_NExit.Name = "L_NExit";
            this.L_NExit.Size = new System.Drawing.Size(32, 13);
            this.L_NExit.TabIndex = 25;
            this.L_NExit.Text = "NExit";
            // 
            // L_SExit
            // 
            this.L_SExit.AutoSize = true;
            this.L_SExit.Location = new System.Drawing.Point(681, 78);
            this.L_SExit.Name = "L_SExit";
            this.L_SExit.Size = new System.Drawing.Size(31, 13);
            this.L_SExit.TabIndex = 26;
            this.L_SExit.Text = "SExit";
            // 
            // L_WExit
            // 
            this.L_WExit.AutoSize = true;
            this.L_WExit.Location = new System.Drawing.Point(677, 138);
            this.L_WExit.Name = "L_WExit";
            this.L_WExit.Size = new System.Drawing.Size(35, 13);
            this.L_WExit.TabIndex = 27;
            this.L_WExit.Text = "WExit";
            // 
            // L_EExit
            // 
            this.L_EExit.AutoSize = true;
            this.L_EExit.Location = new System.Drawing.Point(677, 107);
            this.L_EExit.Name = "L_EExit";
            this.L_EExit.Size = new System.Drawing.Size(31, 13);
            this.L_EExit.TabIndex = 28;
            this.L_EExit.Text = "EExit";
            // 
            // TB_Dialog
            // 
            this.TB_Dialog.Location = new System.Drawing.Point(12, 12);
            this.TB_Dialog.Name = "TB_Dialog";
            this.TB_Dialog.Size = new System.Drawing.Size(382, 333);
            this.TB_Dialog.TabIndex = 29;
            this.TB_Dialog.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 440);
            this.Controls.Add(this.TB_Dialog);
            this.Controls.Add(this.L_EExit);
            this.Controls.Add(this.L_WExit);
            this.Controls.Add(this.L_SExit);
            this.Controls.Add(this.L_NExit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.L_EnemyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Attack);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_RoomToPlayer);
            this.Controls.Add(this.Btn_PlayerToRoom);
            this.Controls.Add(this.Btn_ExamineItem);
            this.Controls.Add(this.Btn_UseItem);
            this.Controls.Add(this.LB_RoomInv);
            this.Controls.Add(this.LB_PlayerInv);
            this.Controls.Add(this.PB_EnemyHealth);
            this.Controls.Add(this.PB_PlayerHealth);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ring Wars";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar PB_PlayerHealth;
        private System.Windows.Forms.ProgressBar PB_EnemyHealth;
        private System.Windows.Forms.ListBox LB_PlayerInv;
        private System.Windows.Forms.ListBox LB_RoomInv;
        private System.Windows.Forms.Button Btn_North;
        private System.Windows.Forms.Button Btn_East;
        private System.Windows.Forms.Button Btn_West;
        private System.Windows.Forms.Button Btn_South;
        private System.Windows.Forms.Button Btn_Attack;
        private System.Windows.Forms.Button Btn_UseItem;
        private System.Windows.Forms.Button Btn_ExamineItem;
        private System.Windows.Forms.Button Btn_PlayerToRoom;
        private System.Windows.Forms.Button Btn_RoomToPlayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label L_EnemyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label L_NExit;
        private System.Windows.Forms.Label L_SExit;
        private System.Windows.Forms.Label L_WExit;
        private System.Windows.Forms.Label L_EExit;
        private System.Windows.Forms.RichTextBox TB_Dialog;
    }
}

