using Newtonsoft.Json;

namespace HomeTaskOne.Models.PageItemModels
{
    public class Answer
    {
        public int question_id { get; set; }
        public int variant_id { get; set; }
        public bool selected { get; set; }

        public Answer() { }
    }
}