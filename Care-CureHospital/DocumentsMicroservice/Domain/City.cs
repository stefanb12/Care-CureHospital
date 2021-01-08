﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Domain
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public City()
        {
        }

        public City(string name, string address, Country country)
        {
            Name = name;
            Address = address;
            CountryId = country.Id;
            Country = country;
        }

    }
}
