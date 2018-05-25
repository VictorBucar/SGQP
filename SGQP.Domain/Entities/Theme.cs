using System.Collections.Generic;

namespace SGQP.Domain.Entities
{
    public class Theme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subtheme> Subtemas { get; set; }
        public string ThemeCod { get; set; }
    }
}
