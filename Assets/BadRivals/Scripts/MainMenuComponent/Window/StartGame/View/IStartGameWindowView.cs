using System;
using System.Collections.Generic;

using BadRivals.Application;

namespace BadRivals.MainMenuComponent.Window.StartGame
{
	public interface IStartGameWindowView
	{
		event Action OnWindowLoaded;
		void InitSaveList(List<IMainMenuSaveData> saveList);
	}
}