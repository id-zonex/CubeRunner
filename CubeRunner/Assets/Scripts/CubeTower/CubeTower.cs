using UnityEngine;

[ExecuteInEditMode]
public class CubeTower : MonoBehaviour
{
    [SerializeField] protected int numberCubes = 1;
    [SerializeField] protected Cube cubePrefab;

    private Transform GetLastCube => transform.GetChild(transform.childCount - 1);

    private void Start()
    {
        if(transform.childCount != numberCubes)
            SpawnCubes();
    }

    private void SpawnCubes()
    {
        for (int i = 0; i < numberCubes; i++)
        {
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        Transform cube = Instantiate(cubePrefab.transform, GetNextCubePosition(), Quaternion.identity);
        cube.SetParent(transform);
    }

    private Vector3 GetNextCubePosition()
    {
        if (transform.childCount == 0)
            return transform.position;

        return new Vector3(transform.position.x, GetLastCube.position.y + cubePrefab.CubeHeight, transform.position.z);
    }
}
