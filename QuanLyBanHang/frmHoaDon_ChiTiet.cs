using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmHoaDon_ChiTiet : Form
    {
        public frmHoaDon_ChiTiet(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;
        }


        QLBHDbContext context = new QLBHDbContext(); // Khởi tạo biến ngữ cảnh CSDL
        int id; // Lấy mã hóa đơn (dùng cho Sửa và Xóa)
        BindingList<DanhSachHoaDon_ChiTiet> hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>();

        public void BatTatChucNang()
        {
            if (id == 0 && dataGridView.Rows.Count == 0) // Thêm
            {
                // Xóa trắng các trường
                cboKhachHang.Text = "";
                cboNhanVien.Text = "";
                cboSanPham.Text = "";
                numSoLuong.Value = 1;
                numDonGia.Value = 0;
            }
            // Nút lưu và xóa chỉ sáng khi có sản phẩm
            btnLuuHoaDon.Enabled = dataGridView.Rows.Count > 0;
            btnXoa.Enabled = dataGridView.Rows.Count > 0;
        }
        private void frmHoaDon_ChiTiet_Load(object sender, EventArgs e)
        {
            // 1. Load dữ liệu cho các ComboBox
            cboNhanVien.DataSource = context.NhanVien.ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";

            cboKhachHang.DataSource = context.KhachHang.ToList();
            cboKhachHang.ValueMember = "ID";
            cboKhachHang.DisplayMember = "HoVaTen";

            cboSanPham.DataSource = context.SanPham.ToList();
            cboSanPham.ValueMember = "ID";
            cboSanPham.DisplayMember = "TenSanPham";

            // 2. Cấu hình DataGridView (Rất quan trọng để hiện dữ liệu)
            dataGridView.AutoGenerateColumns = false; //

            // Ánh xạ các cột (Phải khớp chính xác tên thuộc tính trong DanhSachHoaDon_ChiTiet)
            if (dataGridView.Columns.Count > 0)
            {
                // Giả sử các cột của bạn theo thứ tự trong Designer
                // Bạn nên đặt lại DataPropertyName cho từng cột trong Designer hoặc dùng code:
                dataGridView.Columns[0].DataPropertyName = "SanPhamID";  // Cột ID
                dataGridView.Columns[1].DataPropertyName = "TenSanPham"; // Cột Tên sản phẩm
                dataGridView.Columns[2].DataPropertyName = "DonGiaBan";  // Cột Đơn giá
                dataGridView.Columns[3].DataPropertyName = "SoLuongBan"; // Cột Số lượng
                dataGridView.Columns[4].DataPropertyName = "ThanhTien";
            }

            // 3. Load dữ liệu cũ nếu là chế độ Sửa
            if (id != 0)
            {
                var hoaDon = context.HoaDon.FirstOrDefault(r => r.ID == id);
                if (hoaDon != null)
                {
                    cboNhanVien.SelectedValue = hoaDon.NhanVienID;
                    cboKhachHang.SelectedValue = hoaDon.KhachHangID;
                    txtGhiChuHoaDon.Text = hoaDon.GhiChuHoaDon; //

                    var ct = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).Select(r => new DanhSachHoaDon_ChiTiet
                    {
                        ID = r.ID,
                        SanPhamID = r.SanPhamID,
                        TenSanPham = r.SanPham.TenSanPham,
                        SoLuongBan = r.SoLuongBan,
                        DonGiaBan = r.DonGiaBan,
                        ThanhTien = (int)(r.SoLuongBan * r.DonGiaBan)
                    }).ToList();
                    hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>(ct);
                }
            }

            dataGridView.DataSource = hoaDonChiTiet;
            BatTatChucNang();
        }

        private void btnXacNhanBan_Click(object sender, EventArgs e)
        {
            // Kiểm tra lỗi format ComboBox
            if (cboSanPham.SelectedValue == null || !(cboSanPham.SelectedValue is int))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ.", "Lỗi");
                return;
            }

            int maSanPham = (int)cboSanPham.SelectedValue;
            var itemTonTai = hoaDonChiTiet.FirstOrDefault(x => x.SanPhamID == maSanPham);

            if (itemTonTai != null)
            {
                // Cập nhật nếu đã có trong danh sách
                itemTonTai.SoLuongBan = (short)numSoLuong.Value; //
                itemTonTai.DonGiaBan = (int)numDonGia.Value;
                itemTonTai.ThanhTien = (int)(numSoLuong.Value * numDonGia.Value);
                dataGridView.Refresh();
            }
            else
            {
                // Thêm mới vào danh sách hiển thị
                hoaDonChiTiet.Add(new DanhSachHoaDon_ChiTiet
                {
                    SanPhamID = maSanPham,
                    TenSanPham = cboSanPham.Text,
                    SoLuongBan = (short)numSoLuong.Value,
                    DonGiaBan = (int)numDonGia.Value,
                    ThanhTien = (int)(numSoLuong.Value * numDonGia.Value)
                });
            }
            BatTatChucNang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Sửa lỗi Null Reference bằng cách kiểm tra CurrentRow
            if (dataGridView.CurrentRow != null)
            {
                // Lấy đối tượng đang được liên kết với dòng đó (Cách này an toàn nhất)
                var item = (DanhSachHoaDon_ChiTiet)dataGridView.CurrentRow.DataBoundItem;
                if (item != null)
                {
                    hoaDonChiTiet.Remove(item);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng trong bảng để xóa!", "Thông báo");
            }
            BatTatChucNang();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboNhanVien.Text))
                MessageBox.Show("Vui lòng chọn nhân viên lập hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboKhachHang.Text))
                MessageBox.Show("Vui lòng chọn khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (id != 0) // Đã tồn tại chi tiết thì chỉ cập nhật
                {
                    HoaDon hd = context.HoaDon.Find(id);
                    if (hd != null)
                    {
                        hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                        hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue.ToString());
                        hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;
                        context.HoaDon.Update(hd);
                        // Xóa chi tiết cũ
                        var old = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).ToList();
                        context.HoaDon_ChiTiet.RemoveRange(old);
                        // Thêm lại chi tiết mới
                        foreach (var item in hoaDonChiTiet.ToList())
                        {
                            HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                            ct.HoaDonID = id;
                            ct.SanPhamID = item.SanPhamID;
                            ct.SoLuongBan = item.SoLuongBan;
                            ct.DonGiaBan = item.DonGiaBan;
                            context.HoaDon_ChiTiet.Add(ct);
                        }
                        context.SaveChanges();
                    }
                }
                else // Thêm mới
                {
                    HoaDon hd = new HoaDon();
                    hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                    hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue.ToString());
                    hd.NgayLap = DateTime.Now;
                    hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;
                    context.HoaDon.Add(hd);
                    context.SaveChanges();
                    // Thêm chi tiết
                    foreach (var item in hoaDonChiTiet.ToList())
                    {
                        HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                        ct.HoaDonID = hd.ID;
                        ct.SanPhamID = item.SanPhamID;
                        ct.SoLuongBan = item.SoLuongBan;
                        ct.DonGiaBan = item.DonGiaBan;
                        context.HoaDon_ChiTiet.Add(ct);
                    }
                    context.SaveChanges();
                }
                MessageBox.Show("Đã lưu thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue is int maSanPham)
            {
                var sanPham = context.SanPham.Find(maSanPham);
                if (sanPham != null)
                {
                    // Lưu ý: Designer của bạn đặt tên là numDonGia, không phải numDonGiaBan
                    numDonGia.Value = sanPham.DonGia;
                }
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không phải header
            {
                int maSanPham = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["SanPhamID"].Value.ToString());
                var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.SanPhamID == maSanPham);
                if (chiTiet != null)
                {
                    cboSanPham.SelectedValue = chiTiet.SanPhamID;
                    numSoLuong.Value = chiTiet.SoLuongBan;
                    numDonGia.Value = chiTiet.DonGiaBan;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
