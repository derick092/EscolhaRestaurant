using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolhaRestauranteCore.Model
{
    public class Vote
    {
        public Vote(){}
        public Vote(string idPeople, string idRestraunt, DateTime votingDate)
        {
            IDPeople = idPeople;
            IDRestaurant = idRestraunt;
            VotingDate = votingDate;
        }

        public string IDPeople { get; set; }
        public string IDRestaurant { get; set; }
        public DateTime VotingDate { get; set; }
    }
}
