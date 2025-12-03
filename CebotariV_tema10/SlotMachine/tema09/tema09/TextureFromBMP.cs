using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Bitmap = System.Drawing.Bitmap;

namespace tema09
{
    internal class TextureFromBMP
    {
        public int id;
        public int texWidth;
        public int texHeight;

        public TextureFromBMP(int _id, int _texWidth, int _texHeight)
        {
            id = _id;
            texWidth = _texWidth;
            texHeight = _texHeight;
        }

        public TextureFromBMP(string filename)
        {
            try
            {
                id = GL.GenTexture();

                Bitmap bmp = new Bitmap(filename);

                BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.BindTexture(TextureTarget.Texture2D, id);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                    bmp.Width, bmp.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                    PixelType.UnsignedByte, data.Scan0);


                bmp.UnlockBits(data);

                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);

                texWidth = bmp.Width;
                texHeight = bmp.Height;
            }
            catch {
                MessageBox.Show("Eroare la textura" + filename);
            }

        }
    }
}
