using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext(); 

        // GET: Categories
        public  async Task<List<Category>> GetAll()
        {
            return await _context.Category.ToListAsync();
        }
        // GET: Categories/Details/5
        public async Task<Category> GetDetails(Guid? id)
        {      
            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            return category;
        }
        // POST: Categories/Create
        public async Task<Category> Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        // POST: Categories/Edit/5
        public async Task Edit(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
              _context.Update(category);
                await _context.SaveChangesAsync();
        }
        // POST: Categories/Delete/5
        public async Task DeleteConfirmed(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }
        public bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
