using BoxProblem.Data;
using BoxProblem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxProblem.ViewModel;

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
        public List<BoxInventory> Search(SearchField field)
        {
            return repository.Search(field);
        }
    }
}
