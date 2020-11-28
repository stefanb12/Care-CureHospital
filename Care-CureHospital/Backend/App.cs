﻿using Backend.Model.BlogAndNotification;
using Backend.Model.DoctorMenager;
using Backend.Model.PatientDoctor;
using Backend.Repository.BlogNotificationRepository;
using Backend.Repository.DirectorRepository;
using Backend.Repository.ExaminationSurgeryRepository;
using Backend.Repository.MySQL.Stream;
using Backend.Repository.UsersRepository;
using Backend.Service.BlogNotificationServices;
using Backend.Service.DirectorService;
using Backend.Service.ExaminationSurgeryServices;
using Backend.Service.UsersServices;
using Model.AllActors;
using Model.DoctorMenager;
using Model.Patient;
using Model.PatientDoctor;
using Model.Term;
using Repository.ExaminationSurgeryRepository;
using Repository.IDSequencer;
using Repository.MedicalRecordRepository;
using Service.ExaminationSurgeryServices;
using Repository.MedicamentRepository;
using Service.MedicalRecordService;
using Service.MedicamentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class App
    {
        private static App _instance = null;

        public SurveyService SurveyService;
        public QuestionService QuestionService;
        public AnswerService AnswerService;
        public PatientFeedbackService PatientFeedbackService;
        public MedicalExaminationService MedicalExaminationService; 
        public MedicalExaminationReportService MedicalExaminationReportService;
        public PrescriptionService PrescriptionService;
        public MedicalRecordService MedicalRecordService;
        public AllergiesService AllergiesService;
        public DoctorService DoctorService;
        public ReportService ReportService;


        private App()
        {
            MedicalExaminationService = new MedicalExaminationService(
                new MedicalExaminationRepository(new MySQLStream<MedicalExamination>(), new IntSequencer()));
            PatientFeedbackService = new PatientFeedbackService(
                new PatientFeedbackRepository(new MySQLStream<PatientFeedback>(), new IntSequencer()));
            MedicalExaminationReportService = new MedicalExaminationReportService(
               new MedicalExaminationReportRepository(new MySQLStream<MedicalExaminationReport>(), new IntSequencer()));
            PrescriptionService = new PrescriptionService(
               new PrescriptionRepository(new MySQLStream<Prescription>(), new IntSequencer()));
            MedicalRecordService = new MedicalRecordService(
               new MedicalRecordRepository(new MySQLStream<MedicalRecord>(), new IntSequencer()));
            QuestionService = new QuestionService(
                new QuestionRepository(new MySQLStream<Question>(), new IntSequencer()));
            AnswerService = new AnswerService(
                new AnswerRepository(new MySQLStream<Answer>(), new IntSequencer()), QuestionService);
            AllergiesService = new AllergiesService(
               new AllergiesRepository(new MySQLStream<Allergies>(), new IntSequencer()));
            SurveyService = new SurveyService(
               new SurveyRepository(new MySQLStream<Survey>(), new IntSequencer()), MedicalExaminationService, AnswerService);
            DoctorService = new DoctorService(
                new DoctorRepository(new MySQLStream<Doctor>(), new IntSequencer()));
            ReportService = new ReportService(
               new ReportRepository(new MySQLStream<Report>(), new IntSequencer()));
        }

        public static App Instance()
        {
            if (_instance == null)
            {
                _instance = new App();
            }
            return _instance;
        }
        
    }
}
