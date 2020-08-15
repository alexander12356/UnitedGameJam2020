using BadRivals.MainMenuComponent.Window.MainMenu.View;
using BadRivals.MainMenuComponent.Window.Settings;
using BadRivals.MainMenuComponent.Window.StartGame.Presenter;

using UnityEngine;

using Zenject;

namespace BadRivals.MainMenuComponent.Window.MainMenu.Presenter
{
	public class MainMenuWindowPresenter : MonoBehaviour, IMainMenuWindowPresenter
	{
		[Inject] private readonly IMainMenuWindowView _view = null;
		[Inject] private readonly IStartGameWindowPresenter _startGameWindowPresenter = null;
		[Inject] private readonly ISettingsWindowPresenter _settingsWindowPresenter = null;

		[Inject]
		private void Construct()
		{
			_view.OnQuitButtonPressed += QuitButtonPressedHandler;
			_view.OnStartGameButtonPressed += StartGameButtonPressedHandler;
			_view.OnSettingsButtonPressed += SettingsButtonPressedHandler;
		}

		private void OnDestroy()
		{
			_view.OnQuitButtonPressed -= QuitButtonPressedHandler;
			_view.OnStartGameButtonPressed -= StartGameButtonPressedHandler;
			_view.OnSettingsButtonPressed -= SettingsButtonPressedHandler;
		}

		private void QuitButtonPressedHandler()
		{
			_view.Quit();
		}

		private void StartGameButtonPressedHandler()
		{
			_startGameWindowPresenter.Open();
		}

		private void SettingsButtonPressedHandler()
		{
			_settingsWindowPresenter.Open();
		}
	}
}