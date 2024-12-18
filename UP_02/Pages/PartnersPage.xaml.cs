using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace UP_02.Pages
{
    /// <summary>
    /// Логика взаимодействия для PartnersPage.xaml
    /// </summary>
    public partial class PartnersPage : Page
    {
        private List<Partners> partners;

        // Список данных о продажах
        private List<PartnerProducts> salesData;


        public PartnersPage()
        {
            InitializeComponent();
            //partnersListView.ItemsSource = Entities1.GetContext().Partners.ToList();
            partners = Entities1.GetContext().Partners.ToList();

            salesData = Entities1.GetContext().PartnerProducts.ToList();

            if (salesData == null)
            {
                MessageBox.Show("Данные о продажах отсутствуют!");
                return;
            }

            // Расчет скидок
            var discounts = DiscountCalculator.CalculateDiscounts(salesData);

            // Привязка скидок к данным о партнерах
            foreach (var partner in partners)
            {
                if (discounts.ContainsKey(partner.PartnerID))
                {
                    partner.Discount = discounts[partner.PartnerID];
                }
            }

            // Привязка данных к ListView
            partnersListView.ItemsSource = partners;



        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)

            {
                Entities1.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                partnersListView.ItemsSource = Entities1.GetContext().Partners.ToList();

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage(null));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage((sender as Button).DataContext as Partners));
        }

        private void partnersListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox)
            {

                var selectedItem = listBox.SelectedItem as Partners;


                if (selectedItem != null)
                {
                    NavigationService.Navigate(new AddPage(selectedItem));
                }
            }
        }

        private void HistoryBTN_Click(object sender, RoutedEventArgs e)
        {

            var selectedItem = partnersListView.SelectedItem as Partners;
            if (selectedItem != null)
            {
                NavigationService.Navigate(new HistoryPage(selectedItem));
                 
            }
            else
            {
                MessageBox.Show("Выберите партнера");
            }

        }

    }
}
