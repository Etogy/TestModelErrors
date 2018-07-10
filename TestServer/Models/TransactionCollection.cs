using System.Collections.Generic;

namespace TestServer.Models {
  public class TransactionCollection {
    public List<Transaction> Transactions { get; } = new List<Transaction>();

    public TransactionCollection(IEnumerable<Transaction> transactions) {
      Transactions.AddRange(transactions);
    }
  }
}