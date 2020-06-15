using Kira.Genealogy.Model.Domain.Drawing;
using Kira.Genealogy.Model.Domain.Tree;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kira.Genealogy.Persistence.Context
{
    public class GenealogyContext : DbContext
    {
        public DbSet<TreeFamily> Trees { get; set; }
        public DbSet<Branch> Branches { get; set; }
        //public DbSet<PersonBranch> PersonBranches { get; set; }
        public DbSet<Person> People{ get; set; }
        public DbSet<Node> Nodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GenealogyDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            CreateRelationships(modelBuilder);
            SetFilter(modelBuilder);
        }

        private void CreateRelationships(ModelBuilder modelBuilder)
        {
            //  Person
            modelBuilder.Entity<Person>(person => {
                person.Property(p => p.Name).HasMaxLength(100).IsRequired();
                person.Property(p => p.FirstFamilyName).HasMaxLength(100).IsRequired();
                person.Property(p => p.SecondFamilyName).HasMaxLength(100);
                person.Property(p => p.BornDate);
                person.Property(p => p.IsBornDateExactly);
                person.Property(p => p.IsAlive).IsRequired();
                person.Property(p => p.DeathDate);
                person.Property(p => p.Gender).IsRequired();
                person.Property(p => p.IsDeathDateExactly);
                person.Property(p => p.PhoneNumber).HasMaxLength(100);
                person.Property(p => p.SharePhone).IsRequired();
                person.Property(p => p.MailAddress).HasMaxLength(100);
                person.Property(p => p.ShareMailAddress).IsRequired();
                person.Property(p => p.BornCity).HasMaxLength(200).IsRequired();
                person.Property(p => p.PersonalImage).HasMaxLength(100);
                person.Property(p => p.IsBornCityExactly).IsRequired();
                person.Property(p => p.TreeId).IsRequired();

                person.HasOne(p => p.TreeFamily).WithMany(tree => tree.TreePeople).HasForeignKey(p => p.TreeId);
            });

            //  Branch
            modelBuilder.Entity<Branch>(branch => {
                branch.Property(p => p.FirstFamilyName).HasMaxLength(100).IsRequired();
                branch.Property(p => p.SecondFamilyName).HasMaxLength(100);
                branch.Property(p => p.TreeId).IsRequired();
                branch.Property(p => p.ParentBranchId).IsRequired(false);
                branch.HasOne(p => p.TreeFamily).WithMany(tree => tree.Branches).HasForeignKey(p => p.TreeId);
            });

            ////  Person Branch
            //modelBuilder.Entity<PersonBranch>(pb => {
            //    pb.Property(p => p.PersonId).IsRequired();
            //    pb.Property(p => p.BranchId).IsRequired();
            //    pb.HasOne(p => p.Person).WithMany(p => p.Branches).HasForeignKey(p => p.BranchId);
            //    pb.HasOne(p => p.Branch).WithMany(p => p.BranchPeople).HasForeignKey(p => p.PersonId);
            //});

            //  Tree
            modelBuilder.Entity<TreeFamily>(tf => {
                tf.Property(p => p.FirstFamilyName).HasMaxLength(100).IsRequired();
                tf.Property(p => p.SecondFamilyName).HasMaxLength(100);
            });

            //  Tree
            modelBuilder.Entity<Node>(node => {
                node.Property(p => p.NodeType).IsRequired();
                node.Property(p => p.NodeParentId).IsRequired(false);
                node.Property(p => p.PersonId).IsRequired(false);
                node.Property(p => p.MatePersonId).IsRequired(false);
            });
        }

        private void SetFilter(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var isActiveProperty = entityType.FindProperty("Enabled");
                if (isActiveProperty != null && isActiveProperty.ClrType == typeof(bool))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "p");
                    var filter = Expression.Lambda(Expression.Property(parameter, isActiveProperty.PropertyInfo), parameter);
                    entityType.SetQueryFilter(filter);
                }
            }
        }
    }
}
