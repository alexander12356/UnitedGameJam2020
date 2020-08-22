using System;
using System.Collections.Generic;

using BadRivals.Application;

namespace BadRivals.MainMenuComponent.Window.StartGame
{
	public interface IStartGameWindowView
	{
		event Action OnWindowLoaded;
		event Action OnWindowOpened;
		event Action OnCloseButtonPressed;
		void InitSaveList(List<IMainMenuSaveData> saveList);
		void OpenWindow();
		void CloseWindow();
	}
}