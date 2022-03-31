using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PaymentsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> Get()
        {
            return await context.Payments.ToListAsync();
        }

        [HttpGet("cards")]
        public async Task<ActionResult<IEnumerable<CardPayment>>> GetCardPayments()
        {
            return await context.Payments.OfType<CardPayment>().ToListAsync();
        }

        [HttpGet("paypal")]
        public async Task<ActionResult<IEnumerable<PaypalPayment>>> GetPaypalPayments()
        {
            return await context.Payments.OfType<PaypalPayment>().ToListAsync();
        }
    }
}
