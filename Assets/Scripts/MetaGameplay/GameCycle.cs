using System;
using System.Collections;
using System.Collections.Generic;

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
}
