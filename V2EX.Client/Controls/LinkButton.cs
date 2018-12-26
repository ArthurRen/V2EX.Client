using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace V2EX.Client.Controls
{
    public class LinkButton : ButtonBase
    {
        public static readonly DependencyProperty MouseHoverBackgroundProperty =
            DependencyProperty.Register(nameof(MouseHoverBackground), typeof(Brush), typeof(LinkButton), null);

        public static readonly DependencyProperty MouseLeaveBackgroundProperty =
            DependencyProperty.Register(nameof(MouseLeaveBackground), typeof(Brush), typeof(LinkButton), null);

        public static readonly DependencyProperty MouseHoverForegroundProperty =
            DependencyProperty.Register(nameof(MouseHoverForeground), typeof(Brush), typeof(LinkButton), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty MouseLeaveForegroundProperty =
            DependencyProperty.Register(nameof(MouseLeaveForeground), typeof(Brush), typeof(LinkButton), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty IsUnderlineVisibleProperty =
            DependencyProperty.Register(nameof(IsUnderlineVisible), typeof(bool), typeof(LinkButton), new PropertyMetadata(true));
        
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(LinkButton), new PropertyMetadata(null));
        
        public static readonly DependencyProperty TextDecorationsProperty =
            DependencyProperty.Register(nameof(TextDecorations), typeof(TextDecorationCollection), typeof(LinkButton), new PropertyMetadata(null));

        public static DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(LinkButton), new PropertyMetadata(new CornerRadius(0)));
        
        public static DependencyProperty ContentMarginProperty =
            DependencyProperty.Register(nameof(ContentMargin), typeof(Thickness), typeof(LinkButton), new PropertyMetadata(new Thickness(0)));

        static LinkButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LinkButton),
                new FrameworkPropertyMetadata(typeof(LinkButton)));
        }

        public Brush MouseLeaveForeground
        {
            get => GetValue(MouseLeaveForegroundProperty) as Brush;
            set => SetValue(MouseLeaveForegroundProperty, value);
        }

        public Brush MouseHoverForeground
        {
            get => GetValue(MouseHoverForegroundProperty) as Brush;
            set => SetValue(MouseHoverForegroundProperty, value);
        }

        public Brush MouseHoverBackground
        {
            get => GetValue(MouseHoverBackgroundProperty) as Brush;
            set => SetValue(MouseHoverBackgroundProperty, value);
        }

        public Brush MouseLeaveBackground
        {
            get => GetValue(MouseLeaveBackgroundProperty) as Brush;
            set => SetValue(MouseLeaveBackgroundProperty, value);
        }

        public bool IsUnderlineVisible
        {
            get => (bool)GetValue(IsUnderlineVisibleProperty);
            set => SetValue(IsUnderlineVisibleProperty, value);
        }

        public string Text
        {
            get => GetValue(TextProperty) as string;
            set => SetValue(TextProperty, value);
        }

        public TextDecorationCollection TextDecorations
        {
            get => GetValue(TextDecorationsProperty) as TextDecorationCollection;
            set => SetValue(TextDecorationsProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty , value);
        }

        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }
    }
}
