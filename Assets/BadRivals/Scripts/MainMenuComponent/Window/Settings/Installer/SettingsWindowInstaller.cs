using UnityEngine;

using Zenject;

namespace BadRivals.MainMenuComponent.Window.Settings.Installer
{
	public class SettingsWindowInstaller : MonoInstaller
	{
		[SerializeField] private SettingsWindowPresenter _settingsWindowPresenter = null;
		
		public override void InstallBindings()
		{
			Container.Bind<ISettingsWindowPresenter>().FromInstance(_settingsWindowPresenter);
		}
	}
}
