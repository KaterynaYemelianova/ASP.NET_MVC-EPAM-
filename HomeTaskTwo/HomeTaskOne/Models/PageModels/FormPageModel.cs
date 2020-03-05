using System.Linq;
using System.Collections.Generic;

using HomeTaskOne.Models.PageItemModels;

namespace HomeTaskOne.Models.PageModels
{
    public class FormPageModel : PageModelBase
    {
        private const string FORM_HEADER_TEXT = "Form";
        public IEnumerable<Question> Questions { get; private set; }

        public IEnumerable<Answer> Answers { get; private set; }
        public Answer this[Question q, Variant v] => Answers.Single(A => A.question_id == q.Id && A.variant_id == v.Id);

        public FormPageModel(NavigationMenuModel menuModel, IEnumerable<Question> questions = null) :
            base(FORM_HEADER_TEXT, menuModel)
        {
            Questions = questions ?? new List<Question>();
            Answers = Questions.Aggregate(new List<Answer>(), (A, Q) => A.Concat(Q.AnswerVariants.Select(V => new Answer() { question_id = Q.Id, variant_id = V.Id, selected = false })).ToList());
        }
    }
}