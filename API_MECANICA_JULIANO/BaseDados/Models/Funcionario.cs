using API_MECANICA_JULIANO.BaseDados.Models;

// Classe que representa a tabela de Funcionário no banco de dados
public class Funcionario
{
    // Chave primária da tabela
    public int IdFuncionario { get; set; }

    // Nome do funcionário
    public string? Nome { get; set; }

    // Função ou cargo que o funcionário exerce
    public string? Funcao { get; set; }

    // Telefone para contato
    public string? Telefone { get; set; }

    // Relacionamento: um funcionário pode estar em várias ordens de serviço
    public ICollection<OrdemServico>? OrdemServicos { get; set; }
}
