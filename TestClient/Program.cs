using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TestServer.Models;

namespace TestClient {
  public class Program {
    private const int RequestSize = 1000;

    private static HttpClient _client;

    public static async Task Main(string[] args) {
      _client = new HttpClient {
        BaseAddress = new Uri("http://localhost:5000")
      };
      _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

      var transactions = BuildTransactions();

      // await RunTest("api/test/withToken", transactions);
      // await RunTest("api/test/noToken", transactions);
      await RunTest("api/test/tokenFirst", transactions);
    }

    private static async Task RunTest(string uri, TransactionCollection transactions) {
      HttpResponseMessage withoutToken = await _client.PostAsJsonAsync(uri, transactions);
      var body = await withoutToken.Content.ReadAsStringAsync();
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
