namespace MyGame
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
            this.Player1 = new System.Windows.Forms.Label();
            this.Player2 = new System.Windows.Forms.Label();
            this.RollButton = new System.Windows.Forms.Button();
            this.TurnResultsGridView = new System.Windows.Forms.DataGridView();
            this.FirstPlayerWinCount = new System.Windows.Forms.Label();
            this.SecondPlayerWinCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TurnResultsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1.Location = new System.Drawing.Point(13, 13);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(36, 39);
            this.Player1.TabIndex = 0;
            this.Player1.Text = "0";
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2.Location = new System.Drawing.Point(153, 13);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(36, 39);
            this.Player2.TabIndex = 1;
            this.Player2.Text = "0";
            // 
            // RollButton
            // 
            this.RollButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollButton.Location = new System.Drawing.Point(63, 13);
            this.RollButton.Name = "RollButton";
            this.RollButton.Size = new System.Drawing.Size(75, 39);
            this.RollButton.TabIndex = 2;
            this.RollButton.Text = "Roll";
            this.RollButton.UseVisualStyleBackColor = true;
            this.RollButton.Click += new System.EventHandler(this.RollButton_Click);
            // 
            // TurnResultsGridView
            // 
            this.TurnResultsGridView.AllowUserToAddRows = false;
            this.TurnResultsGridView.AllowUserToDeleteRows = false;
            this.TurnResultsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TurnResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TurnResultsGridView.Location = new System.Drawing.Point(20, 108);
            this.TurnResultsGridView.Name = "TurnResultsGridView";
            this.TurnResultsGridView.ReadOnly = true;
            this.TurnResultsGridView.Size = new System.Drawing.Size(363, 187);
            this.TurnResultsGridView.TabIndex = 3;
            // 
            // FirstPlayerWinCount
            // 
            this.FirstPlayerWinCount.AutoSize = true;
            this.FirstPlayerWinCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstPlayerWinCount.Location = new System.Drawing.Point(20, 65);
            this.FirstPlayerWinCount.Name = "FirstPlayerWinCount";
            this.FirstPlayerWinCount.Size = new System.Drawing.Size(40, 24);
            this.FirstPlayerWinCount.TabIndex = 4;
            this.FirstPlayerWinCount.Text = "000";
            // 
            // SecondPlayerWinCount
            // 
            this.SecondPlayerWinCount.AutoSize = true;
            this.SecondPlayerWinCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondPlayerWinCount.Location = new System.Drawing.Point(160, 65);
            this.SecondPlayerWinCount.Name = "SecondPlayerWinCount";
            this.SecondPlayerWinCount.Size = new System.Drawing.Size(40, 24);
            this.SecondPlayerWinCount.TabIndex = 5;
            this.SecondPlayerWinCount.Text = "000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 307);
            this.Controls.Add(this.SecondPlayerWinCount);
            this.Controls.Add(this.FirstPlayerWinCount);
            this.Controls.Add(this.TurnResultsGridView);
            this.Controls.Add(this.RollButton);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TurnResultsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Player1;
        private System.Windows.Forms.Label Player2;
        private System.Windows.Forms.Button RollButton;
        private System.Windows.Forms.DataGridView TurnResultsGridView;
        private System.Windows.Forms.Label FirstPlayerWinCount;
        private System.Windows.Forms.Label SecondPlayerWinCount;
    }
}

