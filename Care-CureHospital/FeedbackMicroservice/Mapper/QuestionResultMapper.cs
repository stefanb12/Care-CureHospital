﻿using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Dto;
using System.Collections.Generic;
using System.Linq;

namespace FeedbackMicroservice.Mapper
{
    public class QuestionResultMapper
    {
        public static List<QuestionResultDto> CreateQuestionResultsDto(Dictionary<int, List<int>> results)
        {
            List<QuestionResultDto> questionResults = new List<QuestionResultDto>();
            foreach (int key in results.Keys)
            {
                questionResults.Add(new QuestionResultDto(key, results[key]));
            }

            return questionResults;
        }

        public static List<DoctorResultDto> CreateDoctorResultsDto(Dictionary<int, Dictionary<int, List<int>>> results, IEnumerable<Doctor> doctors)
        {
            List<DoctorResultDto> doctorResults = new List<DoctorResultDto>();
            foreach (int key in results.Keys)
            {
                Doctor doctor = doctors.FirstOrDefault(doctor => doctor.Id == key);
                doctorResults.Add(new DoctorResultDto(new Doctor(doctor.Name, doctor.Surname, doctor.Username, doctor.Specialitation), CreateQuestionResultsDto(results[key])));
            }

            return doctorResults;
        }
    }
}
