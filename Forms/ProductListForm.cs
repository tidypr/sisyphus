using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using sisyphus.Models;
using sisyphus.Services;

namespace sisyphus
{
    public partial class ProductListForm : Form
    {
        private FlowLayoutPanel flowLayoutPanel1;
        private Item selectedItem;
        private Panel lastSelectedCard;

        public Item SelectedItem => selectedItem;

        public ProductListForm()
        {
            InitializeFlowLayout();
            LoadItems();
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
            Panel panelButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50
            };

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

        private void LoadItems()
        {
            List<Item> items = ItemService.GetAllItems();

            foreach (var item in items)
            {
                flowLayoutPanel1.Controls.Add(CreateCard(item));
            }
        }

        private Control CreateCard(Item item)
        {
            Panel card = new Panel
            {
                Size = new Size(160, 240),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.None,
                Tag = item,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Padding = new Padding(5)
            };

            // 모서리 둥글게 (패널)
            card.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(card.BackColor))
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, 20, 20, 180, 90);
                    path.AddArc(card.Width - 20, 0, 20, 20, 270, 90);
                    path.AddArc(card.Width - 20, card.Height - 20, 20, 20, 0, 90);
                    path.AddArc(0, card.Height - 20, 20, 20, 90, 90);
                    path.CloseAllFigures();
                    g.FillPath(brush, path);
                    card.Region = new Region(path);
                }
            };

            PictureBox pic = new PictureBox
            {
                Size = new Size(140, 100),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None
            };

            try
            {
                if (!string.IsNullOrEmpty(item.ImageUrl))
                {
                    if (item.ImageUrl.StartsWith("http"))
                    {
                        using (var client = new System.Net.WebClient())
                        {
                            byte[] data = client.DownloadData(item.ImageUrl);
                            using (var ms = new MemoryStream(data))
                            {
                                pic.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    else
                    {
                        string imagePath = Path.Combine(Application.StartupPath, "img", item.ImageUrl);
                        if (File.Exists(imagePath))
                        {
                            pic.Image = Image.FromFile(imagePath);
                        }
                        else
                        {
                            Debug.WriteLine("이미지 파일이 존재하지 않습니다: " + imagePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"이미지 로드 실패: {ex.Message}");
            }

            Label lblName = new Label
            {
                Text = item.Name,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(140, 25),
                Location = new Point(10, 115),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };

            Label lblQuantity = new Label
            {
                Text = $"수량: {item.Quantity}",
                TextAlign = ContentAlignment.MiddleLeft,
                Size = new Size(140, 20),
                Location = new Point(10, 145),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DimGray,
                BackColor = Color.Transparent
            };

            Label lblPrice = new Label
            {
                Text = $"가격: {item.Price:N0}원",
                TextAlign = ContentAlignment.MiddleLeft,
                Size = new Size(140, 20),
                Location = new Point(10, 170),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DarkGreen,
                BackColor = Color.Transparent
            };

            void SelectCard()
            {
                if (lastSelectedCard != null)
                {
                    lastSelectedCard.BackColor = Color.White;
                }
                card.BackColor = Color.LightBlue;
                lastSelectedCard = card;
                selectedItem = item;
            }

            card.Click += (s, e) => SelectCard();
            lblName.Click += (s, e) => SelectCard();
            lblQuantity.Click += (s, e) => SelectCard();
            lblPrice.Click += (s, e) => SelectCard();
            pic.Click += (s, e) => SelectCard();

            card.Controls.Add(pic);
            card.Controls.Add(lblName);
            card.Controls.Add(lblQuantity);
            card.Controls.Add(lblPrice);

            return card;
        }

    }
}
