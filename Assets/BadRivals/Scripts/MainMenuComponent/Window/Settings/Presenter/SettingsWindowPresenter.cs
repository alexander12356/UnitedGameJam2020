using UnityEngine;

namespace BadRivals.MainMenuComponent.Window.Settings
{
	public class SettingsWindowPresenter : MonoBehaviour, ISettingsWindowPresenter
	{
		public void Open()
		{
			Debug.Log("Settings window opened");
		}
	}
}