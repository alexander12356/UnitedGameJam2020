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

	public void StartGame()
	{
		LoadLevel();
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
		SceneManager.LoadScene("GameComplete");
	}

	private void LoadStore()
	{
		SceneManager.LoadScene("Store");
	}

	public void CloseStore()
	{
		LoadLevel();
	}

	private void LoadLevel()
	{
		SceneManager.LoadScene($"Level{_currentLevel}");

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
		actorData.MeleeAttackValue1 = PlayerStats.Instance.MeleeAttackValue1;
		actorData.MeleeAttackValue2 = PlayerStats.Instance.MeleeAttackValue2;
	}
}
