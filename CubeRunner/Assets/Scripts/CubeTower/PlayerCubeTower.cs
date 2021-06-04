using UnityEngine;

public class PlayerCubeTower : MonoBehaviour
{
    [SerializeField] private Cube cubePrefab;

    public Cubes cubes { get; private set; }

    private void Start()
    {
        cubes = new Cubes(transform, cubePrefab);
        cubes.AddCube();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            cubes.RemoveCube();
    }
}
