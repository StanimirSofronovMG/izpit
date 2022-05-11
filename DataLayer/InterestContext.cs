using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class InterestContext : IDB<Interest, int>
    {
        private StanimirSofronovDbContext _context;

        public InterestContext(StanimirSofronovDbContext context) { _context = context; }

        public void Create(Interest item)
        {
            try
            {
                List<Area> Areas = new List<Area>();

                foreach (var Area in item.Areas)
                {
                    Area fromDb = _context.Areas.Find(Area.Id);

                    if (fromDb != null)
                    {
                        Areas.Add(fromDb);
                    }
                    else
                    {
                        Areas.Add(Area);
                    }
                }

                item.Areas = Areas;

                _context.Interests.Add(item);
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
                _context.Interests.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Interest Read(int key, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Interest> query = _context.Interests;

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Areas).Include(b => b.Customers);
                }

                return query.SingleOrDefault(g => g.Id == key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Interest> ReadAll(bool useNavigationProperties = false)
        {
            try
            {

                IQueryable<Interest> query = _context.Interests.AsNoTracking();

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Areas).Include(b => b.Customers);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Interest item, bool useNavigationProperties = false)
        {
            try
            {
                Interest fromDb = Read(item.Id, useNavigationProperties);

                if (useNavigationProperties)
                {
                    List<Area> Areas = new List<Area>();

                    foreach (var Area in item.Areas)
                    {
                        Area fromDB = _context.Areas.Find(Area.Id);

                        if (fromDB != null)
                        {
                            Areas.Add(fromDB);
                        }
                        else
                        {
                            Areas.Add(Area);
                        }
                    }

                    fromDb.Areas = Areas;
                }

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
