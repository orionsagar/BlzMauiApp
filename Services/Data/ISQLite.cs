using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlzMauiApp.Services.Data
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
