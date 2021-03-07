using Flunt.Notifications;
using Flunt.Validations;

namespace AlternativaTest.ViewModels
{
    public class ProductViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string Brand { get; set; }
        public int CategoryId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsNotNullOrEmpty(Name, "Name", "O Nome do produto precisa ser definido")
                    .IsGreaterThan(Value, decimal.Zero, "Value", "O valor precisa ser maior que zero")
                    .IsNotNull(CategoryId, "CategoryId", "A categoria do produto precisa ser definida")
            );
        }
    }
}