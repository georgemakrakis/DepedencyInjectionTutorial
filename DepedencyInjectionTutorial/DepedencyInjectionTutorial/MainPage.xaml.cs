using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DepedencyInjectionTutorial
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void DownloadButton_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var uri = "https://yourservice.com/myfile.pdf";
            client.BaseAddress = new Uri(uri);
            client.MaxResponseContentBufferSize = 256000;

            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsByteArrayAsync();

            DependencyService.Get<IPdfActions>().WriteReadData("myfilename.pdf", responseContent);
        }
    }
}
