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
using System.Net.Http;
using WpfHelloAPP;
using Microsoft.Extensions.Configuration;
using System.IO;




namespace WpfHelloAPP
{  
    public partial class MainWindow : Window
    {
        private readonly WeatherService _weatherService = new WeatherService();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            var MyConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
           
            var apiKey = MyConfig.GetSection("AppSettings")["ApiKey"];
           

            Console.WriteLine(apiKey);
       


            string city = "London"; // Or get from user input
            //string apiKey = "*********"; 

            string weatherData = await _weatherService.GetWeatherDataAsync(city, apiKey);
            Console.WriteLine(weatherData);
            

            // Display the weatherData in your application (e.g., in a text box or label)
            // ...
        }


    }
}
