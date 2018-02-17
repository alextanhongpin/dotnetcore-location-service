using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Company.LocationService.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Company.LocationService.Persistence 
{
    public class LocationRecordRepository : ILocationRecordRepository
    {
        private LocationDbContext _context;

        public LocationRecordRepository(LocationDbContext context)
        {
            _context = context;
        }

        public LocationRecord Add(LocationRecord locationRecord)
        {
            _context.Add(locationRecord);
            _context.SaveChanges();
            return locationRecord;
        }

        public LocationRecord Update(LocationRecord locationRecord)
        {
            _context.Entry(locationRecord).State = EntityState.Modified;
            _context.SaveChanges();
            return locationRecord;
        }

        public LocationRecord Get(Guid memberId, Guid recordId)
        {
            return _context.LocationRecords
            .Single(lr => lr.MemberID == memberId && lr.ID == recordId);
        }

        public LocationRecord Delete(Guid memberId, Guid recordId)
        {
            LocationRecord locationRecord = this.Get(memberId, recordId);
            _context.Remove(locationRecord);
            _context.SaveChanges();
            return locationRecord;
        }

        public LocationRecord GetLatestForMember(Guid memberId)
        {
            LocationRecord locationRecord = _context.LocationRecords.
                Where(lr => lr.MemberID == memberId).
                OrderBy(lr => lr.Timestamp).
                Last();
            
            return locationRecord;
        }

        public ICollection<LocationRecord> AllForMember(Guid memberId)
        {
            return _context.LocationRecords.
                Where(lr => lr.MemberID == memberId).
                OrderBy(lr => lr.Timestamp).
                ToList();
        }
    }
}