using System.Data.Entity;

namespace SMSApp.DataAccess
{
    public class AppContext : DbContext
    {
        public AppContext() : base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*User_FarmOwner FK Configurations*/
            modelBuilder.Entity<FarmOwner>()
                .HasRequired(f => f.User)
                .WithMany(u => u.FarmOwners)
                .HasForeignKey(f => f.UserId)
                .WillCascadeOnDelete(false);

            /*User_Farm FK Configurations*/
            modelBuilder.Entity<Farm>()
                .HasRequired(f => f.User)
                .WithMany(u => u.Farms)
                .HasForeignKey(f => f.UserId)
                .WillCascadeOnDelete(false);

            /*User_SoilReading FK Configurations*/
            modelBuilder.Entity<SoilReading>()
                .HasRequired(s => s.User)
                .WithMany(u => u.SoilReadings)
                .HasForeignKey(s => s.UserId)
                .WillCascadeOnDelete(false);

            /*User_Contagion FK Configurations*/
            modelBuilder.Entity<Contagion>()
                .HasRequired(s => s.User)
                .WithMany(u => u.Contagions)
                .HasForeignKey(s => s.UserId)
                .WillCascadeOnDelete(false);

            /*User_Broadcast FK Configurations*/
            modelBuilder.Entity<Broadcast>()
                .HasRequired(b => b.User)
                .WithMany(u => u.Broadcasts)
                .HasForeignKey(b => b.UserId)
                .WillCascadeOnDelete(false);

            /*FarmOwner_Farm FK Configurations*/
            modelBuilder.Entity<Farm>()
                .HasRequired(f => f.FarmOwner)
                .WithMany(fo => fo.Farms)
                .HasForeignKey(f => f.FarmOwnerId)
                .WillCascadeOnDelete();

            /*Farm_Geoposition FK Configurations*/
            modelBuilder.Entity<Geoposition>()
                .HasRequired(g => g.Farm)
                .WithMany(f => f.Geopositions)
                .HasForeignKey(f => f.FarmId)
                .WillCascadeOnDelete();

            /*Geoposition_SoilReading FK Configurations*/
            modelBuilder.Entity<SoilReading>()
                .HasRequired(s => s.Geoposition)
                .WithMany(g => g.SoilReadings)
                .HasForeignKey(s => s.GeopositionId)
                .WillCascadeOnDelete();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FarmOwner> FarmOwners { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Geoposition> Geopositions { get; set; }
        public DbSet<SoilReading> SoilReadings { get; set; }
        public DbSet<FarmPlant> FarmPlants { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Contagion> Contagions { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Pest> Pests { get; set; }
        public DbSet<Broadcast> Broadcasts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}