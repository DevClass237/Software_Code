using SenaiKeys.Academicos;
using SenaiKeys.Cusos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SenaiKeys.Salas
{
    public class SalaManager {

        public List<Sala> salas = new List<Sala>();    
        private List<Curso> cursos = new List<Curso>();
        private List<Turma> turmas = new List<Turma>();
     

        public void EditarAssociacao(int chave, int? novoIdDocente = null, int? novoIdCurso = null, string novoLaboratorio = null, int? novoNumeroTurma = null)
        {
            var sala = BuscarSalaPorChave(chave);
            if (sala == null) {
                Console.WriteLine("Sala não encontrada.");
                return;
            }
            if (novoIdCurso.HasValue && !cursos.Any(c => c.Id == novoIdCurso.Value)) {
                Console.WriteLine("Curso não encontrado.");
                return;
            }
            if (novoNumeroTurma.HasValue && !turmas.Any(t => t.NumeroTurma == novoNumeroTurma.Value)) {
                Console.WriteLine("Turma não encontrada.");
                return;
            }

            if (novoIdDocente.HasValue)
                sala.AlterarDocente(novoIdDocente.Value);
            if (novoIdCurso.HasValue)
                sala.AlterarCurso(novoIdCurso.Value);
            if (novoLaboratorio != null)
                sala.AlterarLaboratorio(novoLaboratorio);
            if (novoNumeroTurma.HasValue)
                sala.AlterarTurma(novoNumeroTurma.Value);

            Console.WriteLine("Associação editada com sucesso!");
        }
        public Sala? BuscarSalaPorChave(int chave)
        {
            return salas.FirstOrDefault(s => s.Chave == chave);
        }
        public IEnumerable<Sala> ListarSalas()
        {
            return salas;
        }
    }
}
