using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AreaContext : IDB<Area, int>
    {
        StanimirSofronovDbContext _context;

        public AreaContext(StanimirSofronovDbContext context)
        {
            _context = context;
        }

        public void Create(Area item)
        {
            try
            {
                _context.Areas.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                _context.Areas.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Area Read(int key, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Area> query = _context.Areas;

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Customers);
                }

                return query.SingleOrDefault(g => g.Id == key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Area> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Area> query = _context.Areas.AsNoTracking();

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Customers);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Area item, bool useNavigationProperties = false)
        {
            try
            {
                Area fromDb = Read(item.Id);

                _context.Entry(fromDb).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}