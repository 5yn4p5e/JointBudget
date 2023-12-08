using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JointBudgetAPI.JointBudgetModels;

public partial class JointBudgetContext : IdentityDbContext<User>
{
    public JointBudgetContext()
    {
    }

    public JointBudgetContext(DbContextOptions<JointBudgetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }

    public virtual DbSet<ExpenseImage> ExpenseImages { get; set; }

    public virtual DbSet<FamilyGroup> FamilyGroups { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<IncomeCategory> IncomeCategories { get; set; }

    public virtual DbSet<IncomeImage> IncomeImages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=NE0L\\SQLEXPRESS;Database=JointBudget;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.ToTable("Expense");

            entity.Property(e => e.Id)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.ExpenseCategory).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expense_ExpenseCategory");

            entity.HasOne(d => d.User).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expense_User");
        });

        modelBuilder.Entity<ExpenseCategory>(entity =>
        {
            entity.ToTable("ExpenseCategory");

            entity.Property(e => e.Id)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.Name)
            .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.ExpenseImage).WithMany(p => p.ExpenseCategories)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExpenseCategory_ExpenseImage");

            entity.HasOne(d => d.User).WithMany(p => p.ExpenseCategories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExpenseCategory_User");
        });

        modelBuilder.Entity<ExpenseImage>(entity =>
        {
            entity.ToTable("ExpenseImage");

            entity.Property(e => e.Id)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.HexColor)
                .HasMaxLength(7)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FamilyGroup>(entity =>
        {
            entity.ToTable("FamilyGroup");

            entity.Property(e => e.Id)
                .HasMaxLength(450)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.ToTable("Income");

            entity.Property(e => e.Id)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.IncomeCategory).WithMany(p => p.Incomes)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Income_IncomeCategory");

            entity.HasOne(d => d.User).WithMany(p => p.Incomes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Income_User");
        });

        modelBuilder.Entity<IncomeCategory>(entity =>
        {
            entity.ToTable("IncomeCategory");

            entity.Property(e => e.Id)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IncomeImage).WithMany(p => p.IncomeCategories)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IncomeCategory_IncomeImage");

            entity.HasOne(d => d.User).WithMany(p => p.IncomeCategories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IncomeCategory_User");
        });

        modelBuilder.Entity<IncomeImage>(entity =>
        {
            entity.ToTable("IncomeImage");

            entity.Property(e => e.Id)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.HexColor)
                .HasMaxLength(7)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasMaxLength(450)
                .IsUnicode(false);

            entity.HasOne(d => d.FamilyGroup).WithMany(p => p.Users)
                .HasForeignKey(d => d.FamilyGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_FamilyGroup");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}