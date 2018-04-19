using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [MetadataType(typeof(HabilidadMetaData))]
    public partial class Habilidad
    {
        class HabilidadMetaData
        {
            [Display(Name = "Nombre de habilidad" )]
            public object Nombre { get; set; }
        }
    }
}
