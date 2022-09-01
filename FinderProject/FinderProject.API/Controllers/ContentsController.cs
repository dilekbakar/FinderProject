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

        /// <summary>
        /// Tüm datalar listelenir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Contents> Get()
        {
            return _contentService.GetAll();
        }


        /// <summary>
        /// Id'si girilen data listelenir.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Contents Get(int id)
        {
            return _contentService.GetById(id);
        }


        /// <summary>
        /// Yeni data kaydedilir. Id hariç tüm parametreler girilmelidir.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Contents Post([FromBody] Contents content)
        {
           return _contentService.Create(content);
        }

        /// <summary>
        /// Id'si verilen data güncellenir.  
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public Contents Put([FromBody] Contents content)
        {
            return _contentService.Update(content);
        }

        /// <summary>
        /// Id'si verilen data silinir.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _contentService.Delete(id);
        }
    }
}
