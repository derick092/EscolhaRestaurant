using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolhaRestauranteCore.Model
{
    public class Restaurant
    {
        public Restaurant() { }
        public Restaurant(string id, string name)
        {
            ID = id;
            Name = name;
        }
        public Restaurant(string id, string name, DateTime date)
        {
            ID = id;
            Name = name;
            LastChoiceDate = date;
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime LastChoiceDate { get; set; }
    }
}
