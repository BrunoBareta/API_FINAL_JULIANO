using System;
using System.Collections.Generic;

namespace API_MECANICA_JULIANO.BaseDados.Models;

public partial class ServicoRealizado
{
    public int IdServicoRealizado { get; set; }

    public int? IdOrdemServico { get; set; }

    public int? IdServico { get; set; }

    public int? Quantidade { get; set; }

    public decimal Subtotal { get; set; }

    public virtual OrdemServico? IdOrdemServicoNavigation { get; set; }

    public virtual Servico? IdServicoNavigation { get; set; }
}
