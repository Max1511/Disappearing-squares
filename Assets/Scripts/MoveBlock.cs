using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBlock : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject? CellConnected = null;

    public bool _moveable = true;

    private bool _isPoket = false;
    private bool _foundNewPosition = false;

    private Vector3 _positionPrevious;
    private Vector3 _newPosition;

    public GameObject? Cell { get; private set; }

    public void OnDrag(PointerEventData eventData)
    {
        if (_moveable)
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = transform.position.z;
            transform.position = position;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cell" || other.gameObject.tag == "Poket")
        {
            GameObject cellCurrent = other.gameObject;
            var cellPosition = new Vector2(cellCurrent.transform.position.x, cellCurrent.transform.position.y);
            var blockPosition = new Vector2(transform.position.x, transform.position.y);
            if (Vector2.Distance(cellPosition, blockPosition) < 0.5f)
            {
                Cell?.GetComponent<CellUsing>().SetColorPrevious();
                Cell = cellCurrent;
                Cell.GetComponent<CellUsing>().SetColorTargeting();
                _newPosition = new Vector3(Cell.transform.position.x, Cell.transform.position.y, transform.position.z);
                _foundNewPosition = true;

                if (cellCurrent.tag == "Poket")
                    _isPoket = true;
                else
                    _isPoket = false;
            }
            else
            {
                cellCurrent.GetComponent<CellUsing>().SetColorPrevious();
                _foundNewPosition = false;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _positionPrevious = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_foundNewPosition)
        {
            if (!_isPoket)
            {
                transform.SetParent(Cell.transform);
                _moveable = false;
            }

            Cell?.GetComponent<CellUsing>().Filled();
            if (CellConnected != null)
                CellConnected.GetComponent<CellUsing>().NotFilled();
            CellConnected = Cell;
            transform.position = _newPosition;

            if (_isPoket)
            {
                PlayerPrefs.SetFloat("BlockPosX", transform.position.x);
                PlayerPrefs.SetFloat("BlockPosY", transform.position.y);
            }
        }
        else
        {
            Cell?.GetComponent<CellUsing>().SetColorPrevious();
            transform.position = _positionPrevious;
        }
    }

    public void SetMoveable(bool moveable)
    {
        _moveable = moveable;
    }
}
