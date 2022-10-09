namespace Backend.DAL.Models
{
    /// <summary>
    /// Сущность товара магазина
    /// </summary>
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public int Price { get; set; }

        public string ImageLink { get; set; }

        public string Description { get; set; }
    }
}
