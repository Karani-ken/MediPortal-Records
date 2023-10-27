using MediPortal_Records.Models;
using MediPortal_Records.Models.Dtos;

namespace MediPortal_Records.Services
{
    public interface IRecordsInterface
    {
        Task<string> AddRecord(Record record);
        Task<string> UpdateRecord(Record record);
        Task<string>DeleteRecord(Record record);

        Task<List<Record>> GetAllRecords();

        Task<Record> GetRecordById(Guid id);
    }
}
