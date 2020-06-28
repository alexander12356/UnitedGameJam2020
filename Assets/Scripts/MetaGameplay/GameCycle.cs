using System;
using System.Collections;
using System.Collections.Generic;

using BR;

using MetaGameplay;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCycle : MonoBehaviour
{
	public static GameCycle Instance;

	private int _currentLevel = 0;
	[SerializeField] private int _maxLevel = 0;

	private void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void Start()
	{
		SceneManager.LoadScene("Main");
	}

	public void StartGame()
	{
		LoadLevel(0);
	}

	public void LevelComplete()
	{
		_currentLevel++;

		if (_currentLevel > _maxLevel)
		{
			CompleteGame();
		}
		else
		{
			LoadStore();
		}
	}

	private void CompleteGame()
	{
		var result = 0;

		if (PlayerStats.Instance.MaxHP1 > PlayerStats.Instance.MaxHP2)
		{
			result++;
		}
		else if (PlayerStats.Instance.MaxHP1 < PlayerStats.Instance.MaxHP2)
		{
			result--;
		}
		
		if (PlayerStats.Instance.MeleeAttackValue1 > PlayerStats.Instance.MeleeAttackValue2)
		{
			result++;
		}
		else if (PlayerStats.Instance.MeleeAttackValue1 < PlayerStats.Instance.MeleeAttackValue2)
		{
			result--;
		}

		if (PlayerStats.Instance.RangeAttackValue1 > PlayerStats.Instance.RangeAttackValue2)
		{
			result++;
		}
		else if (PlayerStats.Instance.RangeAttackValue1 < PlayerStats.Instance.RangeAttackValue2)
		{
			result--;
		}

		if (result > 0)
		{
			SceneManager.LoadScene("GameComplete1");
		}
		else if (result < 0)
		{
			SceneManager.LoadScene("GameComplete2");
		}
		else
		{
			SceneManager.LoadScene("GameComplete3");
		}
		
	}

	private void LoadStore()
	{
		SceneManager.LoadScene("Store");
	}

	public void CloseStore(int type)
	{
		LoadLevel(type);
	}

	private void LoadLevel(int type)
	{
		if (type == 0)
		{
			SceneManager.LoadScene($"Level{_currentLevel}p");
		}
		else
		{
			SceneManager.LoadScene($"Level{_currentLevel}s");
		}
	}
	
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (!scene.name.Contains("Level"))
		{
			return;
		}

		var actorData = PlayerActor.Instance.Data;
		actorData._currentHP1 = PlayerStats.Instance.CurrentHP1;
		actorData._currentHP2 = PlayerStats.Instance.CurrentHP2;
		actorData._maxHP1 = PlayerStats.Instance.MaxHP1;
		actorData._maxHP2 = PlayerStats.Instance.MaxHP2;
		actorData.MeleeAttackValue1 = PlayerStats.Instance.MeleeAttackValue1;
		actorData.MeleeAttackValue2 = PlayerStats.Instance.MeleeAttackValue2;
		actorData.RangeAttackValue1 = PlayerStats.Instance.RangeAttackValue1;
		actorData.RangeAttackValue2 = PlayerStats.Instance.RangeAttackValue2;
	}

	public void PlayerDead()
	{
		Invoke(nameof(LoadMainMenu), 3f);
	}

	public void LoadFirstTime()
	{
	}

	private void LoadMainMenu()
	{
		_currentLevel = 1;
		SceneManager.LoadScene("Main");

		PlayerStats.Instance.CurrentHP1 = 10;
		PlayerStats.Instance.CurrentHP2 = 10;
		PlayerStats.Instance.MaxHP1 = 10;
		PlayerStats.Instance.MaxHP2 = 10;
		PlayerStats.Instance.MeleeAttackValue1 = 2;
		PlayerStats.Instance.MeleeAttackValue2 = 2;
		PlayerStats.Instance.RangeAttackValue1 = 4;
		PlayerStats.Instance.RangeAttackValue2 = 4;
		PlayerStats.Instance.Coins = 0;
	}
}
