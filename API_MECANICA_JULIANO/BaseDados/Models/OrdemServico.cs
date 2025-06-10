using System;
using System.Collections.Generic;

namespace API_MECANICA_JULIANO.BaseDados.Models;

public partial class OrdemServico
{
    public int IdOrdemServico { get; set; }

    public DateOnly DataAbertura { get; set; }

    public DateOnly? DataFechamento { get; set; }

    public string? Status { get; set; }

    public int? IdVeiculo { get; set; }

    public int? IdCliente { get; set; }

    public int? IdFuncionario { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Funcionario? IdFuncionarioNavigation { get; set; }

    public virtual Veiculo? IdVeiculoNavigation { get; set; }

    public virtual ICollection<ServicoRealizado> ServicoRealizados { get; set; } = new List<ServicoRealizado>();
}
