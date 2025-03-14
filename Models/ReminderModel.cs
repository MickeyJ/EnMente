using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMente.Models
{
    [SQLite.Table("reminder")]
    public class ReminderModel
    {
        [PrimaryKey, AutoIncrement, SQLite.Column("id")]
        public int Id { get; set; }

        [MaxLength(100), SQLite.Column("title")]
        public string? Title { get; set; }

        [MaxLength(150), SQLite.Column("description")]
        public string? Description { get; set; }

        [SQLite.Column("date_time")]
        public DateTime DateTime { get; set; }

        
    }
}

