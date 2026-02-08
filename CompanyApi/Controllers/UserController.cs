using DockerExample.Data;
using DockerExample.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DockerExample.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class UserController : Controller
    {
        string[] FirstNames =
        [
            "John",
            "Jiri",
            "Carlos",
            "Hans",
            "Marco",
            "Pierre",
            "Piotr",
            "Ivan",
            "Georgios",
            "Hiroshi",
            "Min",
            "Wei",
            "Arjun",
            "Ahmed",
            "Joao",
            "Ngoc",
            "Lars",
            "Patrick",
            "Sipho",
            "Mateo"
        ];

        string[] LastNames =
        [
            "Smith",
            "Procházka",
            "García",
            "Müller",
            "Rossi",
            "Dubois",
            "Kowalski",
            "Ivanov",
            "Papadopoulos",
            "Nakamura",
            "Kim",
            "Wang",
            "Singh",
            "Hassan",
            "Silva",
            "Nguyen",
            "Andersson",
            "O'Connor",
            "Dlamini",
            "Fernández"
        ];

        private readonly IMongoCollection<UserModel> users;

        public UserController(MongoDbService mongoDbService)
        {
            if (mongoDbService?.Database == null)
            {
                throw new Exception("Database not inicialized.");
            }
            users = mongoDbService.Database.GetCollection<UserModel>("Users");
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> Get()
        {
            return await users.Find(FilterDefinition<UserModel>.Empty).ToListAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetRandom()
        {
            return new List<UserModel>
            {
                new UserModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = FirstNames[new Random().Next(0, 19)],
                    LastName = LastNames[new Random().Next(0, 19)],
                    Age = new Random().Next(16, 62)
                },
                new UserModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = FirstNames[new Random().Next(0, 19)],
                    LastName = LastNames[new Random().Next(0, 19)],
                    Age = new Random().Next(16, 62)
                }
            };
        }

        [HttpGet]
        public async Task<ActionResult<UserModel?>> GetById(string id)
        {
            var filter = Builders<UserModel>.Filter.Eq(u => u.Id, id);
            var user = await users.Find(filter).FirstOrDefaultAsync();
            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserModel newUser)
        {
            await users.InsertOneAsync(newUser);
            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRandom()
        {

            var newUser = new UserModel()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = FirstNames[new Random().Next(0, 19)],
                LastName = LastNames[new Random().Next(0, 19)],
                Age = new Random().Next(16, 62)
            };
            await users.InsertOneAsync(newUser);
            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, [FromBody] UserModel updatedUser)
        {
            var filter = Builders<UserModel>.Filter.Eq(u => u.Id, id);
            var result = await users.ReplaceOneAsync(filter, updatedUser);
            if (result.MatchedCount == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var filter = Builders<UserModel>.Filter.Eq(u => u.Id, id);
            var result = await users.DeleteOneAsync(filter);
            if (result.DeletedCount == 0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
