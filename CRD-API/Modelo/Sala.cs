using System.ComponentModel.DataAnnotations.Schema;

namespace PocheteAPI.Modelo {
    public class Sala {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
