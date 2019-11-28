using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        
        public ProductsListViewModel(IEnumerable<Product> P , PagingInfo P2, string CurrentCategory)
        {
            this.Products = P;
            this.PagingInfo = P2;
            this.CurrentCategory = CurrentCategory;
        }
    }
}