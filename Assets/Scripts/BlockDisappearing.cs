using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BlockDisappearing : MonoBehaviour
{
    private bool _isDisappearing = false;
    private SpriteRenderer _spriteRender;

    private void Start()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    public void Disappear()
    {
        _isDisappearing = true;
    }

    private void Update()
    {
        if (_isDisappearing)
        {
            if (_spriteRender.color.a > 0)
                _spriteRender.color = new Color(_spriteRender.color.r, _spriteRender.color.g, _spriteRender.color.b, _spriteRender.color.a - 0.01f);
            else
                _isDisappearing = false;
        }
    }
}
