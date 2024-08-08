namespace TreatQuest.Models
{
    public class SubOption
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public int OptionId { get; set; }   
        public Option Option { get; set; }

        public ICollection<SubChoice> SubChoice { get; set; }
    }
}
