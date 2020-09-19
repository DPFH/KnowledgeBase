using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dapper;
using Npgsql;
using System.Diagnostics;

namespace KnowledgeBaseDPFH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KnowledgeItemController : ControllerBase
    {
        private static readonly string connectionString = "Host=database-1.cx7ddt0hgocb.us-east-2.rds.amazonaws.com;Port=5432;Username=postgres;Password=password;Database=myDatabase";

        private readonly ILogger<KnowledgeItemController> _logger;

        public KnowledgeItemController(ILogger<KnowledgeItemController> logger)
        {
            _logger = logger;
        }

        // GET: ../KnowledgeItem
        [HttpGet()]
        public ActionResult<IEnumerable<KnowledgeItem>> Get()
        {
            string sql = "Select * from knowledgeitems;";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var results = connection.Query<KnowledgeItem>(sql).ToList();
                connection.Close();

                return results;
            }
        }

        // GET: ../KnowledgeItem/{id}
        [HttpGet("{id}")]
        public ActionResult<KnowledgeItem> GetKnowledgeItem(long id)
        {
            //Debug.Print("ID is " + id);
            string sql = "SELECT * FROM knowledgeitems WHERE id = @searchId;";
            var parameters = new { searchId = id };
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var results = connection.Query<KnowledgeItem>(sql, parameters).FirstOrDefault();
                connection.Close();

                if (results == null)
                {
                    return NotFound();
                }

                return results;
            }
        }
    }
}
