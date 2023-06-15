using Ankikun.Views;

namespace Ankikun
{
	/// <summary>
	/// メインプログラム
	/// </summary>
	internal static class Program
	{
		/// <summary>
		/// エントリポイント
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			// アプリケーション設定のアップグレード
			SettingsUpgrade();
			
			Application.Run(new MainView());
		}

		/// <summary>
		/// アプリケーション設定のアップグレード
		/// </summary>
		static void SettingsUpgrade()
		{
			if (Properties.Settings.Default.IsUpgrade) return;
			Properties.Settings.Default.Upgrade();
			Properties.Settings.Default.IsUpgrade = true;
			Properties.Settings.Default.Save();
		}
	}
}