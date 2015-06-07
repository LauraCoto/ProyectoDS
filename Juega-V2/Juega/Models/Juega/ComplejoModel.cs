using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Juega.Models.Juega
{
    public class ComplejoModel
    {
        [Required] 
        public virtual long IdComplejoDeportivo { get; set; }

        [Required]
        [MaxLength(30)]
        public virtual string Nombre { get; set; }

        [Required]
        [MaxLength(220)]
        public virtual string Direccion { get; set; }

        public virtual string Telefonos { get; set; }
        public virtual string Coodernadas { get; set; }
        public virtual string FotoPrincipal { get; set; }

        public virtual int CantCanchas { get; set; }
    }

}