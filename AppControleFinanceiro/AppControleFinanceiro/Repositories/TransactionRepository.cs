using AppControleFinanceiro.Models;
using LiteDB;

namespace AppControleFinanceiro.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly LiteDatabase _database;
    private readonly string _collectionName = "transactions";
    
    public TransactionRepository(LiteDatabase database)
    {
        _database = database;
    }

    public List<Transaction> GetAll()
    {
        return _database
            .GetCollection<Transaction>(_collectionName)
            .Query()
            .OrderByDescending(a => a.Date)
            .ToList();
    }

    public void Add(Transaction transaction)
    {
        var col =_database.GetCollection<Transaction>(_collectionName);
        col.Insert(transaction);
        col.EnsureIndex(a => a.Date);
    }

    public void Update(Transaction transaction)
    {
        var col =_database.GetCollection<Transaction>(_collectionName);
        col.Update(transaction);
    }

    public void Delete(Transaction transaction)
    {
        var col =_database.GetCollection<Transaction>(_collectionName);
        col.Delete(transaction.Id);
    }
}