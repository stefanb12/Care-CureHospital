﻿using Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Repository
{
    public interface IQuestionRepository : IRepository<Question, int>
    {
    }
}
