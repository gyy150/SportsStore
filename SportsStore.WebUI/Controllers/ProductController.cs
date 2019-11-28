using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ActionResult Test()
        {
            return new FilePathResult("~/Static/Testing.html", "text/html");
        }

        public ViewResult List(string Category,int page = 1)
        {
            IEnumerable<Product>  P = repository.Products.Where(p => p.Category == Category || Category == null).OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize);
            PagingInfo P2 = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products.Where(p => p.Category == Category || Category == null).Count()
            };
            ProductsListViewModel model = new ProductsListViewModel(P,P2,Category);
            return View(model);
        }

    }
}