using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Runtime.InteropServices;
using System.IO;


namespace tema09
{
    internal class SlotsItem
    {
        public Vector3[] vertices = new Vector3[4];
        public TextureFromBMP Texture;
        bool Visible;

        int length = 25;

        public SlotsItem(TextureFromBMP tex, float scale, int moveX, int moveY, int moveZ)
        {
            Visible = true;
            Texture = tex;

            SetCoordonites(length, scale, moveX, moveY, moveZ);
        }

        public void SetCoordonites(int length, float scale, int moveX, int moveY, int moveZ)
        {
            vertices[0] = new Vector3(moveX, moveY, moveZ);
            vertices[1] = new Vector3(moveX + (int)(length * scale), moveY, moveZ);
            vertices[2] = new Vector3(moveX + (int)(length * scale), moveY + (int)(length * scale), moveZ);
            vertices[3] = new Vector3(moveX, moveY + (int)(length * scale), moveZ);

        }

        public void move(float moveX, float moveY, float moveZ)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].X += moveX;
                vertices[i].Y += moveY;
                vertices[i].Z += moveZ;
            }
        }

        public void Draw()
        {
            if (Visible)
            {
                GL.BindTexture(TextureTarget.Texture2D, this.Texture.id);

                GL.Color3(OpenTK.Color.White);

                GL.Begin(PrimitiveType.Quads);
                GL.TexCoord2(0, 1);
                GL.Vertex3(this.vertices[0]);
                GL.TexCoord2(1, 1);
                GL.Vertex3(this.vertices[1]);
                GL.TexCoord2(1, 0);
                GL.Vertex3(this.vertices[2]);
                GL.TexCoord2(0, 0);
                GL.Vertex3(this.vertices[3]);
                GL.End();
            }
        }

        public int getTexId()
        {
            return this.Texture.id;
        }
    }
}
