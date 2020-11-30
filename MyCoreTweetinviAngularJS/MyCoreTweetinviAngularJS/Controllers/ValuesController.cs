using System;
using System.Collections.Generic; 
using System.Configuration; 
using System.Web.Http; 
using Console = System.Console;
using MyCoreTweetinviAngularJS.DataAccessLayer; 
using MyCoreTweetinviAngularJS.Models;

namespace MyCoreTweetinviAngularJS.Controllers
{

    public class ValuesController : ApiController
    {
        [HttpGet]
        public List<Twit> GetTweet(string searchInput)
        {
            Twitter tw = new Twitter(ConfigurationManager.AppSettings["ConsumerKey"], ConfigurationManager.AppSettings["ConsumerSecret"], ConfigurationManager.AppSettings["AccessToken"], ConfigurationManager.AppSettings["AccessTokenSecret"]);

            //tw.PublishTweet("Hello world");

            return tw.GetTweets(searchInput);

        }
    } 
}

