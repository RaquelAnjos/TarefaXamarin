using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Controle.Modelos;
using System.Threading.Tasks;


namespace Controle.Dados
{
    class ElementoDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ElementoDatabase(String dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Elemento>().Wait();
        }

        public Task<int> SalvarElementosAsync(Elemento elementos)
        {
            if (elementos.Id == 0)
            {
                return database.InsertAsync(elementos);
            }
            else
            {
                return database.UpdateAsync(elementos);
            }
        }

        public Task<List<Elemento>> ConsultarTodosAsync()
        {
            return database.Table<Elemento>().ToListAsync();
        }

        public Task<int> DeleteElementosAsync(Elemento elementos)
        {
            return database.DeleteAsync(elementos);
        }

    }
}
