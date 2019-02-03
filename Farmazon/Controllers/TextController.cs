using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace Farmazon.Controllers
{
    public class TextController : TwilioController
    {
        [AllowAnonymous]
        [HttpPost]
        public TwiMLResult Index()
        {
            var requestBody = Request.Form["Body"];
            var response = new MessagingResponse();
            Regex wantBuy = new Regex(@"I want to buy\s([\w\s]+)", RegexOptions.IgnoreCase);
            Regex message = new Regex(@"Message\s(\w+)\s", RegexOptions.IgnoreCase);
            Regex wantSell = new Regex(@"I want to sell\s([\w\s]+)/(\d+)/(\d+)", RegexOptions.IgnoreCase);
            Regex inArea = new Regex(@"for sale near me", RegexOptions.IgnoreCase);

            switch ("")
            {
                case var val when wantBuy.IsMatch(requestBody):
                    string item = wantBuy.Match(requestBody).Groups[1].Value;
                    response.Message($"The best farmer in your area that sells {item} is Farmer Jim Bo!\n" +
                        $"Reply Message JimBo <message> to arrange your purchase!");
                    break;
                case var val when message.IsMatch(requestBody):
                    string user = message.Match(requestBody).Groups[1].Value;
                    response.Message($"Hi! This is {user}! I would love to sell to you, come to my farm to pick up at:\n" +
                        $"1234 Street Ave Farmington, MN 55555");
                    break;
                case var val when inArea.IsMatch(requestBody):
                    response.Message($"Stuff in your area.");
                    break;
                case var val when wantSell.IsMatch(requestBody):
                    string itemList = wantSell.Match(requestBody).Groups[1].Value;
                    string quant = wantSell.Match(requestBody).Groups[2].Value;
                    string price = wantSell.Match(requestBody).Groups[3].Value;
                    response.Message($"Your {quant} {itemList} for ${price} have been listed!");
                    break;
                default:
                    response.Message("Commands: \n" +
                        "Message <user> <message>\n" +
                        "I want to buy <item>\n" +
                        "For sale near me\n" +
                        "I want to sell <item>/<count>/<price>");
                    break;
            }

            return TwiML(response);
        }
    }
}

