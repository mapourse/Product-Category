using ADO.NET_Dapper.Objects;
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

namespace ADO.NET_Dapper
{
    /// <summary>
    /// Логика взаимодействия для ProductInfoWindow.xaml
    /// </summary>
    public partial class ProductInfoWindow : Window
    {
        private GenericUnitofWork _uow;
        public Products Product { get; set; }

        public ProductInfoWindow(Products prdct, GenericUnitofWork unitofWork)
        {
            InitializeComponent();
            _uow = unitofWork;

            CB_Category.ItemsSource = _uow.Repository<Categories>().GetEntities();
            CB_Category.DisplayMemberPath = nameof(Categories.Name);

            if (prdct is null)
                Product = new Products();
            else
            {
                Product = prdct;
                InitializeContents();
            }
        }

        private void InitializeContents()
        {
            TB_Name.Text = Product.Name;
            TB_Price.Text = Product.Price.ToString();
            CB_Category.Text = _uow.Repository<Categories>().GetbyId(Product.CategoryId).Name;
            CB_Availability.IsChecked = Product.Availability;
        }

        private void Bttn_Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product.Price = decimal.Parse(TB_Price.Text);
                Product.Name = TB_Name.Text;
                Product.Availability = CB_Availability.IsChecked.Value;
                Product.CategoryId = (CB_Category.SelectedValue as Categories).Id;

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops!");
            }
        }

        private void Bttn_NewCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryInfoWindow ncw = new CategoryInfoWindow(null, _uow);
            if (ncw.ShowDialog() == true)
            {
                _uow.Repository<Categories>().Insert(ncw.Category);
                CB_Category.ItemsSource = _uow.Repository<Categories>().GetEntities();
            }
        }
    }
}
