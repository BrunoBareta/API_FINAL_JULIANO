using Microsoft.EntityFrameworkCore;
using API_MECANICA_JULIANO.BaseDados.Models;

namespace API_MECANICA_JULIANO.BaseDados
{
    public class TrabalhoMecanicaContext : DbContext
    {
        public TrabalhoMecanicaContext(DbContextOptions<TrabalhoMecanicaContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<OrdemServico> OrdemServicos { get; set; }
        public DbSet<ServicoRealizado> ServicoRealizados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");
                entity.HasKey(e => e.IdCliente);
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
                entity.Property(e => e.Nome).HasColumnName("nome").HasMaxLength(100);
                entity.Property(e => e.Telefone).HasColumnName("telefone").HasMaxLength(20);
                entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(100);
                entity.Property(e => e.Endereco).HasColumnName("endereco").HasMaxLength(150);
            });

            // Veiculo
            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.ToTable("veiculo");
                entity.HasKey(e => e.IdVeiculo);
                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");
                entity.Property(e => e.Placa).HasColumnName("placa").HasMaxLength(10);
                entity.Property(e => e.Modelo).HasColumnName("modelo").HasMaxLength(50);
                entity.Property(e => e.Ano).HasColumnName("ano");
                entity.Property(e => e.Cor).HasColumnName("cor").HasMaxLength(30);
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.HasOne(e => e.Cliente)
                      .WithMany(c => c.Veiculos)
                      .HasForeignKey(e => e.IdCliente);
            });

            // Funcionario
            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("funcionario");
                entity.HasKey(e => e.IdFuncionario);
                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");
                entity.Property(e => e.Nome).HasColumnName("nome").HasMaxLength(100);
                entity.Property(e => e.Funcao).HasColumnName("funcao").HasMaxLength(50);
                entity.Property(e => e.Telefone).HasColumnName("telefone").HasMaxLength(20);
            });

            // Servico
            modelBuilder.Entity<Servico>(entity =>
            {
                entity.ToTable("servico");
                entity.HasKey(e => e.IdServico);
                entity.Property(e => e.IdServico).HasColumnName("id_servico");
                entity.Property(e => e.Descricao).HasColumnName("descricao").HasMaxLength(100);
                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            // OrdemServico
            modelBuilder.Entity<OrdemServico>(entity =>
            {
                entity.ToTable("ordem_servico");
                entity.HasKey(e => e.IdOrdemServico);
                entity.Property(e => e.IdOrdemServico).HasColumnName("id_ordem_servico");
                entity.Property(e => e.Status).HasColumnName("status").HasMaxLength(20).HasDefaultValue("Aberta");
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
                entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");
                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");
                entity.Property(e => e.DataAbertura).HasColumnName("data_abertura");
                entity.Property(e => e.DataFechamento).HasColumnName("data_fechamento");


                entity.HasOne(e => e.Cliente)
                      .WithMany(c => c.OrdemServicos)
                      .HasForeignKey(e => e.IdCliente);

                entity.HasOne(e => e.Veiculo)
                      .WithMany(v => v.OrdemServicos)
                      .HasForeignKey(e => e.IdVeiculo);

                entity.HasOne(e => e.Funcionario)
                      .WithMany(f => f.OrdemServicos)
                      .HasForeignKey(e => e.IdFuncionario);
            });

            // ServicoRealizado
            modelBuilder.Entity<ServicoRealizado>(entity =>
            {
                entity.ToTable("servico_realizado");
                entity.HasKey(e => e.IdServicoRealizado);
                entity.Property(e => e.IdServicoRealizado).HasColumnName("id_servico_realizado");
                entity.Property(e => e.IdOrdemServico).HasColumnName("id_ordem_servico");
                entity.Property(e => e.IdServico).HasColumnName("id_servico");
                entity.Property(e => e.Quantidade).HasColumnName("quantidade");
                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.HasOne(e => e.OrdemServico)
                      .WithMany(o => o.ServicoRealizados)
                      .HasForeignKey(e => e.IdOrdemServico);

                entity.HasOne(e => e.Servico)
                      .WithMany(s => s.ServicosRealizados)
                      .HasForeignKey(e => e.IdServico);
            });
        }
    }
}
