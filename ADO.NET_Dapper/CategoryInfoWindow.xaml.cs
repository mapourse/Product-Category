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
    /// Логика взаимодействия для NewCategoryWindow.xaml
    /// </summary>
    public partial class CategoryInfoWindow : Window
    {
        private GenericUnitofWork _uow;
        public Categories Category { get; set; }

        public CategoryInfoWindow(Categories ctgr, GenericUnitofWork unitofWork)
        {
            InitializeComponent();

            _uow = unitofWork;

            if (ctgr is null)
                Category = new Categories();
            else
            {
                Category = ctgr;
                TB_Name.Text = ctgr.Name;
            }
        }

        private void Bttn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TB_Name.Text))
            {
                Category.Name = TB_Name.Text;
                this.DialogResult = true;
            }
        }
    }
}
