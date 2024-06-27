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

        public virtual element element1 { get; set; }

        public virtual tecnicos tecnicos { get; set; }
    }
}
