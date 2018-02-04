using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZClock
{
    class Clock : Control
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            timeLeft = new TimeSpan(6, 15, 17);

            hPen = new Pen(Color.Green, 3);
            mPen = new Pen(Color.Blue, 2);
            sPen = new Pen(Color.Red, 1);

            hLen = this.Width * 0.15;
            mLen = this.Width * 0.25;
            sLen = this.Width * 0.45;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, x) =>
            {
                if (timeLeft.TotalSeconds > 0)
                {
                    timeLeft = timeLeft - new TimeSpan(0, 0, 1);
                    this.Invalidate();
                }
                else
                    timer.Stop();
            };
        }

        Pen hPen, mPen, sPen;

        TimeSpan timeLeft;
        double hLen, mLen, sLen;
        Timer timer;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.Width = this.Height;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = this.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Point center = new Point(this.Width / 2, this.Height / 2);

            //eclipse
            g.DrawEllipse(Pens.Black, 3, 3, this.Width * 0.95f, this.Height * 0.95f);

            //hour
            double hdegree = (timeLeft.Hours / 6.0 - 0.5) * Math.PI;
            Point hEnd = new Point(center.X + (int)(hLen * Math.Cos(hdegree)),
                center.Y + (int)(hLen * Math.Sin(hdegree)));
            g.DrawLine(hPen, center, hEnd);

            //minute
            double mdegree = (timeLeft.Minutes / 30.0 - 0.5) * Math.PI;
            Point mEnd = new Point(center.X + (int)(mLen * Math.Cos(mdegree)),
                center.Y + (int)(mLen * Math.Sin(mdegree)));
            g.DrawLine(mPen, center, mEnd);

            //second
            double sdegree = (timeLeft.Seconds / 30.0 - 0.5) * Math.PI;
            Point sEnd = new Point(center.X + (int)(sLen * Math.Cos(sdegree)),
                center.Y + (int)(sLen * Math.Sin(sdegree)));
            g.DrawLine(sPen, center, sEnd);
        }

        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
    }
}
