using PostApp.Data;
using PostApp.Net;

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

            Title = userId.ToString() + "'s Profile";

            this.dataRetriever = new DataRetriever();

            Author = dataRetriever.GetAuthorOfPost(userId);

            BindingContext = Author;
        }
    }
}