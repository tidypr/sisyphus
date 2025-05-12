namespace sisyphus
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lableSelectedTableName = new System.Windows.Forms.Label();
            this.ListBoxSelected = new System.Windows.Forms.ListBox();
            this.selectedTotal = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.배치도ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.재고관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.displayTablePanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(508, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 941);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lableSelectedTableName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ListBoxSelected, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.selectedTotal, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1221, 709);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lableSelectedTableName
            // 
            this.lableSelectedTableName.AutoSize = true;
            this.lableSelectedTableName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lableSelectedTableName.Font = new System.Drawing.Font("굴림", 12F);
            this.lableSelectedTableName.Location = new System.Drawing.Point(3, 0);
            this.lableSelectedTableName.Name = "lableSelectedTableName";
            this.lableSelectedTableName.Size = new System.Drawing.Size(1215, 24);
            this.lableSelectedTableName.TabIndex = 0;
            this.lableSelectedTableName.Text = "선택된 테이블이 없습니다";
            // 
            // ListBoxSelected
            // 
            this.ListBoxSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxSelected.FormattingEnabled = true;
            this.ListBoxSelected.ItemHeight = 18;
            this.ListBoxSelected.Location = new System.Drawing.Point(4, 110);
            this.ListBoxSelected.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListBoxSelected.Name = "ListBoxSelected";
            this.ListBoxSelected.Size = new System.Drawing.Size(1213, 488);
            this.ListBoxSelected.TabIndex = 1;
            // 
            // selectedTotal
            // 
            this.selectedTotal.AutoSize = true;
            this.selectedTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.selectedTotal.Font = new System.Drawing.Font("굴림", 12F);
            this.selectedTotal.Location = new System.Drawing.Point(4, 685);
            this.selectedTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectedTotal.Name = "selectedTotal";
            this.selectedTotal.Size = new System.Drawing.Size(1213, 24);
            this.selectedTotal.TabIndex = 2;
            this.selectedTotal.Text = "합계: ";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnPayment);
            this.panel8.Controls.Add(this.btnAddItem);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 709);
            this.panel8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1221, 232);
            this.panel8.TabIndex = 0;
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.Red;
            this.btnPayment.Location = new System.Drawing.Point(184, 46);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(107, 34);
            this.btnPayment.TabIndex = 0;
            this.btnPayment.Text = "결제";
            this.btnPayment.UseVisualStyleBackColor = false;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.Lime;
            this.btnAddItem.Location = new System.Drawing.Point(39, 46);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(107, 34);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.Text = "추가";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.배치도ToolStripMenuItem,
            this.재고관리ToolStripMenuItem,
            this.toolStripTextBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1729, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 배치도ToolStripMenuItem
            // 
            this.배치도ToolStripMenuItem.Name = "배치도ToolStripMenuItem";
            this.배치도ToolStripMenuItem.Size = new System.Drawing.Size(82, 31);
            this.배치도ToolStripMenuItem.Text = "배치도";
            // 
            // 재고관리ToolStripMenuItem
            // 
            this.재고관리ToolStripMenuItem.Name = "재고관리ToolStripMenuItem";
            this.재고관리ToolStripMenuItem.Size = new System.Drawing.Size(100, 31);
            this.재고관리ToolStripMenuItem.Text = "재고관리";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(1141, 31);
            // 
            // displayTablePanel
            // 
            this.displayTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayTablePanel.Location = new System.Drawing.Point(0, 35);
            this.displayTablePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.displayTablePanel.Name = "displayTablePanel";
            this.displayTablePanel.Size = new System.Drawing.Size(508, 941);
            this.displayTablePanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1729, 976);
            this.Controls.Add(this.displayTablePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ToolStripMenuItem 배치도ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 재고관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lableSelectedTableName;
        private System.Windows.Forms.Panel displayTablePanel;
        private System.Windows.Forms.ListBox ListBoxSelected;
        private System.Windows.Forms.Label selectedTotal;
    }
}

