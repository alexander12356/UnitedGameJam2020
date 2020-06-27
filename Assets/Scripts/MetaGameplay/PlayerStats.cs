using UnityEngine;

namespace MetaGameplay
{
	public class PlayerStats : MonoBehaviour
	{
		public static PlayerStats Instance = null;

		public int CurrentHP1;
		public int CurrentHP2;
		public int CurrentAttackValue1;
		public int CurrentAttackValue2;
		public int MaxHP1;
		public int MaxHP2;
		public int Coins;

		private void Awake()
		{
			Instance = this;
				
			DontDestroyOnLoad(gameObject);
		}

		public void Heal1()
		{
			CurrentHP1 = MaxHP1;
		}

		public void Heal2()
		{
			CurrentHP2 = MaxHP2;
		}
	}
}