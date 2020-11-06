using BLL.DTO;
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

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BLL.Controllers.BLLMainController _bllCntrllr;

        public MainWindow()
        {
            InitializeComponent();

            _bllCntrllr = new BLL.Controllers.BLLMainController();
            UpdateTableItems();
        }


        private void UpdateTableItems()
        {
            DG_Info.ItemsSource = _bllCntrllr.GetProducts();
        }

        private void Bttn_NewProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductInfoWindow piw = new ProductInfoWindow(null, _bllCntrllr);
            if (piw.ShowDialog() == true)
            {
                _bllCntrllr.InsertorUpdateProduct(piw.Product);
                _bllCntrllr.SaveChanges();
                UpdateTableItems();
            }
        }

        private void CMI_Modify_Click(object sender, RoutedEventArgs e)
        {
            ProductDTO selectedPr = DG_Info.SelectedItem as ProductDTO;
            if (selectedPr != null)
            {
                ProductInfoWindow piw = new ProductInfoWindow(selectedPr, _bllCntrllr);
                if (piw.ShowDialog() == true)
                {
                    _bllCntrllr.InsertorUpdateProduct(piw.Product);
                    _bllCntrllr.SaveChanges();
                    UpdateTableItems();
                }
            }
        }

        private void CMI_Delete_Click(object sender, RoutedEventArgs e)
        {
            ProductDTO selectedPr = DG_Info.SelectedItem as ProductDTO;

            if (selectedPr != null) {
                _bllCntrllr.DeleteProductbyId(selectedPr.Id);
                _bllCntrllr.SaveChanges();
                UpdateTableItems();
            }
        }
    }
}
