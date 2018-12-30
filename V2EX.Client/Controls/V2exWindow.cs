using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using V2EX.Foundation.Commands;

namespace V2EX.Client.Controls
{
    public class V2exWindow : Window
    {
        public static readonly DependencyProperty CaptionBackgroundProperty =
            DependencyProperty.Register(nameof(CaptionBackground) , typeof(Brush) , typeof(V2exWindow), new PropertyMetadata(Brushes.Transparent));

        public static readonly DependencyProperty TitleContentProperty =
            DependencyProperty.Register(nameof(TitleContent), typeof(object), typeof(V2exWindow));
        
        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register(nameof(CloseCommand), typeof(ICommand), typeof(V2exWindow));
        
        public static readonly DependencyProperty RestoreCommandProperty =
            DependencyProperty.Register(nameof(RestoreCommand), typeof(ICommand), typeof(V2exWindow));
        
        public static readonly DependencyProperty MaximizeCommandProperty =
            DependencyProperty.Register(nameof(MaximizeCommand), typeof(ICommand), typeof(V2exWindow));
        
        public static readonly DependencyProperty MinimizeCommandProperty =
            DependencyProperty.Register(nameof(MinimizeCommand), typeof(ICommand), typeof(V2exWindow));
        
        static V2exWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(V2exWindow), new FrameworkPropertyMetadata(typeof(V2exWindow)));
        }

        public Brush CaptionBackground
        {
            get => GetValue(CaptionBackgroundProperty) as Brush;
            set => SetValue(CaptionBackgroundProperty, value);
        }

        public object TitleContent
        {
            get => GetValue(TitleContentProperty);
            set => SetValue(TitleContentProperty, value);
        }

        public ICommand CloseCommand
        {
            get => GetValue(CloseCommandProperty) as ICommand;
            private set => SetValue(CloseCommandProperty, value);
        }

        public ICommand RestoreCommand
        {
            get => GetValue(RestoreCommandProperty) as ICommand;
            private set => SetValue(RestoreCommandProperty, value);
        }

        public ICommand MinimizeCommand
        {
            get => GetValue(MinimizeCommandProperty) as ICommand;
            private set => SetValue(MinimizeCommandProperty, value);
        }

        public ICommand MaximizeCommand
        {
            get => GetValue(MaximizeCommandProperty) as ICommand;
            private set => SetValue(MaximizeCommandProperty, value);
        }

        public V2exWindow()
        {
            CloseCommand = new RelayCommand(Close);
            RestoreCommand = new RelayCommand(() => WindowState = WindowState.Normal);
            MinimizeCommand = new RelayCommand(() => WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => WindowState = WindowState.Maximized);
        }

    }
}
