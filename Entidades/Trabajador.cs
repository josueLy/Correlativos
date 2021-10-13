using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Trabajador
    {

        [Column("IdTrabajador")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTrabajador { get; set; }

        [Column("DNI")]
        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Column("nombre")]
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }


        public Trabajador() { }
        public Trabajador(int id,string dni,string nombre) 
        {
            this.idTrabajador = id;
            this.dni = dni;
            this.nombre = nombre;
        }

    }
}
