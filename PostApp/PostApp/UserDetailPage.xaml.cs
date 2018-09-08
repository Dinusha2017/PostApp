using PostApp.Data;
using PostApp.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetailPage : ContentPage
	{
        private int userId;

        private DataRetriever dataRetriever;
        public User Author { get; set; }

        public UserDetailPage ()
		{
			InitializeComponent ();
		}

        public UserDetailPage(int userId)
            :this()
        {
            this.userId = userId;

            ListLoadActivityIndicator.BindingContext = this;
            IsBusy = false;

            this.dataRetriever = new DataRetriever();

            LoadAuthorData();
        }

        async void LoadAuthorData()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    await Task.Run(() => {
                        Author = dataRetriever.GetAuthorOfPost(userId);
                    });
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
    }
}