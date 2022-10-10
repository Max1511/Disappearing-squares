using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CellUsing : MonoBehaviour
{
    [SerializeField] private Color _colorTargeting;

    public bool filled = false;

    private Color _colorPrevious;
    private SpriteRenderer _spriteRender;

    private void Start()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
        _colorPrevious = _spriteRender.color;
    }

    public void SetColorTargeting()
    {
        if (!filled)
            _spriteRender.color = _colorTargeting;
    }

    public void SetColorPrevious()
    {
        _spriteRender.color = _colorPrevious;
    }

    public void Filled()
    {
        filled = true;
        _spriteRender.color = _colorPrevious;
        if (tag == "Cell")
        {
            var cells = transform.GetComponentInParent(typeof(CellsRules)) as CellsRules;
            cells.CompleteGame();
            tag = "Filled cell";
        }
    }

    public void NotFilled()
    {
        filled = false;
        _spriteRender.color = _colorPrevious;
    }

    public bool IsFilled()
    {
        return filled;
    }
}
