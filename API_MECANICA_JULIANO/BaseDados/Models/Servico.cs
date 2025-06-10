using System;
using System.Collections.Generic;

namespace API_MECANICA_JULIANO.BaseDados.Models;

public partial class Servico
{
    public int IdServico { get; set; }

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    public virtual ICollection<ServicoRealizado> ServicoRealizados { get; set; } = new List<ServicoRealizado>();
}
