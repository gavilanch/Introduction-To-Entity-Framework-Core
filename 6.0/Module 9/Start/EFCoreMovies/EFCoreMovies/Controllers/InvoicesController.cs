using EFCoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;

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
