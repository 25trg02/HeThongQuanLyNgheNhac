using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MaterialSkin;

namespace HeThongQuanLyNgheNhac
{
    public partial class Admin_Main_Form : Form
    {
        private Guna2Panel mainContentPanel;

        public Admin_Main_Form()
        {
            InitializeComponent();

            // Xử lý sự kiện khi chọn tab
            mainTabControl.SelectedIndexChanged += MainTabControl_SelectedIndexChanged;

            // Xử lý sự kiện cho các ContextMenuStrip
            ContextMenuStrip_AmNhac.ItemClicked += ContextMenu_ItemClicked;
            ContextMenuStrip_SoThich.ItemClicked += ContextMenu_ItemClicked;
            ContextMenuStrip_TuongTac.ItemClicked += ContextMenu_ItemClicked;
            ContextMenuStrip_DoanhThu.ItemClicked += ContextMenu_ItemClicked;

            // Sửa icon người dùng
            guna2PictureBox4.Click += guna2PictureBox4_Click;
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTab = mainTabControl.SelectedTab.Name;
            if (selectedTab == "tabAmNhac" || selectedTab == "tabSoThich" || selectedTab == "tabTuongTac" || selectedTab == "tabDoanhThu")
            {
                // Hiển thị menu con khi chọn tab
                Point tabLocation = mainTabControl.GetTabRect(mainTabControl.SelectedIndex).Location;
                tabLocation.Offset(mainTabControl.Location.X, mainTabControl.Location.Y + headerPanel.Height);
                if (selectedTab == "tabAmNhac") ContextMenuStrip_AmNhac.Show(this, tabLocation);
                else if (selectedTab == "tabSoThich") ContextMenuStrip_SoThich.Show(this, tabLocation);
                else if (selectedTab == "tabTuongTac") ContextMenuStrip_TuongTac.Show(this, tabLocation);
                else if (selectedTab == "tabDoanhThu") ContextMenuStrip_DoanhThu.Show(this, tabLocation);
            }
            else if (selectedTab == "tabDashboard")
            {
                // Tải nội dung cho Dashboard
                LoadDashboard();
            }
        }

        private void ContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Guna2ContextMenuStrip menu = sender as Guna2ContextMenuStrip;
            menu.Close();

            string category = e.ClickedItem.Text;
            // Xác định TabPage hiện tại
            TabPage currentTab = mainTabControl.SelectedTab;
            LoadDataGrid(category, currentTab);
        }

        private void LoadDashboard()
        {
            tabDashboard.Controls.Clear();

            // Thêm nội dung mẫu cho Dashboard
            Guna2HtmlLabel dashboardLabel = new Guna2HtmlLabel();
            dashboardLabel.Text = "<h2>Dashboard</h2><p>Thống kê top bài hát, MV, v.v.</p>";
            dashboardLabel.Dock = DockStyle.Fill;
            dashboardLabel.ForeColor = Color.Black;
            tabDashboard.Controls.Add(dashboardLabel);
        }

