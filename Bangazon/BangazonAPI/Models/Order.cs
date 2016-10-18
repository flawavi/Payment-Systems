using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bangazon.Models
{
  public class Order
  {
    [Key]
    public int OrderId {get;set;}

    [Required]
    [DataType(DataType.Date)]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated {get;set;}

    
    [DataType(DataType.Date)]
    public DateTime? DateCompleted {get;set;}

    public int CustomerId {get;set;}//setting up a relationship to the PaymentType table
    public Customer Customer {get;set;}//setting up a relationship to the PaymentType table
    public int? PaymentTypeId {get;set;}//setting up a relationship to the PaymentType table
    public PaymentType PaymentType {get;set;}//setting up a relationship to the PaymentType table

    public ICollection<LineItem> LineItems;
  }
}