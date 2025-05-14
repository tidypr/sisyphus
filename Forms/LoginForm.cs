using System;
using System.Drawing;
using System.Windows.Forms;
using sisyphus.Services;  // AuthService 사용

namespace sisyphus
{
    public partial class LoginForm : Form
    {

        private Button btnRegister;
        private Panel imagePanel;

        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Login";
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height / 3);
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Controls.Clear();

            int imagePanelWidth = this.Width * 2 / 3;
            int formPadding = 30;

            // 이미지 패널 (왼쪽 2/3)
            imagePanel = new Panel
            {
                Size = new Size(imagePanelWidth, this.Height),
                Location = new Point(0, 0)
            };
            try
            {
                string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, "..", "..", "mainImg.png"));
                imagePanel.BackgroundImage = System.IO.File.Exists(path) ? Image.FromFile(path) : null;
                imagePanel.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch { imagePanel.BackColor = Color.Gray; }

            // 오른쪽 1/3 영역 시작 좌표
            int inputAreaX = imagePanel.Right + formPadding;
            int inputWidth = this.Width - inputAreaX - formPadding;
            int currentY = 30;

            // 타이틀 라벨
            Label titleLabel = new Label
            {
                Text = "SISYPOS",
                Font = new Font("Arial", 20, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(inputAreaX, currentY),
                Size = new Size(inputWidth, 50)
            };
            currentY = titleLabel.Bottom + 20;  // 타이틀 아래 여백

            // ID 입력
            txtID = new TextBox
            {
                Location = new Point(inputAreaX, currentY),
                Width = inputWidth
            };
            currentY = txtID.Bottom + 10;

            // PW 입력
            txtPW = new TextBox
            {
                Location = new Point(inputAreaX, currentY),
                Width = inputWidth,
                UseSystemPasswordChar = true
            };
            currentY = txtPW.Bottom + 15;

            // 로그인 버튼
            btnLogin = new Button
            {
                Text = "로그인",
                Location = new Point(inputAreaX, currentY),
                Width = inputWidth
            };
            btnLogin.Click += BtnLogin_Click;
            currentY = btnLogin.Bottom + 10;

            // 회원가입 버튼
            btnRegister = new Button
            {
                Text = "회원가입",
                Location = new Point(inputAreaX, currentY),
                Width = inputWidth
            };
            btnRegister.Click += BtnRegister_Click;

            // 컨트롤 추가
            this.Controls.Add(imagePanel);
            this.Controls.Add(titleLabel);
            this.Controls.Add(txtID);
            this.Controls.Add(txtPW);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnRegister);
        }



        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtPW.Text))
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요.");
                return;
            }

            if (AuthService.Login(txtID.Text.Trim(), txtPW.Text.Trim()))
            {
                new MainForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 잘못되었습니다.");
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtPW.Text))
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요.");
                return;
            }

            if (AuthService.Register(txtID.Text.Trim(), txtPW.Text.Trim()))
            {
                MessageBox.Show("회원가입이 완료되었습니다.");
            }
            else
            {
                MessageBox.Show("회원가입에 실패했습니다.");
            }
        }
    }
}
