using System.Linq;
using System.Collections.Generic;

namespace HomeTaskOne.Models.PageItemModels
{
    public class Question : PageItemBase
    {
        public int Id { get; private set; }
        public Dictionary<Variant, bool> Variants { get; private set; }

        public Question(int id, string questionName, string questionText, Dictionary<Variant, bool> variants = null) :
            base(questionName, questionText)
        {
            Id = id;
            Variants = variants == null ? new Dictionary<Variant, bool>() : variants;
        }

        public bool IsRight(List<Answer> answers) =>
            answers.Where(A => A.question_id == Id).ToList().TrueForAll(A => Variants.SingleOrDefault(V => V.Key.Id == A.variant_id).Value == A.selected);

        public bool IsMultiselect => Variants.Where(V => V.Value).Count() > 1;

        public override bool Equals(object obj) =>
            obj is Question && (obj as Question).Id == Id;
    }
}