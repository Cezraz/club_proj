using System.Windows;
using System.Windows.Input;

namespace MessBox
{
	public static class WpfMessageBox
	{
		private static void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			((Window)sender).DragMove();
		}
		private static MessageBoxResult ShowDispatcher(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
		{
			MessageBoxWin window = new MessageBoxWin()
			{
				Text = messageBoxText,
				Caption = caption,
				MessageBoxButton = button,
				MessageIcon = icon
			};
			window.MouseLeftButtonDown += Window_MouseLeftButtonDown;
			window.ShowDialog();

			return window.Result;

		}

		public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
		{
			return Application.Current.Dispatcher.Invoke(() => ShowDispatcher(messageBoxText, caption, button, icon));
		}

		public static string CaptionDefault { get; } = "Сообщение";

		public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
		{
			return Show(messageBoxText, caption, button, MessageBoxImage.None);
		}
		public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxImage icon)
		{
			return Show(messageBoxText, caption, MessageBoxButton.OK, icon);
		}
		public static MessageBoxResult Show(string messageBoxText, MessageBoxButton button, MessageBoxImage icon)
		{
			return Show(messageBoxText, CaptionDefault, button, icon);
		}
		public static MessageBoxResult Show(string messageBoxText, string caption)
		{
			return Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.None);
		}
		public static MessageBoxResult Show(string messageBoxText, MessageBoxButton button)
		{
			return Show(messageBoxText, CaptionDefault, button, MessageBoxImage.None);
		}
		public static MessageBoxResult Show(string messageBoxText, MessageBoxImage icon)
		{
			return Show(messageBoxText, CaptionDefault, MessageBoxButton.OK, icon);
		}
		public static MessageBoxResult Show(string messageBoxText)
		{
			return Show(messageBoxText, CaptionDefault, MessageBoxButton.OK, MessageBoxImage.None);
		}
	}

}
