using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_MECANICA_JULIANO.BaseDados.Models;

public partial class TrabalhoMecanicaContext : DbContext
{
    public TrabalhoMecanicaContext()
    {
    }

    public TrabalhoMecanicaContext(DbContextOptions<TrabalhoMecanicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<OrdemServico> OrdemServicos { get; set; }

    public virtual DbSet<Servico> Servicos { get; set; }

    public virtual DbSet<ServicoRealizado> ServicoRealizados { get; set; }

    public virtual DbSet<Veiculo> Veiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Trabalho_Mecanica;Username=postgres;Password=Casa2150!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasMaxLength(150)
                .HasColumnName("endereco");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.IdFuncionario).HasName("funcionario_pkey");

            entity.ToTable("funcionario");

            entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");
            entity.Property(e => e.Funcao)
                .HasMaxLength(50)
                .HasColumnName("funcao");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<OrdemServico>(entity =>
        {
            entity.HasKey(e => e.IdOrdemServico).HasName("ordem_servico_pkey");

            entity.ToTable("ordem_servico");

            entity.Property(e => e.IdOrdemServico).HasColumnName("id_ordem_servico");
            entity.Property(e => e.DataAbertura).HasColumnName("data_abertura");
            entity.Property(e => e.DataFechamento).HasColumnName("data_fechamento");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");
            entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Aberta'::character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.OrdemServicos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("ordem_servico_id_cliente_fkey");

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.OrdemServicos)
                .HasForeignKey(d => d.IdFuncionario)
                .HasConstraintName("ordem_servico_id_funcionario_fkey");

            entity.HasOne(d => d.IdVeiculoNavigation).WithMany(p => p.OrdemServicos)
                .HasForeignKey(d => d.IdVeiculo)
                .HasConstraintName("ordem_servico_id_veiculo_fkey");
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(e => e.IdServico).HasName("servico_pkey");

            entity.ToTable("servico");

            entity.Property(e => e.IdServico).HasColumnName("id_servico");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.Valor)
                .HasPrecision(10, 2)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<ServicoRealizado>(entity =>
        {
            entity.HasKey(e => e.IdServicoRealizado).HasName("servico_realizado_pkey");

            entity.ToTable("servico_realizado");

            entity.Property(e => e.IdServicoRealizado).HasColumnName("id_servico_realizado");
            entity.Property(e => e.IdOrdemServico).HasColumnName("id_ordem_servico");
            entity.Property(e => e.IdServico).HasColumnName("id_servico");
            entity.Property(e => e.Quantidade)
                .HasDefaultValue(1)
                .HasColumnName("quantidade");
            entity.Property(e => e.Subtotal)
                .HasPrecision(10, 2)
                .HasColumnName("subtotal");

            entity.HasOne(d => d.IdOrdemServicoNavigation).WithMany(p => p.ServicoRealizados)
                .HasForeignKey(d => d.IdOrdemServico)
                .HasConstraintName("servico_realizado_id_ordem_servico_fkey");

            entity.HasOne(d => d.IdServicoNavigation).WithMany(p => p.ServicoRealizados)
                .HasForeignKey(d => d.IdServico)
                .HasConstraintName("servico_realizado_id_servico_fkey");
        });

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.IdVeiculo).HasName("veiculo_pkey");

            entity.ToTable("veiculo");

            entity.HasIndex(e => e.Placa, "veiculo_placa_key").IsUnique();

            entity.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");
            entity.Property(e => e.Ano).HasColumnName("ano");
            entity.Property(e => e.Cor)
                .HasMaxLength(30)
                .HasColumnName("cor");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .HasColumnName("modelo");
            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .HasColumnName("placa");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Veiculos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("veiculo_id_cliente_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
