namespace GerenciamentoFinanceiro.Models
{
    public class Filtros
    {
        public string FiltroString { get; set; }

        public string CategoraiId { get; set; }

        public string TransacaoId { get; set; }

        public string DataOperacao { get; set; }

        public Filtros(string filtroString)
        {
            FiltroString = filtroString ?? "todos-todos-todos";
            string[] filtros = FiltroString.Split('-');

            CategoraiId = filtros[0];
            DataOperacao = filtros[1];
            TransacaoId = filtros[2];
        }

        public bool TemCategoria => CategoraiId.ToLower() != "todos";
        public bool TemTrasacao => TransacaoId.ToLower() != "todos";
        public bool TemDataOperacao => DataOperacao.ToLower() != "todos";

        public static Dictionary<string, string> ValoresDataOperacao =>
            new Dictionary<string, string>
            {
                {"mes-anterior", "Mês Passado" },
                {"proximo-mes", "Proximo Mês" },
                {"este-mes", "Este Mês" }

            };

        public bool EPassado => DataOperacao.ToLower() == "mes-anterior";
        public bool EFuturo => DataOperacao.ToLower() == "proximo-mes";
        public bool EesseMes => DataOperacao.ToLower() == "este-mes";


    }
}
