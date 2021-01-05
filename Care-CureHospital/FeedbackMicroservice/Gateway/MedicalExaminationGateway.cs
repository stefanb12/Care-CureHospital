﻿using FeedbackMicroservice.Domain;
using FeedbackMicroservice.Gateway.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FeedbackMicroservice.Gateway
{
    public class MedicalExaminationGateway : IMedicalExaminationGateway
    {
        public MedicalExamination GetMedicalExaminationById(int id)
        {
           
            MedicalExamination medicalExamination = null;
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetMedicalExaminationService() + "/api/medicalExamination/getMedicalExamination/" + id)
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    medicalExamination = JsonConvert.DeserializeObject<MedicalExamination>(json.Result);
                });
            task.Wait();
            
            return medicalExamination;
            
        }
        public string GetMedicalExaminationService()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "5171";

            return $"http://{origin}:{port}";
        }
    }
}
