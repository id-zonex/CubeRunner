using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CubeBonus : CubeTower
{
    public void AddCubes(Cubes cubes)
    {
        cubes.AddCube(transform.childCount);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCubeTower playerCubeTower = other.gameObject.GetComponentInParent<PlayerCubeTower>();

        if (playerCubeTower)
            AddCubes(playerCubeTower.cubes);
    }
}
