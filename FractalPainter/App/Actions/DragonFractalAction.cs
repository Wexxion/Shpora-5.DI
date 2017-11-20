using System;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure;
using Ninject;

namespace FractalPainting.App.Actions
{
    public interface IDragonPainterFactory
    {
        DragonPainter Create(DragonSettings settings);
    }
    public class DragonFractalAction : IUiAction
	{
	    private IDragonPainterFactory factory;

	    public DragonFractalAction(IDragonPainterFactory factory)
        { 
	        this.factory = factory;
	    }


	    public string Category => "Фракталы";
		public string Name => "Дракон";
		public string Description => "Дракон Хартера-Хейтуэя";

		public void Perform()
		{
            
            var dragonSettings = CreateRandomSettings();
            SettingsForm.For(dragonSettings).ShowDialog();
		    factory.Create(dragonSettings).Paint();
        }

        private static DragonSettings CreateRandomSettings()
		{
			return new DragonSettingsGenerator(new Random()).Generate();
		}
	}

    
}