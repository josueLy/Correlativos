using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class TipoDocumento
    {


        [Column("IdTipDoc")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int idTipDoc { get; set; }


        [Column("Prefijo")]
        [Required]
        [StringLength(50)]
        public string prefijo { get; set; }


        [Column("Descripcion")]
        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }

        

        
    }
}
