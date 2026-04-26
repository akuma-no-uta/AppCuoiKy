
namespace BasicGroceryStore
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlContainer.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pnlMain);
            this.pnlContainer.Controls.Add(this.pnlControl);
            this.pnlContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(2400, 1385);
            this.pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(375, 62);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(2025, 1323);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.Gold;
            this.pnlControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlControl.BackgroundImage")));
            this.pnlControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.btnCalendar);
            this.pnlControl.Controls.Add(this.btnBrowser);
            this.pnlControl.Controls.Add(this.lblTime);
            this.pnlControl.Controls.Add(this.monthCalendar1);
            this.pnlControl.Controls.Add(this.btnStaff);
            this.pnlControl.Controls.Add(this.btnStatistic);
            this.pnlControl.Controls.Add(this.btnImport);
            this.pnlControl.Controls.Add(this.btnOrder);
            this.pnlControl.Controls.Add(this.btnProduct);
            this.pnlControl.Controls.Add(this.btnHomePage);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(273, 1385);
            this.pnlControl.TabIndex = 1;
            // 
            // btnCalendar
            // 
            this.btnCalendar.Image = global::BasicGroceryStore.Properties.Resources.icons8_Tear_Off_Calendar_32;
            this.btnCalendar.Location = new System.Drawing.Point(12, 402);
            this.btnCalendar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(246, 55);
            this.btnCalendar.TabIndex = 9;
            this.btnCalendar.Text = "KHUYẾN MÃI";
            this.btnCalendar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCalendar.UseVisualStyleBackColor = true;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Enabled = false;
            this.btnBrowser.Image = global::BasicGroceryStore.Properties.Resources.icons8_mint_browser_32;
            this.btnBrowser.Location = new System.Drawing.Point(4, 759);
            this.btnBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(10, 21);
            this.btnBrowser.TabIndex = 8;
            this.btnBrowser.Text = "TRÌNH DUYỆT";
            this.btnBrowser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowser.UseVisualStyleBackColor = true;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(18, 1237);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 33);
            this.lblTime.TabIndex = 7;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(-1, 476);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(14);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 6;
            // 
            // btnStaff
            // 
            this.btnStaff.Image = global::BasicGroceryStore.Properties.Resources.icons8_staff_32;
            this.btnStaff.Location = new System.Drawing.Point(12, 326);
            this.btnStaff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(246, 66);
            this.btnStaff.TabIndex = 5;
            this.btnStaff.Text = "NHÂN VIÊN";
            this.btnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnStatistic
            // 
            this.btnStatistic.Image = global::BasicGroceryStore.Properties.Resources.icons8_plot_32;
            this.btnStatistic.Location = new System.Drawing.Point(12, 255);
            this.btnStatistic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Size = new System.Drawing.Size(246, 61);
            this.btnStatistic.TabIndex = 4;
            this.btnStatistic.Text = "THỐNG KÊ";
            this.btnStatistic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStatistic.UseVisualStyleBackColor = true;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // btnImport
            // 
            this.btnImport.Image = global::BasicGroceryStore.Properties.Resources.icons8_import_32;
            this.btnImport.Location = new System.Drawing.Point(12, 191);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(246, 54);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "NHẬP HÀNG";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Image = global::BasicGroceryStore.Properties.Resources.icons8_purchase_order_32;
            this.btnOrder.Location = new System.Drawing.Point(12, 133);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(246, 48);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "BÁN HÀNG";
            this.btnOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Image = global::BasicGroceryStore.Properties.Resources.icons8_product_32;
            this.btnProduct.Location = new System.Drawing.Point(12, 75);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(246, 48);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "SẢN PHẨM";
            this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnHomePage
            // 
            this.btnHomePage.Image = global::BasicGroceryStore.Properties.Resources.icons8_home_32;
            this.btnHomePage.Location = new System.Drawing.Point(12, 13);
            this.btnHomePage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(246, 52);
            this.btnHomePage.TabIndex = 0;
            this.btnHomePage.Text = "TRANG CHỦ";
            this.btnHomePage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHomePage.UseVisualStyleBackColor = true;
            this.btnHomePage.Click += new System.EventHandler(this.btnHomePage_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1946, 1226);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.pnlContainer.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Button btnCalendar;
    }
}
