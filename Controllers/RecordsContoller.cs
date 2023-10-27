using AutoMapper;
using MediPortal_Records.Models;
using MediPortal_Records.Models.Dtos;
using MediPortal_Records.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MediPortal_Records.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsContoller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRecordsInterface _recordsInterface;
        private readonly ResponseDto _response;
        public RecordsContoller(IMapper mapper, IRecordsInterface recordsInterface)
        {
            _mapper = mapper;
            _recordsInterface = recordsInterface;
            _response = new ResponseDto();
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> AddRecord( RecordRequestDto recordRequestDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var NewRecord =  _mapper.Map<Record>(recordRequestDto);
            NewRecord.PatientId = Guid.Parse(userIdClaim.Value);
            var res = await _recordsInterface.AddRecord(NewRecord);
            if (string.IsNullOrWhiteSpace(res))
            {
                _response.IsSuccess = false;
                _response.Message = "Something went wrong";
                return BadRequest(_response);
            }
            _response.Message = res;
            return Ok(_response);
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetRecords()
        {
           
            var res = await _recordsInterface.GetAllRecords();
            if (res == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Something went wrong";
                return BadRequest(_response);
            }
            _response.obj = res;
            return Ok(_response);
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<ResponseDto>> GetRecord(Guid id)
        {

            var res = await _recordsInterface.GetRecordById(id);
            if (res == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Something went wrong";
                return BadRequest(_response);
            }
            _response.obj = res;
            return Ok(_response);
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseDto>> DeleteRecord(Guid Id)
        {
            var RecordToDelete = await _recordsInterface.GetRecordById(Id);
            if (RecordToDelete == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Something went wrong";
                return BadRequest(_response);
            }
          
            var res = await _recordsInterface.DeleteRecord(RecordToDelete);
            if (string.IsNullOrWhiteSpace(res))
            {
                _response.IsSuccess = false;
                _response.Message = "Something went wrong";
                return BadRequest(_response);
            }
            _response.Message = res;
            return Ok(_response);
        }
        [HttpPut]
        public async Task<ActionResult<ResponseDto>> UpdateRecord(Guid Id, RecordRequestDto recordRequestDto)
        {
            var RecordToUpdate = await _recordsInterface.GetRecordById(Id);
            if(RecordToUpdate == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Something went wrong";
                return BadRequest(_response);
            }
            var UpdatedRecord = _mapper.Map(recordRequestDto, RecordToUpdate);
            var res = await _recordsInterface.UpdateRecord(UpdatedRecord);
            if (string.IsNullOrWhiteSpace(res))
            {
                _response.IsSuccess = false;
                _response.Message = "Something went wrong";
                return BadRequest(_response);
            }
            _response.Message = res;
            return Ok(_response);
        }
    }
}
