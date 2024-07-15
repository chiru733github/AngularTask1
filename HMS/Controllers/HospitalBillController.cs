using System.Data.SqlClient;
using HMS.Model.Entity;
using HMS.Model.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ModelLayer.Models;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalBillController : ControllerBase
    {
        private readonly PatientRepo repo;
        public HospitalBillController(PatientRepo patient)
        {
            repo=patient;
        }

        [HttpPost("AddPatient")]
        public ActionResult AddPatient(PatientBill bill)
        {
            try
            {
                var result = repo.Save_Button(bill);
                if (result == null)
                {
                    return BadRequest(new ResponseModel<string> { IsSuccess = false, Message = "User Register Failed", Data = "Email Already Exists" });
                }
                else
                {
                    return Ok(new ResponseModel<PatientBill> { IsSuccess = true, Message = "Register successfull", Data = result });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<string> { IsSuccess = false, Message = "User Register Failed", Data = ex.Message });
            }
        }

        [HttpPost("AddToGrid")]
        public IActionResult AddToGrid(int billNo, int InvestId)
        {
            try
            {
                var result = repo.Grid_Button(billNo,InvestId);
                if (result == null)
                {
                    return BadRequest(new ResponseModel<string> { IsSuccess = false, Message = "User Register Failed", Data = "Email Already Exists" });
                }
                else
                {
                    return Ok(new ResponseModel<bool> { IsSuccess = true, Message = "Register successfull", Data = result });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<string> { IsSuccess = false, Message = "User Register Failed", Data = ex.Message });
            }
        }

        [HttpGet("GetByBillNo")]
        public IActionResult GetByBillNo(int id)
        {
            try
            {
                var result = repo.GetById(id);
                if (result == null)
                {
                    return BadRequest(new ResponseModel<string> { IsSuccess = false, Message = "User Register Failed", Data = "Email Already Exists" });
                }
                else
                {
                    return Ok(new ResponseModel<PatientBill> { IsSuccess = true, Message = "Register successfull", Data = result });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<string> { IsSuccess = false, Message = "User Register Failed", Data = ex.Message });
            }
        }
        [HttpGet("GetAllPatient")]
        public IActionResult GetAllPatient() 
        {
            try
            {
                var result = repo.GetAllPatient();
                if (result == null)
                {
                    return BadRequest(new ResponseModel<string> { IsSuccess = false, Message = "User Register Failed", Data = "Email Already Exists" });
                }
                else
                {
                    return Ok(new ResponseModel<List<PatientBill>> { IsSuccess = true, Message = "Register successfull", Data = result });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<string> { IsSuccess = false, Message = "User Register Failed", Data = ex.Message });
            }
        }
        [HttpGet("ShowGrid")]
        public IActionResult ShowGrid(int BillNo)
        {
            try
            {
                var result = repo.ViewGrid(BillNo);
                if (result == null)
                {
                    return BadRequest(new ResponseModel<string> { IsSuccess = false, Message = "User Register Failed", Data = "Email Already Exists" });
                }
                else
                {
                    return Ok(new ResponseModel<List<Investigations>> { IsSuccess = true, Message = "Register successfull", Data = result });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<string> { IsSuccess = false, Message = "User Register Failed", Data = ex.Message });
            }
        }
    }
}
