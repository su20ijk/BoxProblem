using BoxProblem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.ViewModel;

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
            context.Entry(toEdit).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteBox(BoxInventory toDelete)
        {
            context.Boxes.Remove(toDelete);
            context.SaveChanges();
        }
        public List<BoxInventory> Search(SearchField field)
        {
            switch (field.GType())
            {
                case "bv":
                    {
                        Int32.TryParse(field.GValue(), out int x);
                        return context.Boxes.Where(b => b.Volume > x).ToList();
                    }
                case "sv":
                    {
                        Int32.TryParse(field.GValue(), out int x);
                        return context.Boxes.Where(b => b.Volume == x).ToList();
                    }
                case "lv":
                    {
                        Int32.TryParse(field.GValue(), out int x);
                        return context.Boxes.Where(b => b.Volume < x).ToList();
                    }
                case "bw":
                    {
                        Int32.TryParse(field.GValue(), out int x);
                        return context.Boxes.Where(b => b.Weight > x).ToList();
                    }
                case "sw":
                    {
                        Int32.TryParse(field.GValue(), out int x);
                        return context.Boxes.Where(b => b.Weight == x).ToList();
                    }
                case "lw":
                    {
                        Int32.TryParse(field.GValue(), out int x);
                        return context.Boxes.Where(b => b.Weight < x).ToList();
                    }
                case "bc":
                    {
                        Double.TryParse(field.GValue(), out double x);
                        return context.Boxes.Where(b => b.Cost > x).ToList();
                    }
                case "sc":
                    {
                        Double.TryParse(field.GValue(), out double x);
                        return context.Boxes.Where(b => b.Cost == x).ToList();
                    }
                case "lc":
                    {
                        Double.TryParse(field.GValue(), out double x);
                        return context.Boxes.Where(b => b.Cost < x).ToList();
                    }
                case "tl":
                    {
                        Boolean.TryParse(field.GValue(), out bool x);
                        return context.Boxes.Where(b => b.CanHoldLiquid == x).ToList();
                    }
                case "bi":
                    {
                        Int32.TryParse(field.GValue(), out int x);
                        return context.Boxes.Where(b => b.InventoryCount > x).ToList();
                    }
                case "si":
                    {
                        Int32.TryParse(field.GValue(), out int x);
                        return context.Boxes.Where(b => b.InventoryCount == x).ToList();
                    }
                case "li":
                    {
                        Int32.TryParse(field.GValue(), out int x);
                        return context.Boxes.Where(b => b.InventoryCount < x).ToList();
                    }
                case "bd":
                    {
                        DateTime.TryParse(field.GValue(), out DateTime x);
                        return context.Boxes.Where(b => b.CreatedAt.CompareTo(x)>0).ToList();
                    }
                case "sd":
                    {
                        DateTime.TryParse(field.GValue(), out DateTime x);
                        return context.Boxes.Where(b => b.CreatedAt.Equals(x)).ToList();
                    }
                case "ld":
                    {
                        DateTime.TryParse(field.GValue(), out DateTime x);
                        return context.Boxes.Where(b => b.CreatedAt.CompareTo(x)<0).ToList();
                    }
            }

            return context.Boxes.ToList();




        }
    }
}
