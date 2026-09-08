using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaSPlit.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = "";
            ErrorTextBlock.Text = "";

            string totalText = TotalTextBox.Text.Trim();
            string peopleText = PeopleTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(totalText) ||
                string.IsNullOrWhiteSpace(peopleText))
            {
                ErrorTextBlock.Text = "Palun sisesta tellimuse summa ja sööjate arv.";
                return;
            }

            if (!decimal.TryParse(totalText, out decimal total))
            {
                ErrorTextBlock.Text = "Tellimuse summa on vales vormingus.";
                return;
            }

            if (!int.TryParse(peopleText, out int people))
            {
                ErrorTextBlock.Text = "Sööjate arv peab olema täisarv.";
                return;
            }

            bool addTip = TipCheckBox.IsChecked == true;

            if (PizzaSplit.Core.BillCalculator.TryCalculate(
                total,
                people,
                addTip,
                out decimal share,
                out string error))
            {
                ResultTextBlock.Text = $"Ühe sööja kohta: {share:F2} €";
            }
            else
            {
                ErrorTextBlock.Text = error;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TotalTextBox.Clear();
            PeopleTextBox.Clear();
            TipCheckBox.IsChecked = false;
            ResultTextBlock.Text = "";
            ErrorTextBlock.Text = "";
            TotalTextBox.Focus();
        }

        private void TotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}