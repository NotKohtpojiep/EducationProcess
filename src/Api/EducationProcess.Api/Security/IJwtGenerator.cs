using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationProcess.Api.Security
{
    public interface IJwtGenerator
    {
        string CreateToken(string userName);
    }
}
