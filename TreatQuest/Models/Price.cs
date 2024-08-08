namespace TreatQuest.Models
{
    public class Price
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int SubChoiceId { get; set; }
        public SubChoice SubChoice { get; set; }

    }
}
