using BoxProblem.Data;
using BoxProblem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.Server
{
    public class BoxInventoryService
    {
        private BoxInventoryRepository repository;
        public BoxInventoryService(ApplicationDbContext dbContext)
        {
            repository = new BoxInventoryRepository(dbContext);
        }
        public List<BoxInventory> GetAll()
        {
            return repository.GetAllBoxes();
        }
        public BoxInventory GetById(int id)
        {
            return repository.GetBoxById(id);
        }
        public void AddBox(BoxInventory toAdd)
        {
            repository.AddBox(toAdd);
        }
        public void EditBox(BoxInventory toEdit)
        {
            repository.EditBox(toEdit);
        }
        public void DeleteBox(BoxInventory toDelete)
        {
            repository.DeleteBox(toDelete);
        }

        public List<BoxInventory> GetVolumeLargerThan(int vol)
        {
            List<BoxInventory> boxes = repository.GetAllBoxes();
            List<BoxInventory> x = new List<BoxInventory>();
            foreach (BoxInventory y in boxes)
            {
                if (y.Volume > vol)
                {
                    x.Add(y);
                }
            }

            return x;
        }

    }
}
