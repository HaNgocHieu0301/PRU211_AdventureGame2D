using UnityEngine;
using DG.Tweening;
public class UpDown : MonoBehaviour
{
    public enum Direction { Up, Down }
    
    public float moveRange = 5f;
    public float duration = 4f;
    public Direction direction = Direction.Up;
    
    private Vector3 _initialPosition;
    private float _targetY;
    private void Start()
    {
        if (direction == Direction.Up)
        {
            _initialPosition = transform.position;
            _targetY = _initialPosition.y + moveRange;
        }
        else if(direction == Direction.Down)
        {
            Debug.LogError("before: " + transform.position);
            transform.position = transform.position + new Vector3(0, 5, 0);
            _initialPosition = transform.position;
            _targetY = _initialPosition.y - moveRange;
            Debug.LogError("late: " + transform.position);
        }
        // Bắt đầu di chuyển liên tục
        StartContinuousMovement();
    }

    private void StartContinuousMovement()
    {
        // Di chuyển đối tượng lên và xuống trong phạm vi với tùy chọn Loop và Yoyo
        transform.DOMoveY(_targetY, duration)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
