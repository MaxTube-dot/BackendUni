using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Models
{
    public class UsersQuestionnaireAnswers
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Questionnaire Questionnaire { get; set; }

        public AnswerVariant AnswerVariant { get; set; }
    }
}
