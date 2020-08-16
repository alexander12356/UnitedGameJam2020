using System;
using System.Collections.Generic;

using BadRivals.Application;

using UnityEngine;

using Zenject;

namespace BadRivals.MainMenuComponent.Window.StartGame.Model
{
	public class StartGameWindowModel : MonoBehaviour, IStartGameWindowModel
	{
		[Inject] private readonly ISaveSystemAccess _saveSystemAccess = null;
		
		public void GetSaveList(Action<List<IMainMenuSaveData>> saveListGetHandler)
		{
			_saveSystemAccess.GetSaveList(saveListGetHandler);
		}
	}
}
