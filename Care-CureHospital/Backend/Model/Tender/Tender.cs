﻿using HealthClinic.Repository;
using Model.DoctorMenager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Tender
{
    public class Tender : IIdentifiable<int>
    {
        public int Id { get; set; }

        public String MedicamentName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Active { get; set; }

        public Tender()
        {

        }

        public Tender(int id, String medicamentName, DateTime startDate, DateTime endDate, bool active)
        {
            Id = id;
            MedicamentName = medicamentName;
            StartDate = startDate;
            EndDate = endDate;
            Active = active;
        }

        public int GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(int id)
        {
            throw new NotImplementedException();
        }
    }
}