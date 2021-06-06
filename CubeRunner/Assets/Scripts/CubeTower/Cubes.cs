using System.Collections.Generic;
using UnityEngine;

public class Cubes
{
    private Cube _cubePrefab;
    private Transform _parent;

    private List<Cube> _spawnedCubes = new List<Cube>();

    private float GetCubeHeight => _cubePrefab.CubeHeight;

    private Cube GetLastCube => _spawnedCubes[_spawnedCubes.Count - 1];
    private Cube GetFirstCube => _spawnedCubes[0];

    private Vector3 GetLastCubePosition => GetLastCube.transform.position;

    private Vector3 GetNextCubePosition => new Vector3(_parent.position.x, GetLastCubePosition.y + GetCubeHeight, _parent.position.z);

    public Cubes(Transform parent, Cube cubePrefab)
    {
        _parent = parent;
        _cubePrefab = cubePrefab;
    }

    #region Cube Placer
    public void AddCube(int count)
    {
        Debug.Log("Add:" + count);

        for (int i = 0; i < count; i++)
        {
            AddCube();
        }
    }

    public void AddCube()
    {
        if (_spawnedCubes.Count == 0)
        {
            SpawnCube(new Vector3(_parent.position.x, _parent.position.y - GetCubeHeight, _parent.position.z));
            return;
        }

        SpawnCube(GetNextCubePosition);
    }

    private void SpawnCube(Vector3 position)
    {
        Cube cube = Object.Instantiate(_cubePrefab, position, Quaternion.identity);
        cube.transform.SetParent(_parent);

        _spawnedCubes.Add(cube);
    }
    #endregion

    #region Cube Remover
    public void RemoveCube(int count)
    {
        Debug.Log("Remove:" + count);

        for (int i = 0; i < count; i++)
        {
            RemoveCube();
        }
    }

    public void RemoveCube()
    {
        if(_spawnedCubes.Count - 1 > 0)
        {
            RemoveLastCube();
        }
    }

    private void RemoveLastCube()
    {
        Cube firstCube = GetFirstCube;

        _spawnedCubes.RemoveAt(0);
        firstCube.DeActivate();
    }
    #endregion
}
