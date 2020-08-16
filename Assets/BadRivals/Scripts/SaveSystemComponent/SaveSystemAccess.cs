using System;
using System.Collections.Generic;

using BadRivals.Application;

using UnityEngine;

namespace BadRivals.SaveSystem
{
	public class SaveSystemAccess : MonoBehaviour, ISaveSystemAccess
	{
		public void GetSaveList(Action<List<IMainMenuSaveData>> onSuccess)
		{
			onSuccess?.Invoke(new List<IMainMenuSaveData>());
		}
	}
}
