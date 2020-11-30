using System;
using System.Collections.Generic;
using Tweetinvi;
using System.Configuration;
using Tweetinvi.Models;
using MyCoreTweetinviAngularJS.Models; 

namespace MyCoreTweetinviAngularJS.DataAccessLayer
{
    public class Twitter 
    {
        public string ConsumerKey;
        public string ConsumerSecret;
        public string AccessToken;
        public string AccessTokenSecret;
        public Twitter(string ConsumerKey, string ConsumerSecret, string AccessToken, string AccessTokenSecret)
        {
            this.ConsumerKey = ConsumerKey;
            this.ConsumerSecret = ConsumerSecret;
            this.AccessToken = AccessToken;
            this.AccessTokenSecret = AccessTokenSecret;
        }
        public List<Twit> GetTweets(string searchInput)
        {
            Auth.SetUserCredentials(ConsumerKey, ConsumerSecret, AccessToken, AccessTokenSecret);

            List<Twit> tweets = new List<Twit>();

            var stream = Stream.CreateFilteredStream();
            stream.AddTrack(searchInput);
            stream.AddTweetLanguageFilter(LanguageFilter.English);
            stream.MatchingTweetReceived += (sender, arguments) =>
            {
                tweets.Add(new Twit { Id = arguments.Tweet.Id, Text = arguments.Tweet.Text });
                if (tweets.Count >= 2)
                {
                    stream.StopStream();
                }

            };
            stream.StartStreamMatchingAllConditions();
            return tweets;
        }

    }
}
