using System;
using System.Collections.Generic;

namespace API_MECANICA_JULIANO.BaseDados.Models;

public partial class Funcionario
{
    public int IdFuncionario { get; set; }

    public string Nome { get; set; } = null!;

    public string? Funcao { get; set; }

    public string? Telefone { get; set; }

    public virtual ICollection<OrdemServico> OrdemServicos { get; set; } = new List<OrdemServico>();
}
