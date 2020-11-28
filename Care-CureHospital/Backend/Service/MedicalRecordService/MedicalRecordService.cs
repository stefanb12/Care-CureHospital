/***********************************************************************
 * Module:  MedicalRecordService.cs
 * Author:  Stefan
 * Purpose: Definition of the Class Service.MedicalRecordService
 ***********************************************************************/

using Backend.Service.UsersServices;
using Model.PatientDoctor;
using Repository.MedicalRecordRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace Service.MedicalRecordService
{
    public class MedicalRecordService : IService<MedicalRecord, int>
    {
        public IMedicalRecordRepository medicalRecordRepository;
        public IEmailVerificationService emailVerificationService;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository, IEmailVerificationService emailVerificationService)
        {
            this.medicalRecordRepository = medicalRecordRepository;
            this.emailVerificationService = emailVerificationService;
        }

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            this.medicalRecordRepository = medicalRecordRepository;
        }

        public MedicalRecord GetMedicalRecordForPatient(int patientID)
        {
            return medicalRecordRepository.GetAllEntities().ToList().Find(medicalRecord => medicalRecord.PatientId == patientID); ;
        }

        public MedicalRecord GetMedicalRecordForPatientByUsername(string username)
        {
            return medicalRecordRepository.GetAllEntities().ToList().Find(medicalRecord => medicalRecord.Patient.Username.Equals(username)); ;
        }

        public void ActivatePatientMedicalRecord(MedicalRecord medicalRecord)
        {
            medicalRecord.ActiveMedicalRecord = true;
            UpdateEntity(medicalRecord);
        }

        public MedicalRecord CreatePatientMedicalRecord(MailAddress email, MedicalRecord medicalRecord)
        {
            emailVerificationService.SendVerificationEmailLink(email, medicalRecord.Patient.Username);
            return AddEntity(medicalRecord);
        }

        public MedicalRecord GetEntity(int id)
        {
            return medicalRecordRepository.GetEntity(id);
        }

        public IEnumerable<MedicalRecord> GetAllEntities()
        {
            return medicalRecordRepository.GetAllEntities();
        }

        public MedicalRecord AddEntity(MedicalRecord entity)
        {
            return medicalRecordRepository.AddEntity(entity);
        }

        public void UpdateEntity(MedicalRecord entity)
        {
            medicalRecordRepository.UpdateEntity(entity);
        }

        public void DeleteEntity(MedicalRecord entity)
        {
            medicalRecordRepository.DeleteEntity(entity);
        }

        public MedicalRecord GetMedicalRecordByPatient(Model.AllActors.Patient patient)
        {
            return medicalRecordRepository.GetMedicalRecordByPatient(patient);
        }
    }
}