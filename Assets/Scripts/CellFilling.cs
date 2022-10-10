using UnityEngine;

public class CellFilling : MonoBehaviour
{
    [SerializeField] private GameObject _blockUsing;
    void Start()
    {
        GetComponent<CellUsing>().filled = true;
        _blockUsing.GetComponent<MoveBlock>().SetMoveable(false);
        tag = "Filled cell";
    }
}
