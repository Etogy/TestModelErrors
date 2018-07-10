using System;
using System.ComponentModel.DataAnnotations;

namespace TestServer.Models {
  public class Transaction {
    [Required]
    public string OrderNumber { get; set; }
  }
}