﻿using AppointmentMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentMicroservice.Domain
{
    public class DoctorWorkDay : IIdentifiable<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        [NotMapped]
        public virtual Doctor Doctor { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public virtual List<Appointment> ScheduledAppointments { get; set; }

        public DoctorWorkDay()
        {
        }

        public DoctorWorkDay(int id, DateTime date, int doctorId, Doctor doctor, int roomId, Room room, List<Appointment> scheduledAppointments)
        {
            Id = id;
            Date = date;
            DoctorId = doctorId;
            Doctor = doctor;
            RoomId = roomId;
            Room = room;
            ScheduledAppointments = scheduledAppointments;
        }

        public DoctorWorkDay(int id, DateTime date, int doctorId, List<Appointment> scheduledAppointments)
        {
            Id = id;
            Date = date;
            DoctorId = doctorId;
            ScheduledAppointments = scheduledAppointments;
        }


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
