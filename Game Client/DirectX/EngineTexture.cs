using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using SharpDX;
using SharpDX.Direct3D9;

namespace Elysium_Diamond.DirectX {
    public class EngineTexture {
        /// <summary>
        /// Número de Identificação
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Textura
        /// </summary>
        public Texture Texture { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="texture"></param>
        public EngineTexture(int id, Texture texture) {
            ID = id;
            Texture = texture;
        }

        private static HashSet<EngineTexture> userinterfaces { get; set; } = new HashSet<EngineTexture>();
        private static HashSet<EngineTexture> sprites { get; set; } = new HashSet<EngineTexture>();
        private static HashSet<EngineTexture> icons { get; set; } = new HashSet<EngineTexture>();

        /// <summary>
        /// Campo de referência.
        /// </summary>
        private static HashSet<EngineTexture> reference;

        /// <summary>
        /// Adiciona uma nova textura ao hashset.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="texture"></param>
        /// <param name="type"></param>
        public static void AddTexture(int id, Texture texture, EngineTextureType type) {
            if (type == EngineTextureType.GraphicUserInterface) reference = userinterfaces;
            if (type == EngineTextureType.Sprites) reference = sprites;
            if (type == EngineTextureType.Icons) reference = icons;

            reference.Add(new EngineTexture(id, texture));
        }

        /// <summary>
        /// Realiza a busca pelo número da textura.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Texture FindTextureByID(int id, EngineTextureType type) {
            if (type == EngineTextureType.GraphicUserInterface) reference = userinterfaces;
            if (type == EngineTextureType.Sprites) reference = sprites;
            if (type == EngineTextureType.Icons) reference = icons;

            var find_texture = from sData in reference
                               where sData.ID.Equals(id)
                               select sData;

            return find_texture.FirstOrDefault().Texture;
        }

        /// <summary>
        /// Carrega a textura a partir de um arquivo.
        /// </summary>
        /// <param name="file">Nome do arquivo</param>
        /// <returns></returns>
        public static Texture TextureFromFile(string file) {
            var img = Image.FromFile(file);

            var width = img.Width;
            var height = img.Height;

            byte[] buffer;
            using (var ms = new MemoryStream()) {
                img.Save(ms, ImageFormat.Png);
                buffer = ms.ToArray();
            }

            return Texture.FromFile(EngineCore.Device, file, width, height, 0, Usage.None, Format.Unknown, Pool.Managed, Filter.None, Filter.None, 0);
        }

        /// <summary>
        /// Carrega a textura a partir de um arquivo e passa sua resolução.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Texture TextureFromFile(string file, out Size2 size) {
            var img = Image.FromFile(file);

            var width = img.Width;
            var height = img.Height;

            size.Width = width;
            size.Height = height;

            byte[] buffer;
            using (var ms = new MemoryStream()) {
                img.Save(ms, ImageFormat.Png);
                buffer = ms.ToArray();
            }

            return Texture.FromFile(EngineCore.Device, file, width, height, 0, Usage.None, Format.A16B16G16R16, Pool.Managed, Filter.None, Filter.None, 0);
        }

        /// <summary>
        /// Carrega a textura a partir de um arquivo com o tamanho definido.
        /// </summary>
        /// <param name="file">Nome do arquivo</param>
        /// <param name="width">Comprimento</param>
        /// <param name="height">Altura</param>
        /// <returns></returns>
        public static Texture TextureFromFile(string file, int width, int height) {
            return Texture.FromFile(EngineCore.Device, file, width, height, 0, Usage.None, Format.A16B16G16R16, Pool.Managed, Filter.None, Filter.None, 0);
        }

        /// <summary>
        /// Carrega a textura a partir de um arquivo com o tamanho definido e cor de transparência.
        /// </summary>
        /// <param name="file">Nome do arquivo</param>
        /// <param name="width">Comprimento</param>
        /// <param name="height">Altura</param>
        /// <param name="color">Cor de transparência</param>
        /// <returns></returns>
        public static Texture TextureFromFile(string file, int width, int height, SharpDX.Color color) {
            return Texture.FromFile(EngineCore.Device, file, width, height, 0, Usage.None, Format.A16B16G16R16, Pool.Managed, Filter.None, Filter.None, color.ToAbgr());
        }

        /// <summary>
        /// Carrega a textura a partir de uma imagem.
        /// </summary>
        /// <param name="img">Imagem</param>
        /// <returns></returns>
        public static Texture TextureFromImage(Image img) {
            var width = img.Width;
            var height = img.Height;

            byte[] buffer;
            using (var ms = new MemoryStream()) {
                img.Save(ms, ImageFormat.Png);
                buffer = ms.ToArray();
            }

            return Texture.FromMemory(EngineCore.Device, buffer, width, height, 0, Usage.None, Format.A16B16G16R16, Pool.Managed, Filter.None, Filter.None, 0);
        }
    }
}