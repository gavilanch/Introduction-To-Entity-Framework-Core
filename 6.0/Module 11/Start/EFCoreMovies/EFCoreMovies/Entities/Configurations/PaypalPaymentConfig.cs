using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreMovies.Entities.Configurations
{
    public class PaypalPaymentConfig : IEntityTypeConfiguration<PaypalPayment>
    {
        public void Configure(EntityTypeBuilder<PaypalPayment> builder)
        {
            builder.Property(p => p.EmailAddress).IsRequired();

            var payment1 = new PaypalPayment()
            {
                Id = 1,
                PaymentDate = new DateTime(2022, 3, 2),
                PaymentType = PaymentType.Paypal,
                Amount = 123,
                EmailAddress = "felipe@hotmail.com"
            };

            var payment2 = new PaypalPayment()
            {
                Id = 2,
                PaymentDate = new DateTime(2022, 3, 1),
                PaymentType = PaymentType.Paypal,
                Amount = 456,
                EmailAddress = "claudia@hotmail.com"
            };

            builder.HasData(payment1, payment2);

        }
    }
}
