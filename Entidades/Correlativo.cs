using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Correlativo
    {
        [Column("IdCorrelativo")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int idCorrelativo { get; set; }

        [Column("codigo")]
        [Required]
        [StringLength(50)]
        public string codigo { get; set; }

        [ForeignKey("idTrabajador")]
        [StringLength(8)]
        public virtual Trabajador trabajador { get; set; }

        [ForeignKey("IdTipDoc")]
        public virtual TipoDocumento tipodocumento { get; set; }

        [Column("descripcion")]        
        [StringLength(50)]
        public string descripcion { get; set; }

        [Column("monto")]
        [Required]
        public Double monto { get; set; }

        [NotMapped]
        public List<TipoDocumento> tiposDocumento { get; set; }
    }
}
