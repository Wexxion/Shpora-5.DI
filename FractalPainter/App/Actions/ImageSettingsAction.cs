using FractalPainting.Infrastructure;

namespace FractalPainting.App.Actions
{
	public class ImageSettingsAction : IUiAction
	{
		private IImageHolder imageHolder;
	    private ImageSettings settings;


	    public ImageSettingsAction(IImageHolder imageHolder, ImageSettings settings)
	    {
	        this.imageHolder = imageHolder;
	        this.settings = settings;
	    }

		public string Category => "Настройки";
		public string Name => "Изображение...";
		public string Description => "Размеры изображения";

		public void Perform()
		{
			SettingsForm.For(settings).ShowDialog();
			imageHolder.RecreateImage(settings);
		}
	}
}