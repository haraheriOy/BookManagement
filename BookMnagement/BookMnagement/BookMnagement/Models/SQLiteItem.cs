using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BookMnagement.Models
{
    public class SQLiteItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Delete { get; set; }
    }
}
