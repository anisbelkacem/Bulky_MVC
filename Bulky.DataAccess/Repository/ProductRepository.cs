using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.EntityFrameworkCore; // Add this
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly ApplicationDbContext _db;
		public ProductRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		
		public void Update(Product obj)
		{
			var objFromDb = _db.Products.FirstOrDefault(u => u.Product_Id == obj.Product_Id);
			if(objFromDb != null) 
			{
				objFromDb.Title = obj.Title;
				objFromDb.ISBN = obj.ISBN;
				objFromDb.Price = obj.Price;
				objFromDb.Price100 = obj.Price100;
				objFromDb.ListPrice = obj.ListPrice;
				objFromDb.Author = obj.Author;
				objFromDb.CategoryId = obj.CategoryId;
				objFromDb.Price50 = obj.Price50;
				if(obj.ImageUrl != null)
				{
					objFromDb.ImageUrl = obj.ImageUrl;
				}

			}
		}
	}
}