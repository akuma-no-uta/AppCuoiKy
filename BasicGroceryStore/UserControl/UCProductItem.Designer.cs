namespace BasicGroceryStore
{
    partial class UCProductItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.txtProductValue = new System.Windows.Forms.TextBox();
            this.numUDQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.lblOriginalPrice = new System.Windows.Forms.Label();
            this.lblDiscountBadge = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlMain.Controls.Add(this.btnDelete);
            this.pnlMain.Controls.Add(this.numUDQuantity);
            this.pnlMain.Controls.Add(this.pnlControl);
            this.pnlMain.Controls.Add(this.lblProductName);
            this.pnlMain.Controls.Add(this.lblProductPrice);
            this.pnlMain.Controls.Add(this.lblOriginalPrice);
            this.pnlMain.Controls.Add(this.lblDiscountBadge);
            this.pnlMain.Location = new System.Drawing.Point(4, 5);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(820, 68);
            this.pnlMain.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(693, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 57);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "X";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.txtProductValue);
            this.pnlControl.Location = new System.Drawing.Point(434, 18);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(239, 45);
            this.pnlControl.TabIndex = 2;
            // 
            // txtProductValue
            // 
            this.txtProductValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductValue.Location = new System.Drawing.Point(0, 4);
            this.txtProductValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProductValue.Name = "txtProductValue";
            this.txtProductValue.Size = new System.Drawing.Size(198, 30);
            this.txtProductValue.TabIndex = 1;
            // 
            // numUDQuantity
            // 
            this.numUDQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUDQuantity.Location = new System.Drawing.Point(357, 23);
            this.numUDQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numUDQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUDQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDQuantity.Name = "numUDQuantity";
            this.numUDQuantity.Size = new System.Drawing.Size(69, 30);
            this.numUDQuantity.TabIndex = 0;
            this.numUDQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDQuantity.ValueChanged += new System.EventHandler(this.numUDQuantity_ValueChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(4, 0);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(64, 25);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Name";
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.Location = new System.Drawing.Point(4, 46);
            this.lblProductPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(79, 20);
            this.lblProductPrice.TabIndex = 0;
            this.lblProductPrice.Text = "Price vnd";
            // 
            // lblOriginalPrice — giá gốc gạch ngang, chỉ hiện khi có KM
            // 
            this.lblOriginalPrice.AutoSize = true;
            this.lblOriginalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginalPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblOriginalPrice.Location = new System.Drawing.Point(160, 0);
            this.lblOriginalPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOriginalPrice.Name = "lblOriginalPrice";
            this.lblOriginalPrice.Size = new System.Drawing.Size(90, 20);
            this.lblOriginalPrice.TabIndex = 5;
            this.lblOriginalPrice.Text = "";
            this.lblOriginalPrice.Visible = false;
            // 
            // lblDiscountBadge — badge đỏ hiển thị % giảm
            // 
            this.lblDiscountBadge.AutoSize = true;
            this.lblDiscountBadge.BackColor = System.Drawing.Color.OrangeRed;
            this.lblDiscountBadge.ForeColor = System.Drawing.Color.White;
            this.lblDiscountBadge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountBadge.Location = new System.Drawing.Point(160, 22);
            this.lblDiscountBadge.Margin = new System.Windows.Forms.Padding(2);
            this.lblDiscountBadge.Name = "lblDiscountBadge";
            this.lblDiscountBadge.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lblDiscountBadge.Size = new System.Drawing.Size(40, 20);
            this.lblDiscountBadge.TabIndex = 6;
            this.lblDiscountBadge.Text = "";
            this.lblDiscountBadge.Visible = false;
            // 
            // UCProductItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UCProductItem";
            this.Size = new System.Drawing.Size(831, 78);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.TextBox txtProductValue;
        private System.Windows.Forms.NumericUpDown numUDQuantity;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label lblOriginalPrice;
        private System.Windows.Forms.Label lblDiscountBadge;
        private System.Windows.Forms.Button btnDelete;
    }
}