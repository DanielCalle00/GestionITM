using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionITM.Domain.Dtos
{
    public class MatriculaCreateDto
    {
        public int CursoId { get; set; }
        public string Periodo { get; set; } = "2026-1";
    }

}
