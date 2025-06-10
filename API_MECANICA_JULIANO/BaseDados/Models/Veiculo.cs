using System;
using System.Collections.Generic;

namespace API_MECANICA_JULIANO.BaseDados.Models;

public partial class Veiculo
{
    public int IdVeiculo { get; set; }

    public string Placa { get; set; } = null!;

    public string? Modelo { get; set; }

    public int? Ano { get; set; }

    public string? Cor { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<OrdemServico> OrdemServicos { get; set; } = new List<OrdemServico>();
}
