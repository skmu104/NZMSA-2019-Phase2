using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    [Table("clients")]
    public partial class Clients
    {
        public Clients()
        {
            Video = new HashSet<Video>();
        }

        [Key]
        [Column("clientId")]
        public int ClientId { get; set; }
        [Column("displayed")]
        public int Displayed { get; set; }

        [InverseProperty("Client")]
        public ICollection<Video> Video { get; set; }
    }
}
