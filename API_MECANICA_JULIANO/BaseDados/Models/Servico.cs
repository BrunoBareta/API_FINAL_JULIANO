using API_MECANICA_JULIANO.BaseDados.Models;

// Classe que representa um serviço disponível na oficina
public class Servico
{
    // Chave primária
    public int IdServico { get; set; }

    // Descrição do serviço (ex: troca de óleo, alinhamento)
    public string? Descricao { get; set; }

    // Valor do serviço
    public decimal Valor { get; set; }

    // Lista de serviços realizados relacionados a este serviço
    public ICollection<ServicoRealizado>? ServicosRealizados { get; set; }
}
