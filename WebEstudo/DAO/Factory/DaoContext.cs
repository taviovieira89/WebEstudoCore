using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using WebEstudo.DAO.EntidadesDAO;
using WebEstudo.Entidades;

namespace WebEstudo.DAO.Factory
{
    public class DaoContext : DbContext
    {
        public DaoContext(DbContextOptions<DaoContext> options) : base(options)
        { }
        DbSet<Usuario>? Usuarios { get; set; }
        DbSet<Produtos>? Produtos { get; set; }

    }
}
