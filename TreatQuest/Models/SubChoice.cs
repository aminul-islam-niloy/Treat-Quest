namespace TreatQuest.Models
{
    public class SubChoice
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public int SubOptionId { get; set; }  
        public SubOption SubOption { get; set; }

        public ICollection<Price> Prices { get; set; }
        

    }
}
