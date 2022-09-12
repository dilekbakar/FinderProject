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
        public IActionResult Get()
        {
            var contents = _contentService.GetAll();
            return Ok(contents); //200 + data
        }


        /// <summary>
        /// Id'si girilen data listelenir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")] //api/contents/getbyid/id
        public IActionResult GetById(int id)
        {
            var content = _contentService.GetById(id);
            if (content != null)
            {
                return Ok(content);// 200 + data
            }
            return NotFound(); //404
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetByName(string name)
        {
           
            return Ok();
           
        }


        
        /// <summary>
        /// Yeni data kaydedilir. Id hariç tüm parametreler girilmelidir.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Contents content)
        {
            //valid değilse hiç girmez ve 400 gönderir.
            var createdContent = _contentService.Create(content);
            return CreatedAtAction("Get", new { id = createdContent.ID }, createdContent); //201 + data
        }

        /// <summary>
        /// Id'si verilen data güncellenir.  
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Contents content)
        {
            if (_contentService.GetById(content.ID)!= null)
            {
                return Ok(_contentService.Update(content));
            }
            return NotFound();
        }

        /// <summary>
        /// Id'si verilen data silinir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_contentService.GetById(id)!=null)
            {
                _contentService.Delete(id);
                return Ok(); //200
            }
            return NotFound();
        }
    }
}
