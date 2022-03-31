using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Functions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoicesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public InvoicesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("Scalars")]
        public async Task<ActionResult> GetScalars()
        {
            var invoices = await context.Invoices.Select(f => new
            {
                Id = f.Id,
                Total = context.InvoiceDetailSum(f.Id),
                Average = Scalars.InvoiceDetailAverage(f.Id)
            }).OrderByDescending(f => context.InvoiceDetailSum(f.Id))
            .ToListAsync();

            return Ok(invoices);
        }

        [HttpGet("{invoiceId:int}/detail")]
        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> GetDetail(int invoiceId)
        {
            return await context.InvoiceDetails
                .Where(p => p.InvoiceId == invoiceId)
                .OrderByDescending(p => p.Total).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var invoice = new Invoice()
                {
                    CreationDate = DateTime.Now
                };
                
                context.Add(invoice);
                await context.SaveChangesAsync();

                //throw new ApplicationException("this is an error");

                var invoiceDetail = new List<InvoiceDetail>()
            {
                new InvoiceDetail()
                {
                    InvoiceId = invoice.Id,
                    Product = "Product A",
                    Price = 123
                },
                 new InvoiceDetail()
                {
                     InvoiceId = invoice.Id,
                    Product = "Product B",
                    Price = 456
                }
            };

                context.AddRange(invoiceDetail);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok("all good");
            }
            catch(Exception ex)
            {
                return BadRequest("There was an error");
            }
        }
    }
}
