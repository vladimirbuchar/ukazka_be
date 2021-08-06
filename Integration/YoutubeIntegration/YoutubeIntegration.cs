using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Integration.HttpClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;

namespace Integration.YoutubeIntegration
{
    public class YoutubeIntegration : IYoutubeIntegration
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClient _httpClient;
        public YoutubeIntegration(IConfiguration configuration, IHttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        public string CreateLiveBroadcastEvent(string eventTitle, DateTime eventStartDate)
        {
            string[] scopes = new string[] { YouTubeService.Scope.Youtube,  // view and manage your YouTube account
                                             YouTubeService.Scope.YoutubeForceSsl,
                                             YouTubeService.Scope.Youtubepartner,
                                             YouTubeService.Scope.YoutubepartnerChannelAudit,
                                             YouTubeService.Scope.YoutubeReadonly,
                                             YouTubeService.Scope.YoutubeUpload};


            // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = _configuration.GetSection("Google").GetSection("ClientId").Value, 
                ClientSecret = _configuration.GetSection("Google").GetSection("ClientSecret").Value }
                                                                                         , scopes
                                                                                         , "vladimirbuchar@gmail.com"
                                                                                         , CancellationToken.None
                                                                                         , new FileDataStore("Daimto.YouTube.Auth.Store")).Result;

            YouTubeService loginService = new YouTubeService(new YouTubeService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = _configuration.GetSection("Google").GetSection("AppName").Value,
            });


            ClientSecrets secrets = new ClientSecrets()
            {
                ClientId = _configuration.GetSection("Google").GetSection("ClientId").Value,
                ClientSecret = _configuration.GetSection("Google").GetSection("ClientSecret").Value
            };
            TokenResponse token = new TokenResponse { RefreshToken = _configuration.GetSection("Google").GetSection("RefreshToken").Value };
            UserCredential credentials = new UserCredential(new GoogleAuthorizationCodeFlow(
            new GoogleAuthorizationCodeFlow.Initializer { ClientSecrets = secrets }),
            "user", token);
            YouTubeService service = new YouTubeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credentials,
                ApplicationName = _configuration.GetSection("Google").GetSection("AppName").Value
            });
            LiveBroadcast broadcast = new LiveBroadcast
            {
                Kind = "youtube#liveBroadcast",
                Snippet = new LiveBroadcastSnippet
                {
                    Title = eventTitle,
                    ScheduledStartTime = eventStartDate
                },
                Status = new LiveBroadcastStatus { PrivacyStatus = "public" }
            };
            LiveBroadcastsResource.InsertRequest request = service.LiveBroadcasts.Insert(broadcast, "id,snippet,status");
            LiveBroadcast response = request.Execute();
            return response.Id;
        }
    }
}
