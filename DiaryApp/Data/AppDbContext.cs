using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace DiaryApp.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<DiaryEntry> DiaryEntries { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<DiaryEntry>().HasData(
				new DiaryEntry
				{
					Id = 1,
					Title = "went shoping",
					Content = "went shoping with Joe!",
					Created = DateTime.Now
				},
				new DiaryEntry
				{
					Id = 2,
					Title = "went eatting",
					Content = "went eatting with Joe!",
					Created = DateTime.Now
				},
				new DiaryEntry
				{
					Id = 3,
					Title = "went hiking",
					Content = "went hiking with Joe!",
					Created = DateTime.Now
				}
			);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
		}
	}
}