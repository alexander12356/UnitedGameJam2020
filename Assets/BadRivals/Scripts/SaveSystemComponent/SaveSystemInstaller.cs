using BadRivals.Application;

using UnityEngine;

using Zenject;

namespace BadRivals.SaveSystem.Installer
{
	public class SaveSystemInstaller : MonoInstaller
	{
		[SerializeField] private SaveSystemAccess _saveSystemAccess = null;

		public override void InstallBindings()
		{
			Container.Bind<ISaveSystemAccess>().FromInstance(_saveSystemAccess);
		}
	}
}
