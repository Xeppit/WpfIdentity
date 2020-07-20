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
using IdentityModel.Client;
using IdentityModel.OidcClient;

namespace WpfIdentity.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OidcClient _oidcClient = null;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += Start;
        }

        public async void Start(object sender, RoutedEventArgs e)
        {
            var options = new OidcClientOptions()
            {
                Authority = "https://localhost:5000",
                ClientId = "wpf",
                Scope = "openid profile email api",
                RedirectUri = "https://notused",
                Browser = new WpfEmbeddedBrowser()
            };

            _oidcClient = new OidcClient(options);

            LoginResult result;
            try
            {
                result = await _oidcClient.LoginAsync();
            }
            catch (Exception ex)
            {
                Message.Text = $"Unexpected Error: {ex.Message}";
                return;
            }

            if (result.IsError)
            {
                Message.Text = result.Error == "UserCancel" ? "The sign-in window was closed before authorization was completed." : result.Error;
            }
            else
            {
                var name = result.User.Identity.Name;
                Message.Text = $"Hello {name}";
            }
        }
    }
}
