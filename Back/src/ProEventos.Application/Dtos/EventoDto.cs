using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Interlavo não permitido.")]
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio.")]
        [MinLength(3, ErrorMessage = "O {0} deve ter no mínimo 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "O {0}  deve ter no máximo 50 caracteres.")]
        public string Tema { get; set; }

        [Display(Name = "Qtd pessoas")]
        [Range(1, 5000, ErrorMessage = "{0} não permitido.")]
        public int QtdPessoas { get; set; }

        [Display(Name = "Imagem")]
        [RegularExpression(@"(?i).*\.(gif|jpe?g|png|bmp)$", ErrorMessage = "Formato de {0} inválido.")]
        public string ImagemURL { get; set; }

        [Required(ErrorMessage = "o campo {0} é requerido.")]
        [Phone(ErrorMessage = "Formato do campo {0} inválido.")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "O camp {0} precisa ser um e-mail válido.")]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }

    }
}
