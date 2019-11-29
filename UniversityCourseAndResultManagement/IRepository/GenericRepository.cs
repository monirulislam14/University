using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.DAL;

namespace UniversityCourseAndResultManagement.IRepository
{
    public class GenericRepository<Tbl_Entity>:IRepository<Tbl_Entity> where Tbl_Entity : class
    {
        DbSet<Tbl_Entity> _dbSet;
        private UniversityManagementDBEntities _DBEntity;

        public GenericRepository(UniversityManagementDBEntities DBEntity)
        {
            _dbSet = DBEntity.Set<Tbl_Entity>();
            _DBEntity = DBEntity;
        }

        public IEnumerable<Tbl_Entity> GetAllRecords()
        {
            return _dbSet.ToList();
        }
        public void Add(Tbl_Entity entity)
        {
            _dbSet.Add(entity);
            _DBEntity.SaveChanges();
        }
        public void Update(Tbl_Entity entity)
        {
            _dbSet.Attach(entity);
            _DBEntity.Entry(entity).State = EntityState.Modified;
            _DBEntity.SaveChanges();

        }
    }
}