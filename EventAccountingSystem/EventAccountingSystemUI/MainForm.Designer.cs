namespace EventAccountingSystemUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private TextBox txtTitle;
        private TextBox txtLocation;
        private TextBox txtDescription;
        private DateTimePicker dtpEventDate;
        private ComboBox cmbType;
        private ComboBox cmbStatus;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            txtTitle = new TextBox();
            txtLocation = new TextBox();
            txtDescription = new TextBox();
            dtpEventDate = new DateTimePicker();
            cmbType = new ComboBox();
            cmbStatus = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeight = 58;
            dataGridView1.Location = new Point(22, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 102;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(2443, 663);
            dataGridView1.TabIndex = 0;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(22, 681);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Название";
            txtTitle.Size = new Size(389, 47);
            txtTitle.TabIndex = 1;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(417, 681);
            txtLocation.Name = "txtLocation";
            txtLocation.PlaceholderText = "Место";
            txtLocation.Size = new Size(374, 47);
            txtLocation.TabIndex = 2;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(797, 681);
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Описание";
            txtDescription.Size = new Size(565, 47);
            txtDescription.TabIndex = 3;
            // 
            // dtpEventDate
            // 
            dtpEventDate.Location = new Point(1368, 681);
            dtpEventDate.Name = "dtpEventDate";
            dtpEventDate.Size = new Size(353, 47);
            dtpEventDate.TabIndex = 4;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Items.AddRange(new object[] { "Conference", "Seminar", "Webinar" });
            cmbType.Location = new Point(2099, 679);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(366, 49);
            cmbType.TabIndex = 5;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new object[] { "Planned", "InProgress", "Completed", "Canceled" });
            cmbStatus.Location = new Point(1727, 679);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(366, 49);
            cmbStatus.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(22, 743);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(209, 70);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Добавить";
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(237, 743);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(209, 70);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Изменить";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(452, 743);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(209, 70);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Удалить";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(667, 743);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(209, 70);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "Обновить";
            // 
            // MainForm
            // 
            ClientSize = new Size(2485, 843);
            Controls.Add(dataGridView1);
            Controls.Add(txtTitle);
            Controls.Add(txtLocation);
            Controls.Add(txtDescription);
            Controls.Add(dtpEventDate);
            Controls.Add(cmbType);
            Controls.Add(cmbStatus);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnRefresh);
            Name = "MainForm";
            Text = "Система учета мероприятий";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}