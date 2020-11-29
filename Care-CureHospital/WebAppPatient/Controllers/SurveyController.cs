﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Patient;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;

namespace WebAppPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {

        public SurveyController() { }

        [HttpGet] // GET /api/survey
        public IActionResult getAllSurveys()
        {
            List<SurveyDto> result = new List<SurveyDto>();
            App.Instance().SurveyService.GetAllEntities().ToList().ForEach(survey => result.Add(SurveyMapper.SurveyToSurveyDto(survey)));
            return Ok(result);
        }


        [HttpGet("getSurveyResults")] // GET /api/survey/getSurveyResults
        public IActionResult getSurveyResults()
        {
            return Ok(QuestionResultMapper.CreateQuestionResultsDto(App.Instance().QuestionService.GetAnswersByQuestion()));
        }

        [HttpPost]      // POST /api/survey
        public IActionResult Add(SurveyDto dto)
        {
            Survey survey = SurveyMapper.SurveyDtoToSurvey(dto, null);
            App.Instance().SurveyService.AddEntity(survey);
            return Ok();
        }
    }
}