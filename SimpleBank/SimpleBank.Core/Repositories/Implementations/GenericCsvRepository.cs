using SimpleBank.Core.Models.Abstractions;
using SimpleBank.Core.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBank.Core.Repositories.Implementations
{
    public abstract class GenericCsvRepository<TObject, TId> : IRepository<TObject, TId> where TObject : IDataObject<TId>
    {
        private readonly IDataReader<string> _dataReader;
        private readonly IDataWriter<string> _dataWriter;
        private readonly Dictionary<TId, TObject> _dataStore;

        protected GenericCsvRepository(IDataReader<string> dataReader, IDataWriter<string> dataWriter)
        {
            _dataReader = dataReader;
            _dataWriter = dataWriter;
            _dataStore = ReadData();
        }

        #region Public

        public TObject GetById(TId id)
        {
            _dataStore.TryGetValue(id, out var entity);
            return entity;
        }

        public TId Add(TObject entity)
        {
            var newId = GenerateNextId(_dataStore.Keys.Max());
            _dataStore[newId] = entity;

            SaveChanges();
            return newId;
        }

        public bool Update(TObject entity)
        {
            var id = entity.Id;
            if (!_dataStore.TryGetValue(id, out _))
                return false;

            _dataStore[id] = entity;

            SaveChanges();
            return true;
        }

        public bool Delete(TId id)
        {
            if (!_dataStore.Remove(id))
                return false;

            SaveChanges();
            return true;
        }

        public IEnumerable<TObject> Query(Func<TObject, bool> condition) =>
            _dataStore.Values.Where(condition);

        #endregion Public

        #region Protected

        protected abstract TObject ToObject(string s);

        protected abstract string ToCsv(TObject obj);

        protected abstract TId GenerateNextId(TId lastId);

        #endregion Protected

        #region Private

        private Dictionary<TId, TObject> ReadData() =>
           _dataReader
               .Read()
               .Skip(1)
               .Select(ToObject)
               .ToDictionary(a => a.Id);

        private void SaveChanges()
        {
            var objectStrings = _dataStore.Select(pair => $"{pair.Key},{ToCsv(pair.Value)}");
            _dataWriter.Write(objectStrings);
        }

        #endregion Private
    }
}