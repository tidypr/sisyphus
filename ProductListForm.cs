using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace sisyphus
{
    public partial class ProductListForm : Form
    {
        private FlowLayoutPanel flowLayoutPanel1;
        private MenuItem selectedItem;
        public MenuItem SelectedItem => selectedItem;

        public ProductListForm()
        {
            InitializeComponent();
            InitializeFlowLayout();
            LoadDummyData();
            InitializeBottomButton();

            // 화면 크기 기반 폼 크기 설정
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Size = new Size(screenWidth * 2 / 3, screenHeight * 2 / 3);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeFlowLayout()
        {
            flowLayoutPanel1 = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };
            this.Controls.Add(flowLayoutPanel1);
        }

        private void InitializeBottomButton()
        {
            // 버튼들을 담을 Panel 생성
            Panel panelButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50
            };

            // 확인 버튼 추가
            Button btnConfirm = new Button
            {
                Text = "확인",
                Width = 100,
                Height = 40,
                Left = 10,
                Top = 5,
                BackColor = Color.LightGreen
            };
            btnConfirm.Click += BtnConfirm_Click;

            // 취소 버튼 추가
            Button btnCancel = new Button
            {
                Text = "취소",
                Width = 100,
                Height = 40,
                Left = 120,
                Top = 5,
                BackColor = Color.Red
            };
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            panelButtons.Controls.Add(btnConfirm);
            panelButtons.Controls.Add(btnCancel);
            this.Controls.Add(panelButtons);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("상품을 선택하세요.");
            }
        }

        // MenuItem 클래스로 변경
        public class MenuItem
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; } = 1; // 기본 수량 1

            public override string ToString()
            {
                return $"{Name} - {Price:C0} x {Quantity}";
            }
        }

        private void LoadDummyData()
        {
            var items = new List<MenuItem>
            {
                new MenuItem { Name = "Apple", Price = 10000 },
                new MenuItem { Name = "Banana", Price = 2000 },
                new MenuItem { Name = "Carrot", Price = 3000 }
            };

            foreach (var item in items)
            {
                flowLayoutPanel1.Controls.Add(CreateCard(item));
            }
        }

        private Control CreateCard(MenuItem item)
        {
            Panel card = new Panel
            {
                Size = new Size(120, 160),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = item
            };

            Label lbl = new Label
            {
                Text = item.Name,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(100, 30),
                Location = new Point(10, 50)
            };

            // 선택 시 배경색 변경 및 선택된 아이템 저장
            lbl.Click += (s, e) =>
            {
                foreach (Panel c in flowLayoutPanel1.Controls)
                {
                    c.BackColor = SystemColors.Control;
                }
                card.BackColor = Color.LightBlue;
                selectedItem = item;
            };
            card.Click += (s, e) =>
            {
                foreach (Panel c in flowLayoutPanel1.Controls)
                {
                    c.BackColor = SystemColors.Control;
                }
                card.BackColor = Color.LightBlue;
                selectedItem = item;
            };

            card.Controls.Add(lbl);

            return card;
        }
    }
}
