using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Table> Tables { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // เพิ่มโต๊ะ 10 โต๊ะ
        modelBuilder.Entity<Table>().HasData(
            Enumerable.Range(1, 10).Select(i => new Table
            {
                Id = i,
                TableName = $"โต๊ะ {i}"
            }).ToArray()
        );
    }
}