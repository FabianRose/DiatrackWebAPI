using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiatrackWebAPI.Model
{
    [Table("reading_types")]
    public partial class ReadingTypes
    {
        [Column("reading_type_id")]
        [StringLength(2)]
        public string ReadingTypeId { get; set; }
        [Required]
        [Column("reading_desc")]
        [StringLength(20)]
        public string ReadingDesc { get; set; }
    }
}
