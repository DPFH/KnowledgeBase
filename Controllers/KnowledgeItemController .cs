using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<IEnumerable<KnowledgeItem>> GetAll()
        {
            string sql = "SELECT * FROM knowledgeitems;";
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
        public ActionResult<KnowledgeItem> Get(long id)
        {
            string sql = "SELECT * FROM knowledgeitems WHERE id = @searchId;";
            var parameters = new { searchId = id };
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<KnowledgeItem>(sql, parameters).FirstOrDefault();
                connection.Close();

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
        }

        // POST: ../KnowledgeItem
        [HttpPost()]
        public ActionResult<KnowledgeItemDTO> Insert([FromBody] KnowledgeItemDTO knowledgeItem)
        {
            string sql = @"INSERT INTO knowledgeitems (title, summary, createdDate, editedDate, createdBy, editedBy)
                         VALUES (@title, @summary, @createdDate, @editedDate, @createdBy, @editedBy)
                         RETURNING id";
            var parameters = new { 
                title = knowledgeItem.title, 
                summary = knowledgeItem.summary, 
                createdDate = knowledgeItem.createdDate, 
                editedDate = knowledgeItem.editedDate, 
                createdBy = knowledgeItem.createdBy, 
                editedBy = knowledgeItem.editedBy
            };

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<KnowledgeItem>(sql, parameters).FirstOrDefault();
                connection.Close();

                if (result == null)
                {
                    return BadRequest();
                }

                return Ok(result.id);
            }
        }
    }
}
