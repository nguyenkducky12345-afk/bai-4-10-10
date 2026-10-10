namespace bai_4_10_10
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private SplitContainer splitMain;
        private TreeView tvDepartments;
        private ListView lsvEmployees;
        private ComboBox cboViewMode;
        private Label lblTreeTitle;
        private Label lblViewTitle;
        private Label lblSelectedNode;
        private ImageList imageList;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitMain = new SplitContainer();
            tvDepartments = new TreeView();
            lsvEmployees = new ListView();
            cboViewMode = new ComboBox();
            lblTreeTitle = new Label();
            lblViewTitle = new Label();
            lblSelectedNode = new Label();
            imageList = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 680);
            MinimumSize = new Size(800, 500);
            Text = "Quản lý tập tin dạng chuyên nghiệp";
            StartPosition = FormStartPosition.CenterScreen;

            splitMain.Dock = DockStyle.Fill;
            splitMain.FixedPanel = FixedPanel.Panel1;
            splitMain.IsSplitterFixed = false;
            splitMain.Location = new Point(0, 0);
            splitMain.Name = "splitMain";
            splitMain.Orientation = Orientation.Vertical;
            splitMain.Panel1MinSize = 220;
            splitMain.Panel2MinSize = 450;
            splitMain.SplitterDistance = 300;

            lblTreeTitle.AutoSize = true;
            lblTreeTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTreeTitle.Location = new Point(12, 12);
            lblTreeTitle.Text = "Cơ cấu tổ chức";
            splitMain.Panel1.Controls.Add(lblTreeTitle);

            tvDepartments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvDepartments.FullRowSelect = true;
            tvDepartments.HideSelection = false;
            tvDepartments.Location = new Point(12, 42);
            tvDepartments.Name = "tvDepartments";
            tvDepartments.ShowLines = true;
            tvDepartments.ShowNodeToolTips = true;
            tvDepartments.Size = new Size(276, 614);
            tvDepartments.ImageList = imageList;
            tvDepartments.AfterSelect += TvDepartmentsAfterSelect;
            splitMain.Panel1.Controls.Add(tvDepartments);

            lblViewTitle.AutoSize = true;
            lblViewTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblViewTitle.Location = new Point(16, 14);
            lblViewTitle.Text = "Danh sách nhân viên";
            splitMain.Panel2.Controls.Add(lblViewTitle);

            cboViewMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboViewMode.FormattingEnabled = true;
            cboViewMode.Location = new Point(720, 11);
            cboViewMode.Name = "cboViewMode";
            cboViewMode.Size = new Size(230, 28);
            cboViewMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboViewMode.SelectedIndexChanged += CboViewModeSelectedIndexChanged;
            splitMain.Panel2.Controls.Add(cboViewMode);

            lblSelectedNode.AutoEllipsis = true;
            lblSelectedNode.Dock = DockStyle.Bottom;
            lblSelectedNode.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSelectedNode.Height = 30;
            lblSelectedNode.Padding = new Padding(16, 5, 0, 0);
            lblSelectedNode.Text = "Danh sách nhân viên";
            splitMain.Panel2.Controls.Add(lblSelectedNode);

            lsvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lsvEmployees.FullRowSelect = true;
            lsvEmployees.GridLines = true;
            lsvEmployees.HideSelection = false;
            lsvEmployees.Location = new Point(16, 52);
            lsvEmployees.Name = "lsvEmployees";
            lsvEmployees.Size = new Size(774, 560);
            lsvEmployees.UseCompatibleStateImageBehavior = false;
            lsvEmployees.View = View.Details;
            lsvEmployees.SmallImageList = imageList;
            lsvEmployees.LargeImageList = imageList;
            splitMain.Panel2.Controls.Add(lsvEmployees);

            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(32, 32);
            imageList.TransparentColor = Color.Transparent;

            Controls.Add(splitMain);
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel1.PerformLayout();
            splitMain.Panel2.ResumeLayout(false);
            splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
        }

        #endregion
    }
}