        private void LoadDataGrid(string category, TabPage tabPage)
        {
            tabPage.Controls.Clear();

            // Tạo DataGridView
            Guna2DataGridView grid = new Guna2DataGridView();
            grid.Dock = DockStyle.Top;
            grid.Size = new Size(tabPage.Width - 20, tabPage.Height - 100);
            grid.Location = new Point(10, 10);

            // Cấu hình cột cho DataGridView dựa trên category (dữ liệu mẫu)
            switch (category)
            {
                case "QL Bài Hát":
                    grid.Columns.Add("SongID", "Mã Bài Hát");
                    grid.Columns.Add("Name", "Tên Bài Hát");
                    grid.Columns.Add("ReleaseDate", "Ngày Phát Hành");
                    grid.Rows.Add("S001", "Bài Hát 1", "2023-01-01");
                    grid.Rows.Add("S002", "Bài Hát 2", "2023-02-01");
                    break;
                case "QL Album":
                    grid.Columns.Add("AlbumID", "Mã Album");
                    grid.Columns.Add("Name", "Tên Album");
                    grid.Columns.Add("ReleaseYear", "Năm Phát Hành");
                    grid.Rows.Add("A001", "Album 1", 2023);
                    grid.Rows.Add("A002", "Album 2", 2022);
                    break;
                case "QL Nghệ Sĩ":
                    grid.Columns.Add("ArtistID", "Mã Nghệ Sĩ");
                    grid.Columns.Add("Name", "Tên Nghệ Sĩ");
                    grid.Columns.Add("Country", "Quốc Gia");
                    grid.Rows.Add("AR001", "Nghệ Sĩ 1", "Việt Nam");
                    grid.Rows.Add("AR002", "Nghệ Sĩ 2", "Hàn Quốc");
                    break;
                case "QL Tác Giả":
                    grid.Columns.Add("ComposerID", "Mã Tác Giả");
                    grid.Columns.Add("Name", "Tên Tác Giả");
                    grid.Columns.Add("Country", "Quốc Gia");
                    grid.Rows.Add("C001", "Tác Giả 1", "Việt Nam");
                    grid.Rows.Add("C002", "Tác Giả 2", "Mỹ");
                    break;
                case "QL Thể Loại":
                    grid.Columns.Add("GenreID", "Mã Thể Loại");
                    grid.Columns.Add("GenreName", "Tên Thể Loại");
                    grid.Rows.Add("G001", "Pop");
                    grid.Rows.Add("G002", "Rock");
                    break;
                case "QL Playlist":
                    grid.Columns.Add("PlaylistID", "Mã Playlist");
                    grid.Columns.Add("Name", "Tên Playlist");
                    grid.Columns.Add("CreatedAt", "Ngày Tạo");
                    grid.Rows.Add("P001", "Playlist 1", "2023-01-01");
                    grid.Rows.Add("P002", "Playlist 2", "2023-02-01");
                    break;
                case "QL Playlist Songs":
                    grid.Columns.Add("PlaylistID", "Mã Playlist");
                    grid.Columns.Add("SongID", "Mã Bài Hát");
                    grid.Rows.Add("P001", "S001");
                    grid.Rows.Add("P002", "S002");
                    break;
                case "QL Bài Hát Yêu Thích":
                    grid.Columns.Add("UserID", "Mã Người Dùng");
                    grid.Columns.Add("SongID", "Mã Bài Hát");
                    grid.Columns.Add("AddAt", "Ngày Thêm");
                    grid.Rows.Add("U001", "S001", "2023-01-01");
                    grid.Rows.Add("U002", "S002", "2023-02-01");
                    break;
                case "QL Người Dùng":
                    grid.Columns.Add("UserID", "Mã Người Dùng");
                    grid.Columns.Add("Username", "Tên Đăng Nhập");
                    grid.Columns.Add("Email", "Email");
                    grid.Rows.Add("U001", "user1", "user1@example.com");
                    grid.Rows.Add("U002", "user2", "user2@example.com");
                    break;
                case "QL Bình Luận":
                    grid.Columns.Add("CommentID", "Mã Bình Luận");
                    grid.Columns.Add("Content", "Nội Dung");
                    grid.Columns.Add("CreatedAt", "Ngày Bình Luận");
                    grid.Rows.Add("C001", "Hay quá!", "2023-01-01");
                    grid.Rows.Add("C002", "Tốt!", "2023-02-01");
                    break;
                case "QL Báo Cáo":
                    grid.Columns.Add("ReportID", "Mã Báo Cáo");
                    grid.Columns.Add("Reason", "Lý Do");
                    grid.Columns.Add("ReportedAt", "Ngày Báo Cáo");
                    grid.Rows.Add("R001", "Nội dung xấu", "2023-01-01");
                    grid.Rows.Add("R002", "Spam", "2023-02-01");
                    break;
                case "QL Lịch Sử":
                    grid.Columns.Add("UserID", "Mã Người Dùng");
                    grid.Columns.Add("SongID", "Mã Bài Hát");
                    grid.Columns.Add("PlayedAt", "Thời Gian Phát");
                    grid.Rows.Add("U001", "S001", "2023-01-01");
                    grid.Rows.Add("U002", "S002", "2023-02-01");
                    break;
            }

            // Thêm các nút chức năng
            Guna2Button btnAdd = new Guna2Button() { Text = "Thêm", Location = new Point(10, grid.Height + 20) };
            Guna2Button btnEdit = new Guna2Button() { Text = "Sửa", Location = new Point(100, grid.Height + 20) };
            Guna2Button btnDelete = new Guna2Button() { Text = "Xóa", Location = new Point(190, grid.Height + 20) };
            Guna2Button btnSearch = new Guna2Button() { Text = "Tìm kiếm", Location = new Point(280, grid.Height + 20) };
            Guna2TextBox txtSearch = new Guna2TextBox() { PlaceholderText = "Nhập từ khóa...", Location = new Point(370, grid.Height + 20), Size = new Size(200, 30) };

            // Thêm controls vào TabPage
            tabPage.Controls.Add(grid);
            tabPage.Controls.Add(btnAdd);
            tabPage.Controls.Add(btnEdit);
            tabPage.Controls.Add(btnDelete);
            tabPage.Controls.Add(btnSearch);
            tabPage.Controls.Add(txtSearch);

            // Sự kiện mẫu (chỉ hiển thị thông báo)
            btnAdd.Click += (s, ev) => MessageBox.Show("Thêm mới " + category);
            btnEdit.Click += (s, ev) => MessageBox.Show("Sửa " + category);
            btnDelete.Click += (s, ev) => MessageBox.Show("Xóa " + category);
            btnSearch.Click += (s, ev) => MessageBox.Show("Tìm kiếm: " + txtSearch.Text + " trong " + category);
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
