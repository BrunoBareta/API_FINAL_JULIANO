namespace API_MECANICA_JULIANO.BaseDados.Models
{
    // Classe que representa a tabela de Cliente no banco de dados
    public class Cliente
    {
        // Chave primária da tabela
        public int IdCliente { get; set; }

        // Nome do cliente
        public string? Nome { get; set; }

        // Telefone para contato
        public string? Telefone { get; set; }

        // Email do cliente
        public string? Email { get; set; }

        // Endereço do cliente
        public string? Endereco { get; set; }

        // Relacionamento: um cliente pode ter vários veículos
        public ICollection<Veiculo>? Veiculos { get; set; }

        // Relacionamento: um cliente pode ter várias ordens de serviço
        public ICollection<OrdemServico>? OrdemServicos { get; set; }
    }
}
