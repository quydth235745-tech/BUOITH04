namespace QuanLyBanHang
{
    partial class frmHoaDon_ChiTiet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            txtGhiChuHoaDon = new TextBox();
            label2 = new Label();
            cboNhanVien = new ComboBox();
            label1 = new Label();
            cboKhachHang = new ComboBox();
            label6 = new Label();
            groupBox2 = new GroupBox();
            btnXoa = new Button();
            btnXacNhanBan = new Button();
            cboSanPham = new ComboBox();
            label4 = new Label();
            numDonGia = new NumericUpDown();
            numSoLuong = new NumericUpDown();
            label3 = new Label();
            label5 = new Label();
            dataGridView = new DataGridView();
            SanPhamID = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            DonGiaBan = new DataGridViewTextBoxColumn();
            SoLuongBan = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            btnInHoaDon = new Button();
            btnLuuHoaDon = new Button();
            btnThoat = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtGhiChuHoaDon);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboNhanVien);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cboKhachHang);
            groupBox1.Controls.Add(label6);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1188, 160);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hóa đơn";
            // 
            // txtGhiChuHoaDon
            // 
            txtGhiChuHoaDon.Font = new Font("Times New Roman", 12F);
            txtGhiChuHoaDon.Location = new Point(194, 92);
            txtGhiChuHoaDon.Multiline = true;
            txtGhiChuHoaDon.Name = "txtGhiChuHoaDon";
            txtGhiChuHoaDon.Size = new Size(948, 34);
            txtGhiChuHoaDon.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F);
            label2.Location = new Point(30, 95);
            label2.Name = "label2";
            label2.Size = new Size(146, 22);
            label2.TabIndex = 25;
            label2.Text = "Ghi chú hóa đơn:";
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(194, 40);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(326, 28);
            cboNhanVien.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F);
            label1.Location = new Point(30, 42);
            label1.Name = "label1";
            label1.Size = new Size(126, 22);
            label1.TabIndex = 23;
            label1.Text = "Nhân Viên (*):";
            // 
            // cboKhachHang
            // 
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(770, 40);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(372, 28);
            cboKhachHang.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F);
            label6.Location = new Point(611, 42);
            label6.Name = "label6";
            label6.Size = new Size(140, 22);
            label6.TabIndex = 21;
            label6.Text = "Khách Hàng (*):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnXacNhanBan);
            groupBox2.Controls.Add(cboSanPham);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(numDonGia);
            groupBox2.Controls.Add(numSoLuong);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label5);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 160);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1188, 125);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin chi tiết hóa đơn";
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(1043, 71);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(77, 38);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnXacNhanBan
            // 
            btnXacNhanBan.Location = new Point(875, 69);
            btnXacNhanBan.Name = "btnXacNhanBan";
            btnXacNhanBan.Size = new Size(147, 40);
            btnXacNhanBan.TabIndex = 35;
            btnXacNhanBan.Text = "Xác nhận bán";
            btnXacNhanBan.UseVisualStyleBackColor = true;
            btnXacNhanBan.Click += btnXacNhanBan_Click;
            // 
            // cboSanPham
            // 
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(25, 77);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(308, 28);
            cboSanPham.TabIndex = 34;
            cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F);
            label4.Location = new Point(25, 37);
            label4.Name = "label4";
            label4.Size = new Size(121, 22);
            label4.TabIndex = 33;
            label4.Text = "Sản Phẩm (*):";
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(381, 77);
            numDonGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(216, 27);
            numDonGia.TabIndex = 32;
            numDonGia.ThousandsSeparator = true;
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(626, 78);
            numSoLuong.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(214, 27);
            numSoLuong.TabIndex = 31;
            numSoLuong.ThousandsSeparator = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F);
            label3.Location = new Point(381, 37);
            label3.Name = "label3";
            label3.Size = new Size(107, 22);
            label3.TabIndex = 30;
            label3.Text = "Đơn giá (*):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F);
            label5.Location = new Point(624, 37);
            label5.Name = "label5";
            label5.Size = new Size(116, 22);
            label5.TabIndex = 29;
            label5.Text = "Số lượng (*):";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { SanPhamID, TenSanPham, DonGiaBan, SoLuongBan, ThanhTien });
            dataGridView.Dock = DockStyle.Top;
            dataGridView.Location = new Point(0, 285);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1188, 299);
            dataGridView.TabIndex = 2;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // SanPhamID
            // 
            SanPhamID.HeaderText = "ID";
            SanPhamID.MinimumWidth = 6;
            SanPhamID.Name = "SanPhamID";
            // 
            // TenSanPham
            // 
            TenSanPham.HeaderText = "Tên sản phẩm";
            TenSanPham.MinimumWidth = 6;
            TenSanPham.Name = "TenSanPham";
            // 
            // DonGiaBan
            // 
            DonGiaBan.HeaderText = "Đơn giá bán";
            DonGiaBan.MinimumWidth = 6;
            DonGiaBan.Name = "DonGiaBan";
            // 
            // SoLuongBan
            // 
            SoLuongBan.HeaderText = "Số lượng bán";
            SoLuongBan.MinimumWidth = 6;
            SoLuongBan.Name = "SoLuongBan";
            // 
            // ThanhTien
            // 
            ThanhTien.HeaderText = "Thành tiền";
            ThanhTien.MinimumWidth = 6;
            ThanhTien.Name = "ThanhTien";
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.Font = new Font("Times New Roman", 12F);
            btnInHoaDon.ForeColor = Color.Black;
            btnInHoaDon.Location = new Point(490, 610);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(194, 46);
            btnInHoaDon.TabIndex = 16;
            btnInHoaDon.Text = "In hóa đơn";
            btnInHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnLuuHoaDon
            // 
            btnLuuHoaDon.Font = new Font("Times New Roman", 12F);
            btnLuuHoaDon.ForeColor = Color.Blue;
            btnLuuHoaDon.Location = new Point(264, 610);
            btnLuuHoaDon.Name = "btnLuuHoaDon";
            btnLuuHoaDon.Size = new Size(194, 46);
            btnLuuHoaDon.TabIndex = 15;
            btnLuuHoaDon.Text = "Lưu hóa đơn";
            btnLuuHoaDon.UseVisualStyleBackColor = true;
            btnLuuHoaDon.Click += btnLuuHoaDon_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Times New Roman", 12F);
            btnThoat.ForeColor = Color.Red;
            btnThoat.Location = new Point(732, 610);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(108, 46);
            btnThoat.TabIndex = 17;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // frmHoaDon_ChiTiet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1188, 668);
            Controls.Add(btnThoat);
            Controls.Add(btnInHoaDon);
            Controls.Add(btnLuuHoaDon);
            Controls.Add(dataGridView);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmHoaDon_ChiTiet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa Đơn chi tiết";
            Load += frmHoaDon_ChiTiet_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cboNhanVien;
        private Label label1;
        private ComboBox cboKhachHang;
        private Label label6;
        private TextBox txtGhiChuHoaDon;
        private Label label2;
        private GroupBox groupBox2;
        private NumericUpDown numDonGia;
        private NumericUpDown numSoLuong;
        private Label label3;
        private Label label5;
        private Button btnXoa;
        private Button btnXacNhanBan;
        private ComboBox cboSanPham;
        private Label label4;
        private DataGridView dataGridView;
        private Button btnInHoaDon;
        private Button btnLuuHoaDon;
        private Button btnThoat;
        private DataGridViewTextBoxColumn SanPhamID;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn DonGiaBan;
        private DataGridViewTextBoxColumn SoLuongBan;
        private DataGridViewTextBoxColumn ThanhTien;
    }
}