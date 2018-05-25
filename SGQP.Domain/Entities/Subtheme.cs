namespace SGQP.Domain.Entities
{
    public class Subtheme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Theme ThemeId { get; set; }
        public string SubThemeCod { get; set; }
    }
}