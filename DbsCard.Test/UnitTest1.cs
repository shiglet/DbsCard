using DbsCard.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

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
        public async Task TestMethod1()
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
    }
}
