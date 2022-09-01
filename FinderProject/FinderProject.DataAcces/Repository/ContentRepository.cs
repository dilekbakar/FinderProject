using FinderProject.Data;
using FinderProject.DataAcces.DataContext;
using FinderProject.DataAcces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinderProject.DataAcces.Repository
{
    public class ContentRepository : IContentRepository
    {
       public Contents Create(Contents content)
        {
            using (var finderDbContext = new FinderDbContext())
            {
               finderDbContext.Contents.Add(content);
                finderDbContext.SaveChanges();
                return content;
            }
        }

        public void Delete(int id)
        {
            using (var finderDbContext = new FinderDbContext())
            {
               var deletedContent = GetById(id);
                finderDbContext.Contents.Remove(deletedContent);
                finderDbContext.SaveChanges();
            }
        }

        public List<Contents> GetAll()
        {
           using (var finderDbContext = new FinderDbContext())
            {
                return finderDbContext.Contents.ToList();
            }
        }

        public Contents GetById(int id)
        {
            using (var finderDbContext = new FinderDbContext())
            {
                return finderDbContext.Contents.Find(id); //id kısmı int olduğu için Find() kullandık. Diğer türlü FirstOrDefault() kullanılmalı.
            }
        }

        public Contents Update(Contents content)
        {
            using (var finderDbContext = new FinderDbContext())
            {
                finderDbContext.Contents.Update(content);
                finderDbContext.SaveChanges();
                return content;
            }
        }

    }
}
