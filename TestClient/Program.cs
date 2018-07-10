using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Etogy.Settlement.API.Models;

namespace Etogy.Settlement.API.Client {
  public class Program {
    private const int RequestSize = 1000;

    public static async Task Main(string[] args) {
      var client = new HttpClient {
        BaseAddress = new Uri("http://localhost:5000")
      };

      var transactions = BuildTransactions();

      HttpResponseMessage withToken = await client.PostAsJsonAsync("api/test/withToken", transactions);
      var body = await withToken.Content.ReadAsStringAsync();
      Console.WriteLine(body);

      if (withToken.IsSuccessStatusCode) {
        Console.WriteLine("Test failed! Validation errors not receieved.");
      } else {
        Console.WriteLine("Test passed! Validation errors received.");
      }

      HttpResponseMessage withoutToken = await client.PostAsJsonAsync("api/test/noToken", transactions);
      body = await withoutToken.Content.ReadAsStringAsync();
      Console.WriteLine(body);

      if (withoutToken.IsSuccessStatusCode) {
        Console.WriteLine("Test failed! Validation errors not receieved.");
      } else {
        Console.WriteLine("Test passed! Validation errors received.");
      }
    }

    private static TransactionCollection BuildTransactions() {
      var transactions = Enumerable.Range(0, RequestSize)
        .Select(x => BuildTransaction());
      return new TransactionCollection(transactions);
    }

    private static Transaction BuildTransaction() {
      return new Transaction {
        OrderNumber = null // A required value. Definitely a validation error
      };
    }
  }
}
