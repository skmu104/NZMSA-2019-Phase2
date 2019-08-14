using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mee_Mee.Model
{
    [Table("clients")]
    public partial class Clients
    {
        public Clients()
        {
            Video = new HashSet<Video>();
        }

        [Column("clientId")]
        public int ClientId { get; set; }
        [Column("displayed")]
        public int Displayed { get; set; }
        [Required]
        [Column("client_name")]
        [StringLength(255)]
        public string ClientName { get; set; }
        [Column("client_Dp")]
        [StringLength(255)]
        public string ClientDp { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<Video> Video { get; set; }
    }
}
