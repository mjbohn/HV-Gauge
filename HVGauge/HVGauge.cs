using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;


namespace Mich3l.Controls.Gauges
{
    public partial class HVGauge : Control 
    {
        public enum GaugeTypes { Bar, Line };
        public enum MidRangePositions { Position1, Middle, Position2 };
        public enum GaugeOrientations { Horizontal, Vertical };

        int maxPercentage = 0;
        Timer maxResetTimer = new Timer();
        
        public HVGauge()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.ResizeRedraw = true;

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this))
            {
                DefaultValueAttribute myAttribute = (DefaultValueAttribute)property.Attributes[typeof(DefaultValueAttribute)];

                if (myAttribute != null)
                {
                    property.SetValue(this, myAttribute.Value);
                }
            }

            //if (this.GaugeType== GaugeTypes.Line && this.ShowRanges)
            //{
            //    this.GaugeBackColor = this.Range3Color;
            //}

            maxResetTimer.Tick += new EventHandler(maxResetTimer_Tick);
        }

        void maxResetTimer_Tick(object sender, EventArgs e)
        {
            this.maxPercentage = this.GaugePercent;
            this.Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (this.GaugeType== GaugeTypes.Line && this.ShowRanges)
            {
                this.GaugeBackColor = Range3Color;
            }
            base.OnPaintBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = ClientRectangle;

            Rectangle barGaugeRectangle = rect;
            Rectangle lineGaugeRectangle = Rectangle.Inflate(rect, 0, -1);
            lineGaugeRectangle.Width = 5;
            
            #region LineGauge offset
            Point lineOffset = new Point();

            if (this.GaugeOrientation== GaugeOrientations.Horizontal)
            {
                if (_gaugePercent == 0)
                {
                    lineOffset = new Point(-lineGaugeRectangle.Width - 1, 0);
                }
                else if (_gaugePercent == 100)
                {
                    lineOffset = new Point(rect.Width - 4, 0);
                }
                else
                {
                    lineOffset = new Point(rect.Width * _gaugePercent / 100 - 3, 0);
                } 
            }
            else
            {
                lineGaugeRectangle.Height = 5;
                lineGaugeRectangle.Width = rect.Width;
                if (_gaugePercent == 0)
                {
                    lineOffset = new Point(0, -lineGaugeRectangle.Height - 1);
                }
                else if (_gaugePercent == 100)
                {
                    lineOffset = new Point(0, rect.Height - 4);
                }
                else
                {
                    lineOffset = new Point(0, rect.Height * _gaugePercent / 100 - 3);
                }
            }
            
            lineGaugeRectangle.Offset(lineOffset);
            #endregion

            if (this.GaugeOrientation == GaugeOrientations.Vertical)
            {
                g.TranslateTransform(0, rect.Height);
                g.ScaleTransform(1.0f, -1.0f);
                barGaugeRectangle.Height = barGaugeRectangle.Height * _gaugePercent / 100;
                
            }
            else
            {
                barGaugeRectangle.Width = barGaugeRectangle.Width * _gaugePercent / 100;
            }

            Color gaugeBarColor = GaugeColor;
            if (this.ShowRanges)
            {
                if (this.GaugePercent >= Range1Min && this.GaugePercent < Range1Max)
                {
                    gaugeBarColor = Range1Color;
                }
                else if (this.GaugePercent >= Range2Min && this.GaugePercent < Range2Max)
                {
                    gaugeBarColor = Range2Color;
                }
                else if (this.GaugePercent >= Range3Min && this.GaugePercent <= Range3Max)
                {
                    gaugeBarColor = Range3Color;
                }
            }
            
            Brush gaugeBrushBar = new SolidBrush(gaugeBarColor);
            if (this._gaugePercent > 0 && GaugeAsGradient)
            {
                gaugeBrushBar = new LinearGradientBrush(barGaugeRectangle, Color.White, gaugeBarColor, GaugeGradientMode);
            }

            Brush gaugeBrushLine = new SolidBrush(GaugeColor);
            Brush valueBrush = new SolidBrush(GaugeForeColor);

            #region ValueString
            /* 
              =================== ValueString ===========================
            */

            System.Drawing.Font valueFont = null;

            if (this.GaugeOrientation== GaugeOrientations.Horizontal)
            {
                if (this.Height <= 25)
                {
                    valueFont = new Font("Tahoma", rect.Height / 2, FontStyle.Bold);
                }
                else
                {
                    valueFont = new Font("Tahoma", rect.Height / 3, FontStyle.Regular);
                } 
            }
            else
            {
                if (this.Height <= 25)
                {
                    //valueFont = new Font("Tahoma", rect.Width / 4, FontStyle.Regular);
                    valueFont = new Font("Tahoma", 15, FontStyle.Regular);
                }
                else
                {
                    //valueFont = new Font("Tahoma", rect.Width / 3, FontStyle.Regular);
                    valueFont = new Font("Tahoma", 20, FontStyle.Regular);
                } 
            }


            string valueString = string.Format("{0}{1}", this.GaugePercent.ToString(), ShowPercentSign ? "%" : "");
            SizeF valueStringSize = g.MeasureString(valueString, valueFont);
            
            #endregion

            #region Switch GaugeType
            switch (this.GaugeType)
            {
                case GaugeTypes.Bar:
                    if (this.StackedBar)
                    {
                        if (this.GaugeOrientation == GaugeOrientations.Horizontal)
                        {
                            drawStackedBarGaugeH(g, rect); 
                        }
                        else
                        {
                            drawStackedBarGaugeV(g, rect);
                        }
                    }
                    else
                    {
                        g.FillRectangle(gaugeBrushBar, barGaugeRectangle);
                    }


                    if (this.ShowIndicator)
                        DrawMaxIndicator(g, rect);

                    if (this.ShowValue)
                    {
                        g.ResetTransform();
                        g.DrawString(valueString, valueFont, valueBrush, (rect.Width / 2) - valueStringSize.Width / 2, (rect.Height / 2) - valueFont.Height / 2);
                    }
                    break;
                case GaugeTypes.Line:
                    if (this.ShowRanges)
                        DrawRanges(g, rect);
                    if (this.ShowIndicator)
                        DrawMaxIndicator(g, rect);

                    g.FillRectangle(gaugeBrushLine, lineGaugeRectangle);
                    if (this.ShowValue)
                    {
                        g.ResetTransform();
                        g.DrawString(valueString, valueFont, valueBrush, (rect.Width / 2) - valueStringSize.Width / 2, (rect.Height / 2) - valueFont.Height / 2);
                    }
                    break;
                default:
                    break;
            }
            #endregion

            //g.FillRectangle(gaugeBrushBar, barGaugeRectangle);


            // Border
            Pen pen = new Pen(new SolidBrush(this.GaugeBorderColor), 2);
            if (this.ShowBorder)
            {
                g.DrawRectangle(pen, rect);
            }
        }

        #region private methods

        private void drawStackedBarGaugeH(Graphics g, Rectangle rect)
        {
            Rectangle Range1 = rect;
            Rectangle Range2 = rect;
            Rectangle Range3 = rect;
            Range1.Offset(rect.Width * Range1Min / 100, 0);
            Range2.Offset(rect.Width * Range2Min / 100, 0);
            Range3.Offset(rect.Width * Range3Min / 100, 0);

            Range1.Width = rect.Width * this.Range1Max / 100;
            Range2.Width = rect.Width * (this.Range2Max - this.Range1Max) / 100;
            Range3.Width = rect.Width * (this.Range3Max - this.Range2Max) / 100;

            Brush Range1Brush = new SolidBrush(Range1Color);
            Brush Range2Brush = new SolidBrush(Range2Color);
            Brush Range3Brush = new SolidBrush(Range3Color);
            if (this.GaugeAsGradient)
            {
                Range1Brush = new LinearGradientBrush(Range1, Color.White, Range1Color, LinearGradientMode.ForwardDiagonal);
                Range2Brush = new LinearGradientBrush(Range2, Color.White, Range2Color, LinearGradientMode.ForwardDiagonal);
                Range3Brush = new LinearGradientBrush(Range3, Color.White, Range3Color, LinearGradientMode.ForwardDiagonal);
            }


            if (this.GaugePercent >= Range1Min && this.GaugePercent < Range1Max)
            {
                Range1.Width = rect.Width * _gaugePercent / 100;
                Range2.Width = 0;
                Range3.Width = 0;
            }
            else if (this.GaugePercent >= Range2Min && this.GaugePercent < Range2Max)
            {
                Range1.Width = rect.Width * this.Range1Max / 100;
                Range2.Width = rect.Width * (_gaugePercent - this.Range1Max) / 100;
                Range3.Width = 0;
            }
            else if (this.GaugePercent >= Range3Min && this.GaugePercent <= Range3Max)
            {
                Range1.Width = rect.Width * this.Range1Max / 100;
                Range2.Width = rect.Width * (_gaugePercent - this.Range1Max) / 100;
                Range3.Width = rect.Width * (_gaugePercent - this.Range2Max) / 100;
            }

            if (this.SmoothGradientTransition)
            {
                drawSmoothGradientRect(g, rect);

            }
            else
            {
                g.FillRectangle(Range1Brush, Range1);
                g.FillRectangle(Range2Brush, Range2);
                g.FillRectangle(Range3Brush, Range3);
            }

        }

        private void drawStackedBarGaugeV(Graphics g, Rectangle rect)
        {

            Rectangle Range1 = rect;
            Rectangle Range2 = rect;
            Rectangle Range3 = rect;
            Range1.Offset(0,rect.Height * Range1Min / 100);
            Range2.Offset(0,rect.Height * Range2Min / 100);
            Range3.Offset(0,rect.Height * Range3Min / 100);

            Range1.Height = rect.Height * this.Range1Max / 100;
            Range2.Height = rect.Height * (this.Range2Max - this.Range1Max) / 100;
            Range3.Height = rect.Height * (this.Range3Max - this.Range2Max) / 100;

            Brush Range1Brush = new SolidBrush(Range1Color);
            Brush Range2Brush = new SolidBrush(Range2Color);
            Brush Range3Brush = new SolidBrush(Range3Color);
            if (this.GaugeAsGradient)
            {
                Range1Brush = new LinearGradientBrush(Range1, Color.White, Range1Color, LinearGradientMode.ForwardDiagonal);
                Range2Brush = new LinearGradientBrush(Range2, Color.White, Range2Color, LinearGradientMode.ForwardDiagonal);
                Range3Brush = new LinearGradientBrush(Range3, Color.White, Range3Color, LinearGradientMode.ForwardDiagonal);
            }


            if (this.GaugePercent >= Range1Min && this.GaugePercent < Range1Max)
            {
                Range1.Height = rect.Height * _gaugePercent / 100;
                Range2.Height = 0;
                Range3.Height = 0;
            }
            else if (this.GaugePercent >= Range2Min && this.GaugePercent < Range2Max)
            {
                Range1.Height = rect.Height * this.Range1Max / 100;
                Range2.Height = rect.Height * (_gaugePercent - this.Range1Max) / 100;
                Range3.Height = 0;
            }
            else if (this.GaugePercent >= Range3Min && this.GaugePercent <= Range3Max)
            {
                Range1.Height = rect.Height * this.Range1Max / 100;
                Range2.Height = rect.Height * (_gaugePercent - this.Range1Max) / 100;
                Range3.Height = rect.Height * (_gaugePercent - this.Range2Max) / 100;
            }

            if (this.SmoothGradientTransition)
            {
                drawSmoothGradientRect(g, rect);

            }
            else
            {
                g.FillRectangle(Range1Brush, Range1);
                g.FillRectangle(Range2Brush, Range2);
                g.FillRectangle(Range3Brush, Range3);
            }

        }
        
        private void drawSmoothGradientRect(Graphics g, Rectangle rect)
        {
            this.drawSmoothGradientRect(g, rect, false);
        }

        private void drawSmoothGradientRect(Graphics g, Rectangle rect, bool asBackground)
        {

            float angle = this.GaugeOrientation == GaugeOrientations.Horizontal ? 0f : 90f;
            LinearGradientBrush lgb = new LinearGradientBrush(rect, Color.Black, Color.Black, angle);
            ColorBlend cb = new ColorBlend();

            cb.Colors = new[] { Range1Color, Range2Color, Range3Color };

            float midrange = 0f;
            switch (this.MiddleRangeposition)
            {
                case MidRangePositions.Position1:
                    midrange = 0.25f;
                    break;
                case MidRangePositions.Middle:
                    midrange = 0.5f;
                    break;
                case MidRangePositions.Position2:
                    midrange = 0.75f;
                    break;
                default:
                    break;
            }
            cb.Positions = new[] { 0, midrange, 1F };

            lgb.InterpolationColors = cb;
            if (!asBackground)
            {
                if (this.GaugeOrientation== GaugeOrientations.Horizontal)
                {
                    rect.Width = rect.Width * _gaugePercent / 100; 
                }
                else
                {
                    rect.Height = rect.Height * _gaugePercent / 100;
                }
            }
            g.FillRectangle(lgb, rect);
        }

        private void DrawMaxIndicator(Graphics g, Rectangle rect)
        {
            maxResetTimer.Interval = this.IndicatorDisplayTime;
            maxResetTimer.Start();

            int maxGaugePosition = 0;
            Brush maxBrush = new SolidBrush(this.IndicatorColor);
            
            Rectangle maxGaugeRectangle = new Rectangle();
            
            if (this.GaugeOrientation == GaugeOrientations.Horizontal)
            {
                maxGaugePosition = this.maxPercentage < 100 ? (rect.Width * this.maxPercentage / 100) - 3 : (rect.Width * this.maxPercentage / 100) - 5;
                maxGaugeRectangle = new Rectangle(maxGaugePosition + 1, rect.Y, 5, rect.Height);
            }
            else
            {
                maxGaugePosition = this.maxPercentage < 100 ? (rect.Height * this.maxPercentage / 100) - 3 : (rect.Height * this.maxPercentage / 100) - 5;
                maxGaugeRectangle = new Rectangle(rect.X, maxGaugePosition + 1, rect.Width, 5);
            }
            g.FillRectangle(maxBrush, maxGaugeRectangle);
        }

        private void DrawRanges(Graphics g, Rectangle rect)
        {

            Brush Range1Brush = new SolidBrush(Range1Color);
            Rectangle Range1 = rect;
            if (this.GaugeOrientation== GaugeOrientations.Horizontal)
            {
                Range1.Offset(rect.Width * Range1Min / 100, 0);
                Range1.Width = rect.Width * (Range1Max - Range1Min) / 100; 
            }
            else
            {
                Range1.Offset(0, rect.Height * Range1Min / 100);
                Range1.Height = rect.Height * (Range1Max - Range1Min) / 100; 
            }
            if (this.RangeAsGradient)
            {
                Range1Brush = new LinearGradientBrush(Range1, Color.White, Range1Color, LinearGradientMode.ForwardDiagonal);
            }
            g.FillRectangle(Range1Brush, Range1);

            Brush Range2Brush = new SolidBrush(Range2Color);
            Rectangle Range2 = rect;
            if (this.GaugeOrientation== GaugeOrientations.Horizontal)
            {
                Range2.Offset(rect.Width * Range2Min / 100, 0);
                Range2.Width = rect.Width * (Range2Max - Range2Min) / 100; 
            }
            else
            {
                Range2.Offset(0, rect.Height * Range2Min / 100);
                Range2.Height = rect.Height * (Range2Max - Range2Min) / 100;
            }
            if (this.RangeAsGradient)
            {
                Range2Brush = new LinearGradientBrush(Range2, Color.White, Range2Color, LinearGradientMode.ForwardDiagonal);
            }
            g.FillRectangle(Range2Brush, Range2);

            Brush Range3Brush = new SolidBrush(Range3Color);
            Rectangle Range3 = rect; 
            if (this.GaugeOrientation== GaugeOrientations.Horizontal)
            {
                Range3.Offset(rect.Width * Range3Min / 100, 0);
                Range3.Width = rect.Width * (Range3Max - Range3Min) / 100; 
            }
            else
            {
                Range3.Offset(0, rect.Height * Range3Min / 100);
                Range3.Height = rect.Height * (Range3Max - Range3Min) / 100;
            }

            #region Range3 adaption
            float mod = 0f;
            if (this.GaugeOrientation == GaugeOrientations.Vertical)
            {
                mod = (this.Height / 2 % 2);
                if (mod > 0f)
                {
                    Range3.Inflate(0, 2);
                }
            }
            else
            {
                mod = (this.Width / 2 % 2);
                if (mod > 0f)
                {
                    Range3.Inflate(2, 0);
                }
            }
            #endregion

            if (this.RangeAsGradient)
            {
                Range3Brush = new LinearGradientBrush(Range3, Color.White, Range3Color, LinearGradientMode.ForwardDiagonal);
            }
            
            
            g.FillRectangle(Range3Brush, Range3);
            
            //string sum = string.Format("R1:{0}  R2:{1}  R3:{2}  sum:{3}", Range1.Height, Range2.Height, Range3.Height, Range1.Height + Range2.Height + Range3.Height);
            //g.ResetTransform();
            //g.DrawString(sum, this.Font, Brushes.Black, 10f, 10.0f);
            
            if (SmoothGradientTransition)
            {
                drawSmoothGradientRect(g, rect, true);
            }
        }
        
        #endregion
    }
}
