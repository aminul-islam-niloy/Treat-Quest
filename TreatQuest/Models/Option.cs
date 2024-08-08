namespace TreatQuest.Models
{
    public class Option
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<SubOption> SubOptions { get; set; }

    }
}
