using DbsCard.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace DbsCard.Test
{
    [TestClass]
    public class UnitTest1
    {
        private AppDbContext _context;
        private ServiceProvider _serviceProvider;
        public UnitTest1()
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=DbsCard;Trusted_Connection=True;ConnectRetryCount=0";

            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(
               (options => options.UseSqlServer(connectionString)));

            _serviceProvider = services.BuildServiceProvider();
            _context = _serviceProvider.GetService<AppDbContext>();
        }
        [TestMethod]
        public async Task Add_ImgFrURL_If_Exist()
        {
            Assert.IsNotNull(_context);
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                using (HttpClient client = new HttpClient())
                {
                    foreach (var card in _context.Cards.Where(x => x.DateDeleted == null && !x.IsSideCard && !x.IsPR))
                    {
                        var imgFr = "https://static.cardgame.fr/images/cards_medium/" + card.BaseCardNumber + (card.IsLeader ? "LF" : "") +".png" ;
                        var response = await client.GetAsync(imgFr);
                        if (response.IsSuccessStatusCode)
                        {
                            card.CardImgFr = imgFr;
                        }
                        else
                        {
                            w.WriteLine($"[1] image {imgFr}  doesn't exist");
                            imgFr = "http://www.dbs-cardgame.com/europe-fr/images/cartes/cardimg/" + card.BaseCardNumber + ".png";
                            response = await client.GetAsync(imgFr);
                            if (response.IsSuccessStatusCode)
                            {
                                card.CardImgFr = imgFr;
                            }
                            else
                            {
                                w.WriteLine($"[2] image {imgFr}  doesn't exist");
                                response = await client.GetAsync("http:"+card.CardImg);
                                if (!response.IsSuccessStatusCode)
                                {
                                    w.WriteLine($"[3] image {card.CardImg}  doesn't exist");
                                    card.CardImg = null;
                                }
                            }
                        }
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }

        [TestMethod]
        public async Task Check_Number_Of_Card_Is_Right()
        {
            Assert.IsNotNull(_context);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            using (HttpClient client = new HttpClient())
            {
                foreach (var card in _context.Cards.Where(x => x.DateDeleted == null && !x.IsSideCard && !x.IsPR))
                {
                    var token = card.BaseCardNumber.Split('-');
                    if(dict.ContainsKey(token[0]))
                    {
                        int n = int.Parse(token[1]);
                        if (dict[token[0]] < n)
                            dict[token[0]] = n;
                    }
                    else
                    {
                        dict.Add(token[0], int.Parse(token[1]));
                    }
                }
                
                using (StreamWriter w = File.AppendText("dict.txt"))
                {
                    int total = 0;
                    foreach (var item in dict.OrderBy(x => x.Key))
                    {
                        total += item.Value;
                        w.WriteLine("[" + item.Key + "] " + "[" + item.Value + "]");
                        for(int i = 1; i < item.Value;i++)
                        {
                            if(_context.Cards.All(x => !x.CardNumber.Contains(item.Key + "-" + i.ToString("D3")) && !x.CardNumber.Contains(item.Key + "-" + i.ToString("D2"))))
                            {
                                w.WriteLine($"{ item.Key }-{ i.ToString("D3") } doesn't exist");
                            }
                        }
                    }
                    w.WriteLine(total);
                }
            }
        }
    }
}
