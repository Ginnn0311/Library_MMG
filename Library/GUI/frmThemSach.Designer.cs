
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Library
{
    partial class frmThemSach
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtMaSach = new Guna2TextBox();
            cboTheLoai = new Guna2ComboBox();
            txtTacGia = new Guna2TextBox();
            txtTenSach = new Guna2TextBox();
            txtNamXB = new Guna2TextBox();
            txtSoLuong = new Guna2TextBox();
            txtNhaXuatBan = new Guna2TextBox();
            btnLuu = new Guna2Button();
            btnHuy = new Guna2Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            pictureBox1 = new PictureBox();
            pnlMain = new Guna2Panel();
            pnlImage = new Guna2Panel();
            pnlForm = new Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();

            // frmThemSach
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 251);
            ClientSize = new Size(780, 490);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThemSach";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin sách";

            // pnlMain
            pnlMain.BackColor = Color.Transparent;
            pnlMain.BorderRadius = 14;
            pnlMain.FillColor = Color.White;
            pnlMain.Location = new Point(15, 15);
            pnlMain.Size = new Size(750, 460);
            pnlMain.Controls.Add(label8);
            pnlMain.Controls.Add(pnlImage);
            pnlMain.Controls.Add(pnlForm);
            Controls.Add(pnlMain);

            // label8
            label8.AutoSize = false;
            label8.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(31, 58, 95);
            label8.Location = new Point(25, 15);
            label8.Size = new Size(700, 40);
            label8.Text = "THÔNG TIN SÁCH";
            label8.TextAlign = ContentAlignment.MiddleLeft;

            // pnlImage
            pnlImage.BackColor = Color.Transparent;
            pnlImage.BorderRadius = 10;
            pnlImage.FillColor = Color.FromArgb(243, 246, 251);
            pnlImage.Location = new Point(25, 75);
            pnlImage.Size = new Size(260, 335);
            pnlImage.Controls.Add(pictureBox1);

            // pictureBox1
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(15, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(230, 305);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;

            // pnlForm
            pnlForm.BackColor = Color.Transparent;
            pnlForm.BorderRadius = 10;
            pnlForm.FillColor = Color.White;
            pnlForm.Location = new Point(305, 70);
            pnlForm.Size = new Size(420, 340);

            // label1 - Mã sách
            SetupLabel(label1, "Mã sách", 0, 12);
            pnlForm.Controls.Add(label1);

            // txtMaSach
            SetupTextBox(txtMaSach, "Nhập mã sách...", 115, 8);
            pnlForm.Controls.Add(txtMaSach);

            // label5 - Tên sách
            SetupLabel(label5, "Tên sách", 0, 60);
            pnlForm.Controls.Add(label5);

            // txtTenSach
            SetupTextBox(txtTenSach, "Nhập tên sách...", 115, 56);
            pnlForm.Controls.Add(txtTenSach);

            // label4 - Tác giả
            SetupLabel(label4, "Tác giả", 0, 108);
            pnlForm.Controls.Add(label4);

            // txtTacGia
            SetupTextBox(txtTacGia, "Nhập tên tác giả...", 115, 104);
            pnlForm.Controls.Add(txtTacGia);

            // label3 - Thể loại
            SetupLabel(label3, "Thể loại", 0, 156);
            pnlForm.Controls.Add(label3);

            // cboTheLoai
            cboTheLoai.BackColor = Color.Transparent;
            cboTheLoai.BorderRadius = 6;
            cboTheLoai.BorderColor = Color.FromArgb(210, 218, 230);
            cboTheLoai.DrawMode = DrawMode.OwnerDrawFixed;
            cboTheLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTheLoai.FocusedColor = Color.FromArgb(35, 120, 210);
            cboTheLoai.Font = new Font("Segoe UI", 9.5F);
            cboTheLoai.ForeColor = Color.FromArgb(45, 55, 72);
            cboTheLoai.ItemHeight = 30;
            cboTheLoai.Location = new Point(115, 152);
            cboTheLoai.Size = new Size(285, 34);
            cboTheLoai.TabIndex = 3;
            pnlForm.Controls.Add(cboTheLoai);

            // label7 - Nhà xuất bản
            SetupLabel(label7, "Nhà xuất bản", 0, 204);
            label7.Size = new Size(105, 25);
            pnlForm.Controls.Add(label7);

            // txtNhaXuatBan
            SetupTextBox(txtNhaXuatBan, "Nhập nhà xuất bản...", 115, 200);
            pnlForm.Controls.Add(txtNhaXuatBan);

            // label2 - Năm xuất bản
            SetupLabel(label2, "Năm xuất bản", 0, 252);
            label2.Size = new Size(105, 25);
            pnlForm.Controls.Add(label2);

            // txtNamXB
            SetupTextBox(txtNamXB, "Nhập năm xuất bản...", 115, 248);
            pnlForm.Controls.Add(txtNamXB);

            // label6 - Số lượng
            SetupLabel(label6, "Số lượng", 0, 300);
            pnlForm.Controls.Add(label6);

            // txtSoLuong
            SetupTextBox(txtSoLuong, "Nhập số lượng...", 115, 296);
            pnlForm.Controls.Add(txtSoLuong);

            // btnLuu
            btnLuu.BorderRadius = 8;
            btnLuu.FillColor = Color.FromArgb(35, 120, 210);
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(420, 420);
            btnLuu.Size = new Size(140, 38);
            btnLuu.Text = "Lưu sách";
            btnLuu.Click += btnLuu_Click;
            pnlMain.Controls.Add(btnLuu);

            // btnHuy
            btnHuy.BorderRadius = 8;
            btnHuy.FillColor = Color.FromArgb(115, 125, 140);
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(575, 420);
            btnHuy.Size = new Size(140, 38);
            btnHuy.Text = "Hủy";
            btnHuy.Click += btnHuy_Click;
            pnlMain.Controls.Add(btnHuy);

            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private void SetupLabel(Label lbl, string text, int x, int y)
        {
            lbl.AutoSize = false;
            lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(50, 65, 85);
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(105, 25);
            lbl.Text = text;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void SetupTextBox(Guna2TextBox txt, string placeholder, int x, int y)
        {
            txt.BorderRadius = 6;
            txt.BorderColor = Color.FromArgb(210, 218, 230);
            txt.FocusedState.BorderColor = Color.FromArgb(35, 120, 210);
            txt.Font = new Font("Segoe UI", 9.5F);
            txt.ForeColor = Color.FromArgb(45, 55, 72);
            txt.PlaceholderText = placeholder;
            txt.Location = new Point(x, y);
            txt.Size = new Size(285, 34);
        }

        private Guna2Panel pnlMain;
        private Guna2Panel pnlImage;
        private Guna2Panel pnlForm;

        private Guna2TextBox txtMaSach;
        private Guna2ComboBox cboTheLoai;
        private Guna2TextBox txtTacGia;
        private Guna2TextBox txtTenSach;
        private Guna2TextBox txtNamXB;
        private Guna2TextBox txtSoLuong;
        private Guna2TextBox txtNhaXuatBan;

        private Guna2Button btnLuu;
        private Guna2Button btnHuy;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;

        private PictureBox pictureBox1;
    }
}
