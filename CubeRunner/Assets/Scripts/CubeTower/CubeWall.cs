using UnityEngine;

public class CubeWall : CubeTower
{
    private bool _active = true;

    public void RemoveCubes(Cubes cubes)
    {
        if (_active)
            cubes.RemoveCube(transform.childCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCubeTower playerCubeTower = other.GetComponentInParent<PlayerCubeTower>();

        if (playerCubeTower)
        {
            RemoveCubes(playerCubeTower.cubes);
            _active = false;
        }

    }
}
