
using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Library
{
    partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel pnlLoc;
        private Guna2Panel pnlThongKe;
        private Guna2Panel pnlBieuDo;
        private Guna2Panel pnlDanhSach;

        private Guna2DateTimePicker dtpTuNgay;
        private Guna2DateTimePicker dtpDenNgay;
        private Guna2ComboBox cboLoaiBaoCao;

        private Guna2Button btnThongKe;
        private Guna2Button btnLamMoi;
        private Guna2Button btnXuatExcel;

        private Guna2DataGridView dgvBaoCao;
        private Chart chartMuonSach;

        private Label lblTongSach;
        private Label lblTongDocGia;
        private Label lblTongPhieuMuon;
        private Label lblSachDangMuon;
        private Label lblPhieuSapHan;
        private Label lblPhieuQuaHan;
        private Label lblSoDong;

        private Guna2Panel[] danhSachCard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            pnlLoc = new Guna2Panel();
            pnlThongKe = new Guna2Panel();
            pnlBieuDo = new Guna2Panel();
            pnlDanhSach = new Guna2Panel();

            dtpTuNgay = new Guna2DateTimePicker();
            dtpDenNgay = new Guna2DateTimePicker();
            cboLoaiBaoCao = new Guna2ComboBox();

            btnThongKe = new Guna2Button();
            btnLamMoi = new Guna2Button();
            btnXuatExcel = new Guna2Button();

            dgvBaoCao = new Guna2DataGridView();
            chartMuonSach = new Chart();

            lblTongSach = new Label();
            lblTongDocGia = new Label();
            lblTongPhieuMuon = new Label();
            lblSachDangMuon = new Label();
            lblPhieuSapHan = new Label();
            lblPhieuQuaHan = new Label();
            lblSoDong = new Label();

            SuspendLayout();

            Color xanh = Color.FromArgb(29, 67, 120);
            Color xanhSang = Color.FromArgb(37, 99, 235);
            Color nen = Color.FromArgb(245, 247, 251);

            Name = "frmBaoCao";
            Text = "Báo cáo - Thống kê";
            BackColor = nen;
            ClientSize = new Size(1100, 850);
            MinimumSize = new Size(650, 500);
            AutoScroll = true;
            Font = new Font("Segoe UI", 10F);

            pnlLoc.Location = new Point(15, 15);
            pnlLoc.Size = new Size(1050, 100);
            pnlLoc.FillColor = Color.White;
            pnlLoc.BorderRadius = 12;
            pnlLoc.BorderThickness = 0;
            pnlLoc.CustomBorderThickness = new Padding(0);
            pnlLoc.ShadowDecoration.Enabled = false;

            TaoNhan(pnlLoc, "Từ ngày", 20, 12);
            TaoNhan(pnlLoc, "Đến ngày", 225, 12);
            TaoNhan(pnlLoc, "Loại báo cáo", 430, 12);

            dtpTuNgay.Location = new Point(20, 43);
            dtpTuNgay.Size = new Size(185, 38);
            dtpTuNgay.BorderRadius = 7;
            dtpTuNgay.FillColor = Color.FromArgb(240, 245, 252);
            dtpTuNgay.ForeColor = xanh;
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";

            dtpDenNgay.Location = new Point(225, 43);
            dtpDenNgay.Size = new Size(185, 38);
            dtpDenNgay.BorderRadius = 7;
            dtpDenNgay.FillColor = Color.FromArgb(240, 245, 252);
            dtpDenNgay.ForeColor = xanh;
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            cboLoaiBaoCao.Location = new Point(430, 43);
            cboLoaiBaoCao.Size = new Size(175, 38);
            cboLoaiBaoCao.BorderRadius = 7;
            cboLoaiBaoCao.BorderThickness = 0;
            cboLoaiBaoCao.FillColor = Color.FromArgb(240, 245, 252);

            cboLoaiBaoCao.Items.AddRange(new object[]
            {
                "Tất cả phiếu",
                "Sắp đến hạn",
                "Đã quá hạn"
            });

            TaoNut(
                btnThongKe,
                "Thống kê",
                620,
                xanhSang,
                100);

            TaoNut(
                btnLamMoi,
                "Làm mới",
                730,
                Color.FromArgb(100, 116, 139),
                100);

            TaoNut(
                btnXuatExcel,
                "Xuất Excel",
                840,
                Color.FromArgb(22, 163, 74),
                140);

            pnlLoc.Controls.Add(dtpTuNgay);
            pnlLoc.Controls.Add(dtpDenNgay);
            pnlLoc.Controls.Add(cboLoaiBaoCao);
            pnlLoc.Controls.Add(btnThongKe);
            pnlLoc.Controls.Add(btnLamMoi);
            pnlLoc.Controls.Add(btnXuatExcel);

            pnlThongKe.Location = new Point(15, 130);
            pnlThongKe.Size = new Size(1050, 210);
            pnlThongKe.FillColor = nen;
            pnlThongKe.BorderThickness = 0;
            pnlThongKe.CustomBorderThickness = new Padding(0);

            Guna2Panel card1 = TaoCard(
                pnlThongKe,
                "TỔNG SỐ SÁCH",
                lblTongSach,
                0,
                0,
                xanhSang);

            Guna2Panel card2 = TaoCard(
                pnlThongKe,
                "TỔNG ĐỘC GIẢ",
                lblTongDocGia,
                340,
                0,
                xanhSang);

            Guna2Panel card3 = TaoCard(
                pnlThongKe,
                "TỔNG PHIẾU MƯỢN",
                lblTongPhieuMuon,
                680,
                0,
                xanhSang);

            Guna2Panel card4 = TaoCard(
                pnlThongKe,
                "SÁCH ĐANG MƯỢN",
                lblSachDangMuon,
                0,
                110,
                Color.FromArgb(14, 165, 233));

            Guna2Panel card5 = TaoCard(
                pnlThongKe,
                "PHIẾU SẮP ĐẾN HẠN",
                lblPhieuSapHan,
                340,
                110,
                Color.FromArgb(217, 119, 6));

            Guna2Panel card6 = TaoCard(
                pnlThongKe,
                "PHIẾU QUÁ HẠN",
                lblPhieuQuaHan,
                680,
                110,
                Color.FromArgb(220, 38, 38));

            danhSachCard = new Guna2Panel[]
            {
                card1, card2, card3,
                card4, card5, card6
            };

            pnlBieuDo.Location = new Point(15, 355);
            pnlBieuDo.Size = new Size(1050, 300);
            pnlBieuDo.FillColor = Color.White;
            pnlBieuDo.BorderRadius = 12;
            pnlBieuDo.BorderThickness = 0;
            pnlBieuDo.CustomBorderThickness = new Padding(0);
            pnlBieuDo.ShadowDecoration.Enabled = false;

            TaoNhan(
                pnlBieuDo,
                "BIỂU ĐỒ PHIẾU MƯỢN THEO THÁNG",
                20,
                12,
                true);

            chartMuonSach.Location = new Point(20, 45);
            chartMuonSach.Size = new Size(1010, 240);
            chartMuonSach.BackColor = Color.White;
            chartMuonSach.BorderlineWidth = 0;
            chartMuonSach.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            pnlBieuDo.Controls.Add(chartMuonSach);

            pnlDanhSach.Location = new Point(15, 670);
            pnlDanhSach.Size = new Size(1050, 365);
            pnlDanhSach.FillColor = Color.White;
            pnlDanhSach.BorderRadius = 12;
            pnlDanhSach.BorderThickness = 0;
            pnlDanhSach.CustomBorderThickness = new Padding(0);
            pnlDanhSach.ShadowDecoration.Enabled = false;

            TaoNhan(
                pnlDanhSach,
                "DANH SÁCH PHIẾU MƯỢN CẦN THEO DÕI",
                20,
                12,
                true);

            lblSoDong.Text = "Tổng cộng: 0 phiếu";
            lblSoDong.ForeColor =
                Color.FromArgb(100, 116, 139);
            lblSoDong.BackColor = Color.Transparent;
            lblSoDong.Location = new Point(800, 15);
            lblSoDong.Size = new Size(220, 25);
            lblSoDong.TextAlign = ContentAlignment.MiddleRight;
            lblSoDong.Anchor =
                AnchorStyles.Top | AnchorStyles.Right;

            dgvBaoCao.Location = new Point(20, 50);
            dgvBaoCao.Size = new Size(1010, 295);
            dgvBaoCao.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvBaoCao.BorderStyle = BorderStyle.None;
            dgvBaoCao.BackgroundColor = Color.White;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvBaoCao.ColumnHeadersDefaultCellStyle.BackColor = xanh;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            dgvBaoCao.ColumnHeadersHeight = 40;
            dgvBaoCao.RowTemplate.Height = 35;

            dgvBaoCao.CellBorderStyle =
                DataGridViewCellBorderStyle.None;

            dgvBaoCao.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvBaoCao.GridColor = Color.FromArgb(240, 243, 248);

            pnlDanhSach.Controls.Add(lblSoDong);
            pnlDanhSach.Controls.Add(dgvBaoCao);

            Controls.Add(pnlLoc);
            Controls.Add(pnlThongKe);
            Controls.Add(pnlBieuDo);
            Controls.Add(pnlDanhSach);

            Resize += frmBaoCao_ResizeGiaoDien;
            Shown += frmBaoCao_ShownGiaoDien;

            ResumeLayout(false);
        }

        private void frmBaoCao_ShownGiaoDien(
            object sender,
            EventArgs e)
        {
            CanChinhGiaoDien();
        }

        private void frmBaoCao_ResizeGiaoDien(
            object sender,
            EventArgs e)
        {
            CanChinhGiaoDien();
        }


        private void CanChinhGiaoDien()
        {
            if (pnlLoc == null ||
                pnlThongKe == null ||
                pnlBieuDo == null ||
                pnlDanhSach == null ||
                danhSachCard == null)
                return;

            SuspendLayout();

            int margin = 15;
            int gap = 15;
            int width = Math.Max(620, ClientSize.Width - margin * 2);

            pnlLoc.Location = new Point(margin, margin);
            pnlLoc.Width = width;

            dtpTuNgay.Location = new Point(20, 43);
            dtpDenNgay.Location = new Point(225, 43);
            cboLoaiBaoCao.Location = new Point(430, 43);

            if (width >= 1050)
            {
                pnlLoc.Height = 100;

                btnThongKe.Location =
                    new Point(width - 375, 43);

                btnLamMoi.Location =
                    new Point(width - 265, 43);

                btnXuatExcel.Location =
                    new Point(width - 155, 43);
            }
            else
            {
                pnlLoc.Height = 155;

                int khoangCach = 12;

                int tongRong =
                    btnThongKe.Width +
                    btnLamMoi.Width +
                    btnXuatExcel.Width +
                    khoangCach * 2;

                int x = Math.Max(20, (width - tongRong) / 2);

                btnThongKe.Location = new Point(x, 100);

                btnLamMoi.Location = new Point(
                    btnThongKe.Right + khoangCach, 100);

                btnXuatExcel.Location = new Point(
                    btnLamMoi.Right + khoangCach, 100);
            }

            pnlThongKe.Location =
                new Point(margin, pnlLoc.Bottom + gap);

            pnlThongKe.Width = width;
            pnlThongKe.Height = 210;

            int cardGap = 18;
            int cardWidth = (width - cardGap * 2) / 3;

            for (int i = 0; i < danhSachCard.Length; i++)
            {
                int cot = i % 3;
                int hang = i / 3;

                danhSachCard[i].Location = new Point(
                    cot * (cardWidth + cardGap),
                    hang * 110);

                danhSachCard[i].Size =
                    new Size(cardWidth, 95);
            }

            pnlBieuDo.Location =
                new Point(margin, pnlThongKe.Bottom + gap);

            pnlBieuDo.Width = width;
            pnlBieuDo.Height = 300;

            chartMuonSach.Location = new Point(20, 45);
            chartMuonSach.Size =
                new Size(width - 40, 240);

            pnlDanhSach.Location =
                new Point(margin, pnlBieuDo.Bottom + gap);

            pnlDanhSach.Width = width;

            int soDong = dgvBaoCao.Rows.Count;

            int chieuCaoBang = Math.Max(
                295,
                Math.Min(650, 45 + soDong * 35));

            pnlDanhSach.Height = chieuCaoBang + 70;

            dgvBaoCao.Location = new Point(20, 50);
            dgvBaoCao.Size =
                new Size(width - 40, chieuCaoBang);

            lblSoDong.Location = new Point(
                Math.Max(20, width - lblSoDong.Width - 20),
                15);

            AutoScrollMinSize = new Size(
                0,
                pnlDanhSach.Bottom + 20);

            ResumeLayout(true);
        }


        private void TaoNhan(
            Control parent,
            string text,
            int x,
            int y,
            bool dam = false)
        {
            Label lbl = new Label();

            lbl.Text = text;
            lbl.Font = new Font(
                "Segoe UI",
                dam ? 10F : 9F,
                dam ? FontStyle.Bold : FontStyle.Regular);

            lbl.ForeColor = Color.FromArgb(29, 67, 120);
            lbl.BackColor = Color.Transparent;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(420, 25);

            parent.Controls.Add(lbl);
        }

        private void TaoNut(
            Guna2Button btn,
            string text,
            int x,
            Color mau,
            int width)
        {
            btn.Text = text;
            btn.Location = new Point(x, 43);
            btn.Size = new Size(width, 38);

            btn.BorderRadius = 7;
            btn.BorderThickness = 0;
            btn.BorderColor = Color.Transparent;
            btn.CustomBorderThickness = new Padding(0);
            btn.CustomBorderColor = Color.Transparent;

            btn.FillColor = mau;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9F);
            btn.Cursor = Cursors.Hand;

            btn.HoverState.BorderColor = Color.Transparent;
            btn.CheckedState.BorderColor = Color.Transparent;
            btn.DisabledState.BorderColor = Color.Transparent;

            btn.ShadowDecoration.Enabled = false;
            btn.FocusedColor = Color.Transparent;
        }

        private Guna2Panel TaoCard(
            Control parent,
            string tieuDe,
            Label giaTri,
            int x,
            int y,
            Color mau)
        {
            Guna2Panel card = new Guna2Panel();

            card.Location = new Point(x, y);
            card.Size = new Size(320, 95);
            card.FillColor = Color.White;
            card.BorderRadius = 12;
            card.BorderThickness = 0;
            card.BorderColor = Color.Transparent;
            card.CustomBorderThickness = new Padding(0);
            card.CustomBorderColor = Color.Transparent;
            card.ShadowDecoration.Enabled = false;

            Label lbl = new Label();

            lbl.Text = tieuDe;
            lbl.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Bold);

            lbl.ForeColor =
                Color.FromArgb(100, 116, 139);

            lbl.BackColor = Color.Transparent;
            lbl.Location = new Point(18, 12);
            lbl.Size = new Size(280, 24);
            lbl.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            giaTri.Text = "--";
            giaTri.Font = new Font(
                "Segoe UI",
                22F,
                FontStyle.Bold);

            giaTri.ForeColor = mau;
            giaTri.BackColor = Color.Transparent;
            giaTri.Location = new Point(18, 38);
            giaTri.Size = new Size(280, 45);
            giaTri.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            card.Controls.Add(lbl);
            card.Controls.Add(giaTri);

            parent.Controls.Add(card);

            return card;
        }
    }
}
