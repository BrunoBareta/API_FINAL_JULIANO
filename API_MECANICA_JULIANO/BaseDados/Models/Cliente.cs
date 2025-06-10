using System;
using System.Collections.Generic;

namespace API_MECANICA_JULIANO.BaseDados.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nome { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public string? Endereco { get; set; }

    public virtual ICollection<OrdemServico> OrdemServicos { get; set; } = new List<OrdemServico>();

    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
