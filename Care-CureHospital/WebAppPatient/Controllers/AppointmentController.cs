﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        public AppointmentController() { }

        [HttpGet("getAvailableAppointments")]
        public IActionResult GetAvailableAppointmentsByDateAndDoctorId([FromQuery(Name = "date")] string date, [FromQuery(Name = "doctorId")] int doctorId)
        {
            return Ok(DoctorWorkDayMapper.DoctorWorkDayToDoctorWorkDayDto(
                App.Instance().DoctorWorkDayService.GetDoctorWorkDayByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-dd-MM", CultureInfo.InvariantCulture), doctorId),
                App.Instance().DoctorWorkDayService.GetAvailableAppointmentsByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-dd-MM", CultureInfo.InvariantCulture), doctorId)
                ));
        }

        [HttpGet("getAllSpecialization")]       // GET /api/appointment/getAllSpecialization
        public IActionResult GetAllSpecialization()
        {
            List<SpecializationDto> result = new List<SpecializationDto>();
            App.Instance().SpetialitationService.GetAllEntities().ToList().ForEach(specialization => result.Add(SpecializationMapper.SpecializationToSpecializationDto(specialization)));
            return Ok(result);
        }

        [HttpGet("getAllDoctorBySpecializationId/{specializationId}")]       // GET /api/appointment/getAllDoctorBySpecializationId/{specializationId}
        public IActionResult GetAllDoctorsBySpecializationId(int specializationId)
        {
            List<DoctorDto> result = new List<DoctorDto>();
            App.Instance().DoctorService.GetAllDoctorsBySpecialization(specializationId).ToList().ForEach(doctor => result.Add(DoctorMapper.DoctorToDoctorDto(doctor)));
            return Ok(result);
        }


        [HttpGet("getPreviousAppointmetsByPatient/{patientId}")]       // GET /api/appointment/getPreviousAppointmetsByPatient/{patientId}
        public IActionResult GetPreviousAppointmetsByPatient(int patientId)
        {
            List<AppointmentDto> result = new List<AppointmentDto>();
            App.Instance().AppointmentService.GetPreviousAppointmetsByPatient(patientId, DateTime.Now).ToList().ForEach(appointment => result.Add(AppointmentMapper.AppointmentToAppointmentDto(appointment)));
            return Ok(result);
        }

        [HttpGet("getScheduledAppointmetsByPatient/{patientId}")]       // GET /api/appointment/getScheduledAppointmetsByPatient/{patientId}
        public IActionResult GetScheduledAppointmetsByPatient(int patientId)
        {
            List<AppointmentDto> result = new List<AppointmentDto>();
            App.Instance().AppointmentService.GetScheduledAppointmetsByPatient(patientId, DateTime.Now).ToList().ForEach(appointment => result.Add(AppointmentMapper.AppointmentToAppointmentDto(appointment)));
            return Ok(result);
        }

        [HttpPut("cancelAppointment/{appointmentId}")]       // GET /api/appointment/cancelAppointment/{appointmentId}
        public IActionResult CancelPatientAppointment(int appointmentId)
        {
            return Ok(App.Instance().AppointmentService.CancelPatientAppointment(appointmentId));
        }
    }
}