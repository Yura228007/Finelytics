namespace Finelytics.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int CategoryId { get; set; }
        public decimal PlannedAmmount { get; set; }
        public string Comment { get; set; }
    }
}
