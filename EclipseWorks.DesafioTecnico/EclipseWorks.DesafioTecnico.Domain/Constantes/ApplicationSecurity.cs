using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Domain.Constantes
{
    public class SigningCredentialsConfiguration
    {
        public SigningCredentials SigningCredentials { get; }
        public SymmetricSecurityKey Key { get; private set; }

        public SigningCredentialsConfiguration(string secretKey)
        {
            Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        }
    }
}
