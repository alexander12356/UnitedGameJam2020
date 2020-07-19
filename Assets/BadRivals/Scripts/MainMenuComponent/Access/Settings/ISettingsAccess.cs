namespace BadRivals.MainMenuComponent.Access.Settings
{
	public interface ISettingsAccess
	{
		ISettingsData Load();
		void Save(ISettingsData data);
		void Accept(ISettingsData data);
	}
}