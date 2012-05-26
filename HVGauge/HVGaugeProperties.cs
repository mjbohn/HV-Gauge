using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Mich3l.Controls.Gauges
{
    public partial class HVGauge 
    {
        #region BaseProperty Hiding
        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [Browsable(false)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        #endregion

        #region GaugeProperties

        [DefaultValue(typeof(Color), "Control"), Category("Gauge")]
        public Color GaugeBackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [DefaultValue(typeof(Color), "Black"), Category("Gauge")]
        public Color GaugeForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        private Color _gaugeColor;
        [DefaultValue(typeof(Color), "Lime"), Category("Gauge")]
        public Color GaugeColor
        {
            get { return _gaugeColor; }
            set
            {
                _gaugeColor = value;
                this.Invalidate();
            }
        }

        private int _gaugePercent;
        [DefaultValue(0), Category("Gauge")]
        public int GaugePercent
        {
            get { return _gaugePercent; }
            set
            {
                if (value <= 0)
                {
                    _gaugePercent = 0;
                }
                else if (value >= 100)
                {
                    _gaugePercent = 100;
                }
                else
                {
                    _gaugePercent = value;
                }
                if (value > this.maxPercentage)
                {
                    this.maxPercentage = value;
                }
                this.Invalidate();
            }
        }

        private Color _gaugeBorderColor;
        [DefaultValue(typeof(Color), "Black"), Category("Gauge")]
        public Color GaugeBorderColor
        {
            get { return _gaugeBorderColor; }
            set
            {
                _gaugeBorderColor = value;
                this.Invalidate();
            }
        }

        private GaugeTypes _gaugeType;
        [DefaultValue(typeof(GaugeTypes), "Bar"), Category("Gauge")]
        public GaugeTypes GaugeType
        {
            get { return _gaugeType; }
            set
            {
                _gaugeType = value;
                this.Invalidate();
            }
        }

        private bool _showValue;
        [DefaultValue(true), Category("Gauge")]
        public bool ShowValue
        {
            get { return _showValue; }
            set
            {
                _showValue = value;
                this.Invalidate();
            }
        }

        private bool _showPercentSign;
        [DefaultValue(true), Category("Gauge"),DisplayName("Show % Sign")]
        public bool ShowPercentSign
        {
            get { return _showPercentSign; }
            set 
            { 
                _showPercentSign = value;
                this.Invalidate();
            }
        }


        private bool _showBorder;
        [DefaultValue(true), Category("Gauge")]
        public bool ShowBorder
        {
            get { return _showBorder; }
            set
            {
                _showBorder = value;
                this.Invalidate();
            }
        }

        private bool _gaugeAsGradient;
        [DefaultValue(false), Category("Gauge")]
        public bool GaugeAsGradient
        {
            get { return _gaugeAsGradient; }
            set
            {
                _gaugeAsGradient = value;
                this.Invalidate();
            }
        }

        private bool _stackedBar;
        [DefaultValue(true), Category("Gauge")]
        public bool StackedBar
        {
            get { return _stackedBar; }
            set
            {
                _stackedBar = value;
                this.Invalidate();
            }
        }


        private LinearGradientMode _gaugeGradientMode;
        [DefaultValue(LinearGradientMode.Horizontal), Category("Gauge")]
        public LinearGradientMode GaugeGradientMode
        {
            get { return _gaugeGradientMode; }
            set
            {
                _gaugeGradientMode = value;
                this.Invalidate();
            }
        }

        private GaugeOrientations _gaugeOrientation;
        [DefaultValue(GaugeOrientations.Horizontal), Category("Gauge"),DisplayName("GaugeOrientation")]
        public GaugeOrientations GaugeOrientation
        {
            get { return _gaugeOrientation; }
            set 
            { 
                _gaugeOrientation = value;
                this.Invalidate();
            }
        }


        #endregion

        #region RangeProperties

        private int _range1Min;
        [DefaultValue(0), Category("Gauge Ranges")]
        public int Range1Min
        {
            get { return _range1Min; }
            set
            {
                _range1Min = value;
                this.Invalidate();
            }
        }

        private int _range1Max;
        [DefaultValue(60), Category("Gauge Ranges")]
        public int Range1Max
        {
            get { return _range1Max; }
            set
            {
                _range1Max = value;
                this.Invalidate();
            }
        }

        private Color _range1Color;
        [DefaultValue(typeof(Color), "Green"), Category("Gauge Ranges")]
        public Color Range1Color
        {
            get { return _range1Color; }
            set
            {
                _range1Color = value;
                this.Invalidate();
            }
        }

        private int _range2Min;
        [DefaultValue(60), Category("Gauge Ranges")]
        public int Range2Min
        {
            get { return _range2Min; }
            set
            {
                _range2Min = value;
                this.Invalidate();
            }
        }

        private int _range2Max;
        [DefaultValue(85), Category("Gauge Ranges")]
        public int Range2Max
        {
            get { return _range2Max; }
            set
            {
                _range2Max = value;
                this.Invalidate();
            }
        }

        private Color _range2Color;
        [DefaultValue(typeof(Color), "Yellow"), Category("Gauge Ranges")]
        public Color Range2Color
        {
            get { return _range2Color; }
            set
            {
                _range2Color = value;
                this.Invalidate();
            }
        }

        private int _range3Min;
        [DefaultValue(85), Category("Gauge Ranges")]
        public int Range3Min
        {
            get { return _range3Min; }
            set
            {
                _range3Min = value;
                this.Invalidate();
            }
        }

        private int _range3Max;
        [DefaultValue(100), Category("Gauge Ranges")]
        public int Range3Max
        {
            get { return _range3Max; }
            set
            {
                _range3Max = value;
                this.Invalidate();
            }
        }

        private Color _range3Color;
        [DefaultValue(typeof(Color), "Red"), Category("Gauge Ranges")]
        public Color Range3Color
        {
            get { return _range3Color; }
            set
            {
                _range3Color = value;
                this.Invalidate();
            }
        }

        private bool _showRanges;
        [DefaultValue(true), Category("Gauge")]
        public bool ShowRanges
        {
            get { return _showRanges; }
            set
            {
                _showRanges = value;
                this.Invalidate();
            }
        }

        private bool _rangeAsGradient;
        [DefaultValue(true), Category("Gauge Ranges")]
        public bool RangeAsGradient
        {
            get { return _rangeAsGradient; }
            set
            {
                _rangeAsGradient = value;
                this.Invalidate();
            }
        }

        private bool _smoothGradientTransition;
        [DefaultValue(false), Category("Gauge Smooth Gradient")]
        public bool SmoothGradientTransition
        {
            get { return _smoothGradientTransition; }
            set
            {
                _smoothGradientTransition = value;
                this.Invalidate();
            }
        }


        private MidRangePositions _midRangePos;
        [DefaultValue(MidRangePositions.Middle), Category("Gauge Smooth Gradient")]
        public MidRangePositions MiddleRangeposition
        {
            get { return _midRangePos; }
            set
            {
                _midRangePos = value;
                this.Invalidate();
            }
        }


        #endregion

        #region MaxIndicator Properties

        private int _displayTime;
        [DefaultValue(2500), Category("Gauge Maximum Indicator"), Description("Displaytime of MaxIndicator in milliseconds")]
        public int IndicatorDisplayTime
        {
            get { return _displayTime; }
            set { _displayTime = value; }
        }

        private bool _showIndicator;
        [DefaultValue(false), Category("Gauge Maximum Indicator")]
        public bool ShowIndicator
        {
            get { return _showIndicator; }
            set
            {
                _showIndicator = value;
                this.Invalidate();
            }
        }

        private Color _indicatorColor;
        [DefaultValue(typeof(Color), "Red"), Category("Gauge Maximum Indicator")]
        public Color IndicatorColor
        {
            get { return _indicatorColor; }
            set
            {
                _indicatorColor = value;
                this.Invalidate();
            }
        }


        #endregion
    }
}