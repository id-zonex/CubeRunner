using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{ 
    [Header("Speed Settings")]
    [SerializeField] private float forwardSpeed = 1;
    [SerializeField] private float horizontalSpeed = 1;

    [Header("Horizontal Move Settings")]
    [SerializeField] private List<Vector3> lines = new List<Vector3>();

    private int _currentLineIndex;

    private void Awake()
    {
        _currentLineIndex = lines.Count / 2;
    }

    private void Update()
    {
        MoveForward();
        ControllHorizontal();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.fixedDeltaTime);
    }

    private void ControllHorizontal()
    {
        ChangeCurrentIndex();
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Lerp(newPosition.x, lines[_currentLineIndex].x, Time.deltaTime * horizontalSpeed);
        transform.position = newPosition;
    }

    private void ChangeCurrentIndex()
    {
        if (Input.GetKeyDown(KeyCode.A))
            _currentLineIndex--;

        else if (Input.GetKeyDown(KeyCode.D))
            _currentLineIndex++;

        _currentLineIndex = Mathf.Clamp(_currentLineIndex, 0, lines.Count - 1);
    }

    private void OnDrawGizmos()
    {
        foreach(Vector3 line in lines)
        {
            Gizmos.DrawLine(line, Vector3.forward * 500);
        }
    }
}
 