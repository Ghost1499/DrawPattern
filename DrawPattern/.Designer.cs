namespace DrawPattern
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.mainGridView = new System.Windows.Forms.DataGridView();
            this.addColumnButton = new System.Windows.Forms.Button();
            this.deleteColumnButton = new System.Windows.Forms.Button();
            this.addRowButton = new System.Windows.Forms.Button();
            this.deleteRowButton = new System.Windows.Forms.Button();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.addColumnsTextbox = new System.Windows.Forms.TextBox();
            this.deleteColumnsTextbox = new System.Windows.Forms.TextBox();
            this.addRowsTextbox = new System.Windows.Forms.TextBox();
            this.deleteRowsTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.columnTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rowTextbox = new System.Windows.Forms.TextBox();
            this.changeDGVCountButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            this.settingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1585, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1585, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // mainGridView
            // 
            this.mainGridView.AllowUserToAddRows = false;
            this.mainGridView.AllowUserToDeleteRows = false;
            this.mainGridView.AllowUserToResizeColumns = false;
            this.mainGridView.AllowUserToResizeRows = false;
            this.mainGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mainGridView.Location = new System.Drawing.Point(22, 70);
            this.mainGridView.Name = "mainGridView";
            this.mainGridView.ReadOnly = true;
            this.mainGridView.RowTemplate.Height = 28;
            this.mainGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mainGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.mainGridView.Size = new System.Drawing.Size(761, 439);
            this.mainGridView.TabIndex = 2;
            // 
            // addColumnButton
            // 
            this.addColumnButton.AutoSize = true;
            this.addColumnButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addColumnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addColumnButton.Location = new System.Drawing.Point(3, 14);
            this.addColumnButton.Name = "addColumnButton";
            this.addColumnButton.Size = new System.Drawing.Size(210, 35);
            this.addColumnButton.TabIndex = 3;
            this.addColumnButton.Text = "+Добавить столбец";
            this.addColumnButton.UseVisualStyleBackColor = true;
            this.addColumnButton.Click += new System.EventHandler(this.addColumnButton_Click);
            // 
            // deleteColumnButton
            // 
            this.deleteColumnButton.AutoSize = true;
            this.deleteColumnButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteColumnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.deleteColumnButton.Location = new System.Drawing.Point(3, 55);
            this.deleteColumnButton.Name = "deleteColumnButton";
            this.deleteColumnButton.Size = new System.Drawing.Size(192, 35);
            this.deleteColumnButton.TabIndex = 4;
            this.deleteColumnButton.Text = "-Удалить столбец";
            this.deleteColumnButton.UseVisualStyleBackColor = true;
            this.deleteColumnButton.Click += new System.EventHandler(this.deleteColumnButton_Click);
            // 
            // addRowButton
            // 
            this.addRowButton.AutoSize = true;
            this.addRowButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addRowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addRowButton.Location = new System.Drawing.Point(3, 96);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(194, 35);
            this.addRowButton.TabIndex = 5;
            this.addRowButton.Text = "+Добавить строку";
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.addRowButton_Click);
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.AutoSize = true;
            this.deleteRowButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteRowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.deleteRowButton.Location = new System.Drawing.Point(3, 137);
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(176, 35);
            this.deleteRowButton.TabIndex = 6;
            this.deleteRowButton.Text = "-Удалить строку";
            this.deleteRowButton.UseVisualStyleBackColor = true;
            this.deleteRowButton.Click += new System.EventHandler(this.deleteRowButton_Click);
            // 
            // settingsPanel
            // 
            this.settingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsPanel.AutoSize = true;
            this.settingsPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.settingsPanel.Controls.Add(this.changeDGVCountButton);
            this.settingsPanel.Controls.Add(this.rowTextbox);
            this.settingsPanel.Controls.Add(this.label3);
            this.settingsPanel.Controls.Add(this.columnTextbox);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Controls.Add(this.deleteRowsTextbox);
            this.settingsPanel.Controls.Add(this.addRowsTextbox);
            this.settingsPanel.Controls.Add(this.deleteColumnsTextbox);
            this.settingsPanel.Controls.Add(this.addColumnsTextbox);
            this.settingsPanel.Controls.Add(this.label1);
            this.settingsPanel.Controls.Add(this.addColumnButton);
            this.settingsPanel.Controls.Add(this.addRowButton);
            this.settingsPanel.Controls.Add(this.deleteRowButton);
            this.settingsPanel.Controls.Add(this.deleteColumnButton);
            this.settingsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.settingsPanel.Location = new System.Drawing.Point(919, 70);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(654, 485);
            this.settingsPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // addColumnsTextbox
            // 
            this.addColumnsTextbox.Location = new System.Drawing.Point(231, 14);
            this.addColumnsTextbox.Name = "addColumnsTextbox";
            this.addColumnsTextbox.Size = new System.Drawing.Size(59, 30);
            this.addColumnsTextbox.TabIndex = 8;
            // 
            // deleteColumnsTextbox
            // 
            this.deleteColumnsTextbox.Location = new System.Drawing.Point(231, 55);
            this.deleteColumnsTextbox.Name = "deleteColumnsTextbox";
            this.deleteColumnsTextbox.Size = new System.Drawing.Size(59, 30);
            this.deleteColumnsTextbox.TabIndex = 9;
            // 
            // addRowsTextbox
            // 
            this.addRowsTextbox.Location = new System.Drawing.Point(231, 96);
            this.addRowsTextbox.Name = "addRowsTextbox";
            this.addRowsTextbox.Size = new System.Drawing.Size(59, 30);
            this.addRowsTextbox.TabIndex = 10;
            // 
            // deleteRowsTextbox
            // 
            this.deleteRowsTextbox.Location = new System.Drawing.Point(231, 137);
            this.deleteRowsTextbox.Name = "deleteRowsTextbox";
            this.deleteRowsTextbox.Size = new System.Drawing.Size(59, 30);
            this.deleteRowsTextbox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Количество столбцов";
            // 
            // columnTextbox
            // 
            this.columnTextbox.Location = new System.Drawing.Point(543, 14);
            this.columnTextbox.Name = "columnTextbox";
            this.columnTextbox.Size = new System.Drawing.Size(50, 30);
            this.columnTextbox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Количество строк";
            // 
            // rowTextbox
            // 
            this.rowTextbox.Location = new System.Drawing.Point(543, 55);
            this.rowTextbox.Name = "rowTextbox";
            this.rowTextbox.Size = new System.Drawing.Size(50, 30);
            this.rowTextbox.TabIndex = 15;
            // 
            // changeDGVCountButton
            // 
            this.changeDGVCountButton.Location = new System.Drawing.Point(325, 96);
            this.changeDGVCountButton.Name = "changeDGVCountButton";
            this.changeDGVCountButton.Size = new System.Drawing.Size(119, 42);
            this.changeDGVCountButton.TabIndex = 16;
            this.changeDGVCountButton.Text = "Принять";
            this.changeDGVCountButton.UseVisualStyleBackColor = true;
            this.changeDGVCountButton.Click += new System.EventHandler(this.changeDGVCountButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1585, 567);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.mainGridView);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "DrawPattern";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.DataGridView mainGridView;
        private System.Windows.Forms.Button addColumnButton;
        private System.Windows.Forms.Button deleteColumnButton;
        private System.Windows.Forms.Button addRowButton;
        private System.Windows.Forms.Button deleteRowButton;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addColumnsTextbox;
        private System.Windows.Forms.TextBox deleteRowsTextbox;
        private System.Windows.Forms.TextBox addRowsTextbox;
        private System.Windows.Forms.TextBox deleteColumnsTextbox;
        private System.Windows.Forms.TextBox columnTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rowTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button changeDGVCountButton;
    }
}

