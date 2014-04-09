using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace GLModule.Constants
{
    public static class UpdateConstants
    {
        /// <summary>
        /// Informa o tipo da hash para verificar os arquivos para o UPDATE
        /// Recomandado = SHA1
        /// Para evitar colisão
        /// http://msdn.microsoft.com/pt-br/library/wet69s13%28v=vs.100%29.aspx
        /// </summary>
        public static readonly HashAlgorithm TypeHash = HashAlgorithm.Create("SHA1");
    }
}
