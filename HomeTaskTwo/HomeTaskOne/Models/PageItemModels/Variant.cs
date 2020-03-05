using System.ComponentModel.DataAnnotations.Schema;

namespace HomeTaskOne.Models.PageItemModels
{
    public class Variant
    {
        public int Id { get; private set; }
        public string DisplayText { get; private set; }
        public bool IsRight { get; private set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public Variant() { }

        public Variant(string displayText, bool isRight, Question question = null)
        {
            DisplayText = displayText;
            IsRight = isRight;
            Question = question;
            QuestionId = Question?.Id ?? 0;
        }

        public override bool Equals(object obj) => 
            obj is Variant && (obj as Variant).Id == Id;
    }
}