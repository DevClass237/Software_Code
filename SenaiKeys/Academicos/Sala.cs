using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenaiKeys.Academicos
{
  public  class Sala {

        private List<Sala> salas = new List<Sala>();
        public int Chave { get; private set; }
        public bool Status { get; private set; }
        public string Laboratorio { get; private set; }
        public int IdDocente { get; private set; }
        public int IdCurso { get; private set; }

        public Sala(int chave, bool status, string laboratorio, int idDocente, int idCurso)
        {
            Chave = chave;
            Status = status;
            Laboratorio = laboratorio;
            IdDocente = idDocente;
            IdCurso = idCurso;
        }
        public IEnumerable<Sala> ListarSalas()
        {
            return salas;
        }
        public Sala BuscarSalaPorChave(int chave)
        {
            return salas.FirstOrDefault(s => s.Chave == chave)!;
        }
        public void AlterarDocente(int novoIdDocente)
        {
            IdDocente = novoIdDocente;
        }
        public void AlterarCurso(int novoIdCurso)
        {
            IdCurso = novoIdCurso;
        }
        public void AlterarLaboratorio(string novoLaboratorio)
        {
            Laboratorio = novoLaboratorio;
        }
        public void AlterarTurma(int novoIdTurma)
        {
            IdCurso = novoIdTurma;
        }
    }
}
