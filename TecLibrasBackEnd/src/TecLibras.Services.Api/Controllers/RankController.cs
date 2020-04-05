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
    public class RankController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IRankRepository _rankRepository;

        public RankController(IMapper mapper,
            IRankRepository rankRepository) : base()
        {
            _rankRepository = rankRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Rank")]
        public IActionResult Get()
        {
            return Response(_rankRepository.GetAllWithApplicationUser());
        }
    }
}
