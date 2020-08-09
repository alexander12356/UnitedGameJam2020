using System;
using System.Collections.Generic;

namespace BadRivals.Application
{
	public interface ISaveSystemAccess
	{
		void GetSaveList(Action<List<IMainMenuSaveData>> onSuccess);
	}
}
