using FinderProject.Business.Infrastructure;
using FinderProject.Data;
using FinderProject.DataAcces.Infrastructure;
using FinderProject.DataAcces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinderProject.Business.Repository
{
   
    public class ContentManager : IContentService
    {
        private IContentRepository _contentRepository;
        public ContentManager(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }
        public Contents Create(Contents content)
        {
            return _contentRepository.Create(content);
        }

        public void Delete(int id)
        {
            _contentRepository.Delete(id);
        }

        public List<Contents> GetAll()
        {
           return  _contentRepository.GetAll();
        }

        public Contents GetById(int id)
        {
            if (id>0)
            {
                return _contentRepository.GetById(id);
            }
            throw new Exception("ID 1 den küçük olamaz");
        }

        public Contents Update(Contents content)
        {
            return _contentRepository.Update(content);
        }
    }
}
