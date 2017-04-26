using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Maps {
    public interface IMapNpc {
        void Compute();
        void Move();
    }
}
