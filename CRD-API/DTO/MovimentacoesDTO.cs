namespace PocheteAPI.DTO {

    public class MovimentacaoDTO {
        public long Id { get; set; }
        public int ProfessorMatricula { get; set; }
        public long PocheteId { get; set; }

        public DateTime DataRetirada { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}