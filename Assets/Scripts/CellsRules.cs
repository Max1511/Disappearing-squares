using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CellsRules : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cells;
    [SerializeField] private GameObject _popupPanel;
    [SerializeField] private TMP_Text _finalText;

    private List<GameObject> _savingCells = new List<GameObject>();

    private IEnumerator _waitingDisappearing;

    private int _cellInRowAmmount = 3;
    private bool _threeInRow = false;

    public void CompleteGame()
    {
        // Left - Right
        for (int i = 0; i < _cellInRowAmmount; i++)
        {
            _threeInRow = true;
            for (int j = 0; j < _cellInRowAmmount; j++)
            {
                int ij = i * _cellInRowAmmount + j;
                _savingCells.Add(_cells[ij]);
                if (!_cells[ij].GetComponent<CellUsing>().IsFilled())
                {
                    _threeInRow = false;
                    _savingCells.Clear();
                    break;
                }
            }
            if (_threeInRow)
            {
                _waitingDisappearing = AnimationWin();
                StartCoroutine(_waitingDisappearing);
                return;
            }
        }

        // Up - Down
        for (int i = 0; i < _cellInRowAmmount; i++)
        {
            _threeInRow = true;
            for (int j = 0; j < _cellInRowAmmount; j++)
            {
                int ji = j * _cellInRowAmmount + i;
                _savingCells.Add(_cells[ji]);
                if (!_cells[ji].GetComponent<CellUsing>().IsFilled())
                {
                    _threeInRow = false;
                    _savingCells.Clear();
                    break;
                }
            }
            if (_threeInRow)
            {
                _waitingDisappearing = AnimationWin();
                StartCoroutine(_waitingDisappearing);
                return;
            }
        }
        ActiveLosePopup();
    }

    private IEnumerator AnimationWin()
    {
        foreach (var cell in _savingCells)
        {
            cell.transform.GetChild(0)?.GetComponent<BlockDisappearing>().Disappear();
        }
        yield return new WaitForSeconds(1);
        ActiveWinPopup();
        _waitingDisappearing = null;
    }

    private void ActiveWinPopup()
    {
        _popupPanel.SetActive(true);
        _finalText.text = "онаедю";
    }

    private void ActiveLosePopup()
    {
        _popupPanel.SetActive(true);
        _finalText.text = "ньхайю";
    }
}
