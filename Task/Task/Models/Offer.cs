using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Model
{
    public class Offer
    {
        public Offer(string id, string properties)
        {
            this.Id = id;
            this.Properties = properties;
        }

        public string Id { get; set; }
        public string Properties { get; set; }
       
    }
}
