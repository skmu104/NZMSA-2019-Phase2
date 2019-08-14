using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mee_Mee.Model
{
    [Table("video")]
    public partial class Video
    {
        [Column("v_id")]
        public int VId { get; set; }
        [Required]
        [Column("v_url")]
        [StringLength(255)]
        public string VUrl { get; set; }
        [Required]
        [Column("v_thumb")]
        [StringLength(255)]
        public string VThumb { get; set; }
        [Column("v_length")]
        public int VLength { get; set; }
        [Column("show")]
        public bool Show { get; set; }
        [Column("clientId")]
        public int ClientId { get; set; }
        [Required]
        [Column("v_title")]
        [StringLength(255)]
        public string VTitle { get; set; }

        [ForeignKey("ClientId")]
        [InverseProperty("Video")]
        public virtual Clients Client { get; set; }
    }
}
