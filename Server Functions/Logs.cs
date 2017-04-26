using System;
using System.IO;
using System.Drawing;

namespace Elysium {
    public static class Logs {
        /// <summary>
        /// Quando chamado o write, exporta o texto e a cor.
        /// </summary>
        public static EventHandler<LogsEventArgs> LogsEvent;

        /// <summary>
        /// Ativa ou desativa os logs.
        /// </summary>
        public static bool Enabled { get; set; }

        static string file = $"{DateTime.Today.Year} - {DateTime.Today.Month} - {DateTime.Today.Day}.txt";
        static FileStream stream;
        static StreamWriter writer;

        /// <summary>
        /// Abre o arquivo no modo de escrita.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool OpenFile(out string msg) {
            try {
                stream = new FileStream($"./Log/{file}", FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(stream);
            }
            catch (Exception ex) {
                msg = ex.Message;
                return false;
            }

            msg = string.Empty;
            return true;
        }

        /// <summary>
        /// Fecha o arquivo e libera os recursos.
        /// </summary>
        public static void CloseFile() {
            if (stream == null) { return; }
            writer.Close();
            stream.Close();

            writer.Dispose();
            stream.Dispose();
        }

        /// <summary>
        /// Escreve no arquivo de logs.
        /// </summary>
        /// <param name="text"></param>
        private static void Write(string text) {
            if (!Enabled) return;

            writer.WriteLine($"{DateTime.Now}: {text}");
            writer.Flush();
        }

        /// <summary>
        /// Escreve a mensagem na tela e no arquivo.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void Write(string text, Color color) {
            LogsEvent?.Invoke(null, new LogsEventArgs(text, color));
            Write(text);
        }
    }
}
