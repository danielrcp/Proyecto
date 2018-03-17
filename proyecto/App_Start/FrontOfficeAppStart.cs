using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace proyecto.App_Start
{
    public class FrontOfficeAppStart
    {
        public static int UsuarioVisualizando()
        {
            int usuario_id_por_defecto = 3;
            string usuario_id = HttpContext.Current.Request.QueryString["id"];
            return usuario_id != null ? Convert.ToInt32(usuario_id) : usuario_id_por_defecto;
        }

        public static Usuario NombreUsuarioVisualizando()
        {
            var Usuario = new Usuario();
            int usuario_id_por_defecto = 3;
            string usuario_id = HttpContext.Current.Request.QueryString["id"];
            if (usuario_id != null)
            {
              Usuario = Usuario.Obtener(Convert.ToInt16(usuario_id));
            }
            else
            {
                Usuario = Usuario.Obtener(Convert.ToInt16(usuario_id_por_defecto));
            }
            return Usuario;
        }
    }
}