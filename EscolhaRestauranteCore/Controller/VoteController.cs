using EscolhaRestauranteCore.Data;
using EscolhaRestauranteCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolhaRestauranteCore.Controller
{
    public class VoteController
    {
        public bool AddVote(string peopleId, string restaurantId, DateTime date)
        {
            return FakeDB.GetInstance().AddVote(peopleId, restaurantId, date);
        }

        public List<Vote> GetVotes()
        {
            return FakeDB.GetInstance().GetVotes();
        }
    }
}
