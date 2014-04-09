using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLModule.Tcp;

namespace GLauncherForm
{
    public static class StaticInstances
    {
        public static ClientTCP ClientConn = new ClientTCP(true);
    }
}
