using MongoDB.Bson;
using MongoDB.Driver;
using Solution.CrossCutting.Mapping;
using Solution.CrossCutting.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Solution.CrossCutting.MongoDB
{
    public abstract class MongoRepository<T> : IRepository<T> where T : class
    {
        protected MongoRepository(IMongoContext context)
        {
            Database = context.Database;
            Collection = Database.GetCollection<T>(typeof(T).Name);
        }

        private IMongoCollection<T> Collection { get; }

        private IMongoDatabase Database { get; }

        public void Add(T item)
        {
            Collection.InsertOne(item);
        }

        public Task AddAsync(T item)
        {
            return Collection.InsertOneAsync(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            Collection.InsertMany(items);
        }

        public Task AddRangeAsync(IEnumerable<T> items)
        {
            return Collection.InsertManyAsync(items);
        }

        public bool Any()
        {
            return Collection.Find(new BsonDocument()).Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).Any();
        }

        public Task<bool> AnyAsync()
        {
            return Collection.Find(new BsonDocument()).AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).AnyAsync();
        }

        public long Count()
        {
            return Collection.CountDocuments(new BsonDocument());
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return Collection.CountDocuments(where);
        }

        public Task<long> CountAsync()
        {
            return Collection.CountDocumentsAsync(new BsonDocument());
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return Collection.CountDocumentsAsync(where);
        }

        public void Delete(object key)
        {
            Collection.DeleteOne(FilterId(key));
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            Collection.DeleteMany(where);
        }

        public Task DeleteAsync(object key)
        {
            return Collection.DeleteOneAsync(FilterId(key));
        }

        public Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            return Collection.DeleteManyAsync(where);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).FirstOrDefault();
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return FirstOrDefault(where).Map<TResult>();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).FirstOrDefaultAsync();
        }

        public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return Task.FromResult(FirstOrDefaultAsync(where).Map<TResult>());
        }

        public IEnumerable<T> List()
        {
            return Collection.Find(new BsonDocument()).ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).ToList();
        }

        public IEnumerable<TResult> List<TResult>()
        {
            return List().Map<IEnumerable<TResult>>();
        }

        public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where)
        {
            return List(where).Map<IEnumerable<TResult>>();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return await Collection.Find(where).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await Collection.Find(new BsonDocument()).ToListAsync().ConfigureAwait(false);
        }

        public Task<IEnumerable<TResult>> ListAsync<TResult>()
        {
            return Task.FromResult(ListAsync().Map<IEnumerable<TResult>>());
        }

        public Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return Task.FromResult(ListAsync(where).Map<IEnumerable<TResult>>());
        }

        public T Select(object key)
        {
            return Collection.Find(FilterId(key)).SingleOrDefault();
        }

        public TResult Select<TResult>(object key)
        {
            return Select(key).Map<TResult>();
        }

        public Task<T> SelectAsync(object key)
        {
            return Collection.Find(FilterId(key)).SingleOrDefaultAsync();
        }

        public Task<TResult> SelectAsync<TResult>(object key)
        {
            return Task.FromResult(SelectAsync(key).Map<TResult>());
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).SingleOrDefault();
        }

        public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return SingleOrDefault(where).Map<TResult>();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return Collection.Find(where).SingleOrDefaultAsync();
        }

        public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return Task.FromResult(SingleOrDefaultAsync(where).Map<TResult>());
        }

        public void Update(T item, object key)
        {
            Collection.ReplaceOne(FilterId(key), item);
        }

        public Task UpdateAsync(T item, object key)
        {
            return Collection.ReplaceOneAsync(FilterId(key), item);
        }

        private static FilterDefinition<T> FilterId(object key)
        {
            return Builders<T>.Filter.Eq("Id", key);
        }
    }
}
