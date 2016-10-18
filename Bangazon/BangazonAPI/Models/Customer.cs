//definig the database table for customers
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bangazon.Models
{
  public class Customer//name of class is name of table in database
  {
    [Key]//primary key
    public int CustomerId {get;set;}

    [Required]//validation: there must be a value inputted
    [DataType(DataType.Date)]//must of of type date type
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//database generates the current timestamp
    public DateTime DateCreated {get;set;}

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public ICollection<PaymentType> PaymentTypes;//this is the "many" side of the one to many"
    //every customer has many payment types. this establishes the relationship without actualyl housing the payment types
  }
}