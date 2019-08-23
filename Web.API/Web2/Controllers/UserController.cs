using AutoMapper;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Web2.Models.Users;

namespace Web2.Controllers
{
    public class UserController : ApiController
    {
        private IUserService _userService { get; set; }
        private readonly IMapper _mapper;

        public UserController(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        public async Task<IHttpActionResult> Get(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<UserViewModel>(user);
            return Ok(vm);
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]EditUserViewModel sport)
        {
        }

        // POST api/values
        public async Task<string> PostAsync([FromBody]AddUserViewModel newVM)
        {
            var existed = _userService.Query(s => s.UserId == newVM.UserId).FirstOrDefault();
            if (existed != null)
            {
                Conflict();
            }
            else
            {
                var entity = _mapper.Map<User>(newVM);
                await _userService.SaveAsync(entity);
            }
            return "OK";
        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }

        // DELETE api/values/5
        public void Delete(DeleteUsersViewModel ids)
        {

        }
    }
}
