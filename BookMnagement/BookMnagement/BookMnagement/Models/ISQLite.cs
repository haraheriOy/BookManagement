using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BookMnagement.Models
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
