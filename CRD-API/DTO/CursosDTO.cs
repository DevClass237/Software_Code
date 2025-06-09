namespace PocheteAPI.DTO {
    public class CursosDTO {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int ProfessorMatricula { get; set; }
        public long TurmaId { get; set; }
    }
}
