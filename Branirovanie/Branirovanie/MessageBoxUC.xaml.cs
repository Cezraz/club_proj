using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MessBox
{
	/// <summary>
	/// Логика взаимодействия для UserControl1.xaml
	/// </summary>
	internal partial class MessageBoxWin : Window
	{
		private readonly Action windowsClose;
		public MessageBoxWin(Action windowsClose = null)
		{
			this.windowsClose = windowsClose;
			InitializeComponent();
			MessageBoxButtonChanged(this, new DependencyPropertyChangedEventArgs(MessageBoxButtonProperty, null, MessageBoxButton));
		}

		public MessageBoxButton MessageBoxButton
		{
			get { return (MessageBoxButton)GetValue(MessageBoxButtonProperty); }
			set { SetValue(MessageBoxButtonProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MessageBoxButton.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MessageBoxButtonProperty =
			DependencyProperty.Register(nameof(MessageBoxButton), typeof(MessageBoxButton), typeof(MessageBoxWin),
				new PropertyMetadata(MessageBoxButton.OK, MessageBoxButtonChanged));

		public MessageBoxImage MessageIcon
		{
			get { return (MessageBoxImage)GetValue(MessageIconProperty); }
			set { SetValue(MessageIconProperty, value); }
		}

		// Using a DependencyProperty as the backing store for BoxImage.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MessageIconProperty =
			DependencyProperty.Register(nameof(MessageIcon), typeof(MessageBoxImage), typeof(MessageBoxWin), new PropertyMetadata(MessageBoxImage.None));



		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register(nameof(Text), typeof(string), typeof(MessageBoxWin), new PropertyMetadata(null));

		public string Caption
		{
			get { return (string)GetValue(CaptionProperty); }
			set { SetValue(CaptionProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CaptionProperty =
			DependencyProperty.Register(nameof(Caption), typeof(string), typeof(MessageBoxWin), new PropertyMetadata(null));

		private static void MessageBoxButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			MessageBoxWin uc = (MessageBoxWin)d;
			string value = e.NewValue.ToString().ToUpper();

			uc.btnOk.Visibility = value.Contains("OK") ? Visibility.Visible : Visibility.Collapsed;
			uc.btnYes.Visibility = value.Contains("YES") ? Visibility.Visible : Visibility.Collapsed;
			uc.btnCancel.Visibility = value.Contains("CANCEL") ? Visibility.Visible : Visibility.Collapsed;
			uc.btnNo.Visibility = value.Contains("NO") ? Visibility.Visible : Visibility.Collapsed;
		}

		public MessageBoxResult Result { get; set; } = MessageBoxResult.None;

		private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			string par = (string)e.Parameter;
			string cur_str = string.Empty;
			switch(par)
            {
				case "OK":
					cur_str = "OK";
					break;
				case "Да":
					cur_str = "Yes";
					break;
				case "Нет":
					cur_str = "No";
					break;
				case "Отмена":
					cur_str = "Cancel";
					break;
			}

			Result = (MessageBoxResult)Enum.Parse(typeof(MessageBoxResult), cur_str);
			e.Handled = true;
			Close();
		}
	}
}

