﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Dto;
using AppointmentMicroservice.Gateway.Interface;
using AppointmentMicroservice.Mapper;
using AppointmentMicroservice.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IDoctorWorkDayService doctorWorkDayService;
        private IAppointmentService appointmentService;
        private IDoctorGateway doctorGateway;

        public AppointmentController(IDoctorWorkDayService doctorWorkDayService, IAppointmentService appointmentService, IDoctorGateway doctorGateway) 
        {
            this.doctorWorkDayService = doctorWorkDayService;
            this.appointmentService = appointmentService;
            this.doctorGateway = doctorGateway;
        }

        [HttpGet("getAvailableAppointments")]
        public IActionResult GetAvailableAppointmentsByDateAndDoctorId([FromQuery(Name = "date")] string date, [FromQuery(Name = "doctorId")] int doctorId)
        {
            DoctorWorkDayDto dto = DoctorWorkDayMapper.DoctorWorkDayToDoctorWorkDayDto(
                doctorWorkDayService.GetDoctorWorkDayByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture), doctorId),
                doctorWorkDayService.GetAvailableAppointmentsByDateAndDoctorId(DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture), doctorId));

            if (dto == null)
            {
                return NoContent();
            }
            return Ok(dto);
        }

        [HttpPost]       // POST /api/appointment/
        public IActionResult ScheduleAppointment(SchedulingAppointmentDto dto)
        {
            if (doctorWorkDayService.ScheduleAppointment(SchedulingAppointmentMapper.AppointmentDtoToAppointment(dto)))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("getPreviousAppointmetsByPatient/{patientId}")]       // GET /api/appointment/getPreviousAppointmetsByPatient/{patientId}
        public IActionResult GetPreviousAppointmentsByPatient(int patientId)
        {
            List<AppointmentDto> result = new List<AppointmentDto>();
            appointmentService.GetPreviousAppointmetsByPatient(patientId, DateTime.Now).ToList().ForEach(appointment => result.Add(AppointmentMapper.AppointmentToAppointmentDto(appointment, doctorGateway.GetDoctorById(appointment.MedicalExamination.DoctorId))));
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("getScheduledAppointmetsByPatient/{patientId}")]       // GET /api/appointment/getScheduledAppointmetsByPatient/{patientId}
        public IActionResult GetScheduledAppointmentsByPatient(int patientId)
        {
            List<AppointmentDto> result = new List<AppointmentDto>();
            appointmentService.GetScheduledAppointmetsByPatient(patientId, DateTime.Now).ToList().ForEach(appointment => result.Add(AppointmentMapper.AppointmentToAppointmentDto(appointment, doctorGateway.GetDoctorById(appointment.MedicalExamination.DoctorId))));
            if (result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("cancelAppointment/{appointmentId}")]       // GET /api/appointment/cancelAppointment/{appointmentId}
        public IActionResult CancelPatientAppointment(int appointmentId)
        {
            Appointment appointmentForCancelation = appointmentService.GetEntity(appointmentId);
            if (appointmentForCancelation == null)
            {
                return NotFound();
            }
            doctorWorkDayService.CancelPatientAppointment(appointmentForCancelation.DoctorWorkDayId, appointmentId, DateTime.Now);
            return Ok(appointmentService.CancelPatientAppointment(appointmentId, DateTime.Now));
        }

        [HttpGet("getAllRecommendedTerms")]       // GET /api/appointment/getAllRecommendedTerms
        public IActionResult GetAllRecommendedTerms([FromQuery(Name = "startDate")] string startDate, [FromQuery(Name = "endDate")] string endDate, [FromQuery(Name = "doctorId")] string doctorId, [FromQuery(Name = "priority")] string priority)
        {
            try
            {
                Dictionary<int, List<Appointment>> availableAppointments = doctorWorkDayService.GetAvailableAppointmentsByDateRangeAndDoctorIdIncludingPriority(DateTime.ParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture), DateTime.ParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture), Int32.Parse(doctorId), priority);
                return Ok(DoctorWorkDayMapper.CreateDoctorWorkDayDtos(doctorWorkDayService.GetDoctorWorkDaysByIds(availableAppointments.Keys.ToList()), availableAppointments));
            }
            catch
            {
                return BadRequest("The data which were entered are incorrect!");
            }
        }

        [HttpGet("filledSurveyForAppointment/{appointmentId}")]       // GET /api/appointment/filledSurveyForAppointment/{appointmentId}
        public IActionResult FilledSurveyForAppointment(int appointmentId)
        {
            Appointment appointment = appointmentService.FilledSurveyForAppointment(appointmentId);
            return Ok();
        }

        [HttpGet("countCancelledAppointmentsForPatient/{patientId}")]       // GET /api/appointment/countCancelledAppointmentsForPatient/{patientId}
        public IActionResult GetAllRecommendedTerms(int patientId)
        {
            return Ok(appointmentService.CountCancelledAppointmentsForPatient(patientId, DateTime.Now));
        }
    }
}

