using System.Collections.Generic;

using BadRivals.Application;
using BadRivals.MainMenuComponent.Window.StartGame.Model;

using UnityEngine;

using Zenject;

namespace BadRivals.MainMenuComponent.Window.StartGame.Presenter
{
	public class StartGameWindowPresenter : MonoBehaviour, IStartGameWindowPresenter
	{
		[Inject] private readonly IStartGameWindowView _view = null;
		[Inject] private readonly IStartGameWindowModel _model = null;
		
		[Inject]
		private void Construct()
		{
			_view.OnWindowLoaded += WindowLoadedHandler;
			_view.OnWindowOpened += WindowOpenedHandler;
			_view.OnCloseButtonPressed += CloseButtonPressedHandler;
		}

		private void OnDestroy()
		{
			_view.OnWindowLoaded -= WindowLoadedHandler;
			_view.OnWindowOpened -= WindowOpenedHandler;
			_view.OnCloseButtonPressed -= CloseButtonPressedHandler;
		}

		private void WindowLoadedHandler()
		{
			_model.GetSaveList(SaveListGetHandler);
		}

		private void SaveListGetHandler(List<IMainMenuSaveData> saveList)
		{
			_view.InitSaveList(saveList);
		}

		public void Open()
		{
			_view.OpenWindow();
		}

		private void WindowOpenedHandler()
		{
		}

		private void CloseButtonPressedHandler()
		{
			_view.CloseWindow();
		}
	}
}
