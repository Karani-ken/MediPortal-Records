using MediPortal_Records.Data;
using MediPortal_Records.Models;
using MediPortal_Records.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MediPortal_Records.Services
{
    public class RecordService : IRecordsInterface
    {
        private readonly ApplicationDbContext _context;
        public RecordService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddRecord(Record record)
        {
            await _context.Records.AddAsync(record);
            await _context.SaveChangesAsync();
            return "record added successfully";
        }

        public async Task<string> DeleteRecord(Record record)
        {
            _context.Remove(record);
            await _context.SaveChangesAsync();
            return "Record Added successfully";
        }

        public async Task<List<Record>> GetAllRecords()
        {
            return await _context.Records.ToListAsync();
        }

        public async Task<Record> GetRecordById(Guid id)
        {
            return await _context.Records.FirstOrDefaultAsync(r => r.RecordId == id);
        }

        public async Task<string> UpdateRecord(Record record)
        {
            _context.Records.Update(record);
            await _context.SaveChangesAsync();
            return "Record updated successfully";
        }
    }
}
