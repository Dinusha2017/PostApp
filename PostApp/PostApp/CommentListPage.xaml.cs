using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostApp.Data;
using PostApp.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommentListPage : ContentPage
	{
        private Post post;

        private DataRetriever dataRetriever;
        public ObservableCollection<Comment> CommentsList { get; }

        public CommentListPage ()
		{
			InitializeComponent ();
		}

        public CommentListPage(Post post)
             : this()
        {
            this.post = post;

            ListLoadActivityIndicator.BindingContext = this;
            IsBusy = false;

            this.dataRetriever = new DataRetriever();

            CommentsList = new ObservableCollection<Comment>();
            CommentsListView.ItemsSource = CommentsList;

            LoadCommentData();

            CommentsListView.ItemSelected += CommentsListView_ItemSelected;
        }

        private void CommentsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Comment selectedComment = (e.SelectedItem as Comment);
                Device.OpenUri(new Uri($"mailto:{selectedComment.Email}"));
            }

            CommentsListView.SelectedItem = null;
        }

        async void LoadCommentData()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    await Task.Run(() => {
                        List<Comment> comments = dataRetriever.GetCommentsPerPost(post.Id);
                        foreach (Comment c in comments)
                        {
                            CommentsList.Add(c);
                        }
                    });
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        private void Onclick(object sender, EventArgs e)
        {
            UserDetailPage user = new UserDetailPage(post.UserId);
            Navigation.PushAsync(user);
        }
    }
}