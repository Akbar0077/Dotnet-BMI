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

namespace BMIproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double high=0 ;
        double weigh=0 ;
        
        public MainWindow()
        {

            InitializeComponent();
            string[] height = { "ft", "cm", "m" };
            cmbheight.ItemsSource = height;
            string[] weight = { "kg", "lbs" };
            cmbweight.ItemsSource = weight;
            
        }

       

        private void txtheight_TextChanged(object sender, TextChangedEventArgs e)
        {
            string heights = cmbheight.SelectedItem.ToString();
            if (heights == "ft")
            {
                double feet = Convert.ToDouble(txtheight.Text);
                double m =feet/ 3.280809;
                high= m;
            }
            else if (heights =="cm")
            {
                double cm = Convert.ToDouble(txtheight.Text);
                double m = cm / 100;
                high = m;
            }
            else if (heights == "m")
            {
                double m = Convert.ToDouble(txtheight.Text);
                high = m;
            }
        }

        private void txtweight_TextChanged(object sender, TextChangedEventArgs e)
        {
            string weights = cmbweight.SelectedItem.ToString();
            if (weights == "kg")
            {
                double kg = Convert.ToDouble(txtweight.Text);
                weigh = kg;
            }
            else if (weights == "lbs")
            {
                double pound = Convert.ToDouble(txtweight.Text);
                double kg = pound * 2.2046226218;
                weigh = kg;
            }
        }
        private void btnbmi_Click(object sender, RoutedEventArgs e)
        {
            double totalbmi = (Convert.ToDouble( weigh)) / (Convert.ToDouble( high) *(Convert.ToDouble ( high)));
            txtbmitotal.Text = Convert.ToString(totalbmi);

            
            if(totalbmi <= 18.5)
            {
                txtdetails.Text = Convert.ToString("If your BMI is less than 18.5, it falls within the underweight range.");
            }
            else if (totalbmi >= 18.5 && totalbmi <= 24.9)
            {
                txtdetails.Text=Convert.ToString("If your BMI is 18.5 to 24.9, it falls within the Healthy Weight range.");

            }
            else if (totalbmi >= 25 && totalbmi <= 29.9)
            {
                txtdetails.Text = Convert.ToString("If your BMI is 25.0 to 29.9, it falls within the overweight range.");
            }
            else if(totalbmi >= 30)
            {
                txtdetails.Text = Convert.ToString("If your BMI is 30.0 or higher, it falls within the obese range.");
            }
        }
    }
}