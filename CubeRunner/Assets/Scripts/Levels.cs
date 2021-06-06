using System;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public Action End;
    public static Levels Instanse { get; private set; }

    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    [Header("≈то поле должно быть none дл€ нормальной работы")]
    [Header("”казывай здесь левел который тестиш")]
    [Header("// DEBUG!! //")]
    [SerializeField] private GameObject DebugLevel;

    private const string CURRENT_INDEX_NAME = "CurrentLevel";

    private int _currentLevelIndex
    {
        get
        {
            int index = PlayerPrefs.GetInt(CURRENT_INDEX_NAME);

            return Mathf.Clamp(index, 0, levels.Count - 1);
        }

        set
        {
            if (value > levels.Count - 1) End?.Invoke();

            int index = Mathf.Clamp(value, 0, levels.Count - 1);

            PlayerPrefs.SetInt(CURRENT_INDEX_NAME, index);
        }
    }

    private GameObject _currentSpawnedLevel;

    private void Start()
    {
        Instanse = this;

        if (DebugLevel)
        {
            LoadLevel(DebugLevel);
            return;
        }

        LoadCurrentLevel();
    }

    [EditorButton("Clear (ќчищает количество уровней)")]
    public void Clear()
    {
        PlayerPrefs.DeleteKey(CURRENT_INDEX_NAME);
    }

    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        LoadCurrentLevel();
    }

    public void LoadCurrentLevel()
    {
        LoadLevel(levels[_currentLevelIndex]);
    }

    private void LoadLevel(GameObject levelPrefab)
    {
        DestroyCurrentLevel();
        SpawnLevel(levelPrefab);
    }

    private void SpawnLevel(GameObject levelPrefab)
    {
        _currentSpawnedLevel = Instantiate(levelPrefab);
    }

    private void DestroyCurrentLevel()
    {
        if (_currentSpawnedLevel)
            Destroy(_currentSpawnedLevel);
    }
}
