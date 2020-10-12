using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

 namespace EFCodeFirst
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Code { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal Sales { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }



        public Customer() { }
    }
}
