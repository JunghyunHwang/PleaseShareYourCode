using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PleaseShareYourCode.PSYC
{
	public class Settings
	{
		public ELanguage Language { get; set; }
		public EEncoding Encoding { get; set; }
		public string Separator { get; set; }
		public string LastFolderPath { get; set; }

		private readonly string path = Path.Combine(Environment.CurrentDirectory, "settings.json");

		public void SerializeSettings()
		{
			JsonParser.Serialize<Settings>(this, path);
		}

		public void DeserializeSettings()
		{
			if (File.Exists(path))
			{
				Settings settings = JsonParser.DeserializeFile<Settings>(path);
				Language = settings.Language;
				Encoding = settings.Encoding;
				Separator = settings.Separator;
                LastFolderPath = settings.LastFolderPath;

            }
			else
			{
				Language = ELanguage.C;
				Encoding = EEncoding.Default;
				Separator = "------ %name ------";
                LastFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                JsonParser.Serialize<Settings>(this, path);
			}
		}
	}

	public enum ELanguage
	{
		C,
		CPP,
		CS,
		JAVA,
		ASM
	}

	public enum EEncoding
	{
		Default,
		UTF8,
		ASCII
	}
}
