namespace HomeTaskOne.Models.PageItemModels
{
    public class Variant
    {
        public int Id { get; private set; }
        public string DisplayText { get; private set; }

        public Variant(int id, string displayText)
        {
            Id = id;
            DisplayText = displayText;
        }

        public override bool Equals(object obj) => 
            obj is Variant && (obj as Variant).Id == Id;
    }
}