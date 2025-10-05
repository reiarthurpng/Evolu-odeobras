using System;
using System.ComponentModel.DataAnnotations;

namespace EvolucaoObra.Models
{
    public class Obra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [StringLength(300)]
        public string Endereco { get; set; }

        [StringLength(100)]
        public string Responsavel { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataTerminoPrevista { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataConclusao { get; set; }

        [StringLength(50)]
        public string Status { get; set; } // Ex: Em andamento, Concluída, Atrasada

        [StringLength(100)]
        public string EtapaAtual { get; set; } // Ex: Fundação, Estrutura, Acabamento

        [StringLength(500)]
        public string Observacoes { get; set; }
    }
}
