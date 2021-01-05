﻿using FeedbackMicroservice.Repository;
using System;
using System.Collections.Generic;


namespace FeedbackMicroservice.Domain
{

    public class Survey : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CommentSurvey { get; set; }
        public DateTime PublishingDate { get; set; }
        public int MedicalExaminationId { get; set; }

        public virtual List<Answer> Answers { get; set; }

        public Survey(int id)
        {
            Id = id;
        }

        public Survey()
        {
        }

        public Survey(int id, string title, DateTime publishingDate, string commentSurvey, List<Answer> answers)
        {
            Id = id;
            Title = title;
            PublishingDate = publishingDate;
            CommentSurvey = commentSurvey;
            Answers = answers;
        }

        public Survey(string title, DateTime publishingDate, string commentSurvey, List<Answer> answers)
        {
            Title = title;
            PublishingDate = publishingDate;
            CommentSurvey = commentSurvey;
            Answers = answers;
        }

        public Survey(int id, string title, string commentSurvey, DateTime publishingDate, int medicalExaminationID, List<Answer> answers) : this(id)
        {
            Title = title;
            CommentSurvey = commentSurvey;
            PublishingDate = publishingDate;
            MedicalExaminationId = medicalExaminationID;
            Answers = answers;
        }

        /* public Survey(int id, string title, string commentSurvey, DateTime publishingDate, int medicalExaminationID, List<Answer> answers) : this(id)
         {
             Title = title;
             CommentSurvey = commentSurvey;
             PublishingDate = publishingDate;
             MedicalExaminationId = medicalExaminationID;
             Answers = answers;
         }*/

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}

