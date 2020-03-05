using System.Linq;
using System.Collections.Generic;

namespace HomeTaskOne.Models.PageItemModels
{
    public class Question : PageItemBase
    {
        public ICollection<Variant> AnswerVariants { get; set; } = new List<Variant>();

        public Question() : base(0, "", "") { }

        public Question(string questionName, string questionText,
                        IEnumerable<Variant> variants = null) :
            base(0, questionName, questionText)
        {
            if (variants != null)
                AnswerVariants = variants.ToList();
        }

        public bool IsRight(List<Answer> answers) =>
            answers.Where(A => A.question_id == Id).ToList()
                   .TrueForAll(A => AnswerVariants.SingleOrDefault(V => V.Id == A.variant_id).IsRight == A.selected);

        public bool IsMultiselect => AnswerVariants.Where(V => V.IsRight).Count() > 1;

        public override bool Equals(object obj) =>
            obj is Question && (obj as Question).Id == Id;
    }
}