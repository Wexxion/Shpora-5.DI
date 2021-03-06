﻿using System;
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
        private readonly Func<Random,DragonSettings> settingsFactory;
	    private readonly IDragonPainterFactory factory;

	    public DragonFractalAction(IDragonPainterFactory factory, Func<Random,DragonSettings> settingsFactory)
	    {
	        this.factory = factory;
	        this.settingsFactory = settingsFactory;
	    }


	    public string Category => "Фракталы";
		public string Name => "Дракон";
		public string Description => "Дракон Хартера-Хейтуэя";

		public void Perform()
		{
            
            var dragonSettings = settingsFactory(new Random());
            SettingsForm.For(dragonSettings).ShowDialog();
		    factory.Create(dragonSettings).Paint();
        }
	}
}