using FractalPainting.Infrastructure;

namespace FractalPainting.Solved.Step10.App
{
	public class AppSettings : IImageDirectoryProvider, IImageSettingsProvider
	{
		public string ImagesDirectory { get; set; }
		public ImageSettings ImageSettings { get; set; }
	}
}