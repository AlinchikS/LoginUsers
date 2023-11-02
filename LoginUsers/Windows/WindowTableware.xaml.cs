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

namespace LoginUsers.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowTableware.xaml
    /// </summary>
    public partial class WindowTableware : Window
    {
        public WindowTableware()
        {
            InitializeComponent();
            dgProducts.ItemsSource = App.Dbtableware.Products.ToList();
        }

        private void btnAddProducts_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowAddEditTableware waProduct = new Windows.WindowAddEditTableware(new Products());
            waProduct.ShowDialog();
            dgProducts.ItemsSource = null;
            dgProducts.ItemsSource = App.Dbtableware.Products.ToList();
        }

        private void btnEditProducts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Products product = dgProducts.SelectedItem as Products;
                Windows.WindowAddEditTableware waProduct = new Windows.WindowAddEditTableware(product);
                waProduct.ShowDialog();
                dgProducts.ItemsSource = null;
                dgProducts.ItemsSource = App.Dbtableware.Products.ToList();
            }
            catch
            {
                MessageBox.Show("Выберите объект для редактирования");
            }
        }

        private void btnDeleteProducts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Products product = dgProducts.SelectedItem as Products;
                App.Dbtableware.Products.Remove(product);
                App.Dbtableware.SaveChanges();
                dgProducts.ItemsSource = null;
                dgProducts.ItemsSource = App.Dbtableware.Products.ToList();
            }
            catch
            {
                MessageBox.Show("Выберите объект для удаления");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.currentUser != null)
                lbUsers.Content = $"{App.currentUser.lastname} {App.currentUser.firstname} {App.currentUser.patronymic}";
            else
                lbUsers.Content = "Гость";
        }
    }
}
