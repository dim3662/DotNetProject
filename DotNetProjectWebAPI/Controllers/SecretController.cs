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
    public class SecretController : ControllerBase
    {
        private ILogger<SecretController> Logger { get; }
        private ISecretCreateService SecretCreateService { get; }
        private ISecretGetService SecretGetService { get; }
        private ISecretUpdateService SecretUpdateService { get; }
        private IMapper Mapper { get; }

        public SecretController(ILogger<SecretController> logger, IMapper mapper,
            ISecretCreateService secretCreateService, ISecretGetService secretGetService,
            ISecretUpdateService secretUpdateService)
        {
            this.Logger = logger;
            this.SecretCreateService = secretCreateService;
            this.SecretGetService = secretGetService;
            this.SecretUpdateService = secretUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<SecretDTO> PutAsync(SecretCreateDTO secret)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.SecretCreateService.CreateAsync(this.Mapper.Map<SecretUpdateModel>(secret));

            return this.Mapper.Map<SecretDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<SecretDTO> PatchAsync(SecretUpdateDTO employee)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.SecretUpdateService.UpdateAsync(this.Mapper.Map<SecretUpdateModel>(employee));

            return this.Mapper.Map<SecretDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<SecretDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<SecretDTO>>(await this.SecretGetService.GetAsync());
        }

        [HttpGet]
        [Route("{employeeId}")]
        public async Task<SecretDTO> GetAsync(int employeeId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {employeeId}");

            return this.Mapper.Map<SecretDTO>(
                await this.SecretGetService.GetAsync(new SecretIdentityModel(employeeId)));
        }
    }
}