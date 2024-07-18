using Shabbat.DAL;
using Shabbat.DAL.Model;
using Shabbat.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shabbat
{
    public partial class HostForm : Form
    {
        private CategoryRepository? _categoryRepository;
        public HostForm(CategoryRepository? categoryRepository)
        {
            InitializeComponent();
            _categoryRepository = categoryRepository;
            LoadCategories(_categoryRepository.FindAll());
        }
        public void LoadCategories(List<CategoryModel> categories)
        {
            listView_Categories.Items.Clear();
            listView_Categories.Items.AddRange(categories.Select(category => new ListViewItem(category.CategoryName)).ToArray());
        }

        private void button_Enter_Click(object sender, EventArgs e)
        {
            string categoryName = textBox_Category.Text.Trim();
            CategoryModel category = new CategoryModel(categoryName);
            bool sucsses = _categoryRepository.Insert(category);
            if (!sucsses)
            {
                MessageBox.Show("לא ניתן להוסיף קטגוריה!");
            }
            LoadCategories(_categoryRepository.FindAll());
            textBox_Category.Text = "";
        }
    }
}
