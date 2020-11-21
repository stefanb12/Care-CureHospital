using Model.AllActors;
using Model.DoctorMenager;
using Model.PatientDoctor;
using Moq;
using Repository.MedicalRecordRepository;
using Service.MedicalRecordService;
using System;
using System.Collections.Generic;
using Xunit;

namespace WebAppPatientTests
{
    public class MedicalRecordTest
    {
        [Fact]
        public void Find_medical_record_for_patient()
        {
            MedicalRecordService medicalRecordService = new MedicalRecordService(CreateStubRepository());

            MedicalRecord medicalRecord = medicalRecordService.GetMedicalRecordForPatient(1);

            Assert.NotNull(medicalRecord);
        }

        [Fact]
        public void Not_found_medical_record_for_patient()
        {
            MedicalRecordService medicalRecordService = new MedicalRecordService(CreateStubRepository());

            MedicalRecord medicalRecord = medicalRecordService.GetMedicalRecordForPatient(1);

            Assert.Null(medicalRecord);
        }

        private static IMedicalRecordRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicalRecordRepository>();

            var medicalRecords = new List<MedicalRecord>();
            medicalRecords.Add(new MedicalRecord(1, new Patient(1), new Anamnesis(1, "Sve je u redu", new List<Diagnosis>(), new List<Symptoms>()), new List<Allergies>(), new List<Medicament>()));
            medicalRecords.Add(new MedicalRecord(2, new Patient(2), new Anamnesis(2, "Sve je u redu", new List<Diagnosis>(), new List<Symptoms>()), new List<Allergies>(), new List<Medicament>()));
            medicalRecords.Add(new MedicalRecord(3, new Patient(3), new Anamnesis(3, "Sve je u redu", new List<Diagnosis>(), new List<Symptoms>()), new List<Allergies>(), new List<Medicament>()));

            stubRepository.Setup(medicalRecordRepository => medicalRecordRepository.GetAllEntities()).Returns(medicalRecords);

            return stubRepository.Object;
        }
    }
}
