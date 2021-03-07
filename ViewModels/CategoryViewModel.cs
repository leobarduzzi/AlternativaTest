using Flunt.Notifications;
using Flunt.Validations;

namespace AlternativaTest.ViewModels
{
    public class CategoryViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsNotNullOrEmpty(Name, "Name", "O Nome da categoria precisa ser definido")
            );
        }
    }
}