using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_AI_Experiments
{
    public class Examples
    {
        protected string ApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")??string.Empty;  

        protected string Model = "gpt-4.1";
    }
}
