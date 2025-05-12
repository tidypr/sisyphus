using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sisyphus
{
    public partial class MainForm : Form
    {
        private Panel selectedTablePanel = null; // 선택된 테이블 패널

        public MainForm()
        {
            InitializeComponent();
            CreateTables();
        }

        // 테이블 생성
        private void CreateTables()
        {
            // 컨테이너 패널 생성
            FlowLayoutPanel tableContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight
            };
            this.displayTablePanel.Controls.Add(tableContainer);

            // 더미 데이터에서 테이블 가져오기
            var tables = DummyData.GetTables();

            foreach (var table in tables)
            {
                Panel panel = TablePanelFactory.CreateTable(table);
                tableContainer.Controls.Add(panel);
            }

            // 남은 테이블 (빈 테이블)
            for (int i = tables.Count + 1; i <= 17; i++)
            {
                Panel emptyPanel = TablePanelFactory.CreateTable(new Table { Name = $"Table {i}" }
                );
                tableContainer.Controls.Add(emptyPanel);
            }
        }
       
    }
}
