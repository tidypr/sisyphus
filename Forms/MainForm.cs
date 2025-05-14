using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using sisyphus.Models;
using sisyphus.Services;

namespace sisyphus
{
    public partial class MainForm : Form
    {
        private Panel selectedTablePanel;  // 선택된 테이블 패널

        public MainForm()
        {
            InitializeComponent();
            CreateMainLayout();
        }

        // 공통 클릭 처리 메서드 (MainForm 클래스 안에 위치)
        private void HandleTablePanelClick(Panel clickedPanel, RestaurantTable table, Panel detailsPanel)
        {
            if (selectedTablePanel != null)
            {
                selectedTablePanel.BackColor = Color.LightGray; // 이전 선택된 테이블 색상 복원
            }

            selectedTablePanel = clickedPanel;
            selectedTablePanel.BackColor = Color.Orange; // 새 선택 색상

            ShowTableDetails(table, detailsPanel);
        }


        // 테이블 + 아이템 목록 UI 생성
        private void CreateMainLayout()
        {
            // 기존 내용 제거
            this.displayTablePanel.Controls.Clear();

            // 테이블을 담을 컨테이너 생성 (7:3 비율로 분할)
            FlowLayoutPanel tableContainer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight
            };

            

            // 3분의 1 크기 공간을 만들 패널
            Panel detailsPanel = new Panel
            {
                Width = this.ClientSize.Width * 3 / 10,  // 30%의 폭
                Dock = DockStyle.Right,
                BackColor = Color.LightGray
            };

            this.displayTablePanel.Controls.Add(tableContainer);
            this.displayTablePanel.Controls.Add(detailsPanel);

            // 테이블 목록 가져오기
            List<RestaurantTable> tableList = RestaurantTableService.GetAllTables();

            foreach (var table in tableList)
            {
                // 테이블 패널 생성
                Panel panel = new Panel
                {
                    Width = 200,
                    Height = 200,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.LightGray
                };

                // 테이블 이름 라벨
                Label nameLabel = new Label
                {
                    Text = $"{table.TableName} (ID: {table.TableID})",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    Height = 25,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // 아이템 리스트 박스
                ListBox itemList = new ListBox
                {
                    Height = 100,
                    Dock = DockStyle.Top
                };

                // 테이블에 해당하는 아이템 목록 가져오기
                var items = RestaurantTableService.GetItemsByTableId(table.TableID);
                foreach (var item in items)
                {
                    itemList.Items.Add($"{item.Name} x{item.Quantity} = {item.Price * item.Quantity:C}");
                }

                // 총액 라벨
                Label amountLabel = new Label
                {
                    Text = $"Total: {table.TotalAmount:C}",
                    Dock = DockStyle.Bottom,
                    Height = 25,
                    TextAlign = ContentAlignment.MiddleRight
                };

                // 상태 라벨
                Label statusLabel = new Label
                {
                    Text = $"Status: {table.Status}",
                    Dock = DockStyle.Bottom,
                    Height = 20,
                    TextAlign = ContentAlignment.MiddleLeft
                };

               

                // 이벤트 등록
                itemList.Click += (sender, e) => HandleTablePanelClick(panel, table, detailsPanel);
                panel.Click += (sender, e) => HandleTablePanelClick(panel, table, detailsPanel);


                // 컨트롤을 패널에 추가
                panel.Controls.Add(itemList);
                panel.Controls.Add(nameLabel);
                panel.Controls.Add(amountLabel);
                panel.Controls.Add(statusLabel);

                // 테이블 컨테이너에 패널 추가
                tableContainer.Controls.Add(panel);
            }
        }

        // 테이블 선택 시 상세 정보를 표시하는 메서드
        private void ShowTableDetails(RestaurantTable table, Panel detailsPanel)
        {
            // 기존 내용을 지움
            detailsPanel.Controls.Clear();

            // 테이블 이름 라벨
            Label tableNameLabel = new Label
            {
                Text = $"Table: {table.TableName} (ID: {table.TableID})",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };
            detailsPanel.Controls.Add(tableNameLabel);

            // 상태 라벨
            Label statusLabel = new Label
            {
                Text = $"Status: {table.Status}",
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };
            detailsPanel.Controls.Add(statusLabel);

            // 아이템 목록
            ListBox itemList = new ListBox
            {
                Height = 150,
                Dock = DockStyle.Fill
            };

            // 테이블에 해당하는 아이템 목록 가져오기
            var items = RestaurantTableService.GetItemsByTableId(table.TableID);
            foreach (var item in items)
            {
                itemList.Items.Add($"{item.Name} x{item.Quantity} = {item.Price * item.Quantity:C}");
            }

            detailsPanel.Controls.Add(itemList);

            // 총액 라벨
            Label amountLabel = new Label
            {
                Text = $"Total: {table.TotalAmount:C}",
                Dock = DockStyle.Bottom,
                Height = 30,
                TextAlign = ContentAlignment.MiddleRight
            };
            detailsPanel.Controls.Add(amountLabel);

            // 버튼 패널
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.LightGray // 원하는 배경색
            };

            Button addButton = new Button
            {
                Text = "추가",
                Width = 90,
                Height = 30,
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                Margin = new Padding(5)
            };
            addButton.FlatAppearance.BorderSize = 0;

            Button payButton = new Button
            {
                Text = "결제",
                Width = 90,
                Height = 30,
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                Margin = new Padding(5)
            };
            payButton.FlatAppearance.BorderSize = 0;

            FlowLayoutPanel buttons = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.LightGray,
                FlowDirection = FlowDirection.LeftToRight
            };

            buttons.Controls.Add(addButton);
            buttons.Controls.Add(payButton);

            buttonPanel.Controls.Add(buttons);

            // 버튼 패널을 detailsPanel에 추가
            detailsPanel.Controls.Add(buttonPanel);

            
            // 추가 버튼 클릭 이벤트
            addButton.Click += (sender, e) =>
            {
                // 상품 선택 폼 열기
                ProductListForm productListForm = new ProductListForm();
                if (productListForm.ShowDialog() == DialogResult.OK)
                {
                    // 선택된 상품을 가져옴
                    Item selectedItem = productListForm.SelectedItem;
                    int quantity = 1; // 기본 수량 1, 또는 폼에서 선택하게 할 수 있음

                    // DB에 주문 추가
                    bool success = RestaurantTableService.AddItemToTable(table.TableID, selectedItem.ItemID, quantity, selectedItem.Price);

                    if (success)
                    {
                        Console.WriteLine($"상품 {selectedItem.Name}이(가) 테이블 {table.TableName}에 추가되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("상품 추가에 실패했습니다.");
                    }

                    // UI 갱신
                    this.displayTablePanel.Controls.Clear();
                    CreateMainLayout();
                }
            };

            payButton.Click += (sender, e) =>
            {
                // 결제 처리 로직
                DialogResult result = MessageBox.Show("결제하시겠습니까?", "결제", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // 테이블 데이터 삭제 및 상태 업데이트
                    bool dataDeleted = RestaurantTableService.DeleteTableData(table.TableID);
                    if (dataDeleted)
                    {
                        MessageBox.Show("결제 완료.");
                    }
                    else
                    {
                        MessageBox.Show("결제 처리 중 오류가 발생했습니다.");
                    }

                    // UI 갱신
                    this.displayTablePanel.Controls.Clear();
                    CreateMainLayout();
                }
            };

        }
    }
}
