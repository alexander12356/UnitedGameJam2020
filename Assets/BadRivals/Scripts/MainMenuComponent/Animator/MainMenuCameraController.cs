using UnityEngine;

namespace BadRivals.MainMenuComponent.Animator
{
	public class MainMenuCameraController : MonoBehaviour, IMainMenuCameraController
	{
		[SerializeField] private Camera _camera = null;
		
		public Transform GetCameraTransform()
		{
			return _camera.transform;
		}
	}
}