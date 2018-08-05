using EscolhaRestauranteCore.Data;
using EscolhaRestauranteCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolhaRestauranteCore.Controller
{
    public class RestaurantController
    {
        public List<Restaurant> GetRestaraunts()
        {
            return FakeDB.GetInstance().GetRestaurants();
        }

        public Restaurant GetRestaurantOfTheDay(DateTime date)
        {
            return FakeDB.GetInstance().GetRestaurantByDate(date);
        }
    }
}
