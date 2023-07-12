using UnityEngine;
using DG.Tweening;
public class UpDown : MonoBehaviour
{
    public enum Mode{Auto, Trigger}
    public enum Direction { Up, Down }
    
    public float moveRange = 5f;
    public float duration = 4f;
    public Mode mode = Mode.Auto;
    public Direction direction = Direction.Up;
    private Vector3 _initialPosition;
    private float _targetY;
    private Tweener myTweener;
    private void Start()
    {
        if (direction == Direction.Up)
        {
            _initialPosition = transform.position;
            _targetY = _initialPosition.y + moveRange;
        }
        else if(direction == Direction.Down)
        {
            transform.position = transform.position + new Vector3(0, 5, 0);
            _initialPosition = transform.position;
            _targetY = _initialPosition.y - moveRange;
        }
        // Bắt đầu di chuyển liên tục
        // Di chuyển đối tượng lên và xuống trong phạm vi với tùy chọn Loop và Yoyo
        myTweener = transform.DOMoveY(_targetY, duration)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
        if (mode == Mode.Auto)
        {
            ContinuousMoving();
        }else if (mode == Mode.Trigger)
        {
            PauseMoving();
        }
    }

    public void ContinuousMoving()
    {
        myTweener.Play();
    }
    public void PauseMoving()
    {
        myTweener.Pause();
    }
}
