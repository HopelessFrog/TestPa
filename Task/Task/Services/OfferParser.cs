using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using Task.Model;
using System.IO;
using Task.Services.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using System.Xml;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using Acr.UserDialogs;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Configuration;

namespace Task.Services
{
    public class OfferParser : IOfferParser
    {

        public async System.Threading.Tasks.Task<List<Offer>> Parse()
        {
            UserDialogs.Instance.ShowLoading("Loading", MaskType.Black);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var url = "https://partner.market.yandex.ru/pages/help/YML.xml";

            List<Offer> offers = new List<Offer>();


            using (var client = new System.Net.Http.HttpClient())
            {
                string result = "";

                try
                {
                    var response = await client.GetAsync(url);

                    var stream = await response.Content.ReadAsStreamAsync();
                    using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(1251)))
                    {
                        result = await reader.ReadToEndAsync();
                    }
                  

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    UserDialogs.Instance.HideLoading();
                   

                    return await System.Threading.Tasks.Task.FromResult(new List<Offer>());
                }

                

                XmlDocument document = new XmlDocument();
                document.LoadXml(result);
                XmlNodeList eList = document.GetElementsByTagName("offer");

                foreach (XmlNode node in eList)
                {
                    offers.Add(new Offer(node.Attributes["id"].Value, JsonConvert.SerializeXmlNode(node)));

                }


            }

            await System.Threading.Tasks.Task.Delay(500);
            UserDialogs.Instance.HideLoading();

            return await System.Threading.Tasks.Task.FromResult(offers);
        }
    }
}


