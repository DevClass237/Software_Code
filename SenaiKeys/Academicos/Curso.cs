using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenaiKeys.Cusos
{
    class Curso
    {
        public int Id { get; set; }
        public string NomeCurso { get; private set; }
        public int IdTurma { get; private set; }
        public int IdDocente { get; private set; }
        public int IdSala { get; private set; }

        public Curso(string nomeCurso, int idTurma, int idDocente, int idSala)
        {
            NomeCurso = nomeCurso;
            IdTurma = idTurma;
            IdDocente = idDocente;
            IdSala = idSala;
        }
    }
}
