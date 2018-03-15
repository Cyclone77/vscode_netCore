using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("/values/{name}")]//name参数注入
        public string index(string name) 
        {
            return "Hello World:" + name;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                SqlConnection sqlConnection =
                    new SqlConnection(
                        "Data Source=127.0.0.1;Initial Catalog=GSHRDBII_341_XNMHGLJ_V2;Integrated Security=True;User Id=sa;Password=123");
                sqlConnection.Open();
                string sql = "Select * from SM_Users";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet);
                return JsonConvert.SerializeObject(dataSet);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
