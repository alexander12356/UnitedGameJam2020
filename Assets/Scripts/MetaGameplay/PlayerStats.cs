using UnityEngine;

namespace MetaGameplay
{
	public class PlayerStats : MonoBehaviour
	{
		public static PlayerStats Instance = null;

		public int CurrentHP1;
		public int CurrentHP2;
		public int MeleeAttackValue1;
		public int MeleeAttackValue2;
		public int RangeAttackValue1;
		public int RangeAttackValue2;
		public int MaxHP1;
		public int MaxHP2;
		public int Coins;
		public int HealStage1 = 1;
		public int HealStage2 = 1;
		public int MaxHPStage1 = 1;
		public int MaxHPStage2 = 1;
		public int MeleeAttackStage1 = 1;
		public int MeleeAttackStage2 = 1;
		public int RangeAttackStage1 = 1;
		public int RangeAttackStage2 = 1;

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