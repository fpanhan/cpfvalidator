﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static cpfvalidator.BO.Validators;

namespace cpfvalidator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{cpf}")]
        public ActionResult<string> Get(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                throw new System.ArgumentException("Preencha o CPF!", nameof(cpf));
            }

            var validador = ValidaCpf.IsCpf(cpf);
            if (validador)
            {
                return "válido";
            }
            return "inválido";
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
