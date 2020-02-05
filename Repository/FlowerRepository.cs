using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using flowery.Models;

namespace flowery.Repositories
{
    public class FlowerRepository
    {
        private readonly IDbConnection _db;
        public FlowerRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Flower> Get()
        {
            string sql = "SELECT * FROM flowers";
            return _db.Query<Flower>(sql);
        }

        internal Flower GetById(int Id)
        {
            string sql = "SELECT * FROM flowers WHERE id = @Id";
            return _db.QueryFirstOrDefault<Flower>(sql, new { Id });
        }

        internal Flower Create(Flower newData)
        {
            string sql = @"
            INSERT INTO flowers
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newData);
            newData.Id = id;
            return newData;
        }

        internal void Edit(Flower update)
        {
            string sql = @"
            UPDATE flowers
            SECTION name = @Name,
            WHERE id = @Id;
            ";
            _db.Execute(sql, update);
        }

        internal void Delete(int Id)
        {
            string sql = "DELETE FROM students WHERE id = @Id";
            _db.Execute(sql, new { Id });
        }
    }
}