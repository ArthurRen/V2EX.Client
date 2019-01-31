using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using V2EX.Client.Infrastructure.Commands;

namespace V2EX.Client.Controls
{
    public class V2EXWindow : Window
    {
        public static readonly DependencyProperty CaptionBackgroundProperty =
            DependencyProperty.Register(nameof(CaptionBackground), typeof(Brush), typeof(V2EXWindow), new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register(nameof(CloseCommand), typeof(ICommand), typeof(V2EXWindow));

        public static readonly DependencyProperty RestoreCommandProperty =
            DependencyProperty.Register(nameof(RestoreCommand), typeof(ICommand), typeof(V2EXWindow));

        public static readonly DependencyProperty MaximizeCommandProperty =
            DependencyProperty.Register(nameof(MaximizeCommand), typeof(ICommand), typeof(V2EXWindow));

        public static readonly DependencyProperty MinimizeCommandProperty =
            DependencyProperty.Register(nameof(MinimizeCommand), typeof(ICommand), typeof(V2EXWindow));
        
        public static readonly DependencyProperty ExpandOrShrinkFlyoutsCommandProperty =
            DependencyProperty.Register(nameof(ExpandOrShrinkFlyoutsCommand), typeof(ICommand), typeof(V2EXWindow));
        
        public static readonly DependencyProperty MenuContentProperty =
            DependencyProperty.Register(nameof(MenuContent), typeof(FrameworkElement), typeof(V2EXWindow));

        public static readonly DependencyProperty MenuTitleProperty =
            DependencyProperty.Register(nameof(MenuTitle), typeof(FrameworkElement), typeof(V2EXWindow));

        public static readonly DependencyProperty FlyoutsVisibleProperty =
            DependencyProperty.Register(nameof(FlyoutsVisible), typeof(bool), typeof(V2EXWindow),
                new PropertyMetadata(false));

        static V2EXWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(V2EXWindow), new FrameworkPropertyMetadata(typeof(V2EXWindow)));
        }

        public bool FlyoutsVisible
        {
            get => (bool)GetValue(FlyoutsVisibleProperty);
            private set => SetValue(FlyoutsVisibleProperty, value);
        }

        public FrameworkElement MenuContent
        {
            get => GetValue(MenuContentProperty) as FrameworkElement;
            set => SetValue(MenuContentProperty, value);
        }

        public FrameworkElement MenuTitle
        {
            get => GetValue(MenuTitleProperty) as FrameworkElement;
            set => SetValue(MenuTitleProperty, value);
        }

        public Brush CaptionBackground
        {
            get => GetValue(CaptionBackgroundProperty) as Brush;
            set => SetValue(CaptionBackgroundProperty, value);
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

        public ICommand ExpandOrShrinkFlyoutsCommand
        {
            get => GetValue(ExpandOrShrinkFlyoutsCommandProperty) as ICommand;
            private set => SetValue(ExpandOrShrinkFlyoutsCommandProperty, value);
        }

        public V2EXWindow()
        {
            RestoreCommand = new RelayCommand(() => WindowState = WindowState.Normal);
            MinimizeCommand = new RelayCommand(() => WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => WindowState = WindowState.Maximized);
            CloseCommand = new RelayCommand(Close);
            ExpandOrShrinkFlyoutsCommand = new RelayCommand(() => FlyoutsVisible = !FlyoutsVisible);
        }
    }
}
