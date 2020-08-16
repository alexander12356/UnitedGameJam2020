using System;
using System.Collections.Generic;

using BadRivals.Application;

namespace BadRivals.MainMenuComponent.Window.StartGame.Model
{
	public interface IStartGameWindowModel
	{
		void GetSaveList(Action<List<IMainMenuSaveData>> saveListGetHandler);
	}
}