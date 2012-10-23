
namespace motion
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Media;
    /// <summary>
    /// MotionDetector1
    /// </summary>
    public class MotionDetector1 : IMotionDetector
    {
        private MainForm _mForm;
        int _index = 45;

        public MainForm mForm
        {
            get { return _mForm; }
            set { _mForm = value; }
        }

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
                var simpleSound = new SoundPlayer(@"1.wav");
                simpleSound.Play();
            }
            public static void RecognizedBeepNumber(string s)
            {
                var simpleSound = new SoundPlayer(s);
                simpleSound.Play();
            }

        }

        // Process new frame

        public void ProcessFrame(ref Bitmap image)
        {
            if ((mForm.startStop) && (_index < 0))
            {
                Control(image);
            }
            else
            {
                _index--;
            }
        }

        private void Control(Bitmap image)
        {
            var uBitmap = new Utility.UnsafeBitmap(image);
            uBitmap.LockBitmap();
            try
            {
                for (int y = 0; y < uBitmap.Bitmap.Height; y += 2)
                {
                    for (int x = 0; x < uBitmap.Bitmap.Width; x += 2)
                    {
                        byte r = uBitmap.GetPixel(x, y).red;
                        byte b = uBitmap.GetPixel(x, y).blue;
                        byte g = uBitmap.GetPixel(x, y).green;
                        if ((r - 100 > g) && (r - 100 > b))
                        {
                            var pStart = StartControl(x - 2, y, image);
                            var pHEnd = VerticalControl(pStart, image);
                            var pWEnd = GorizontalControl(pStart, image);
                            if (pHEnd.X != -1)
                            {
                                if (Mathematic(pStart, pHEnd, pWEnd, uBitmap.Bitmap.Size.Width, uBitmap.Bitmap.Size.Height))
                                {
                                    y = uBitmap.Bitmap.Height;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            uBitmap.UnlockBitmap();
            uBitmap.Dispose();
        }

        private Point StartControl(int x, int y, Bitmap image)
        {
            var uBitmap = new Utility.UnsafeBitmap(image);
            uBitmap.LockBitmap();
            var pStart = new Point(-1, -1);
            try
            {
                for (int Y = y; Y < y + 30; Y++)
                {
                    for (int X = x; X < x + 30; X++)
                    {
                        byte r = uBitmap.GetPixel(X, Y).red;
                        byte b = uBitmap.GetPixel(X, Y).blue;
                        byte g = uBitmap.GetPixel(X, Y).green;
                        if ((r - 100 > g) && (r - 100 > b))
                        {
                            if (pStart.X == -1)     // save start point
                            {
                                pStart.X = X;
                                pStart.Y = Y;
                                break;
                            }
                        }
                    }
                    if (pStart.X != -1)
                    {
                        break;
                    }
                }
            }
            catch { }
            uBitmap.UnlockBitmap();
            uBitmap.Dispose();
            return pStart;
        }

        private Point GorizontalControl(Point pStart, Bitmap image)
        {
            Point pHEnd = new Point(-1, -1);
            Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
            uBitmap.LockBitmap();
            try
            {
                byte r, g, b;
                for (int x = pStart.X; x < 30 + pStart.X; x++)
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
                }
            }
            catch { }
            uBitmap.UnlockBitmap();
            uBitmap.Dispose();
            return pHEnd;
        }

        private Point VerticalControl(Point pStart, Bitmap image)
        {
            Utility.UnsafeBitmap uBitmap = new Utility.UnsafeBitmap(image);
            uBitmap.LockBitmap();
            Point pEnd = new Point(-1, -1);
            try
            {
                byte r, g, b;
                for (int y = pStart.Y; y < 30 + pStart.Y; y++)
                {
                    r = uBitmap.GetPixel(pStart.X, y).red;
                    b = uBitmap.GetPixel(pStart.X, y).blue;
                    g = uBitmap.GetPixel(pStart.X, y).green;
                    if (((r - 100 > b) && (r - 100 > g)) || ((r > 150) && (g > 120) && (b > 120)))
                    {
                    }
                    else
                    {
                        pEnd.X = pStart.X;
                        pEnd.Y = y;
                        break;
                    }
                }
            }
            catch { }
            uBitmap.UnlockBitmap();
            uBitmap.Dispose();
            return pEnd;
        }

        private bool Mathematic(Point pStart, Point pHEnd, Point pWEnd, int W, int H)
        {
            int x = (pStart.X + (pWEnd.X - pStart.X) / 2) * mForm.pictureBox1.Size.Width / W;
            int y = (pStart.Y + (pHEnd.Y - pStart.Y) / 2) * mForm.pictureBox1.Size.Height / H;
            if ((pWEnd.X - pStart.X) * (pHEnd.Y - pStart.Y) >= 9)
            {
                Beeper.RecognizedBeep();
                try
                {
                    ChatClient.BatchMode.SendMessage(string.Format("false {0} {1}", x, y));
                }
                catch
                {
                }
                mForm.Shot(x, y);
                _index = 16;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}