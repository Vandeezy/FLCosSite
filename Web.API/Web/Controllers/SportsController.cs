﻿using AutoMapper;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Web.Models.Sports;

namespace Web.Controllers
{
    public class SportsController : ApiController
    {
       
        private ISportService _sportService { get; set; }
        private readonly IMapper _mapper;

        public SportsController(ISportService sportService,
            IMapper mapper)
        {
           _sportService = sportService;
            _mapper = mapper;
        }

        // GET api/values/5
        public async Task<IHttpActionResult> Get(int id)
        {
            var sport = await _sportService.GetSport(id);
            if(sport != null)
            {
                return NotFound();
            }
            var vm = new SportViewModel()
            {
                Id = sport.Id,
                Date = sport.Date,
                Steps = sport.Steps,
                UserId = sport.UserId
            };
            return Ok(vm);
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]EditSportViewModel sport)
        {
        }

        // POST api/values
        public void Post([FromBody]AddSportViewModel value)
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }

        // DELETE api/values/5
        public void Delete(DeleteSportsViewModel ids)
        {

        }
    }
}