﻿using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ServicoOnlineUsuario.empresa.dominio.entidade;
using ServicoOnlineUsuario.empresa.map;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineUsuario.empresa.contexto
{
    public class EmpresaContexto : DbContext
    {
        internal virtual DbSet<Empresa> Empresas { get; set; }
        internal virtual DbSet<EmpresaUsuario> EmpresasUsuarios { get; set; }
        private EmpresaContexto(DbContextOptions<EmpresaContexto> options) : base(options)
        {

        }
        internal static EmpresaContexto Create(DbContextOptions<EmpresaContexto> options)
        {
            return new EmpresaContexto(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EmpresaMap.createInstance(modelBuilder);
            EmpresaUsuarioMap.createInstance(modelBuilder);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.EmpresaUsuarios)
                .WithOne(e => e.Empresa)
                .HasForeignKey(e => e.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_EmpresaUsuario_Empresa");

            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);
        }
    }
}
