using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Item {
    public interface IInventory {
        bool IsExpired();
    }
}
