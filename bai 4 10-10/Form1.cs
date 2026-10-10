namespace bai_4_10_10
{
    public partial class Form1 : Form
    {
        private readonly List<Employee> employees =
        [
            new("NV001", "Nguyễn Văn An", "Trưởng phòng", new DateTime(2018, 3, 12), "Kỹ thuật", "Phát triển phần mềm"),
            new("NV002", "Trần Thị Bình", "Lập trình viên", new DateTime(2020, 7, 20), "Kỹ thuật", "Phát triển phần mềm"),
            new("NV003", "Lê Quốc Cường", "Kiểm thử viên", new DateTime(2021, 1, 8), "Kỹ thuật", "Đảm bảo chất lượng"),
            new("NV004", "Phạm Minh Đức", "Trưởng phòng", new DateTime(2017, 11, 5), "Kinh doanh", "Bán hàng"),
            new("NV005", "Hoàng Thu Hà", "Chuyên viên kinh doanh", new DateTime(2022, 4, 18), "Kinh doanh", "Bán hàng"),
            new("NV006", "Võ Thành Long", "Chuyên viên", new DateTime(2019, 9, 23), "Kinh doanh", "Chăm sóc khách hàng"),
            new("NV007", "Đỗ Ngọc Mai", "Kế toán trưởng", new DateTime(2016, 6, 1), "Tài chính - Kế toán", "Kế toán tổng hợp"),
            new("NV008", "Bùi Gia Huy", "Kế toán viên", new DateTime(2023, 2, 13), "Tài chính - Kế toán", "Kế toán tổng hợp")
        ];

        public Form1()
        {
            InitializeComponent();
            ConfigureImages();
            ConfigureListViewAndComboBox();
            BuildOrganizationTree();
            LoadEmployees(tvDepartments.Nodes[0]);
        }

        private void ConfigureListViewAndComboBox()
        {
            lsvEmployees.Columns.Add("Mã NV", 100);
            lsvEmployees.Columns.Add("Họ Tên", 220);
            lsvEmployees.Columns.Add("Chức vụ", 220);
            lsvEmployees.Columns.Add("Ngày vào làm", 140);

            cboViewMode.Items.Add(new ViewModeOption("Details (Chi tiết)", View.Details));
            cboViewMode.Items.Add(new ViewModeOption("SmallIcon (Icon nhỏ)", View.SmallIcon));
            cboViewMode.Items.Add(new ViewModeOption("LargeIcon (Icon lớn)", View.LargeIcon));
            cboViewMode.Items.Add(new ViewModeOption("Tile (Lát gạch)", View.Tile));
            cboViewMode.SelectedIndex = 0;
        }

        private void ConfigureImages()
        {
            imageList.Images.Add("folder", CreateIcon(Color.FromArgb(245, 180, 55), false));
            imageList.Images.Add("folder-open", CreateIcon(Color.FromArgb(255, 205, 80), true));
            imageList.Images.Add("employee", CreateIcon(Color.FromArgb(70, 140, 210), false));
        }

        private static Bitmap CreateIcon(Color color, bool opened)
        {
            Bitmap bitmap = new(32, 32);
            using Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Transparent);
            using SolidBrush brush = new(color);
            graphics.FillRectangle(brush, new Rectangle(3, opened ? 10 : 8, 26, 18));
            graphics.FillRectangle(brush, new Rectangle(6, opened ? 7 : 6, 11, 6));
            return bitmap;
        }

        private void BuildOrganizationTree()
        {
            tvDepartments.BeginUpdate();
            tvDepartments.Nodes.Clear();

            TreeNode companyNode = CreateNode("Công ty TNHH ABC", employees);
            TreeNode engineeringNode = CreateNode("Phòng Kỹ thuật", GetEmployeesByDepartment("Kỹ thuật"));
            engineeringNode.Nodes.Add(CreateNode("Nhóm Phát triển phần mềm", GetEmployeesByGroup("Kỹ thuật", "Phát triển phần mềm")));
            engineeringNode.Nodes.Add(CreateNode("Nhóm Đảm bảo chất lượng", GetEmployeesByGroup("Kỹ thuật", "Đảm bảo chất lượng")));

            TreeNode businessNode = CreateNode("Phòng Kinh doanh", GetEmployeesByDepartment("Kinh doanh"));
            businessNode.Nodes.Add(CreateNode("Nhóm Bán hàng", GetEmployeesByGroup("Kinh doanh", "Bán hàng")));
            businessNode.Nodes.Add(CreateNode("Nhóm Chăm sóc khách hàng", GetEmployeesByGroup("Kinh doanh", "Chăm sóc khách hàng")));

            TreeNode financeNode = CreateNode("Phòng Tài chính - Kế toán", GetEmployeesByDepartment("Tài chính - Kế toán"));
            financeNode.Nodes.Add(CreateNode("Nhóm Kế toán tổng hợp", GetEmployeesByGroup("Tài chính - Kế toán", "Kế toán tổng hợp")));

            companyNode.Nodes.Add(engineeringNode);
            companyNode.Nodes.Add(businessNode);
            companyNode.Nodes.Add(financeNode);
            tvDepartments.Nodes.Add(companyNode);
            companyNode.Expand();
            tvDepartments.SelectedNode = companyNode;
            tvDepartments.EndUpdate();
        }

        private static TreeNode CreateNode(string text, IEnumerable<Employee> nodeEmployees)
        {
            TreeNode node = new(text) { Tag = nodeEmployees.ToList(), ImageKey = "folder", SelectedImageKey = "folder-open" };
            return node;
        }

        private IEnumerable<Employee> GetEmployeesByDepartment(string department) =>
            employees.Where(employee => employee.Department == department);

        private IEnumerable<Employee> GetEmployeesByGroup(string department, string group) =>
            employees.Where(employee => employee.Department == department && employee.Group == group);

        private void LoadEmployees(TreeNode? node)
        {
            lsvEmployees.BeginUpdate();
            lsvEmployees.Items.Clear();

            if (node?.Tag is IEnumerable<Employee> nodeEmployees)
            {
                foreach (Employee employee in nodeEmployees)
                {
                    ListViewItem item = new(employee.Id, "employee")
                    {
                        Tag = employee
                    };
                    item.SubItems.Add(employee.FullName);
                    item.SubItems.Add(employee.Position);
                    item.SubItems.Add(employee.StartDate.ToString("dd/MM/yyyy"));
                    lsvEmployees.Items.Add(item);
                }
            }

            lsvEmployees.EndUpdate();
            lblSelectedNode.Text = node is null ? "Chưa chọn đơn vị" : $"Danh sách nhân viên: {node.Text}";
        }

        private void TvDepartmentsAfterSelect(object? sender, TreeViewEventArgs e)
        {
            LoadEmployees(e.Node);
        }

        private void CboViewModeSelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboViewMode.SelectedItem is ViewModeOption option)
            {
                lsvEmployees.View = option.View;
            }
        }
    }

    internal sealed record Employee(
        string Id,
        string FullName,
        string Position,
        DateTime StartDate,
        string Department,
        string Group);

    internal sealed record ViewModeOption(string Name, View View)
    {
        public override string ToString() => Name;
    }
}
