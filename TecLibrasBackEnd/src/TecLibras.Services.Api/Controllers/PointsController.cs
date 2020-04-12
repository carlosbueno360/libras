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
    public class PointsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IPointEventRepository _pointsRepository;
        private readonly IRankRepository _rankRepository;

        public PointsController(IMapper mapper,
            IPointEventRepository pointsRepository,
            IRankRepository rankRepository) : base()
        {
            _pointsRepository = pointsRepository;
            _rankRepository = rankRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("points")]
        public IActionResult Get()
        {
            return Response(_pointsRepository.GetAll());
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("points/{userId:guid}")]
        public IActionResult GetByUserId(Guid userId)
        {
            var pointsViewModel = _pointsRepository.GetByUserId(userId).ToList();

            return Response(pointsViewModel);
        }     

        [HttpPost]
        //[Authorize(Policy = "CanWritePointsData")]
        [AllowAnonymous]
        [Route("points")]
        public IActionResult Post([FromBody]PointsViewModel pointsViewModel)
        {
            // Validação dos dados
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();//Verifica se há erros
                return Response(pointsViewModel);
            }

            // Adiciona pontos na tabela de pontos
            var pointEvent = _mapper.Map<PointEvent>(pointsViewModel);
            _pointsRepository.Add(pointEvent);


            if (_pointsRepository.SaveChanges() > 0)
            {
                // Caso seja gravado pontos, iremos somar todos os pontos já acumulados e adicionar ou atualizar a tabela de rank
                UpdateRank(pointsViewModel);
            }

            return Response(pointsViewModel);
        }


        private void UpdateRank(PointsViewModel pointsViewModel)
        {
            // Busca todos pontos do Usuario
            var points = _pointsRepository.GetByUserId(pointsViewModel.UserId).ToList();
            var totalPoints = points.Sum(x => x.Points); // Soma os pontos

            // Busca rank do Usuario, pois caso não exista deve ser criado um novo, caso contrario apenas atualizado
            var userRank = _rankRepository.GetByUserId(pointsViewModel.UserId);
            if (userRank is null) // Se rank for nulo irá gravar um rank novo
            {
                userRank = new Rank(pointsViewModel.UserId, totalPoints);
                _rankRepository.Add(userRank);
            }
            else
            {
                userRank.Update(totalPoints);// Esse caso existe rank então ele irá apenas atualizar os pontos totais
                _rankRepository.Update(userRank);
            }
            _rankRepository.SaveChanges();
        }
    }
}
