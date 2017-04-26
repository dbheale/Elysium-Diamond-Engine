﻿using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Linq;

// @author Paulo Soreto
// @date    03/01/2015
// @contact psoreto@gmail.com

namespace Classe_Editor {
    public static class Configuration {
        private static Hashtable cache = new Hashtable();

        /// <summary>
        /// Lê o arquivo de configuração e armazena as informações.
        /// </summary>
        /// <param name="fileName"></param>
        public static void ParseConfigFile(string fileName) {
            if (!File.Exists(fileName))
                throw new Exception("cannot find server configuration file");

            cache.Clear();

            using (StreamReader reader = new StreamReader(fileName, Encoding.Unicode)) {
                string[] validLines = reader.ReadToEnd().Split('\n').Where(l => !l.StartsWith("//")).ToArray();
                foreach (string line in validLines) {
                    if (line == "\r")
                        continue;

                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parameters = line.Split('=');
                    cache.Add(parameters[0].Trim(), parameters[1].Trim());
                }
            }
        }

        public static bool GetBoolean(string key) {
            return Convert.ToBoolean(Convert.ToInt32(cache[key]));
        }

        public static byte GetByte(string key) {
            return Convert.ToByte(cache[key]);
        }

        public static int GetInt32(string key) {
            return Convert.ToInt32(cache[key]);
        }

        public static long GetInt64(string key) {
            return Convert.ToInt64(cache[key]);
        }

        public static string GetString(string key) {
            if (cache[key] == null) return "command not found";

            return cache[key].ToString();
        }

        public static void Clear() {
            cache.Clear();
        }
    }
}


