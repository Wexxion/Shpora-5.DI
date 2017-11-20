using System;
using System.Configuration;
using System.Windows.Forms;
using FractalPainting.App.Actions;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure;
using Ninject;

namespace FractalPainting.App
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var container = new StandardKernel();
            container.Bind<IUiAction>().To<SaveImageAction>();
            container.Bind<IUiAction>().To<DragonFractalAction>();
            container.Bind<IUiAction>().To<KochFractalAction>();
            container.Bind<IUiAction>().To<ImageSettingsAction>();
            container.Bind<IUiAction>().To<PaletteSettingsAction>();
            //3
            container.Bind<IImageHolder, PictureBoxImageHolder>()
                .To<PictureBoxImageHolder>().InSingletonScope();
            container.Bind<Palette>().ToSelf().InSingletonScope();
            //4
            container.Bind<KochPainter>().ToSelf();

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var form = container.Get<MainForm>();
                Application.Run(form);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}