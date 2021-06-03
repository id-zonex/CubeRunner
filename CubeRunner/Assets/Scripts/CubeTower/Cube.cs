using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{

    public float CubeHeight => transform.localScale.y;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void DeActivate()
    {
        transform.SetParent(null);
        _rigidbody.constraints = RigidbodyConstraints.None;
    }
}
