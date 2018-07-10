using System;
using System.ComponentModel.DataAnnotations;

namespace Etogy.Settlement.API.Models {
  public class Transaction {
    [Required]
    public string OrderNumber { get; set; }
  }
}