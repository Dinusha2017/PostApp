using Newtonsoft.Json;
using PostApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PostApp.Net
{
    public class DataRetriever
    {
        /// <summary>
        /// This method retrieves all the posts.
        /// </summary>
        /// <returns></returns>
        public List<Post> GetPosts()
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("https://jsonplaceholder.typicode.com/posts");
                return JsonConvert.DeserializeObject<Post[]>(json).ToList();
            }
        }

        /// <summary>
        /// This method retrieves all the comments made on a particular post using the PostId.
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns></returns>
        public List<Comment> GetCommentsPerPost(int PostId)
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("https://jsonplaceholder.typicode.com/posts/" + PostId.ToString() + "/comments");
                return JsonConvert.DeserializeObject<Comment[]>(json).ToList();
            }
        }

        /// <summary>
        /// This method retrieves the details of the author of a particular post using UserId.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public User GetAuthorOfPost(int UserId)
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("https://jsonplaceholder.typicode.com/users/" + UserId.ToString());
                return JsonConvert.DeserializeObject<User>(json);
            }
        }
    }
}
