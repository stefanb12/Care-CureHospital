﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.DoctorMenager;
using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Backend.Repository.DirectorRepository;
using Repository.IDSequencer;
using Repository;


namespace Backend.Repository.DirectorRepository
{
    public class ReportRepository : MySQLRepository<Report, int>, IReportRepository
    {

        public ReportRepository(IMySQLStream<Report> stream, ISequencer<int> sequencer):base(stream, sequencer)
        {

        }
    }
}
