using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.Utils
{
    public enum ButtonStyleType
    {
        Primary,    // Xanh dương #1976D2 (Sửa, Tìm kiếm, Đăng nhập)
        Success,    // Xanh lá #22A06B (Thêm mới, Thanh toán)
        Danger,     // Đỏ #D64545 (Xóa, Thoát)
        Secondary,  // Xám #6B7280 (Làm mới, Hủy)
        Light,      // Xám nhạt viền mảnh (Tất cả, Lọc)
        Dark        // Xanh navy #14213D
    }

    /// <summary>
    /// Design System tập trung cho toàn bộ ứng dụng Quản lý cửa hàng điện thoại.
    /// Đảm bảo tính nhất quán về màu sắc, font chữ, kích thước, bo góc và trải nghiệm người dùng.
    /// </summary>
    public static class UITheme
    {
        // ==========================================
        // 1. BẢNG MÀU CHUẨN (PALETTE)
        // ==========================================
        public static readonly Color DarkNavy = Color.FromArgb(20, 33, 61);       // #14213D (Sidebar, Header DGV)
        public static readonly Color SidebarDark = Color.FromArgb(15, 23, 42);    // #0F172A (Sidebar nền sâu sang trọng)
        public static readonly Color SidebarNavHover = Color.FromArgb(30, 41, 59);// #1E293B
        public static readonly Color SidebarNavActive = Color.FromArgb(25, 118, 210); // #1976D2

        public static readonly Color PrimaryBlue = Color.FromArgb(25, 118, 210);   // #1976D2
        public static readonly Color PrimaryBlueHover = Color.FromArgb(21, 101, 192); // #1565C0
        public static readonly Color LightBlue = Color.FromArgb(234, 243, 255);   // #EAF3FF

        public static readonly Color Background = Color.FromArgb(245, 247, 250);  // #F5F7FA
        public static readonly Color CardBackground = Color.FromArgb(255, 255, 255); // #FFFFFF

        public static readonly Color Success = Color.FromArgb(34, 160, 107);      // #22A06B
        public static readonly Color SuccessHover = Color.FromArgb(26, 133, 87);
        public static readonly Color Warning = Color.FromArgb(245, 158, 11);      // #F59E0B
        public static readonly Color Danger = Color.FromArgb(214, 69, 69);        // #D64545
        public static readonly Color DangerHover = Color.FromArgb(185, 28, 28);
        public static readonly Color Secondary = Color.FromArgb(107, 114, 128);   // #6B7280
        public static readonly Color SecondaryHover = Color.FromArgb(75, 85, 99);

        public static readonly Color TextDark = Color.FromArgb(31, 41, 55);       // #1F2937
        public static readonly Color TextSecondary = Color.FromArgb(107, 114, 128); // #6B7280
        public static readonly Color TextMuted = Color.FromArgb(156, 163, 175);    // #9CA3AF

        public static readonly Color BorderColor = Color.FromArgb(229, 231, 235); // #E5E7EB
        public static readonly Color BorderDark = Color.FromArgb(209, 213, 219);  // #D1D5DB

        // DataGridView Colors
        public static readonly Color DgvHeaderBg = Color.FromArgb(20, 33, 61);    // #14213D
        public static readonly Color DgvHeaderFg = Color.White;
        public static readonly Color DgvRowEven = Color.White;
        public static readonly Color DgvRowOdd = Color.FromArgb(248, 250, 252);   // #F8FAFC
        public static readonly Color DgvSelectionBg = Color.FromArgb(219, 234, 254); // #DBEAFE
        public static readonly Color DgvSelectionFg = Color.FromArgb(15, 23, 42); // #0F172A
        public static readonly Color DgvGridLine = Color.FromArgb(226, 232, 240);  // #E2E8F0

        // ==========================================
        // 2. FONT CHỮ CHUẨN (SEGOE UI)
        // ==========================================
        public static readonly Font TitleFont = new Font("Segoe UI", 14f, FontStyle.Bold);
        public static readonly Font HeaderFont = new Font("Segoe UI", 12f, FontStyle.Bold);
        public static readonly Font SectionFont = new Font("Segoe UI", 10.5f, FontStyle.Bold);
        public static readonly Font BodyFont = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        public static readonly Font BodyBoldFont = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font SmallFont = new Font("Segoe UI", 8.5f, FontStyle.Regular);
        public static readonly Font ButtonFont = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font DgvHeaderFont = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font DgvRowFont = new Font("Segoe UI", 9.5f, FontStyle.Regular);

        // ==========================================
        // 3. DATAGRIDVIEW STYLING
        // ==========================================
        public static void ApplyGridStyle(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = DgvGridLine;
            dgv.EnableHeadersVisualStyles = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Column Header Style
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 42;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = DgvHeaderBg;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = DgvHeaderFg;
            dgv.ColumnHeadersDefaultCellStyle.Font = DgvHeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);

            // Default Row Style
            dgv.RowTemplate.Height = 38;
            dgv.DefaultCellStyle.BackColor = DgvRowEven;
            dgv.DefaultCellStyle.ForeColor = TextDark;
            dgv.DefaultCellStyle.Font = DgvRowFont;
            dgv.DefaultCellStyle.SelectionBackColor = DgvSelectionBg;
            dgv.DefaultCellStyle.SelectionForeColor = DgvSelectionFg;
            dgv.DefaultCellStyle.Padding = new Padding(12, 0, 12, 0);

            // Alternating Row Style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = DgvRowOdd;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextDark;
            dgv.AlternatingRowsDefaultCellStyle.Font = DgvRowFont;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = DgvSelectionBg;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = DgvSelectionFg;
            dgv.AlternatingRowsDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);
        }

        // ==========================================
        // 4. BUTTON STYLING
        // ==========================================
        public static void ApplyButtonStyle(Button btn, ButtonStyleType styleType, string overrideText = null)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = ButtonFont;
            if (!string.IsNullOrEmpty(overrideText))
            {
                btn.Text = overrideText;
            }

            switch (styleType)
            {
                case ButtonStyleType.Primary:
                    btn.BackColor = PrimaryBlue;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = PrimaryBlueHover;
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 71, 161);
                    break;

                case ButtonStyleType.Success:
                    btn.BackColor = Success;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = SuccessHover;
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 108, 70);
                    break;

                case ButtonStyleType.Danger:
                    btn.BackColor = Danger;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = DangerHover;
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 27, 27);
                    break;

                case ButtonStyleType.Secondary:
                    btn.BackColor = Secondary;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = SecondaryHover;
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(55, 65, 81);
                    break;

                case ButtonStyleType.Light:
                    btn.BackColor = Color.FromArgb(243, 244, 246);
                    btn.ForeColor = TextDark;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = BorderColor;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 231, 235);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(209, 213, 219);
                    break;

                case ButtonStyleType.Dark:
                    btn.BackColor = DarkNavy;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(15, 23, 42);
                    break;
            }
        }

        // ==========================================
        // 5. INPUT CONTROLS STYLING
        // ==========================================
        public static void ApplyTextBoxStyle(TextBox txt, string placeholder = null)
        {
            if (txt == null) return;
            txt.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            txt.ForeColor = TextDark;
            txt.BackColor = Color.White;
            txt.BorderStyle = BorderStyle.FixedSingle;
            if (!string.IsNullOrEmpty(placeholder))
            {
                txt.PlaceholderText = placeholder;
            }
        }

        public static void ApplyComboBoxStyle(ComboBox cbo)
        {
            if (cbo == null) return;
            cbo.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            cbo.ForeColor = TextDark;
            cbo.BackColor = Color.White;
            cbo.FlatStyle = FlatStyle.Flat;
        }

        public static void ApplyNumericUpDownStyle(NumericUpDown num)
        {
            if (num == null) return;
            num.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            num.ForeColor = TextDark;
            num.BackColor = Color.White;
            num.BorderStyle = BorderStyle.FixedSingle;
        }

        // ==========================================
        // 6. CARD / GROUPBOX STYLING
        // ==========================================
        public static void ApplyCardGroupBox(GroupBox grp)
        {
            if (grp == null) return;
            grp.BackColor = CardBackground;
            grp.ForeColor = TextDark;
            grp.Font = SectionFont;
            grp.FlatStyle = FlatStyle.Standard;

            // Custom paint to draw modern flat 1px border instead of sunken 3D Win32 border
            grp.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var rect = grp.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;

                // Đo kích thước chuỗi tiêu đề
                var text = grp.Text;
                var font = grp.Font;
                var size = g.MeasureString(text, font);

                // Vẽ nền
                using (var brush = new SolidBrush(CardBackground))
                {
                    g.FillRectangle(brush, grp.ClientRectangle);
                }

                // Vẽ khung viền phẳng hiện đại
                using (var pen = new Pen(BorderColor, 1.2f))
                {
                    // Vẽ hình chữ nhật viền nhẹ quanh toàn bộ card
                    var topY = (int)(size.Height / 2) + 2;
                    g.DrawLine(pen, 10, topY, 15, topY);
                    g.DrawLine(pen, 15 + (int)size.Width + 5, topY, rect.Right - 8, topY);
                    g.DrawLine(pen, rect.Right - 8, topY, rect.Right - 8, rect.Bottom - 4);
                    g.DrawLine(pen, rect.Right - 8, rect.Bottom - 4, 10, rect.Bottom - 4);
                    g.DrawLine(pen, 10, rect.Bottom - 4, 10, topY);
                }

                // Vẽ chữ tiêu đề
                using (var textBrush = new SolidBrush(PrimaryBlue))
                {
                    g.DrawString(text, font, textBrush, 18, 0);
                }
            };
        }

        // ==========================================
        // 7. TỰ ĐỘNG CHUẨN HÓA TOÀN BỘ FORM
        // ==========================================
        public static void BeautifyForm(Form form)
        {
            if (form == null) return;

            form.BackColor = Background;
            form.Font = BodyFont;
            form.ForeColor = TextDark;

            ApplyThemeRecursively(form);
        }

        private static void ApplyThemeRecursively(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is DataGridView dgv)
                {
                    ApplyGridStyle(dgv);
                }
                else if (c is Button btn)
                {
                    string txt = btn.Text.ToLower();
                    if (txt.Contains("thêm") || txt.Contains("add") || txt.Contains("+"))
                    {
                        ApplyButtonStyle(btn, ButtonStyleType.Success);
                    }
                    else if (txt.Contains("sửa") || txt.Contains("cập nhật") || txt.Contains("update") || txt.Contains("edit") || txt.Contains("lưu"))
                    {
                        ApplyButtonStyle(btn, ButtonStyleType.Primary);
                    }
                    else if (txt.Contains("xóa") || txt.Contains("delete") || txt.Contains("remove") || txt.Contains("hủy đơn") || txt.Contains("thoát"))
                    {
                        ApplyButtonStyle(btn, ButtonStyleType.Danger);
                    }
                    else if (txt.Contains("làm mới") || txt.Contains("reset") || txt.Contains("clear") || txt.Contains("↺"))
                    {
                        ApplyButtonStyle(btn, ButtonStyleType.Secondary);
                    }
                    else if (txt.Contains("tìm") || txt.Contains("search") || txt.Contains("lọc") || txt.Contains("filter"))
                    {
                        ApplyButtonStyle(btn, ButtonStyleType.Primary);
                    }
                    else if (txt.Contains("tất cả") || txt.Contains("all") || txt.Contains("tháng này"))
                    {
                        ApplyButtonStyle(btn, ButtonStyleType.Light);
                    }
                    else if (txt.Contains("thanh toán") || txt.Contains("xuất hóa đơn") || txt.Contains("nhập kho"))
                    {
                        ApplyButtonStyle(btn, ButtonStyleType.Success);
                    }
                    else
                    {
                        ApplyButtonStyle(btn, ButtonStyleType.Primary);
                    }
                }
                else if (c is TextBox txtBox)
                {
                    ApplyTextBoxStyle(txtBox);
                }
                else if (c is ComboBox cboBox)
                {
                    ApplyComboBoxStyle(cboBox);
                }
                else if (c is NumericUpDown num)
                {
                    ApplyNumericUpDownStyle(num);
                }
                else if (c is GroupBox grp)
                {
                    ApplyCardGroupBox(grp);
                }
                else if (c is Label lbl)
                {
                    lbl.ForeColor = TextDark;
                    if (lbl.Font.Bold)
                    {
                        lbl.Font = BodyBoldFont;
                    }
                    else
                    {
                        lbl.Font = BodyFont;
                    }
                }

                // Đệ quy cho controls con bên trong
                if (c.HasChildren && !(c is DataGridView))
                {
                    ApplyThemeRecursively(c);
                }
            }
        }
    }
}
