﻿using AutoMapper;
using FormulaOne.DataService.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController :ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


    }
}
