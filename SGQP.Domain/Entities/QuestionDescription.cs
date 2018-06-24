using System;
using System.Collections.Generic;

namespace SGQP.Domain.Entities
{
    public class QuestionDescription
    {
        public QuestionDescription(string content)
        {
            content = Content;
            Alternatives = new List<QuestionAlternative>();
        }

        public Guid Id { get; set; }
        public string Cod { get; set; }
        public string Content { get; set; }
        public DateTime DataCreated => DateTime.Now;
        public DateTime DataUsed { get; set; }
        public IList<QuestionAlternative> Alternatives;

        //This fields is to QUESTION OBJECT:
        //public int TimesUsed { get; set; }
        //public Theme Theme { get; set; }
        //public Discipline Discipline { get; set; }
    }
}
