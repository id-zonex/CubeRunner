using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{ 
    [Header("Speed Settings")]
    [SerializeField] private float forwardSpeed = 1;
    [SerializeField] private float horizontalSpeed = 1;

    [Header("Horizontal Move Settings")]
    [SerializeField] private float offset = 2;
    [SerializeField] private int linesCount = 5;

    private int _currentLineIndex;

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
        newPosition.x = Mathf.LerpUnclamped(newPosition.x, _currentLineIndex * offset, Time.deltaTime * horizontalSpeed);
        transform.position = newPosition;
    }

    private void ChangeCurrentIndex()
    {
        if (Input.GetKeyDown(KeyCode.A))
            _currentLineIndex--;

        else if (Input.GetKeyDown(KeyCode.D))
            _currentLineIndex++;

        _currentLineIndex = Mathf.Clamp(_currentLineIndex, -(linesCount / 2), (linesCount / 2));
    }
}
 