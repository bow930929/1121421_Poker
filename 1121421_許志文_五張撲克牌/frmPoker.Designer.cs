namespace _1121421_許志文_五張撲克牌
{
    partial class frmPoker
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpPoker = new System.Windows.Forms.GroupBox();
            this.grpBet = new System.Windows.Forms.GroupBox();
            this.btnBet = new System.Windows.Forms.Button();
            this.txtBet = new System.Windows.Forms.TextBox();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.lblBet = new System.Windows.Forms.Label();
            this.lblTotalFunds = new System.Windows.Forms.Label();
            this.grpButton = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnChangeCard = new System.Windows.Forms.Button();
            this.btnDealCard = new System.Windows.Forms.Button();
            this.grpBet.SuspendLayout();
            this.grpButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPoker
            // 
            this.grpPoker.BackColor = System.Drawing.Color.FloralWhite;
            this.grpPoker.Location = new System.Drawing.Point(12, 12);
            this.grpPoker.Name = "grpPoker";
            this.grpPoker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpPoker.Size = new System.Drawing.Size(776, 200);
            this.grpPoker.TabIndex = 0;
            this.grpPoker.TabStop = false;
            this.grpPoker.Text = "牌桌";
            // 
            // grpBet
            // 
            this.grpBet.BackColor = System.Drawing.Color.FloralWhite;
            this.grpBet.Controls.Add(this.btnBet);
            this.grpBet.Controls.Add(this.txtBet);
            this.grpBet.Controls.Add(this.txtMoney);
            this.grpBet.Controls.Add(this.lblBet);
            this.grpBet.Controls.Add(this.lblTotalFunds);
            this.grpBet.Location = new System.Drawing.Point(12, 218);
            this.grpBet.Name = "grpBet";
            this.grpBet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpBet.Size = new System.Drawing.Size(776, 96);
            this.grpBet.TabIndex = 1;
            this.grpBet.TabStop = false;
            this.grpBet.Text = "下注";
            // 
            // btnBet
            // 
            this.btnBet.BackColor = System.Drawing.Color.MintCream;
            this.btnBet.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnBet.Location = new System.Drawing.Point(549, 18);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(193, 70);
            this.btnBet.TabIndex = 4;
            this.btnBet.Text = "押注（Enter）";
            this.btnBet.UseVisualStyleBackColor = false;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // txtBet
            // 
            this.txtBet.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBet.Location = new System.Drawing.Point(423, 38);
            this.txtBet.Name = "txtBet";
            this.txtBet.Size = new System.Drawing.Size(107, 36);
            this.txtBet.TabIndex = 3;
            this.txtBet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBet_KeyPress);
            // 
            // txtMoney
            // 
            this.txtMoney.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMoney.Location = new System.Drawing.Point(137, 38);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(126, 36);
            this.txtMoney.TabIndex = 2;
            this.txtMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMoney.TextChanged += new System.EventHandler(this.txtMoney_TextChanged);
            this.txtMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoney_KeyPress);
            // 
            // lblBet
            // 
            this.lblBet.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblBet.Location = new System.Drawing.Point(301, 38);
            this.lblBet.Name = "lblBet";
            this.lblBet.Size = new System.Drawing.Size(116, 36);
            this.lblBet.TabIndex = 1;
            this.lblBet.Text = "押注金額";
            this.lblBet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalFunds
            // 
            this.lblTotalFunds.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTotalFunds.Location = new System.Drawing.Point(41, 38);
            this.lblTotalFunds.Name = "lblTotalFunds";
            this.lblTotalFunds.Size = new System.Drawing.Size(100, 36);
            this.lblTotalFunds.TabIndex = 0;
            this.lblTotalFunds.Text = "總資金";
            this.lblTotalFunds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpButton
            // 
            this.grpButton.BackColor = System.Drawing.Color.FloralWhite;
            this.grpButton.Controls.Add(this.lblResult);
            this.grpButton.Controls.Add(this.btnCheck);
            this.grpButton.Controls.Add(this.btnChangeCard);
            this.grpButton.Controls.Add(this.btnDealCard);
            this.grpButton.Location = new System.Drawing.Point(12, 320);
            this.grpButton.Name = "grpButton";
            this.grpButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpButton.Size = new System.Drawing.Size(776, 118);
            this.grpButton.TabIndex = 2;
            this.grpButton.TabStop = false;
            this.grpButton.Text = "功能";
            // 
            // lblResult
            // 
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblResult.Location = new System.Drawing.Point(350, 34);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(392, 59);
            this.lblResult.TabIndex = 8;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCheck.Location = new System.Drawing.Point(196, 14);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(123, 98);
            this.btnCheck.TabIndex = 7;
            this.btnCheck.Text = "判斷牌型";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnChangeCard
            // 
            this.btnChangeCard.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnChangeCard.Location = new System.Drawing.Point(56, 66);
            this.btnChangeCard.Name = "btnChangeCard";
            this.btnChangeCard.Size = new System.Drawing.Size(123, 46);
            this.btnChangeCard.TabIndex = 6;
            this.btnChangeCard.Text = "換牌";
            this.btnChangeCard.UseVisualStyleBackColor = true;
            this.btnChangeCard.Click += new System.EventHandler(this.btnChangeCard_Click);
            // 
            // btnDealCard
            // 
            this.btnDealCard.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDealCard.Location = new System.Drawing.Point(56, 14);
            this.btnDealCard.Name = "btnDealCard";
            this.btnDealCard.Size = new System.Drawing.Size(123, 46);
            this.btnDealCard.TabIndex = 5;
            this.btnDealCard.Text = "發牌";
            this.btnDealCard.UseVisualStyleBackColor = true;
            this.btnDealCard.Click += new System.EventHandler(this.btnDealCard_Click);
            // 
            // frmPoker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpButton);
            this.Controls.Add(this.grpBet);
            this.Controls.Add(this.grpPoker);
            this.Name = "frmPoker";
            this.Text = "元智皇家撲克牌賭城";
            this.grpBet.ResumeLayout(false);
            this.grpBet.PerformLayout();
            this.grpButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPoker;
        private System.Windows.Forms.GroupBox grpBet;
        private System.Windows.Forms.GroupBox grpButton;
        private System.Windows.Forms.Label lblBet;
        private System.Windows.Forms.Label lblTotalFunds;
        private System.Windows.Forms.Button btnBet;
        private System.Windows.Forms.TextBox txtBet;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnChangeCard;
        private System.Windows.Forms.Button btnDealCard;
    }
}

