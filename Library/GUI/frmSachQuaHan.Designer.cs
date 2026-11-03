
namespace Library
{
    partial class frmSachQuaHan
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTongSo;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvQuaHan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.dgvQuaHan = new Guna.UI2.WinForms.Guna2DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvQuaHan)).BeginInit();

            this.SuspendLayout();

            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI", 17F, System.Drawing.FontStyle.Bold);

            this.lblTieuDe.ForeColor =
                System.Drawing.Color.FromArgb(40, 40, 60);

            this.lblTieuDe.Location = new System.Drawing.Point(25, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "DANH SÁCH SÁCH QUÁ HẠN";

            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Font = new System.Drawing.Font(
                "Segoe UI", 10F);

            this.lblTongSo.ForeColor =
                System.Drawing.Color.FromArgb(220, 53, 69);

            this.lblTongSo.Location = new System.Drawing.Point(28, 70);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Text = "Đang tải dữ liệu...";

            this.btnLamMoi.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Right;

            this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.FillColor =
                System.Drawing.Color.FromArgb(100, 88, 255);

            this.btnLamMoi.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(1080, 28);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 38);
            this.btnLamMoi.Text = "Làm mới";

            this.btnLamMoi.Click += new System.EventHandler(
                this.btnLamMoi_Click);

            this.dgvQuaHan.AllowUserToAddRows = false;
            this.dgvQuaHan.AllowUserToDeleteRows = false;

            this.dgvQuaHan.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.dgvQuaHan.AutoGenerateColumns = true;

            this.dgvQuaHan.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvQuaHan.BackgroundColor = System.Drawing.Color.White;

            this.dgvQuaHan.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            this.dgvQuaHan.ColumnHeadersHeight = 45;

            this.dgvQuaHan.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;

            this.dgvQuaHan.Location = new System.Drawing.Point(25, 115);
            this.dgvQuaHan.MultiSelect = false;
            this.dgvQuaHan.Name = "dgvQuaHan";
            this.dgvQuaHan.ReadOnly = true;
            this.dgvQuaHan.RowHeadersVisible = false;
            this.dgvQuaHan.RowTemplate.Height = 42;

            this.dgvQuaHan.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvQuaHan.Size = new System.Drawing.Size(1174, 480);

            this.dgvQuaHan.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvQuaHan_CellContentClick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(248, 249, 252);

            this.ClientSize = new System.Drawing.Size(1224, 611);

            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblTongSo);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvQuaHan);

            this.MinimumSize = new System.Drawing.Size(950, 500);
            this.Name = "frmSachQuaHan";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "Danh sách sách quá hạn";

            this.Load += new System.EventHandler(
                this.frmSachQuaHan_Load);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvQuaHan)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
