using System.Collections.Generic;

using BadRivals.Application;

using UnityEngine;

using Zenject;

namespace BadRivals.MainMenuComponent.Window.StartGame.Presenter
{
	public class StartGameWindowPresenter : MonoBehaviour, IStartGameWindowPresenter
	{
		//[Inject] private readonly ISaveSystemAccess _saveSystemAccess = null;
		
		public void Start()
		{
			InitSaveList();
		}

		private void InitSaveList()
		{
			//_saveSystemAccess.GetSaveList(SaveListGettedHandler);
		}

		private void SaveListGettedHandler(List<IMainMenuSaveData> saveList)
		{
		}

		public void Open()
		{
			Debug.Log("Start game window opened");
		}
	}
}
