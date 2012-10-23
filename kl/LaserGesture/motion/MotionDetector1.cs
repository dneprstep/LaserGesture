
namespace motion
{
    using System;
    using System.Drawing;
    using AForge;
    using AForge.Imaging;
    using AForge.Imaging.Filters;
    using System.Collections;
    using System.Runtime.InteropServices;
    using System.Reflection;
    using Tiger.Video.VFW;
    using System.Windows.Forms;
    using System.Media;
    using AForge.Math;
    using System.Net;
    /// <summary>
    /// MotionDetector1
    /// </summary>
    public class MotionDetector1 : IMotionDetector
    {
      
        private MainForm _mForm;
        int index = 45;
     
        public MainForm mForm
        {
            get { return _mForm; }
            set { _mForm = value; }
        }

        // Get a handle to an application window.
        [DllImport("USER32.DLL")]
        private static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        // Reset detector to initial state
        public void Reset()
        {
          
        }

        // For making beeping sounds
        public class Beeper
        {
            [DllImport("Kernel32.dll")]
            public static extern bool Beep(UInt32 frequency, UInt32 duration);

            public static void RecognizedBeep()
            {
                SoundPlayer simpleSound = new SoundPlayer(@"1.wav");
                simpleSound.Play();
            }
        }

        // Process new frame
       
        public void ProcessFrame(ref Bitmap image)
        {
            if ((mForm.startStop)&&(index<0))
            {
               Control(image);
            }
            else
            {
                index--;
            }
        }

        private void Control(Bitmap image)
        {
            Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
            uBitmap.LockBitmap();

            Point pStart = new Point(-1, -1);
            Point pHEnd = new Point(-1, -1);
            Point pWEnd = new Point(-1, -1);
            byte r, g, b;
            for (int y = 0; y < uBitmap.Bitmap.Height; y+=2)
            {
                for (int x = 0; x < uBitmap.Bitmap.Width; x+=2)
                {
                    r = uBitmap.GetPixel(x, y).red;
                    b = uBitmap.GetPixel(x, y).blue;
                    g = uBitmap.GetPixel(x, y).green;

                    if ((r - 100 > g) && (r - 100 > b))
                    {
                        pStart = StartControl(x - 2, y - 2, image);
                        pWEnd = GorizontalControl(pStart, image);
                        pHEnd = VerticalControl(pStart, image);

                        if (pHEnd.X != -1)
                        {
                            if (Mathematic(pStart, pHEnd, pWEnd, uBitmap.Bitmap.Size.Width, uBitmap.Bitmap.Size.Height))
                            {
                                y = uBitmap.Bitmap.Height;
                                break;
                            }
                        }

                        
                    }
                }//for (int x = 0; x < uBitmap.Bitmap.Width; x++)
            }//for (int y = 0; y < uBitmap.Bitmap.Height; y+=5)

            uBitmap.UnlockBitmap();
            uBitmap.Dispose();
        }

        private Point StartControl(int x,int y, Bitmap image)
        {
            Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
            uBitmap.LockBitmap();

            Point pStart = new Point(-1,-1);
            byte r, g, b;
            for (int Y=y; Y < y+30; Y++)
            {
                for (int X=x; X < x+ 30; X++)
                {
                    r = uBitmap.GetPixel(X, Y).red;
                    b = uBitmap.GetPixel(X, Y).blue;
                    g = uBitmap.GetPixel(X, Y).green;
                    if ((r - 100 > g) && (r - 100 > b))
                    {
                        if (pStart.X == -1)     // save start point
                        {
                            pStart.X = X;
                            pStart.Y = Y;
                            break;
                        }
                    }//if ((r - 100 > g) && (r - 100 > b))
                }//for (int x = 0; x < uBitmap.Bitmap.Width; x++)
                if (pStart.X != -1)
                {
                    break; 
                }
            }//for (int y = 0; y < uBitmap.Bitmap.Height; y+=5)


            uBitmap.UnlockBitmap();
            uBitmap.Dispose();
            return pStart;
        }

        private Point GorizontalControl(Point pStart,Bitmap image)
        {
            Point pHEnd = new Point(-1, -1);
            Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
            uBitmap.LockBitmap();

            byte r, g, b;
                for (int x = pStart.X; x < 30+pStart.X; x++)
                {
                    r = uBitmap.GetPixel(x, pStart.Y).red;
                    b = uBitmap.GetPixel(x, pStart.Y).blue;
                    g = uBitmap.GetPixel(x, pStart.Y).green;
                    if (((r - 100 > b) && (r - 100 > g)) || ((r > 200) && (g > 120) && (b > 120)))
                    {
                    }
                    else
                    {
                            pHEnd.X = x;
                            pHEnd.Y = pStart.Y;
                            break;
                    }                       
                }//for (int x = 0; x < uBitmap.Bitmap.Width; x++)

            uBitmap.UnlockBitmap();
            uBitmap.Dispose();
            return pHEnd;        
        }

        private Point VerticalControl(Point pStart, Bitmap image)
        {
            Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
            uBitmap.LockBitmap();
            Point pEnd = new Point(-1, -1);

            byte r, g, b;
            for (int y = pStart.Y; y < 30+pStart.Y; y++)
            {
                r = uBitmap.GetPixel(pStart.X, y).red;
                b = uBitmap.GetPixel(pStart.X, y).blue;
                g = uBitmap.GetPixel(pStart.X, y).green;

                if (((r-100>b)&&(r-100>g))||((r>150)&&(g>120)&&(b>120)))
                {
                }
                else
                {
                    pEnd.X = pStart.X;
                    pEnd.Y = y;
                    break;
                }                       
            }

            uBitmap.UnlockBitmap();
            uBitmap.Dispose();
            return pEnd;
        }

        private bool Mathematic(Point pStart, Point pHEnd, Point pWEnd, int W, int H)
        {
            int x = (pStart.X + (pWEnd.X - pStart.X) / 2)*mForm.pictureBox1.Size.Width/W;
            int y = (pStart.Y + (pHEnd.Y - pStart.Y) / 2) *mForm.pictureBox1.Size.Height/H;

            if (x * y >= 9)
            {
            	ChatClient.BatchMode.SendMessage(x + " " + y);
                Beeper.RecognizedBeep();
                mForm.shot(x, y);
                index = 5;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}