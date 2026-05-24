using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HealthcareAPI.Models;
using HealthcareAPI.Services;

namespace HealthcareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Billing>> GetBillingById(int id)
        {
            var billing = await _billingService.GetBillingByIdAsync(id);
            if (billing == null)
                return NotFound();

            return Ok(billing);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Billing>>> GetAllBillings()
        {
            var billings = await _billingService.GetAllBillingsAsync();
            return Ok(billings);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<Billing>>> GetBillingsByPatient(int patientId)
        {
            var billings = await _billingService.GetBillingsByPatientAsync(patientId);
            return Ok(billings);
        }

        [HttpPost]
        public async Task<ActionResult<Billing>> CreateBilling([FromBody] Billing billing)
        {
            try
            {
                var result = await _billingService.CreateBillingAsync(billing);
                return CreatedAtAction(nameof(GetBillingById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Billing>> UpdateBilling(int id, [FromBody] Billing billing)
        {
            try
            {
                var result = await _billingService.UpdateBillingAsync(id, billing);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBilling(int id)
        {
            var result = await _billingService.DeleteBillingAsync(id);
            if (!result)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}/balance")]
        public async Task<ActionResult<decimal>> GetBalance(int id)
        {
            var balance = await _billingService.CalculateBalanceAsync(id);
            return Ok(balance);
        }
    }
}
