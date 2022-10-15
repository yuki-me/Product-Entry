namespace Practice_Product_Entry
{
    public partial class MainForm : Form
    {
        private static List<Product> lst = new List<Product>();
        private BindingSource bsMian;
        private AddForm addForm;

        public MainForm()
        {
            InitializeComponent();
            LoadData();

            btnAdd.Click += (sender, e) =>
            {
                addForm = new AddForm();
                addForm.bsAdd = bsMian;
                addForm.add = true;
                addForm.Show();
            };

            btnEdit.Click += (sender, e) =>
            {
                addForm = new AddForm();
                addForm.bsAdd = bsMian;
                addForm.add = false;
                addForm.Show();
            };
        }

        public void LoadData()
        {
            lst.AddRange(new[]
            {
                new Product("P1", "Tiger Beer Can 330ml", 16.7),
                new Product("P2", "Honda Dream 125cc", 2750),
                new Product("P3", "Cowhead Pure milk 1L", 2.5)
            });

            bsMian = new BindingSource(lst, null);
            dgvProductView.DataSource = bsMian;
            dgvProductView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvProductView.AllowUserToAddRows = false;
            dgvProductView.ReadOnly = true;
            bsMian.ResetBindings(false);
            dgvProductView.Columns["Info"].Visible = false;
            var tempVar = dgvProductView.Columns["ValidDate"];
            tempVar.DisplayIndex = 0;
            tempVar.HeaderText = "Valid?";
            dgvProductView.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductView.Columns["Price"].DefaultCellStyle.Format = "#,0.00";
            lblInfo.DataBindings.Add("Text", bsMian, "Info");
        }
    }
}