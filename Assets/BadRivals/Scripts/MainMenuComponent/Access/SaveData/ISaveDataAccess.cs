using System.Collections.Generic;

namespace BadRivals.MainMenuComponent.Access.SaveData
{
	public interface ISaveDataAccess
	{
		List<IMainMenuSaveData> GetSaveDataList();
	}
}