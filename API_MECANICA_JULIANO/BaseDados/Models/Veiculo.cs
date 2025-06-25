using API_MECANICA_JULIANO.BaseDados.Models;

// Representa a entidade Veiculo no sistema
public class Veiculo
{
    // Chave primária
    public int IdVeiculo { get; set; }

    // Dados do veículo
    public string? Placa { get; set; }       // Placa do veículo
    public string? Modelo { get; set; }      // Modelo do veículo
    public int? Ano { get; set; }            // Ano de fabricação
    public string? Cor { get; set; }         // Cor do veículo

    // Chave estrangeira que liga o veículo a um cliente
    public int IdCliente { get; set; }

    // Propriedade de navegação (relacionamento com Cliente)
    public Cliente? Cliente { get; set; }

    // Lista de ordens de serviço associadas a este veículo
    public ICollection<OrdemServico>? OrdemServicos { get; set; }
}
