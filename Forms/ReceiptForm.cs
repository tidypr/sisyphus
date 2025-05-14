using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using sisyphus.Models;

namespace sisyphus
{
    public partial class ReceiptForm : Form
    {
        private List<Item> items;

        public ReceiptForm(List<Item> items)
        {
            InitializeComponent();
            this.items = items;
            DesignReceipt();
        }

        private void DesignReceipt()
        {
            this.Text = "Receipt";
            this.Size = new Size(400, Screen.PrimaryScreen.WorkingArea.Height);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 5,
                ColumnCount = 1,
                RowStyles = {
                        new RowStyle(SizeType.Absolute, 50),
                        new RowStyle(SizeType.Percent, 100),
                        new RowStyle(SizeType.Absolute, 30),
                        new RowStyle(SizeType.Absolute, 40),
                        new RowStyle(SizeType.Absolute, 40)
                    }
            };
            this.Controls.Add(layout);

            var titleLabel = new Label
            {
                Text = "Receipt",
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            layout.Controls.Add(titleLabel, 0, 0);

            var itemList = new ListBox
            {
                Font = new Font("Consolas", 14),
                Dock = DockStyle.Fill
            };

            foreach (var item in items)
            {
                itemList.Items.Add($"{item.Name} x{item.Quantity}   ${item.Price * item.Quantity:F2}");
            }

            layout.Controls.Add(itemList, 0, 1);

            var totalLabel = new Label
            {
                Text = $"Total: {CalculateTotal()}",
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill
            };
            layout.Controls.Add(totalLabel, 0, 2);

            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft
            };

            var confirmButton = new Button
            {
                Text = "Confirm",
                Font = new Font("Arial", 10),
                AutoSize = true
            };
            confirmButton.Click += ConfirmButton_Click;

            var cancelButton = new Button
            {
                Text = "Cancel",
                Font = new Font("Arial", 10),
                AutoSize = true
            };
            cancelButton.Click += CancelButton_Click;

            buttonPanel.Controls.Add(confirmButton);
            buttonPanel.Controls.Add(cancelButton);
            layout.Controls.Add(buttonPanel, 0, 3);
        }

        private string CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.Price * item.Quantity;
            }
            return $"${total:F2}";
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Receipt confirmed.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Receipt canceled.", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }
    }
}
