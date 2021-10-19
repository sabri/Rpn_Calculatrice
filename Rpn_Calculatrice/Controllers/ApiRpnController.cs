using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpn_Calculatrice.Controllers
{
    [Route("api/rpn/[controller]")]
    [ApiController]
    public class ApiRpnController : ControllerBase
    {

        Stack<decimal> stack = new Stack<decimal>();
         

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<Stack<decimal>> GetFromstack()
        {
       
            if (stack.Count == 0)
            {
                return NotFound("stack is empty");
            } else
            {
                return Ok(stack.Peek());
            }  
        }
        [HttpGet("getAllstack")]
        [ProducesResponseType(200)]
        public ActionResult<decimal> GetFromTopstack()
        {
            if (stack.Count == 0)
            {
                return NotFound("stack is empty");
            }
            else
            {
                return Ok(stack);
            }
        }
        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult<Stack<decimal>> save(decimal x)
        {
            stack.Push(x);
            return Ok(stack);

        }
        [HttpDelete]
        [ProducesResponseType(200)]
        public ActionResult<Stack<decimal>> delete()
        {
            if (stack.Count == 0)
            {
                return NotFound("is empty");
            } else
            {
                stack.Pop();
                return Ok(stack);
            }
          

        }
        [HttpDelete("deleteAll")]
        [ProducesResponseType(200)]
        public ActionResult<Stack<decimal>> deleteall()
        {
            stack.Clear();
            return Ok(stack);

        }
    }
}
