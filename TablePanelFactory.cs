using sisyphus;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Linq;


public static class TablePanelFactory
{
    // Fix for CS0708: Convert btnAddItem_Click to a static method
    private static void BtnAddItem_Click(object sender, EventArgs e, Panel selectedTablePanel)
    {
        if (selectedTablePanel == null) // Fix for CS0103: Pass selectedTablePanel as a parameter
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

    public static Panel CreateTable(Table tableData)
    {
        Panel panel = new Panel
        {
            BorderStyle = BorderStyle.FixedSingle,
            Size = new Size(240, 360),
            Margin = new Padding(10),
            Name = tableData.Name,
            BackColor = SystemColors.Control
        };

        Label topLabel = new Label
        {
            Text = tableData.Name,
            Dock = DockStyle.Top,
            TextAlign = ContentAlignment.MiddleCenter,
            Height = 30,
            BackColor = Color.LightGray
        };

        ListBox listBox = new ListBox
        {
            Dock = DockStyle.Fill
        };

        foreach (var item in tableData.Items)
        {
            int total = item.Price * item.Quantity;
            string name = item.Name.PadRight(8);
            string qty = item.Quantity.ToString().PadLeft(2);
            string price = total.ToString().PadLeft(6);
            listBox.Items.Add($"{name} x {qty} = {price}원");
        }

        Label bottomLabel = new Label
        {
            Text = $"총액: {tableData.GetTotalPrice()}원",
            Dock = DockStyle.Bottom,
            Height = 30,
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.LightYellow
        };

        bottomLabel.Text = $"총액: {tableData.Items.Sum(i => i.Price * i.Quantity)}원";

        Panel buttonPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 40,
            BackColor = SystemColors.Control
        };

        Button addButton = new Button
        {
            Text = "추가",
            Dock = DockStyle.Left,
            Width = 90
        };

        Button payButton = new Button
        {
            Text = "결제",
            Dock = DockStyle.Right,
            Width = 90
        };

        // Attach the static BtnAddItem_Click method to the addButton's Click event
        addButton.Click += (sender, e) => BtnAddItem_Click(sender, e, panel);

        buttonPanel.Controls.Add(addButton);
        buttonPanel.Controls.Add(payButton);

        panel.Controls.Add(listBox);
        panel.Controls.Add(buttonPanel);
        panel.Controls.Add(bottomLabel);
        panel.Controls.Add(topLabel);

        return panel;
    }
}
