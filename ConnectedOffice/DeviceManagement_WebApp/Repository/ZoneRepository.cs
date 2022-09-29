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
    public class ZoneRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        // GET: Zones
        public async Task<List<Zone>> GetAll()
        {
            return await _context.Zone.ToListAsync();
        }

        // GET: Zones/Details/5
        public async Task<Zone> GetDetails(Guid? id)
        { 
            var zone = await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);
            return zone;
        }

        // POST: Zones/Create
        public async Task<Zone> Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            _context.Add(zone);
            await _context.SaveChangesAsync();

            return zone;
        }

        // POST: Zones/Edit/5
        public async Task Edit(Guid id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
                _context.Update(zone);
                await _context.SaveChangesAsync();
        }

        // POST: Zones/Delete/5
        public async Task DeleteConfirmed(Guid id)
        {
            var zone = await _context.Zone.FindAsync(id);
            _context.Zone.Remove(zone);
            await _context.SaveChangesAsync();
        }

        public bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }
    }
}
