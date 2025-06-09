﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PocheteAPI.Modelo {
    public class Professor {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Matricula { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}