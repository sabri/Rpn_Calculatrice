using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpn_Calculatrice.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RpnApiController : ControllerBase
    {
  
        public const string SUCCESS_MSG = "success";

        public const string INVALID_OPERATOR_MSG = "invalid operator";

        public const string INVALID_EXPRESSION_MSG = "invalid expression";

        public const string DIVIDE_BY_ZERO_MSG = "divide by zero";

        public const string INCOMPLETE_EXPRESSION_MSG = "incomplete expression - more than one number remaining on stack";

        // GET api/rpneval/5/6/d
        [HttpGet("{*opRStr}")]
        [ProducesResponseType(200)]
        public ActionResult<RpnEvalResult> Get(string opRStr)
        {
            // since we're promising to return a 200, wrap everything
            // in a try/catch just in case something goes wrong
            try
            {
                if (string.IsNullOrWhiteSpace(opRStr))
                {
                    return new RpnEvalResult() { message = "Retry again with vaild url", answer = null };
                }
                // make every character 
                opRStr = Uri.UnescapeDataString(opRStr);
            
                char[] tokens = opRStr.ToCharArray();

                Stack<decimal> stack = new Stack<decimal>();

                decimal numberToken;

                foreach (char token in tokens)
                {
                    if (decimal.TryParse(token.ToString(), out numberToken)) // is it a number? if so push on stack
                    {
                        stack.Push(numberToken);
                    }
                    else
                    {
                        // if there are not two items on the stack, then expression is invalid
                        if (stack.Count < 2)
                        {
                            return new RpnEvalResult() { message = INVALID_EXPRESSION_MSG, answer = null };
                        }

                        decimal op2 = stack.Pop();
                        decimal op1 = stack.Pop();

                        switch (token)
                        {
                            case 'a':
                                stack.Push(op1 + op2);
                                break;

                            case 's':
                                stack.Push(op1 - op2);
                                break;

                            case 'm':
                                stack.Push(op1 * op2);
                                break;

                            case 'd':
                                if (op2 == decimal.Zero)
                                {
                                    return new RpnEvalResult() { message = DIVIDE_BY_ZERO_MSG, answer = null };
                                }
                                stack.Push(op1 / op2);
                                break;

                            default:
                                return new RpnEvalResult() { message = INVALID_OPERATOR_MSG, answer = null };
                        }
                    }
                }

                // more than a single result on the stack - treat as error
                if (stack.Count > 1)
                {
                    return new RpnEvalResult() { message = INCOMPLETE_EXPRESSION_MSG, answer = null };
                }

                return new RpnEvalResult() { message = SUCCESS_MSG, answer = stack.Pop().ToString() };
            }
            catch (Exception)
            {
                return new RpnEvalResult() { message = INVALID_EXPRESSION_MSG, answer = null };
            }
        }
    }

    public class RpnEvalResult
    {
        public string message { get; set; }

        public string answer { get; set; }
    }
}
