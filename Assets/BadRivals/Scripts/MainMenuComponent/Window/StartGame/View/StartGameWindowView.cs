using System;
using System.Collections.Generic;

using BadRivals.Application;
using BadRivals.MainMenuComponent.Animator;

using UnityEngine;

namespace BadRivals.MainMenuComponent.Window.StartGame
{
	public class StartGameWindowView : MonoBehaviour, IStartGameWindowView
	{
		private IWindowShowAnimator _windowShowAnimator = null;
		
		public event Action OnWindowLoaded;
		public event Action OnWindowOpened;
		public event Action OnCloseButtonPressed;

		private void Awake()
		{
			_windowShowAnimator = GetComponent<IWindowShowAnimator>();
		}

		private void Start()
		{
			OnWindowLoaded?.Invoke();
		}

		public void InitSaveList(List<IMainMenuSaveData> saveList)
		{
		}

		public void OpenWindow()
		{
			_windowShowAnimator.Show();
		}

		public void CloseWindow()
		{
			_windowShowAnimator.Close();
		}

		public void CloseWindowButtonPress()
		{
			OnCloseButtonPressed?.Invoke();
		}
	}
}
