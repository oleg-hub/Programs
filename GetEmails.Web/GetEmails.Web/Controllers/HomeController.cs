using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Xml;
using GetEmails.Web.Models;

namespace LettersFromGmail.Controllers
{
    public class HomeController : Controller
    {

        //public string username = "klochkov.oleh@gmail.com";/// /////////////////////////
        //public string password = "hello123g";


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LettersList( String userId = "klochkov.oleh@gmail.com"/*, String query*/)
        {
            LettersListViewModel LettersListViewModel = new LettersListViewModel();
            LettersListViewModel.Mails = new List<Message>();
            List<Message> result = new List<Message>();


            UserCredential credential;
            string[] Scopes = { GmailService.Scope.GmailReadonly };
            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/gmail-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Gmail API service.
            GmailService service = new GmailService(new BaseClientService.Initializer() /////
            {
                HttpClientInitializer = credential
                //   ApplicationName = ApplicationName,
            });


            UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
            //request.Q = query;

            do
            {
                try
                {
                    ListMessagesResponse response = request.Execute();
                    LettersListViewModel.Mails.AddRange(response.Messages);
                    //result.AddRange(response.Messages);
                    request.PageToken = response.NextPageToken;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            } while (!String.IsNullOrEmpty(request.PageToken));
            return View(LettersListViewModel);





            //Mail mail;
            //WebClient objclient = new WebClient();
            //string response = null;
            //XmlDocument xdoc = new XmlDocument();
            //LettersListViewModel LettersListViewModel = new LettersListViewModel();
            //LettersListViewModel.Mails = new List<Mail>();

            //objclient.Credentials = new NetworkCredential(IndexViewModel.Login, IndexViewModel.Password);
            //response = Encoding.UTF8.GetString(objclient.DownloadData("https://mail.google.com/mail/feed/atom"));
            //response = response.Replace("<feed version=\"0.3\" xmlns=\"http://purl.org/atom/ns#\">", "<feed>");
            //xdoc.LoadXml(response);

            //foreach (XmlNode node1 in xdoc.SelectNodes("feed/entry"))
            //{
            //    mail = new Mail();
            //    mail.From = node1.SelectSingleNode("author/email").InnerText;
            //    mail.Title = node1.SelectSingleNode("title").InnerText;
            //    mail.Summary = node1.SelectSingleNode("summary").InnerText;
            //    LettersListViewModel.Mails.Add(mail);
            //}
            //return View(LettersListViewModel);
        }

    }
}