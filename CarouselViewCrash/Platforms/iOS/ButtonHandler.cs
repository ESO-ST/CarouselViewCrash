using CoreGraphics;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace CarouselViewCrash.Platforms.iOS
{
    internal class MyButtonHandler : ButtonHandler
    {
        static MyButtonHandler()
        {
            (new Foundation.NSUserDefaults()).SetBool(false, "_UIConstraintBasedLayoutLogUnsatisfiable");
        }

        protected UIButton Control { get; set; }

        private UITextAlignment _textAlignment = UITextAlignment.Left;

        private bool _disposed = false;
        private bool _loading = true;

        protected int _labelOffset { get; set; }
        protected int _iconOffset { get; set; }
        protected int _iconSize { get; set; } = 15;

        private string _iconSource { get; set; } = "dotnet_bot.png";

        public MyButtonHandler() { }
        public MyButtonHandler(IPropertyMapper<IButton, IButtonHandler> mapper) : base(mapper) { }

        public override void UpdateValue(string property)
        {
            base.UpdateValue(property);

            if (_loading && property == nameof(Button.Background))
            {
                _loading = false;
                SetupControl();
            }
        }

        protected override void ConnectHandler(UIButton platformView)
        {
            base.ConnectHandler(platformView);
            this.Control = platformView;
        }

        protected void SetTextLabel(UITextAlignment textAlignment = UITextAlignment.Left, int textOffset = 6)
        {
            _textAlignment = textAlignment;
            _labelOffset = textOffset;
        }

        protected void SetIconSource(string iconSource)
        {
            _iconSource = iconSource;
        }

        protected void SetIconMetric(int iconSize, int iconOffset = -8)
        {
            _iconSize = 20;
            _iconOffset = iconOffset;
        }

        public virtual void SetupControl()
        {
            if (Control != null)
            {
                Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
                Control.TitleLabel.LineBreakMode = UILineBreakMode.TailTruncation;
                Control.TitleLabel.LeftAnchor.ConstraintEqualTo(Control.ImageView.Superview.LeftAnchor, _labelOffset).Active = true;
                Control.TitleLabel.TextAlignment = _textAlignment;
                Control.TitleLabel.Lines = 2;

                UIImage iconImage = LoadIcon();
                if (iconImage != null)
                {
                    SetStateImage(iconImage);
                }
                Control.TitleLabel.AccessibilityIdentifier = Control.AccessibilityIdentifier + "_ButtonLabel";
            }
        }

        protected virtual UIImage LoadIcon()
        {
            if (!string.IsNullOrEmpty(_iconSource))
            {
                return UIImage.FromFile(_iconSource).Scale(new CGSize(_iconSize, _iconSize))
                    .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            }
            return null;
        }

        protected virtual void SetStateImage(UIImage image, UIImage disabledImage = null)
        {
            Control.SetImage(image, UIControlState.Application);
            Control.SetImage(image, UIControlState.Focused);
            Control.SetImage(image, UIControlState.Highlighted);
            Control.SetImage(image, UIControlState.Normal);
            Control.SetImage(image, UIControlState.Reserved);
            Control.SetImage(image, UIControlState.Selected);

            if (disabledImage != null)
            {
                Control.SetImage(image, UIControlState.Disabled);
            }

            if (Control.ImageView != null)
            {
                Control.ImageView.TranslatesAutoresizingMaskIntoConstraints = false;
                Control.ImageView.RightAnchor.ConstraintEqualTo(Control.RightAnchor, _iconOffset).Active = true;
                Control.ImageView.CenterYAnchor.ConstraintEqualTo(Control.CenterYAnchor).Active = true;
                Control.ImageView.ContentMode = UIViewContentMode.Right;
            }
            Control.AdjustsImageWhenDisabled = true;

            nfloat widthOffset = _iconOffset - _labelOffset - image.Size.Width;
            Control.TitleLabel.WidthAnchor.ConstraintEqualTo(Control.WidthAnchor, constant: widthOffset).Active = true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Control?.ImageView?.Dispose();
                    Control?.Dispose();
                    Control = null;
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code.
            // Put cleanup code in 'Dispose(bool disposing)' method.

            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
