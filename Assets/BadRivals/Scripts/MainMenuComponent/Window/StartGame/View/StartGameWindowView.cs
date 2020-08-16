using System;
using System.Collections.Generic;

using BadRivals.Application;

using UnityEngine;

namespace BadRivals.MainMenuComponent.Window.StartGame
{
	public class StartGameWindowView : MonoBehaviour, IStartGameWindowView
	{
		public event Action OnWindowLoaded;

		private void Start()
		{
			OnWindowLoaded?.Invoke();
		}

		public void InitSaveList(List<IMainMenuSaveData> saveList)
		{
		}
	}
}
