using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginServer.Common {
    public static class Constant {
        /// <summary>
        /// Quantidade máxima de tentativas de login.
        /// </summary>
        public const int MAX_ATTEMPT = 3;

        /// <summary>
        /// Limite de servidores.
        /// </summary>
        public const int MAX_SERVER = 5;
    }
}
