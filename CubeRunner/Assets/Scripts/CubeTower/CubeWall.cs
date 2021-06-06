using UnityEngine;

public class CubeWall : CubeTower
{
    private bool _active = true;

    private void OnTriggerEnter(Collider other)
    {
        PlayerCubeTower playerCubeTower = other.GetComponentInParent<PlayerCubeTower>();

        if (playerCubeTower && _active)
        {
            RemoveCubes(playerCubeTower.cubes);
        }
    }

    private void RemoveCubes(Cubes cubes)
    {
        cubes.RemoveCube(transform.childCount);
        _active = false;
    }
}
