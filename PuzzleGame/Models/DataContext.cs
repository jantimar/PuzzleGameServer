using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PuzzleGame.Models
{
    public class DataContext : DbContext
    {
        public DbSet<TabelScore> Score { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Vytvorenie databazy ak neexistuje
            Database.SetInitializer<DataContext>(new CreateDatabaseIfNotExists<DataContext>());
        }
    }

    [Table("Scores")]
    public class TabelScore
    {
        [Key]
        public int Score_id { get; set; }
        [Column("Player"), StringLength(50)]
        public String Name { get; set; }
        [Column ("Score")]
        public int Score { get; set; }
    }

}