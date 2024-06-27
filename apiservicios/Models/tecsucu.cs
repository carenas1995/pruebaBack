namespace apiservicios.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tecsucu")]
    public partial class tecsucu
    {
        public int id { get; set; }

        public int tecnico { get; set; }

        public int sucursal { get; set; }

        [ForeignKey("FK_sucursal")]
        [NotMapped]
        public virtual sucursales sucursales { get; set; }

        [ForeignKey("FK_tecnico")]
        [NotMapped]
        public virtual tecnicos tecnicos { get; set; }
    }
}
