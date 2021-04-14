using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DotNetProject.DotNetProjectBLL.Contracts;
using DotNetProject.Models;
using DotNetProjectClient.DTO;
using DotNetProjectClient.Request.Create;
using DotNetProjectClient.Request.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetProjectWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private ILogger<PersonController> Logger { get; }
        private IPersonCreateService personCreateService { get; }
        private IPersonGetService personGetService { get; }
        private IPersonUpdateService personUpdateService { get; }
        private IMapper Mapper { get; }

        public PersonController(ILogger<PersonController> logger, IMapper mapper,
            IPersonCreateService personCreateService, IPersonGetService personGetService,
            IPersonUpdateService personUpdateService)
        {
            this.Logger = logger;
            this.personCreateService = personCreateService;
            this.personGetService = personGetService;
            this.personUpdateService = personUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<PersonDTO> PutAsync(PersonCreateDTO Person)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.personCreateService.CreateAsync(this.Mapper.Map<PersonUpdateModel>(Person));

            return this.Mapper.Map<PersonDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<PersonDTO> PatchAsync(PersonUpdateDTO employee)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.personUpdateService.UpdateAsync(this.Mapper.Map<PersonUpdateModel>(employee));

            return this.Mapper.Map<PersonDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PersonDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<PersonDTO>>(await this.personGetService.GetAsync());
        }

        [HttpGet]
        [Route("{employeeId}")]
        public async Task<PersonDTO> GetAsync(int employeeId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {employeeId}");

            return this.Mapper.Map<PersonDTO>(
                await this.personGetService.GetAsync(new PersonIdentityModel(employeeId)));
        }
    }
}