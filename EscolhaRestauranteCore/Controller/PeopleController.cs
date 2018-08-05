using EscolhaRestauranteCore.Data;
using EscolhaRestauranteCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolhaRestauranteCore.Controller
{
    public class PeopleController
    {
        public List<People> GetPeoples()
        {
            return FakeDB.GetInstance().GetPeoples();
        }
    }
}
