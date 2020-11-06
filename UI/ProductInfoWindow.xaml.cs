using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL.DTO;
using BLL.Controllers;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для ProductInfoWindow.xaml
    /// </summary>
    public partial class ProductInfoWindow : Window
    {
        private BLLMainController _bllCntrllr;
        public ProductDTO Product { get; set; }

        public ProductInfoWindow(ProductDTO prdct, BLLMainController bllCntrllr)
        {
            InitializeComponent();
            _bllCntrllr = bllCntrllr;

            CB_Category.ItemsSource = _bllCntrllr.GetCategories();
            CB_Category.DisplayMemberPath = nameof(CategoryDTO.Name);

            if (prdct is null)
                Product = new ProductDTO();
            else {
                Product = prdct;
                InitializeContents();
            }    
        }

        private void InitializeContents()
        {
            TB_Name.Text = Product.Name;
            TB_Price.Text = Product.Price.ToString();
            CB_Category.Text = _bllCntrllr.GetCategorybyId(Product.CategoryId).Name;
            CB_Availability.IsChecked = Product.Availability;
        }

        private void Bttn_Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product.Price = decimal.Parse(TB_Price.Text);
                Product.Name = TB_Name.Text;
                Product.Availability = CB_Availability.IsChecked.Value;
                Product.CategoryId = (CB_Category.SelectedItem as CategoryDTO).Id;

                this.DialogResult = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops!");
            }
        }
    }
}
