using System;

namespace BadRivals.MainMenuComponent.Window.MainMenu.View
{
	public interface IMainMenuWindowView
	{
		event Action OnStartGameButtonPressed;
		event Action OnSettingsButtonPressed;
		event Action OnQuitButtonPressed;
		void Quit();
	}
}