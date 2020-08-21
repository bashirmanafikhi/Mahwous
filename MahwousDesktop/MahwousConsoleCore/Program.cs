using System;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Repositories.Interfaces;
using MahwousWeb.Shared.Repositories;
using MahwousWeb.Shared.Services;
using System.Net.Http;
using System.Collections.Generic;
using MahwousWeb.Shared.Filters;

namespace MahwousConsoleCore
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient
            {
                //BaseAddress = new Uri(@"https://www.mahwous.com/")
                BaseAddress = new Uri(@"https://localhost:44333/")
            };
            IHttpService httpService = new HttpService(httpClient);

            ICategoryRepository categoryRepository = new CategoryRepository(httpService);
            IImageRepository imageRepository = new ImageRepository(httpService);



            //Category category = CategoryRepository.Get(1).Result;

            CategoryFilter categoryFilter = new CategoryFilter() { Name= "s" };
            List<Category> categories = categoryRepository.GetCategoriesFiltered(categoryFilter).Result.Response;

            ImageFilter imageFilter = new ImageFilter
            {
                Categories = categories
            };
            List<ImageStatus> images = imageRepository.GetImagesFiltered(imageFilter).Result.Response;

            Console.WriteLine("categorys count : " + categories.Count);
            Console.WriteLine("images count : " + images.Count);

            Console.ReadKey();
        }
    }
}
