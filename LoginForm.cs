using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sisyphus
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // 화면 크기 가져오기
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // 화면의 2/3 크기 계산
            int formWidth = (int)(screenWidth * 2 / 3);
            int formHeight = (int)(screenHeight * 2 / 3);

            // 폼 크기 설정
            this.Size = new Size(formWidth, formHeight);

            // 화면 중앙에 배치
            this.StartPosition = FormStartPosition.CenterScreen;

            // 이미지 로드
            string imagePath = "C:\\Users\\tidyp\\Downloads\\mainImg.png";
            LeftLoginPanel.BackgroundImage = Image.FromFile(imagePath);
            LeftLoginPanel.BackgroundImageLayout = ImageLayout.Stretch;

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtID.Text.Trim();
            string password = txtPW.Text.Trim();

            // TODO: 로그인 처리 로직 추가

            Console.WriteLine($"ID: {id}, Password: {password}");

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요.");
                return;
            }


            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Hide();
        }
    }
}
