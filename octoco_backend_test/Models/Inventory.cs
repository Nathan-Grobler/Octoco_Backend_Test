namespace octoco_backend_test.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string? Item { get; set; }

        public int Quantity { get; set; }

        public int SurvivorId { get; set; }

        public Survivor? Survivor { get; set; }
    }
}
