using UnityEngine;

using Zenject;

namespace BadRivals.MainMenuComponent.Animator
{
	public class MainMenuCameraControllerInstaller : MonoInstaller
	{
		[SerializeField] private MainMenuCameraController _mainMenuCameraController = null;
		
		public override void InstallBindings()
		{
			Container.Bind<IMainMenuCameraController>().FromInstance(_mainMenuCameraController);
		}
	}
}