using System;
using System.IO;
using ECommerceApp.Interfaces;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(ECommerceApp.iOS.Config))]
namespace ECommerceApp.iOS
{
    public class Config : IConfig
    {
		private string directoryDB;
		private ISQLitePlatform platform;

		public string DirectoryDB
		{
			get
			{
				if (string.IsNullOrEmpty(directoryDB))
				{
					var documentsPath = Environment.GetFolderPath(
						Environment.SpecialFolder.Personal);
                    directoryDB = Path.Combine(documentsPath, "..", "Library");
				}

				return directoryDB;
			}
		}

		public ISQLitePlatform Platform
		{
			get
			{
				if (platform == null)
				{
					platform = new SQLitePlatformIOS();
				}

				return platform;
			}
		}
    }
}
