using webApi_Nupat_1.Data;
using webApi_Nupat_1.IService;
using webApi_Nupat_1.Migrations;
using webApi_Nupat_1.Model;

namespace webApi_Nupat_1.Service
{
    public class FoodService : IFood
    {
        private readonly DataContext _context;

        public FoodService(DataContext context)
        {
            _context = context;
        }

        public void CreateFood(Food food)
        {
            var addFood = _context.Foods.Add(food);
            _context.SaveChanges();
        }

        public void DeleteFood(Food food)
        {
            _context.Foods.Remove(food);
            _context.SaveChanges();
        }

        public Food GetFoodById(int? id)
        {
            Food food = _context.Foods.Find(id);
            return food;
        }

        public Food GetFoodByName(string name)
        {
            Food food = _context.Foods.Where(x => x.Name == name).FirstOrDefault();
            return food;
        }

        public List<Food> GetFoods() 
        { 
            return _context.Foods.ToList();
        } 

        public void UpdateFoodById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
