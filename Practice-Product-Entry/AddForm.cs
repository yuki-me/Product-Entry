using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_Product_Entry
{
    public partial class AddForm : Form
    {
        public BindingSource bsAdd;
        public bool add;
        public AddForm()
        {
            InitializeComponent();

            btnCommit.Click += (sender, e) =>
            {
                
                if (add)
                {

                    bsAdd.AddNew();
                    var pro = bsAdd.Current as Product;
                    pro.Id = txtId.Text;
                    pro.Name = txtName.Text;
                    pro.Price = double.Parse(txtPrice.Text);
                    bsAdd.EndEdit();

                    Clear();
                }
                else
                {
                    var pro = bsAdd.Current as Product;
                    pro.Name = txtName.Text;
                    pro.Price = double.Parse(txtPrice.Text);
                    bsAdd.ResetCurrentItem();

                    Clear();
                }
            };

            btnCancel.Click += (sender, e) =>
            {
                this.Close();
            };
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
           
            if (add)
            {
                lblTitle.Text = "Add Name Product";
            }
            else
            {
                var current = bsAdd.Current as Product;
                lblTitle.Text = $"Update Product : {current.Name}";
                txtId.Text = current.Id;
                txtName.Text = current.Name;
                txtPrice.Text = current.Price.ToString();

                txtId.Enabled = false;
            }
        }

        public void Clear()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }
    }
}
