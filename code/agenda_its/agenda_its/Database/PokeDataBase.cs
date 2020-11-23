using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agenda_its.Models;
using SQLite;

namespace agenda_its.Database
{
    /// DB-STEP 2 - Lazy initialization.
    public class PokeDataBase
    {
        private static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        private static SQLiteAsyncConnection Database => lazyInitializer.Value;
        private static bool initialized = false;

        public PokeDataBase()
        {
            InitializeAsync().ConfigureAwait(false);
        }

        private async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Pokemon).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Pokemon)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        #region DB-STEP 3 - Data Manipulation
        public Task<List<Pokemon>> GetItemsAsync()
        {
            return Database.Table<Pokemon>().ToListAsync();
        }

        public Task<Pokemon> GetItemAsync(int id)
        {
            return Database.Table<Pokemon>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Pokemon item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Pokemon item)
        {
            return Database.DeleteAsync(item);
        }
        #endregion
    }
}
