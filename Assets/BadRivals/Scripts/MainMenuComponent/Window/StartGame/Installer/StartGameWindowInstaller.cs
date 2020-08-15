using BadRivals.MainMenuComponent.Window.StartGame.Model;
using BadRivals.MainMenuComponent.Window.StartGame.Presenter;

using UnityEngine;

using Zenject;

namespace BadRivals.MainMenuComponent.Window.StartGame.Installer
{
	public class StartGameWindowInstaller : MonoInstaller
	{
		[SerializeField] private StartGameWindowPresenter _startGameWindowPresenter = null;

		public override void InstallBindings()
		{
			Container.Bind<IStartGameWindowPresenter>().FromInstance(_startGameWindowPresenter);
			Container.Bind<IStartGameWindowView>().FromComponentSibling();
			Container.Bind<IStartGameWindowModel>().FromComponentSibling();
		}
	}
}
