namespace PocheteAPI.Modelo {
    public class Curso {
        public long Id { get; set; }
        public string? Nome { get; set; }
        
        //Relaçõa

        public int ProfessorMatricula { get; set; }
        public Professor? Professor { get; set; }

        public long TurmaId { get; set; }
        public Turma? Turma { get; set; }
    }
}
