using BoxProblem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.Repository
{
    public class BoxInventoryRepository
    {
        private ApplicationDbContext context;
        public BoxInventoryRepository(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public List<BoxInventory> GetAllBoxes()
        {
            return context.Boxes.ToList();
        }
        public BoxInventory GetBoxById(int id)
        {
            return context.Boxes.Find(id);
        }
        public void AddBox(BoxInventory toAdd)
        {
            context.Boxes.Add(toAdd);
            context.SaveChanges();
        }
        public void EditBox(BoxInventory toEdit)
        {
            context.Entry(toEdit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteBox(BoxInventory toDelete)
        {
            context.Boxes.Remove(toDelete);
            context.SaveChanges();
        }
    }
}
