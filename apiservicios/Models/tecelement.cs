namespace apiservicios.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tecelement")]
    public partial class tecelement
    {
        public int id { get; set; }

        public int tecnico { get; set; }

        public int element { get; set; }      

        [ForeignKey("FK_element")]
        [NotMapped]
        public virtual element elements { get; set; }

        [ForeignKey("FK_tecnico2")]
        [NotMapped]
        public virtual tecnicos tecnicos { get; set; }

    }
}
