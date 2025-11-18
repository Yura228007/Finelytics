using finelytics.Models;
namespace finelytics
{
    public class TransactionsService
    {
        public static Transaction? CurrentTransaction { get; set; }
        public TransactionsService() { }
    }
}
