using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecLibras.Services.Api.ViewModels;
using TecLibras.Services.Api.Repositories;
using AutoMapper;
using TecLibras.Services.Api.Model;
using System.Linq;

namespace TecLibras.Services.Api.Controllers
{
    [Authorize]
    public class QuestionsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IQuestionsRepository _questionsRepository;

        public QuestionsController(IMapper mapper,
            IQuestionsRepository questionsRepository) : base()
        {
            _questionsRepository = questionsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("questions")]
        public IActionResult Get()
        {
            return Response(_questionsRepository.GetAll());
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("questions/{id:guid}")]
        public IActionResult GetByUserId(Guid userId)
        {
            var questionsViewModel = _questionsRepository.GetById(userId);

            return Response(questionsViewModel);
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteQuestionsData")]
        [AllowAnonymous]
        [Route("Questions")]
        public IActionResult Post([FromBody]QuestionViewModel questionsViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(questionsViewModel);
            }
            var questionEvent = _mapper.Map<Question>(questionsViewModel);
            _questionsRepository.Add(questionEvent);
            _questionsRepository.SaveChanges();

            return Response(questionsViewModel);
        }
    }
}
