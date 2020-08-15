using System;

using UnityEngine;

namespace BadRivals.MainMenuComponent.Window.MainMenu.View
{
	public class MainMenuWindowView : MonoBehaviour, IMainMenuWindowView
	{
		public event Action OnStartGameButtonPressed;
		public event Action OnSettingsButtonPressed;
		public event Action OnQuitButtonPressed;

		public void GameStartButtonPress()
		{
			OnStartGameButtonPressed?.Invoke();
		}

		public void SettingsButtonPressed()
		{
			OnSettingsButtonPressed?.Invoke();
		}

		public void QuitButtonPress()
		{
			OnQuitButtonPressed?.Invoke();
		}

		public void Quit()
		{
			UnityEngine.Application.Quit();
		}
	}
}