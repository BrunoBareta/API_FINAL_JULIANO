public class ServicoRealizado
{
    public int IdServicoRealizado { get; set; }
    public int IdOrdemServico { get; set; }
    public int IdServico { get; set; }
    public int Quantidade { get; set; }
    public decimal Subtotal { get; set; }

    public OrdemServico? OrdemServico { get; set; }
    public Servico? Servico { get; set; }
}
