using EscolhaRestauranteCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolhaRestauranteCore.Data
{
    public class FakeDB
    {
        private static FakeDB dbInstance;

        private FakeDB()
        {
            InitializePeoples();
            InitializeRestaurants();
            Votes = new List<Vote>();
        }

        public static FakeDB GetInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new FakeDB();
            }

            return dbInstance;
        }

        private List<People> Peoples { get; set; }

        private List<Restaurant> Restaurants { get; set; }

        private List<Vote> Votes { get; set; }

        public List<People> GetPeoples()
        {
            return Peoples;
        }

        public List<Restaurant> GetRestaurants()
        {
            return Restaurants;
        }

        public List<Vote> GetVotes()
        {
            return Votes;
        }

        public Restaurant GetRestaurantByDate(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    break;
                case DayOfWeek.Monday:
                    date = date.AddDays(-1);
                    break;
                case DayOfWeek.Tuesday:
                    date = date.AddDays(-2);
                    break;
                case DayOfWeek.Wednesday:
                    date = date.AddDays(-3);
                    break;
                case DayOfWeek.Thursday:
                    date = date.AddDays(-4);
                    break;
                case DayOfWeek.Friday:
                    date = date.AddDays(-5);
                    break;
                case DayOfWeek.Saturday:
                    date = date.AddDays(-6);
                    break;
            }

            var moreVoted = Votes.Where(v => v.VotingDate.Date >= date.Date)
                .OrderByDescending(o => o.VotingDate)
                .GroupBy(g => g.IDRestaurant).FirstOrDefault().FirstOrDefault();

            var restaurantOfTheDay = Restaurants.Where(r => r.LastChoiceDate.Date <= date.Date && r.ID == moreVoted.IDRestaurant).FirstOrDefault();

            Restaurants.Where(r => r.ID == restaurantOfTheDay.ID).FirstOrDefault().LastChoiceDate = DateTime.Now;

            return restaurantOfTheDay;
        }

        public bool AddVote(string peopleId, string restaurantId, DateTime date)
        {
            var vote = Votes.Where(v => v.IDPeople == peopleId && v.IDRestaurant == restaurantId && v.VotingDate.Date == date.Date).FirstOrDefault();

            if (vote == null)
            {
                Votes.Add(new Vote(peopleId, restaurantId, date));
                return true;
            }

            return false;
        }

        private void InitializePeoples()
        {
            Peoples = new List<People>()
            {
                new People("1", "Juracy"),
                new People("2", "Lindomar"),
                new People("3", "Rouxinol"),
                new People("4", "Rubenito")
            };
        }

        private void InitializeRestaurants()
        {
            Restaurants = new List<Restaurant>()
            {
                new Restaurant("1","Bocadinha", new DateTime(2018, 8, 4)),
                new Restaurant("2","Pouco Rango", new DateTime(2018, 8, 3)),
                new Restaurant("3","Lanchão 10Barra10", new DateTime(2018, 8, 2)),
                new Restaurant("4","Merendinha da Tia Fifi", new DateTime(2018, 7, 30)),
                new Restaurant("5","Bandeijão do Betão", new DateTime(2018, 7, 29)),
                new Restaurant("6","Sushi do Ling-Sensei", new DateTime(2018, 7, 28))
            };
        }

    }
}