﻿using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using V2EX.Client.ViewModels.Links;

namespace V2EX.Client.Controls
{
    public class TopicList : Control
    {
        public static readonly DependencyProperty TopicsProperty =
            DependencyProperty.Register(nameof(Topics), typeof(ObservableCollection<TopicItem>), typeof(TopicList));

        public static readonly DependencyProperty ViewTopicCommandProperty =
            DependencyProperty.Register(nameof(ViewTopicCommand), typeof(ICommand), typeof(TopicList));

        public static readonly DependencyProperty ViewAuthorInfoCommandProperty =
            DependencyProperty.Register(nameof(ViewAuthorInfoCommand), typeof(ICommand), typeof(TopicList));

        public static readonly DependencyProperty ViewNodeInfoCommandProperty =
            DependencyProperty.Register(nameof(ViewNodeInfoCommand), typeof(ICommand), typeof(TopicList));

        public static readonly DependencyProperty ViewLastReplyMemberInfoCommandProperty =
            DependencyProperty.Register(nameof(ViewLastReplyMemberInfoCommand), typeof(ICommand), typeof(TopicList));

        static TopicList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TopicList),
                new FrameworkPropertyMetadata(typeof(TopicList)));
        }

        public ObservableCollection<TopicItem> Topics
        {
            get => GetValue(TopicsProperty) as ObservableCollection<TopicItem>;
            set => SetValue(TopicsProperty, value);
        }
        
        public ICommand ViewTopicCommand
        {
            get => GetValue(ViewTopicCommandProperty) as ICommand;
            set => SetValue(ViewTopicCommandProperty, value);
        }

        public ICommand ViewAuthorInfoCommand
        {
            get => GetValue(ViewAuthorInfoCommandProperty) as ICommand;
            set => SetValue(ViewAuthorInfoCommandProperty, value);
        }

        public ICommand ViewNodeInfoCommand
        {
            get => GetValue(ViewNodeInfoCommandProperty) as ICommand;
            set => SetValue(ViewNodeInfoCommandProperty, value);
        }

        public ICommand ViewLastReplyMemberInfoCommand
        {
            get => GetValue(ViewLastReplyMemberInfoCommandProperty) as ICommand;
            set => SetValue(ViewLastReplyMemberInfoCommandProperty, value);
        }
    }
}
