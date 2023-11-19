using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using Generalate.Models;
namespace Generalate
{
    public static class   Utils
    {
        static string username = ConfigurationManager.AppSettings["frommail"].ToString();
        static string password = ConfigurationManager.AppSettings["password"].ToString();
        static string host = ConfigurationManager.AppSettings["host"].ToString();
        public static List<EmailMessage> ReceiveEmail(List<string> existingUid)
        {
           
            List<EmailMessage> messages = new List<EmailMessage>();
            var client = new Pop3Client();
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate(username, password);
            List<string> messageUid = client.GetMessageUids();
            var count = client.GetMessageCount();
            for (int i = 0; i < count; i++)
            {
                var uid = messageUid[i];
                if (existingUid == null || !existingUid.Any(x => x == uid))
                {
                    var message = client.GetMessage(i + 1);
                    messages.Add(new EmailMessage
                    {
                        Uid = uid,
                        EmailContent = message,
                        Attachments = message.FindAllAttachments()
                    });
                }

            }
            return messages;
        }
    }
    public class EmailMessage
    {
        [Key]
        public string Uid { get; set; }
        public Message EmailContent { get; set; }
        public List<MessagePart> Attachments { get; set; }
    }
}