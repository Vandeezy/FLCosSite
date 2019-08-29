using AutoMapper;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Web.Models.Sports;
using Web2.Helpers;

namespace Web.Controllers
{
    [RoutePrefix("api/sports")]
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
        [HttpGet]
        public async Task<IHttpActionResult> GetAll(string query = "",string startDate = "", string endDate ="", int page = 1, int pageSize = 20)
        {
            var where = PredicateBuilder.True<Sport>();

            if (!string.IsNullOrEmpty(startDate))
            {
                var start = DateTime.ParseExact(startDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                where = where.And(s => DateTime.Compare(start, (DateTime)s.Date) <= 0);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                var end = DateTime.ParseExact(endDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                where = where.And(s => DateTime.Compare(end, (DateTime)s.Date) >= 0);
            }
            
            var sports = _sportService.GetAll(where);
            
            var vm = _mapper.Map<List<SportViewModel>>(sports);
           
            return Ok(vm);
        }
        // GET api/values/5
        public async Task<IHttpActionResult> Get(int id)
        {
            var sport =  _sportService.Get(id);
            if(sport == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<SportViewModel>(sport);
            //var vm = new SportViewModel()
            //{
            //    Id = sport.Id,
            //    Date = sport.Date,
            //    Steps = sport.Steps,
            //    UserId = sport.UserId
            //};
            return Ok(vm);
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]EditSportViewModel sport)
        {
        }

        // POST api/values
        public async Task<string> PostAsync([FromBody]AddSportViewModel newVM)
        {
            var existed = _sportService.Query(s => s.Date == newVM.Date).FirstOrDefault();
            if(existed != null)
            {
                Conflict();
            }
            else
            {
                try
                {
                    var entity = _mapper.Map<Sport>(newVM);
                    //Test
                    entity.UserId = 1;
                    await _sportService.SaveAsync(entity);
                }
               catch(Exception ex)
                {
                    System.Diagnostics.Debug.Write(ex);
                }
            }
            return "OK";
        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
        [HttpPost]
        [Route("deletelist")]
        public void Delete(DeleteSportsViewModel ids)
        {

        }
    }
}