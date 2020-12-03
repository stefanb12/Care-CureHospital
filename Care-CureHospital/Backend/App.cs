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
using Model.Doctor;
using Model.Patient;
using Model.PatientDoctor;
using Model.Term;
using Repository.ExaminationSurgeryRepository;
using Repository.IDSequencer;
using Repository.MedicalRecordRepository;
using Repository.UsersRepository;
using Service.ExaminationSurgeryServices;
using Service.MedicalRecordService;
using Service.UsersServices;

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
        public PatientService PatientService;
        public DoctorService DoctorService;
        public ReportService ReportService;
        public EmailVerificationService EmailVerificationService;
        public DoctorWorkDayService DoctorWorkDayService;
        public SpetialitationService SpetialitationService;

        private App()
        {
            EmailVerificationService = new EmailVerificationService();
            MedicalExaminationService = new MedicalExaminationService(
                new MedicalExaminationRepository(new MySQLStream<MedicalExamination>(), new IntSequencer()));
            PatientFeedbackService = new PatientFeedbackService(
                new PatientFeedbackRepository(new MySQLStream<PatientFeedback>(), new IntSequencer()));
            MedicalExaminationReportService = new MedicalExaminationReportService(
               new MedicalExaminationReportRepository(new MySQLStream<MedicalExaminationReport>(), new IntSequencer()));
            PrescriptionService = new PrescriptionService(
               new PrescriptionRepository(new MySQLStream<Prescription>(), new IntSequencer()));
            MedicalRecordService = new MedicalRecordService(
               new MedicalRecordRepository(new MySQLStream<MedicalRecord>(), new IntSequencer()), EmailVerificationService);
            QuestionService = new QuestionService(
                new QuestionRepository(new MySQLStream<Question>(), new IntSequencer()));
            AnswerService = new AnswerService(
                new AnswerRepository(new MySQLStream<Answer>(), new IntSequencer()), QuestionService);
            AllergiesService = new AllergiesService(
               new AllergiesRepository(new MySQLStream<Allergies>(), new IntSequencer()));
            PatientService = new PatientService(
               new PatientRepository(new MySQLStream<Patient>(), new IntSequencer()));
            SurveyService = new SurveyService(
               new SurveyRepository(new MySQLStream<Survey>(), new IntSequencer()), MedicalExaminationService, AnswerService);
            DoctorService = new DoctorService(
                new DoctorRepository(new MySQLStream<Doctor>(), new IntSequencer()));
            ReportService = new ReportService(
               new ReportRepository(new MySQLStream<Report>(), new IntSequencer()));
            DoctorWorkDayService = new DoctorWorkDayService(
                new DoctorWorkDayRepository(new MySQLStream<DoctorWorkDay>(), new IntSequencer()));
            SpetialitationService = new SpetialitationService(
                new SpecialitationRepository(new MySQLStream<Specialitation>(), new IntSequencer()));
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
