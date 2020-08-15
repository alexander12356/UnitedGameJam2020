using BadRivals.MainMenuComponent.Window.MainMenu.Presenter;
using BadRivals.MainMenuComponent.Window.MainMenu.View;

using UnityEngine;

using Zenject;

namespace BadRivals.MainMenuComponent.Window.MainMenu.Installer
{
	public class MainMenuWindowInstaller : MonoInstaller
	{
		[SerializeField] private MainMenuWindowPresenter _mainMenuWindowPresenter = null;
		
		public override void InstallBindings()
		{
			Container.Bind<IMainMenuWindowPresenter>().FromInstance(_mainMenuWindowPresenter);
			Container.Bind<IMainMenuWindowView>().FromComponentSibling();
		}
	}
}
