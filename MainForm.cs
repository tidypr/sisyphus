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

        private void CreateTables()
        {
            FlowLayoutPanel tableContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight
            };
            this.displayTablePanel.Controls.Add(tableContainer);

            for (int i = 1; i <= 18; i++)
            {
                Panel tablePanel = TablePanelFactory.CreateTable($"Table {i}", TablePanel_Click);
                tableContainer.Controls.Add(tablePanel);
            }
        }



        private void TablePanel_Click(object sender, EventArgs e)
        {
            // 이전 선택 테이블의 테두리를 원래대로
            if (selectedTablePanel != null)
            {
                selectedTablePanel.Padding = new Padding(0);
                selectedTablePanel.BackColor = SystemColors.Control; // 원래 배경색
            }

            // 새로 선택된 테이블
            selectedTablePanel = sender as Panel;

            if (selectedTablePanel != null)
            {
                selectedTablePanel.Padding = new Padding(4); // 테두리 두께
                selectedTablePanel.BackColor = Color.Blue;    // 테두리 색 (배경으로 표현)

                lableSelectedTableName.Text = selectedTablePanel.Name; // 선택된 테이블 이름 표시
                //selectedTablePanel의 리스트를 가져와서 ListBoxSelected에 넣기
                var listBox = selectedTablePanel.Controls.OfType<ListBox>().FirstOrDefault();
                if (listBox != null)
                {
                    ListBoxSelected.Items.Clear();
                    foreach (var item in listBox.Items)
                    {
                        ListBoxSelected.Items.Add(item);
                    }
                }






            }

            Console.WriteLine("선택된 테이블: " + selectedTablePanel?.Name);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (selectedTablePanel == null)
            {
                MessageBox.Show("테이블을 먼저 선택하세요.");
                return;
            }

            using (var form = new ProductListForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var item = form.SelectedItem;
                    if (item != null)
                    {
                        var listBox = selectedTablePanel.Controls.OfType<ListBox>().FirstOrDefault();
                        if (listBox != null)
                        {
                            listBox.Items.Add(item.ToString());

                        }
                    }
                }
            }
        }
    }
}
