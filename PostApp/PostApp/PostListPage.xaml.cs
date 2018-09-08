using PostApp.Data;
using PostApp.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PostApp
{
    public partial class MainPage : ContentPage
    {
        private DataRetriever dataRetriever;
        public ObservableCollection<Post> PostsList { get; }

        public MainPage()
        {
            InitializeComponent();

            ListLoadActivityIndicator.BindingContext = this;
            IsBusy = false;

            this.dataRetriever = new DataRetriever();

            PostsList = new ObservableCollection<Post>();
            PostsListView.ItemsSource = PostsList;

            LoadPostData();

            PostsListView.ItemSelected += PostsListView_ItemSelected;
        }

        async void LoadPostData()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    await Task.Run(() => {
                        List<Post> posts = dataRetriever.GetPosts();
                        foreach (Post p in posts)
                        {
                            PostsList.Add(p);
                        }
                    });
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        private void PostsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CommentListPage comments = new CommentListPage(e.SelectedItem as Post);
                Navigation.PushAsync(comments);
            }

            PostsListView.SelectedItem = null;
        }
    }
}
