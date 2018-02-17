using System;
using System.Linq;
using System.Collections.Generic;

namespace Company.LocationService.Models
{
    public class InMemoryLocationRecordRepository : ILocationRecordRepository
    {
        private List<LocationRecord> _records = new List<LocationRecord>() {};
        public LocationRecord Add(LocationRecord record)
        {
            _records.Add(record);
            Console.WriteLine(_records.Count());
            return record;
        }

        public LocationRecord Update(LocationRecord record)
        {
            _records = _records.Select(r => {
                if (r.ID == record.ID) {
                    r = record;
                }
                return r;
            }).ToList();
            return record;
        }

        public LocationRecord Get (Guid memberId, Guid recordId)
        {
            var record = _records.First(_ => _.MemberID == memberId);
            return record;
        }

        public LocationRecord Delete(Guid memberId, Guid recordId)
        {
            var record = _records
                .First(_ => _.MemberID == memberId);
            
            _records = _records
                .Where(_ => _.MemberID != memberId)
                .Select(_ => _)
                .ToList();

            return record;
        }

        public LocationRecord GetLatestForMember(Guid memberId)
        {
            var record = _records.First(_ => _.MemberID == memberId);
            if (record == null) {
                return new LocationRecord();
            }
            return record;
        }

        public ICollection<LocationRecord> AllForMember(Guid memberId)
        {
            var records = _records
                .Where(_ => _.MemberID == memberId)
                .Select(_ => _)
                .ToList();

            if (records == null) {
                return new List<LocationRecord>(){};
            }
            return records;
        }
    }
}
