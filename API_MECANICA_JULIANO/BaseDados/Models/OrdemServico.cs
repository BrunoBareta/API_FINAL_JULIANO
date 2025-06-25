using API_MECANICA_JULIANO.BaseDados.Models;

// Classe que representa uma ordem de serviço realizada na oficina
public class OrdemServico
{
    // Chave primária
    public int IdOrdemServico { get; set; }

    // Data em que a ordem foi aberta
    public DateTime DataAbertura { get; set; }
    public DateTime? DataFechamento { get; set; }

    // Status da ordem, por padrão é "Aberta"
    public string Status { get; set; } = "Aberta";

    // Chaves estrangeiras que indicam a quem pertence essa ordem
    public int IdVeiculo { get; set; }
    public int IdCliente { get; set; }
    public int IdFuncionario { get; set; }
    



    // Propriedades de navegação (relacionamentos com outras entidades)
    public Veiculo? Veiculo { get; set; }
    public Cliente? Cliente { get; set; }
    public Funcionario? Funcionario { get; set; }

    // Uma ordem de serviço pode ter vários serviços realizados
    public ICollection<ServicoRealizado>? ServicoRealizados { get; set; }
}
