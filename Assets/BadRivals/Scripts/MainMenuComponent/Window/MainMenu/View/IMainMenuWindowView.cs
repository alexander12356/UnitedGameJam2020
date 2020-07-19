using System;

namespace BadRivals.MainMenuComponent.Window.MainMenu.View
{
	public interface IMainMenuWindowView
	{
		event Action OnGameStartButtonPressed;
		event Action OnSettingsButtonPressed;
		event Action OnQuitButtonPressed;
	}
}