﻿using DocumentsMicroservice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Dto
{
    public class MedicalRecordDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int AnamnesisId { get; set; }
        public Anamnesis Anamnesis { get; set; }
        public List<Allergies> Allergies { get; set; }
        public List<Medicament> Medicaments { get; set; }
        public string DateOfBirthday { get; set; }
        public bool ActiveMedicalRecord { get; set; }
        public string ConfirmedPassword { get; set; }
        public string ProfilePicture { get; set; }

        public MedicalRecordDto() { }
    }
}