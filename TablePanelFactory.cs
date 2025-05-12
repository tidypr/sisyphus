using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace sisyphus
{
    public class TablePanelFactory
    {
        public static Panel CreateTable(string title, EventHandler onClick)
        {
            Panel panel = new Panel
            {

                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(150, 250),
                Margin = new Padding(10, 50, 0, 0),
                Name = title,
                BackColor = SystemColors.Control
            };

            Label topLabel = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 30,
                BackColor = Color.LightGray
            };

            ListBox listBox = new ListBox
            {
                Dock = DockStyle.Fill
            };

            Label bottomLabel = new Label
            {
                Text = "총액: 0",
                Dock = DockStyle.Bottom,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightYellow
            };

            // 모든 컨트롤에 이벤트 연결, 이벤트 위임 - 항상 Panel을 sender로 전달
            topLabel.Click += (s, e) => onClick(panel, e);
            listBox.Click += (s, e) => onClick(panel, e);
            bottomLabel.Click += (s, e) => onClick(panel, e);
            panel.Click += onClick;

            panel.Controls.Add(listBox);
            panel.Controls.Add(bottomLabel);
            panel.Controls.Add(topLabel);

            return panel;
        }
    }

}
