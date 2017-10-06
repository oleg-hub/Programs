using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetEmails.Web.Models
{
    public class LettersListViewModel
    {
        public List<Message> Mails { get; set; }
    }
}