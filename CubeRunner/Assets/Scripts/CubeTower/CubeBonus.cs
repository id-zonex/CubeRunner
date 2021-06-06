using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CubeBonus : CubeTower
{
    private bool _active = true;

    public void AddCubes(Cubes cubes)
    {
        cubes.AddCube(transform.childCount);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCubeTower playerCubeTower = other.gameObject.GetComponentInParent<PlayerCubeTower>();

        if (playerCubeTower && _active)
        {
            AddCubes(playerCubeTower.cubes);
            _active = false;
        }
    }
}
