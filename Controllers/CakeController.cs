using CRUD_cakes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_cakes.Controllers
{
    public class CakeController : Controller
    {
        private readonly CakesContext _cakesContext;

        public CakeController(CakesContext cakesContext)
        {
            _cakesContext = cakesContext;
        }

        public IActionResult Index(int? id, string? cake_name, string? brand, int? weight, int? price, int? calories, bool?  gluten)
        {
            if (id is not null && cake_name is not null && cake_name is not null && brand is not null 
                && weight is not null && price is not null && calories is not null && gluten is not null)
            {
                id = (int)id;
                Cake cake = _cakesContext.Cakes.First(c => c.CakeId == id);
                cake.CakeName = cake_name;
                cake.BrandName = brand;
                cake.Weight = (int)weight;
                cake.Price = (int)price;
                cake.Calories = (int)calories;
                cake.Gluten = (bool)gluten;
                _cakesContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else if(cake_name is not null && brand is not null && weight is not null && price is not null 
                && calories is not null && gluten is not null)
            {
                Cake cake = new Cake();
                cake.CakeName = cake_name;
                cake.BrandName = brand;
                cake.Weight = (int)weight;
                cake.Price = (int)price;
                cake.Calories = (int)calories;
                cake.Gluten = (bool)gluten;
                _cakesContext.Cakes.Add(cake);
                _cakesContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else if(id is not null)
            {
                id = (int)id;
                Cake cake = _cakesContext.Cakes.First(c => c.CakeId == id);
                _cakesContext.Cakes.Remove(cake);
                _cakesContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<Cake> cakes = _cakesContext.Cakes.ToList();
                return View(cakes);
            }
        }
    }
}
