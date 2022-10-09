namespace Backend.DAL.Models
{
    /// <summary>
    /// Сущность активного ивента.
    /// </summary>
    public class Like
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Task Task { get; set; }
    }
}
