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
using System.Windows.Resources;

namespace BMIproject
{
    /// <summary>
    /// Interaction logic for bmiWindow.xaml
    /// </summary>
    public partial class bmiWindow : Window
    {
        double high = 0;
        double weigh = 0;
        public bmiWindow()
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
                double ft = feet / 3.280809;
                high = ft;
            }
            else if (heights == "cm")
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            double totalbmi = (Convert.ToDouble(weigh)) / (Convert.ToDouble(high) * (Convert.ToDouble(high)));
            txtbmitotal.Text = Convert.ToString(totalbmi);


            if (totalbmi <= 18.5)
            {
                txtdetails.Text = Convert.ToString("If your BMI is less than 18.5, it falls\r\nwithin the underweight range.");
            }
            else if (totalbmi >= 18.5 && totalbmi <= 24.9)
            {
                txtdetails.Text = Convert.ToString("If your BMI is 18.5 to 24.9, it falls\r\nwithin the Healthy Weight range.");

            }
            else if (totalbmi >= 25 && totalbmi <= 29.9)
            {
                txtdetails.Text = Convert.ToString("If your BMI is 25.0 to 29.9, it falls\r\nwithin the overweight range.");
            }
            else if (totalbmi >= 30)
            {
                txtdetails.Text = Convert.ToString("If your BMI is 30.0 or higher,it\r\nfalls within the obese range.");
            }
        }
    }
}
