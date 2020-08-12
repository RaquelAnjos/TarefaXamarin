using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Controle.Modelos;

namespace Controle.Dados
{
     public class ElementosDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ElementosDatabase(String dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Elementos>().Wait();
        }

        public Task<int> SalvarPetAsync (Elementos elementos)
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

        public Task<List<Elementos>> ConsultarTodosAsync()
        {
            return database.Table<Elementos>().ToListAsync();
        }
    }
}
