using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tema09
{
    public partial class Form1 : Form
    {
        float camDepth;

        int eyePosX, eyePosY, eyePosZ;

        const int nrItems = 5;
        const int nrSlots = 3;

        int cyclesRemaining = 0;

        private SlotsItem[] slotsItems = new SlotsItem[3];
        private SlotsItem[] slotsItemsTop = new SlotsItem[3];
        private SlotsItem[] slotsItemsBot = new SlotsItem[3];

        private TextureFromBMP[] slotsTextures = new TextureFromBMP[5];

        Random randomizer = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupDefaultValues();
            SetupSceneObjects();

            labelYouWin.Visible = false;
            labelYouLose.Visible = false;

            MainTimer.Start();
        }

        private void MainViewport_Load(object sender, EventArgs e)
        {
          
        }

        private void MainViewport_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(OpenTK.Color.DarkSlateGray);

            SetView();

            for (int i = 0; i < nrSlots; i++)
            {
                slotsItemsTop[i].Draw();
                slotsItems[i].Draw();
                slotsItemsBot[i].Draw();
            }

            MainViewport.SwapBuffers();
        }

        public void SetupDefaultValues()
        {
            camDepth = 1.4f;
            eyePosX = 0;
            eyePosY = 0;
            eyePosZ = 35;
        }

        private void timer1_Tick(object sender, EventArgs e) /// TIMER DE LA INCEPUTUL APLICATIEI
        {
            MainViewport.Invalidate();
            MainTimer.Stop();
        }

        private void SpinButton_Click(object sender, EventArgs e)
        {
            if (cyclesRemaining <= 0)
            {
                labelYouWin.Visible = false;
                labelYouLose.Visible = false;

                AnimationTimer.Start();
                FrameTimer.Start();

                cyclesRemaining = ((int)cyclesInput.Value) - 1;
            }        
        }

        public void SetView()
        {
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(camDepth, MainViewport.Width / MainViewport.Height, 1, 256);
            Matrix4 lookat = Matrix4.LookAt(eyePosX, eyePosY, eyePosZ, 0, 0, 0, 0, 1, 0);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspectiva);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(ref lookat);

            GL.Viewport(0, 0, MainViewport.Width, MainViewport.Height);
        }

        private void AnimationTimer_Tick(object sender, EventArgs e) /// TIMER PENTRU A PORNI ANIMATIA 
        {  
            SwitchElements();
            MainViewport.Invalidate();

            if (cyclesRemaining <= 0)
            {
                AnimationTimer.Stop();
                FrameTimer.Stop();

                if (checkWinCondition())
                {
                    labelYouWin.Visible = true;
                }
                else
                {
                    labelYouLose.Visible = true;
                }
            }
            else
            {
                cyclesRemaining--;
            }
        }

        private void FrameTimer_Tick(object sender, EventArgs e)  /// TIMER PENTRU FRAME URI INDIVIDUALE CAND ANIMATIA E ACTIVA
        {
            for (int i = 0; i < nrSlots; i++)
            {
                slotsItems[i].move(0f, -0.8f, -0.8f);
                slotsItemsTop[i].move(0f, -0.8f, -0.8f);
                slotsItemsBot[i].move(0f, -0.8f, -0.8f);
                MainViewport.Invalidate();
            }
        }

        public void SetupSceneObjects()
        {
            GL.Enable(EnableCap.DepthTest);
            
            GL.Enable(EnableCap.Blend);

            GL.DepthFunc(DepthFunction.Less);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.Enable(EnableCap.Texture2D);

            slotsTextures[0] = new TextureFromBMP("Imagini/banana.png");
            slotsTextures[1] = new TextureFromBMP("Imagini/7.png");
            slotsTextures[2] = new TextureFromBMP("Imagini/cirese.jpeg");
            slotsTextures[3] = new TextureFromBMP("Imagini/clopot.jpeg");
            slotsTextures[4] = new TextureFromBMP("Imagini/lamaie.jpg");

            InitElements();
        }

        public void SwitchElements()
        {
            for (int i = 0; i < nrSlots; i++)
            {
                int nr = randomizer.Next(0, nrItems);
                //MessageBox.Show(nr.ToString());
                int xCoord = -60 + 50*i;

                slotsItemsBot[i] = new SlotsItem(slotsItems[i].Texture, 1f, xCoord, -35, -25);
                slotsItems[i] = new SlotsItem(slotsItemsTop[i].Texture, 1f, xCoord, -10, 0);
                slotsItemsTop[i] = new SlotsItem(slotsTextures[nr], 1f, xCoord, 15, 25);

                // -10 0 25x 25y
            }
        }

        public void InitElements()
        {
            for (int i = 0; i < nrSlots; i++)
            {
                int nr = randomizer.Next(0, nrItems);
                int nrT = randomizer.Next(0, nrItems);
                int nrB = randomizer.Next(0, nrItems);
                //MessageBox.Show(nr.ToString());
                int xCoord = -60 + 50*i;

                slotsItemsBot[i] = new SlotsItem(slotsTextures[nrB], 1f, xCoord, -35, -25);
                slotsItems[i] = new SlotsItem(slotsTextures[nr], 1f, xCoord, -10, 0);
                slotsItemsTop[i] = new SlotsItem(slotsTextures[nrT], 1f, xCoord, 15, 25);

                // -10 0 25x 25y
            }
        }

        public bool checkWinCondition()
        {
            for(int i = 1; i < nrSlots; i++)
            {
                if (slotsItems[i].getTexId() != slotsItems[0].getTexId())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
