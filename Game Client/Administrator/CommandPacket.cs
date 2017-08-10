using Elysium_Diamond.Network;

namespace Elysium_Diamond.Administrator {
    public static class CommandPacket {
        public static void SendCommand(CommandType command, string target, string[] values) {
            var lenght = values.Length;
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((short)PacketList.CL_GS_AdminTool);
            buffer.Write((short)command);
            buffer.Write(target);
            buffer.Write(lenght);

            for(var n = 0; n < lenght; n++) buffer.Write(values[n]);

            NetworkSocket.SendData(SocketEnum.GameServer, buffer);
        }
    }
}