namespace Backend.DAL.Models
{
    /// <summary>
    /// Сущность игровой роли.
    /// </summary>
    public class GameRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Mark> Marks { get; set; }
    }
}
