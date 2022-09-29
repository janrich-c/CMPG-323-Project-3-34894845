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
    public class DeviceRepository
    {

        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        // GET: Devices
        public async Task<List<Device>> GetAll()
        {
            var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return await connectedOfficeContext.ToListAsync();
        }

        // GET: Devices/Details/5
        public async Task<Device> GetDetails(Guid? id)
        {
            var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            return device;
        }

        public DbSet<Category> GetCatg()
        {
            return _context.Category;
        }
        public DbSet<Zone> GetZone()
        {
            return _context.Zone;
        }

        // POST: Devices/Create
        public async Task<Device> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _context.Add(device);
            await _context.SaveChangesAsync();
            return device;
        }

        // POST: Devices/Edit/5
        public async Task Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            _context.Update(device);
            await _context.SaveChangesAsync();
        }

        // POST: Devices/Delete/5
        public async Task DeleteConfirmed(Guid id)
        {
            var device = await _context.Device.FindAsync(id);
            _context.Device.Remove(device);
            await _context.SaveChangesAsync(); 
        }

        public bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
    }
}
