using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EliseCouture.Web.Controllers
{
    public class BlogController : Controller
    {
        const string ClientKey = "cTLPNguFD505HDWDcusDq3KcCjAaF2fr02fgvJu8f5kNx1Ip2r";
        const string ClientSecret = "TA0WeGbvQSLu3n84jjKHZh4g7QoMcTLmjrZ6GjvWwbBdFoeKFZ";

        public ActionResult Index(string x, string y)
        {
            string authorizedToken = "Hp6hOEFek6rujYpVGChGo3mOBY72sARiy8zLCTCHgTyuGvP88C";
            string authorizedTokenSecret = "yaUwgDzoJFUh7bGp2jnAhvp1MgZekN8bCMBnPvBfWDlhIYy1uX";
            string blog = "pedalboston.tumblr.com";

            //TumblrClient tumblr = new TumblrClient(ClientKey, ClientSecret, String.Empty, authorizedToken, authorizedTokenSecret);
            //return View(tumblr.Blog.GetPosts(blog).response.posts);
            
            return View();
        }
    }
}
