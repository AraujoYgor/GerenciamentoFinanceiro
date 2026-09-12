using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GerenciamentoFinanceiro.Models
{
    public class Financeiro
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataDaOperacao { get; set; }

        public string CategoriaId { get; set; }

        [ValidateNever]
        public Categoria categoria{ get; set; }

        public string TransacaoId { get; set; }

        [ValidateNever]
        public string transacao { get; set; }

    }
}
