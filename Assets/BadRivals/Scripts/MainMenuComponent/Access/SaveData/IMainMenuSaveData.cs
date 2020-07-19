using System;

namespace BadRivals.MainMenuComponent.Access.SaveData
{
	public interface IMainMenuSaveData
	{
		string Id { get; }
		TimeSpan Duration { get; }
		DateTime LastSaveData { get; }
		string LocationId { get; }
	}
}