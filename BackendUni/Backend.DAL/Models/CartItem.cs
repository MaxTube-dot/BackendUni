namespace Backend.DAL.Models
{
    /// <summary>
    /// Сущность заказа в магазине.
    /// </summary>
    public class CartItem
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

        public DateTime AddDate { get; set; }

        public bool IsDone { get; set; }
    }
}
