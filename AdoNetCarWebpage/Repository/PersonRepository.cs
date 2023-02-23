using AdoNetCarWebpage.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdoNetCarWebpage.Repository
{
    public class PersonRepository : IPersonRepository
    {
        string connectionString = @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=GarageDB;Integrated Security=True";
        public async Task<int> Create(Person person)
        {

            var sql = $"INSERT INTO Person (FullName,Pasport, PhoneNumber,CarId) values ('{person.FullName}','{person.Pasport}','{person.Pasport}',{person.CarId})";
            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(sql);

                return affectedRows;
            }
        }

        public async Task<int> Delete(int PersonId)
        {
            var sql = $"DELETE FROM Person WHERE (Id={PersonId})";
            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(sql);
                return affectedRows;
            }
        }
        public async Task<List<Person>> GetPerson()
        {
            List<Person> persons;
            using (var connection = new SqlConnection(connectionString))

            {

                // Create a query that retrieves all books with an author name of "John Smith"    
                var sql = "SELECT * FROM Person";

                // Use the Query method to execute the query and return a list of objects    
                persons = (await connection.QueryAsync<Person>(sql)).ToList();
            }
           return persons;
        }

        public async Task<Person> GetPersonById(int PersonId)
        {
            Person persons = new Person();
            using (var connection = new SqlConnection(connectionString))

            {

                // Create a query that retrieves all books with an author name of "John Smith"    
                var sql = $"SELECT * FROM Person WHERE Id={PersonId}";

                // Use the Query method to execute the query and return a list of objects    
                persons = await connection.QuerySingleAsync<Person>(sql);
            }
            return persons;
        }

        public async Task<int> Update(Person person)
        {
            var sql = $"UPDATE Person SET FullName='{person.FullName}',Pasport='{person.Pasport}',PhoneNumber='{person.PhoneNumber}',CarId={person.CarId} WHERE Id={person.Id}";
           
            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(sql);
                return affectedRows;
            }
        }
    }
}