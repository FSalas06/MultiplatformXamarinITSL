using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestDemo.Contracts.Services;
using UnitTestDemo.Models;

namespace UnitTestDemo.Mocks.Services
{
    public class CatalogDataServiceMock : ICatalogDataService
    {
        public async Task<IEnumerable<Pie>> GetAllPiesAsync()
        {
            await Task.Delay(500);
            var pieList = new List<Pie>();

            pieList.Add(new Pie 
            {
                ShortDescription = "Strawberry pie",
                LongDescription = "Delicious strawberry pie",
                Price = 50,
                Name = "Strawberry pie",
                ImageUrl = "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2019/7/12/KC2111__Strawberry-Pie_s4x3.jpg.rend.hgtvcom.826.620.suffix/1563196588079.jpeg"
            });

            pieList.Add(new Pie
            {
                ShortDescription = "Apple pie",
                LongDescription = "Delicious apple pie",
                Price = 60,
                Name = "Apple pie",
                ImageUrl = "https://images-gmi-pmc.edge-generalmills.com/75593ed5-420b-4782-8eae-56bdfbc2586b.jpg"
            });

            pieList.Add(new Pie
            {
                ShortDescription = "Lemon pie",
                LongDescription = "Delicious lemon pie",
                Price = 30,
                Name = "Lemon pie",
                ImageUrl = "https://tabsandtidbits.com/wp-content/uploads/2017/04/Magnolia-Lemon-Pie-1.jpg"
            });

            pieList.Add(new Pie
            {
                ShortDescription = "Cherry pie",
                LongDescription = "Delicious cherry pie",
                Price = 70,
                Name = "Cherry pie",
                ImageUrl = "https://www.musselmans.com/wp-content/uploads/5dd7e7db-e037-400c-be3d-e853363af51b_Landscape-580x435.jpg"
            });

            pieList.Add(new Pie
            {
                ShortDescription = "Pineapple pie",
                LongDescription = "Delicious pineapple pie",
                Price = 40,
                Name = "Pineapple pie",
                ImageUrl = "https://lh3.googleusercontent.com/WADfP1rdRZ1lhKQk_pcfYvsvEEk6wsXfKyqbC5TmogVIIwN_ZYq9vPBhqL9oQ0WOIhSbWDMWJfycHhrHjOa77sxqBbaXpTjWSoglU5s=w600-rj-l68-e365"
            });

            return pieList;          
        }

        public async Task<IEnumerable<Pie>> GetPiesOfTheWeekAsync()
        {
            await Task.Delay(500);
            var pieList = new List<Pie>();

            pieList.Add(new Pie
            {
                ShortDescription = "Strawberry pie",
                LongDescription = "Delicious strawberry pie",
                Price = 50,
                Name = "Strawberry pie"                
            });

            pieList.Add(new Pie
            {
                ShortDescription = "Apple pie",
                LongDescription = "Delicious apple pie",
                Price = 60,
                Name = "Apple pie"                
            });

            return pieList;
        }
    }
}
