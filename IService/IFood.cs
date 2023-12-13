using webApi_Nupat_1.Model;

namespace webApi_Nupat_1.IService
{
    public interface IFood
    {
        //Return type and method name
        /// <summary>
        /// Create food
        /// </summary>
        /// <param name="food"></param>
        void CreateFood(Food food);

        List<Food> GetFoods();

        Food GetFoodById(int? id);   
        Food GetFoodByName(string name);

        void DeleteFood(Food food);

        void UpdateFoodById(int? id);
    }
}
