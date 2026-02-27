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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        QLBHDbContext context = new QLBHDbContext();
        int id;
        private void LoadData()
        {
            dataGridView.AutoGenerateColumns = false;
            var hd = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,
                // Tính tổng tiền trực tiếp từ chi tiết hóa đơn
                TongTienHoaDon = r.HoaDon_ChiTiet.Sum(ct => (double?)(ct.SoLuongBan * ct.DonGiaBan)) ?? 0,
                XemChiTiet = "Xem chi tiết"
            }).ToList();
            dataGridView.DataSource = hd;
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet())
            {
                if (chiTiet.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Load lại sau khi thêm mới
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(id))
                {
                    chiTiet.ShowDialog();
                    LoadData(); // Quan trọng: Phải load lại dữ liệu sau khi sửa
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này và toàn bộ chi tiết của nó không?",
                                            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        var hoaDon = context.HoaDon.Find(id);
                        if (hoaDon != null)
                        {
                            // Xóa các chi tiết trước (nếu database chưa cài đặt Cascade Delete)
                            var chiTiets = context.HoaDon_ChiTiet.Where(x => x.HoaDonID == id);
                            context.HoaDon_ChiTiet.RemoveRange(chiTiets);

                            context.HoaDon.Remove(hoaDon);
                            context.SaveChanges();
                            LoadData();
                            MessageBox.Show("Xóa thành công!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có một TextBox tên là txtTimKiem
            string keyword = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên khách hàng hoặc nhân viên cần tìm:", "Tìm kiếm");

            if (!string.IsNullOrEmpty(keyword))
            {
                var ketQua = context.HoaDon.Where(r => r.KhachHang.HoVaTen.Contains(keyword) ||
                                                     r.NhanVien.HoVaTen.Contains(keyword))
                    .Select(r => new DanhSachHoaDon
                    {
                        ID = r.ID,
                        HoVaTenNhanVien = r.NhanVien.HoVaTen,
                        HoVaTenKhachHang = r.KhachHang.HoVaTen,
                        NgayLap = r.NgayLap,
                        TongTienHoaDon = r.HoaDon_ChiTiet.Sum(ct => (double?)(ct.SoLuongBan * ct.DonGiaBan)) ?? 0
                    }).ToList();
                dataGridView.DataSource = ketQua;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Cách đơn giản nhất: Copy toàn bộ Grid vào Clipboard rồi dán vào Excel
            dataGridView.SelectAll();
            DataObject dataObj = dataGridView.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

            MessageBox.Show("Đã copy dữ liệu vào Clipboard. Bạn chỉ cần mở Excel và nhấn Ctrl + V", "Xuất Excel nhanh");
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng in yêu cầu thư viện ReportViewer hoặc Crystal Reports.", "Thông báo");
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click vào cột "Xem chi tiết" (thường là cột cuối cùng)
            if (dataGridView.Columns[e.ColumnIndex].Name == "ChiTiet" && e.RowIndex >= 0)
            {
                btnSua_Click(null, null); // Tận dụng logic của nút sửa để xem/sửa
            }
        }
    }
}
