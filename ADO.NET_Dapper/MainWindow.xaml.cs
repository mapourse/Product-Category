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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADO.NET_Dapper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        private GenericUnitofWork _uow;

        public MainWindow()
        {
            InitializeComponent();

            _uow = new GenericUnitofWork();

            CB_ItemstoShow.Items.Add(nameof(Products));
            CB_ItemstoShow.Items.Add(nameof(Categories));
            CB_ItemstoShow.SelectedIndex= 0;
            UpdateTableItems();
        }


        private void UpdateTableItems()
        {
            if (DG_Info.Items.Count != 0)
                DG_Info.ItemsSource = null;

            if (CB_ItemstoShow.SelectedItem.ToString() == nameof(Products))
                DG_Info.ItemsSource = _uow.Repository<Products>().GetEntities();
            else
                DG_Info.ItemsSource = _uow.Repository<Categories>().GetEntities();

        }

        private void CMI_Modify_Click(object sender, RoutedEventArgs e)
        {
            switch(DG_Info.SelectedItem.GetType().Name)
            {
                case nameof(Products):
                    Products selectedPr = DG_Info.SelectedItem as Products;
                    if (selectedPr != null)
                    {
                        ProductInfoWindow piw = new ProductInfoWindow(selectedPr, _uow);
                        if (piw.ShowDialog() == true)
                        {
                            _uow.Repository<Products>().Update(piw.Product);
                        }
                    }
                    break;
                case nameof(Categories):
                    Categories selectedCat = DG_Info.SelectedItem as Categories;
                    if (selectedCat != null)
                    {
                        CategoryInfoWindow ciw = new CategoryInfoWindow(selectedCat, _uow);
                        if (ciw.ShowDialog() == true)
                        {
                            _uow.Repository<Categories>().Update(ciw.Category);
                        }
                    }
                    break;
            }
            UpdateTableItems();
        }

        private void CMI_Delete_Click(object sender, RoutedEventArgs e)
        {
            switch (DG_Info.SelectedItem.GetType().Name)
            {
                case nameof(Products):
                    Products selectedPr = DG_Info.SelectedItem as Products;

                if (selectedPr != null)
                {
                    _uow.Repository<Products>().Delete(selectedPr.Id);
                }
                break;
                case nameof(Categories):
                Categories selectedCat = DG_Info.SelectedItem as Categories;

                if (selectedCat != null)
                { 
                    _uow.Repository<Categories>().Delete(selectedCat.Id);
                }
                break;
            }
            UpdateTableItems();
        }

        private void CB_ItemstoShow_Selected(object sender, RoutedEventArgs e)
        {
            UpdateTableItems();
        }

        private void Bttn_NewItem_Click(object sender, RoutedEventArgs e)
        {
            if (CB_ItemstoShow.SelectedItem.ToString() == nameof(Products))
            {
                ProductInfoWindow piw = new ProductInfoWindow(null, _uow);
                if (piw.ShowDialog() == true)
                {
                    _uow.Repository<Products>().Insert(piw.Product);
                }
            }
            else
            {
                CategoryInfoWindow ncw = new CategoryInfoWindow(null, _uow);
                if (ncw.ShowDialog() == true)
                {
                    _uow.Repository<Categories>().Insert(ncw.Category);
                }
            }
            UpdateTableItems();
        }
    }
}
