using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apisBlog.Models.ApisI
{
    interface ComentarioEntradaI
    {
        COMENTARIOENTRADA getComentario(int IdComentario);
        bool setComentario(COMENTARIOENTRADA nuevo);
        List<COMENTARIOENTRADA> getAllComentarios();
        bool deleteComentario(int IdComentario);
    }
}
