namespace TicTacToe
{
    partial class TicTacToeForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cellButton1 = new System.Windows.Forms.Button();
            this.cellButton2 = new System.Windows.Forms.Button();
            this.cellButton3 = new System.Windows.Forms.Button();
            this.cellButton6 = new System.Windows.Forms.Button();
            this.cellButton5 = new System.Windows.Forms.Button();
            this.cellButton4 = new System.Windows.Forms.Button();
            this.cellButton9 = new System.Windows.Forms.Button();
            this.cellButton8 = new System.Windows.Forms.Button();
            this.cellButton7 = new System.Windows.Forms.Button();
            this.gameFieldGroupBox = new System.Windows.Forms.GroupBox();
            this.ticRadioButton = new System.Windows.Forms.RadioButton();
            this.tacRadioButton = new System.Windows.Forms.RadioButton();
            this.selectTicTacGroupBox = new System.Windows.Forms.GroupBox();
            this.gameModeGroupBox = new System.Windows.Forms.GroupBox();
            this.singlePlayerRadioButton = new System.Windows.Forms.RadioButton();
            this.multiPlayerRadioButton = new System.Windows.Forms.RadioButton();
            this.startButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultTitleLabel = new System.Windows.Forms.Label();
            this.currentSideTitleLabel = new System.Windows.Forms.Label();
            this.currentSideLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.statisticsGroupBox = new System.Windows.Forms.GroupBox();
            this.statisticsDataGridView = new System.Windows.Forms.DataGridView();
            this.getStatisticsButton = new System.Windows.Forms.Button();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.gameFieldGroupBox.SuspendLayout();
            this.selectTicTacGroupBox.SuspendLayout();
            this.gameModeGroupBox.SuspendLayout();
            this.statisticsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cellButton1
            // 
            this.cellButton1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cellButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.cellButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cellButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cellButton1.Location = new System.Drawing.Point(20, 30);
            this.cellButton1.Margin = new System.Windows.Forms.Padding(0);
            this.cellButton1.Name = "cellButton1";
            this.cellButton1.Size = new System.Drawing.Size(100, 100);
            this.cellButton1.TabIndex = 0;
            this.cellButton1.TabStop = false;
            this.cellButton1.Tag = "";
            this.cellButton1.UseVisualStyleBackColor = false;
            this.cellButton1.Click += new System.EventHandler(this.cellButton_Click);
            // 
            // cellButton2
            // 
            this.cellButton2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cellButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.cellButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cellButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cellButton2.Location = new System.Drawing.Point(120, 30);
            this.cellButton2.Margin = new System.Windows.Forms.Padding(0);
            this.cellButton2.Name = "cellButton2";
            this.cellButton2.Size = new System.Drawing.Size(100, 100);
            this.cellButton2.TabIndex = 1;
            this.cellButton2.TabStop = false;
            this.cellButton2.Tag = "";
            this.cellButton2.UseVisualStyleBackColor = false;
            this.cellButton2.Click += new System.EventHandler(this.cellButton_Click);
            // 
            // cellButton3
            // 
            this.cellButton3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cellButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.cellButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cellButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cellButton3.Location = new System.Drawing.Point(220, 30);
            this.cellButton3.Margin = new System.Windows.Forms.Padding(0);
            this.cellButton3.Name = "cellButton3";
            this.cellButton3.Size = new System.Drawing.Size(100, 100);
            this.cellButton3.TabIndex = 2;
            this.cellButton3.TabStop = false;
            this.cellButton3.Tag = "";
            this.cellButton3.UseVisualStyleBackColor = false;
            this.cellButton3.Click += new System.EventHandler(this.cellButton_Click);
            // 
            // cellButton6
            // 
            this.cellButton6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cellButton6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.cellButton6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cellButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cellButton6.Location = new System.Drawing.Point(220, 130);
            this.cellButton6.Margin = new System.Windows.Forms.Padding(0);
            this.cellButton6.Name = "cellButton6";
            this.cellButton6.Size = new System.Drawing.Size(100, 100);
            this.cellButton6.TabIndex = 5;
            this.cellButton6.TabStop = false;
            this.cellButton6.UseVisualStyleBackColor = false;
            this.cellButton6.Click += new System.EventHandler(this.cellButton_Click);
            // 
            // cellButton5
            // 
            this.cellButton5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cellButton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.cellButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cellButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cellButton5.Location = new System.Drawing.Point(120, 130);
            this.cellButton5.Margin = new System.Windows.Forms.Padding(0);
            this.cellButton5.Name = "cellButton5";
            this.cellButton5.Size = new System.Drawing.Size(100, 100);
            this.cellButton5.TabIndex = 4;
            this.cellButton5.TabStop = false;
            this.cellButton5.UseVisualStyleBackColor = false;
            this.cellButton5.Click += new System.EventHandler(this.cellButton_Click);
            // 
            // cellButton4
            // 
            this.cellButton4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cellButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.cellButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cellButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cellButton4.Location = new System.Drawing.Point(20, 130);
            this.cellButton4.Margin = new System.Windows.Forms.Padding(0);
            this.cellButton4.Name = "cellButton4";
            this.cellButton4.Size = new System.Drawing.Size(100, 100);
            this.cellButton4.TabIndex = 3;
            this.cellButton4.TabStop = false;
            this.cellButton4.UseVisualStyleBackColor = false;
            this.cellButton4.Click += new System.EventHandler(this.cellButton_Click);
            // 
            // cellButton9
            // 
            this.cellButton9.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cellButton9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.cellButton9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cellButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cellButton9.Location = new System.Drawing.Point(220, 230);
            this.cellButton9.Margin = new System.Windows.Forms.Padding(0);
            this.cellButton9.Name = "cellButton9";
            this.cellButton9.Size = new System.Drawing.Size(100, 100);
            this.cellButton9.TabIndex = 8;
            this.cellButton9.TabStop = false;
            this.cellButton9.UseVisualStyleBackColor = false;
            this.cellButton9.Click += new System.EventHandler(this.cellButton_Click);
            // 
            // cellButton8
            // 
            this.cellButton8.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cellButton8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.cellButton8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cellButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cellButton8.Location = new System.Drawing.Point(120, 230);
            this.cellButton8.Margin = new System.Windows.Forms.Padding(0);
            this.cellButton8.Name = "cellButton8";
            this.cellButton8.Size = new System.Drawing.Size(100, 100);
            this.cellButton8.TabIndex = 7;
            this.cellButton8.TabStop = false;
            this.cellButton8.UseVisualStyleBackColor = false;
            this.cellButton8.Click += new System.EventHandler(this.cellButton_Click);
            // 
            // cellButton7
            // 
            this.cellButton7.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cellButton7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue;
            this.cellButton7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cellButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cellButton7.Location = new System.Drawing.Point(20, 230);
            this.cellButton7.Margin = new System.Windows.Forms.Padding(0);
            this.cellButton7.Name = "cellButton7";
            this.cellButton7.Size = new System.Drawing.Size(100, 100);
            this.cellButton7.TabIndex = 6;
            this.cellButton7.TabStop = false;
            this.cellButton7.UseVisualStyleBackColor = false;
            this.cellButton7.Click += new System.EventHandler(this.cellButton_Click);
            // 
            // gameFieldGroupBox
            // 
            this.gameFieldGroupBox.Controls.Add(this.cellButton1);
            this.gameFieldGroupBox.Controls.Add(this.cellButton9);
            this.gameFieldGroupBox.Controls.Add(this.cellButton2);
            this.gameFieldGroupBox.Controls.Add(this.cellButton8);
            this.gameFieldGroupBox.Controls.Add(this.cellButton3);
            this.gameFieldGroupBox.Controls.Add(this.cellButton7);
            this.gameFieldGroupBox.Controls.Add(this.cellButton4);
            this.gameFieldGroupBox.Controls.Add(this.cellButton6);
            this.gameFieldGroupBox.Controls.Add(this.cellButton5);
            this.gameFieldGroupBox.Location = new System.Drawing.Point(14, 14);
            this.gameFieldGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.gameFieldGroupBox.Name = "gameFieldGroupBox";
            this.gameFieldGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.gameFieldGroupBox.Size = new System.Drawing.Size(340, 350);
            this.gameFieldGroupBox.TabIndex = 9;
            this.gameFieldGroupBox.TabStop = false;
            this.gameFieldGroupBox.Text = "Игра";
            // 
            // ticRadioButton
            // 
            this.ticRadioButton.AutoSize = true;
            this.ticRadioButton.Checked = true;
            this.ticRadioButton.Location = new System.Drawing.Point(8, 28);
            this.ticRadioButton.Margin = new System.Windows.Forms.Padding(5);
            this.ticRadioButton.Name = "ticRadioButton";
            this.ticRadioButton.Size = new System.Drawing.Size(107, 23);
            this.ticRadioButton.TabIndex = 11;
            this.ticRadioButton.TabStop = true;
            this.ticRadioButton.Text = "за крестики";
            this.ticRadioButton.UseVisualStyleBackColor = true;
            // 
            // tacRadioButton
            // 
            this.tacRadioButton.AutoSize = true;
            this.tacRadioButton.Location = new System.Drawing.Point(8, 62);
            this.tacRadioButton.Margin = new System.Windows.Forms.Padding(5);
            this.tacRadioButton.Name = "tacRadioButton";
            this.tacRadioButton.Size = new System.Drawing.Size(96, 23);
            this.tacRadioButton.TabIndex = 12;
            this.tacRadioButton.Text = "за нолики";
            this.tacRadioButton.UseVisualStyleBackColor = true;
            // 
            // selectTicTacGroupBox
            // 
            this.selectTicTacGroupBox.Controls.Add(this.ticRadioButton);
            this.selectTicTacGroupBox.Controls.Add(this.tacRadioButton);
            this.selectTicTacGroupBox.Location = new System.Drawing.Point(364, 125);
            this.selectTicTacGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.selectTicTacGroupBox.Name = "selectTicTacGroupBox";
            this.selectTicTacGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.selectTicTacGroupBox.Size = new System.Drawing.Size(267, 101);
            this.selectTicTacGroupBox.TabIndex = 13;
            this.selectTicTacGroupBox.TabStop = false;
            this.selectTicTacGroupBox.Text = "Выберите, за кого играть";
            // 
            // gameModeGroupBox
            // 
            this.gameModeGroupBox.Controls.Add(this.singlePlayerRadioButton);
            this.gameModeGroupBox.Controls.Add(this.multiPlayerRadioButton);
            this.gameModeGroupBox.Location = new System.Drawing.Point(364, 14);
            this.gameModeGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.gameModeGroupBox.Name = "gameModeGroupBox";
            this.gameModeGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.gameModeGroupBox.Size = new System.Drawing.Size(267, 101);
            this.gameModeGroupBox.TabIndex = 14;
            this.gameModeGroupBox.TabStop = false;
            this.gameModeGroupBox.Text = "Выберите режим игры";
            // 
            // singlePlayerRadioButton
            // 
            this.singlePlayerRadioButton.AutoSize = true;
            this.singlePlayerRadioButton.Checked = true;
            this.singlePlayerRadioButton.Location = new System.Drawing.Point(8, 28);
            this.singlePlayerRadioButton.Margin = new System.Windows.Forms.Padding(5);
            this.singlePlayerRadioButton.Name = "singlePlayerRadioButton";
            this.singlePlayerRadioButton.Size = new System.Drawing.Size(133, 23);
            this.singlePlayerRadioButton.TabIndex = 11;
            this.singlePlayerRadioButton.TabStop = true;
            this.singlePlayerRadioButton.Text = "с компьютером";
            this.singlePlayerRadioButton.UseVisualStyleBackColor = true;
            this.singlePlayerRadioButton.CheckedChanged += new System.EventHandler(this.singlePlayerRadioButton_CheckedChanged);
            // 
            // multiPlayerRadioButton
            // 
            this.multiPlayerRadioButton.AutoSize = true;
            this.multiPlayerRadioButton.Location = new System.Drawing.Point(8, 62);
            this.multiPlayerRadioButton.Margin = new System.Windows.Forms.Padding(5);
            this.multiPlayerRadioButton.Name = "multiPlayerRadioButton";
            this.multiPlayerRadioButton.Size = new System.Drawing.Size(112, 23);
            this.multiPlayerRadioButton.TabIndex = 12;
            this.multiPlayerRadioButton.Text = "с человеком";
            this.multiPlayerRadioButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(364, 236);
            this.startButton.Margin = new System.Windows.Forms.Padding(5);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(267, 33);
            this.startButton.TabIndex = 15;
            this.startButton.Text = "Начать новую игру";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(364, 336);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 19);
            this.resultLabel.TabIndex = 19;
            // 
            // resultTitleLabel
            // 
            this.resultTitleLabel.AutoSize = true;
            this.resultTitleLabel.Location = new System.Drawing.Point(364, 317);
            this.resultTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.resultTitleLabel.Name = "resultTitleLabel";
            this.resultTitleLabel.Size = new System.Drawing.Size(85, 19);
            this.resultTitleLabel.TabIndex = 18;
            this.resultTitleLabel.Text = "Состояние:";
            // 
            // currentSideTitleLabel
            // 
            this.currentSideTitleLabel.AutoSize = true;
            this.currentSideTitleLabel.Location = new System.Drawing.Point(364, 355);
            this.currentSideTitleLabel.Name = "currentSideTitleLabel";
            this.currentSideTitleLabel.Size = new System.Drawing.Size(104, 19);
            this.currentSideTitleLabel.TabIndex = 20;
            this.currentSideTitleLabel.Text = "Сейчас ходят:";
            // 
            // currentSideLabel
            // 
            this.currentSideLabel.AutoSize = true;
            this.currentSideLabel.Location = new System.Drawing.Point(364, 374);
            this.currentSideLabel.Name = "currentSideLabel";
            this.currentSideLabel.Size = new System.Drawing.Size(0, 19);
            this.currentSideLabel.TabIndex = 21;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(364, 393);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 19);
            this.errorLabel.TabIndex = 22;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(364, 279);
            this.stopButton.Margin = new System.Windows.Forms.Padding(5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(267, 33);
            this.stopButton.TabIndex = 23;
            this.stopButton.Text = "Остановить игру";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // statisticsGroupBox
            // 
            this.statisticsGroupBox.Controls.Add(this.statisticsDataGridView);
            this.statisticsGroupBox.Location = new System.Drawing.Point(639, 15);
            this.statisticsGroupBox.Name = "statisticsGroupBox";
            this.statisticsGroupBox.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.statisticsGroupBox.Size = new System.Drawing.Size(542, 297);
            this.statisticsGroupBox.TabIndex = 24;
            this.statisticsGroupBox.TabStop = false;
            this.statisticsGroupBox.Text = "Статистика";
            // 
            // statisticsDataGridView
            // 
            this.statisticsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statisticsDataGridView.Location = new System.Drawing.Point(18, 33);
            this.statisticsDataGridView.Name = "statisticsDataGridView";
            this.statisticsDataGridView.Size = new System.Drawing.Size(506, 246);
            this.statisticsDataGridView.TabIndex = 0;
            // 
            // getStatisticsButton
            // 
            this.getStatisticsButton.Location = new System.Drawing.Point(639, 351);
            this.getStatisticsButton.Name = "getStatisticsButton";
            this.getStatisticsButton.Size = new System.Drawing.Size(542, 33);
            this.getStatisticsButton.TabIndex = 25;
            this.getStatisticsButton.Text = "Запросить статистику";
            this.getStatisticsButton.UseVisualStyleBackColor = true;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(639, 318);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(542, 27);
            this.urlTextBox.TabIndex = 26;
            this.urlTextBox.Text = "http://localhost:59577/";
            // 
            // TicTacToeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1201, 422);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.getStatisticsButton);
            this.Controls.Add(this.statisticsGroupBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.currentSideLabel);
            this.Controls.Add(this.currentSideTitleLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.resultTitleLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.gameModeGroupBox);
            this.Controls.Add(this.selectTicTacGroupBox);
            this.Controls.Add(this.gameFieldGroupBox);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TicTacToeForm";
            this.Text = "Крестики-нолики";
            this.gameFieldGroupBox.ResumeLayout(false);
            this.selectTicTacGroupBox.ResumeLayout(false);
            this.selectTicTacGroupBox.PerformLayout();
            this.gameModeGroupBox.ResumeLayout(false);
            this.gameModeGroupBox.PerformLayout();
            this.statisticsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statisticsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cellButton1;
        private System.Windows.Forms.Button cellButton2;
        private System.Windows.Forms.Button cellButton3;
        private System.Windows.Forms.Button cellButton6;
        private System.Windows.Forms.Button cellButton5;
        private System.Windows.Forms.Button cellButton4;
        private System.Windows.Forms.Button cellButton9;
        private System.Windows.Forms.Button cellButton8;
        private System.Windows.Forms.Button cellButton7;
        private System.Windows.Forms.GroupBox gameFieldGroupBox;
        private System.Windows.Forms.RadioButton ticRadioButton;
        private System.Windows.Forms.RadioButton tacRadioButton;
        private System.Windows.Forms.GroupBox selectTicTacGroupBox;
        private System.Windows.Forms.GroupBox gameModeGroupBox;
        private System.Windows.Forms.RadioButton singlePlayerRadioButton;
        private System.Windows.Forms.RadioButton multiPlayerRadioButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label resultTitleLabel;
        private System.Windows.Forms.Label currentSideTitleLabel;
        private System.Windows.Forms.Label currentSideLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.GroupBox statisticsGroupBox;
        private System.Windows.Forms.DataGridView statisticsDataGridView;
        private System.Windows.Forms.Button getStatisticsButton;
        private System.Windows.Forms.TextBox urlTextBox;
    }
}

