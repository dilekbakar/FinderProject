using FinderProject.Business.Infrastructure;
using FinderProject.Business.Repository;
using FinderProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinderProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private IContentService _contentService;
        public ContentsController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet]
        public List<Contents> Get()
        {
            return _contentService.GetAll();
        }
        [HttpGet("{id}")]
        public Contents Get(int id)
        {
            return _contentService.GetById(id);
        }

        [HttpPost]
        public Contents Post([FromBody] Contents content)
        {
           return _contentService.Create(content);
        }

        [HttpPut]
        public Contents Put([FromBody] Contents content)
        {
            return _contentService.Update(content);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _contentService.Delete(id);
        }
    }
}
