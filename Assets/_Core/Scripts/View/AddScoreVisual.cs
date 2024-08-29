using Game.Core;
using DG.Tweening;
using UnityEngine;

public class AddScoreVisual : PoolObject
{
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    private Vector2 defaultPos;
    private RectTransform t;

    private void Awake()
    {
        t = (RectTransform)transform;
        defaultPos = t.anchoredPosition;
    }

    public void SetAmountAndStartAnim(int score)
    {
        t.DOKill();
        text.DOKill();

        text.text = "+" + score;
        text.alpha = 1;

        t.anchoredPosition = defaultPos;
        t.localScale = Vector3.zero;

        t.DOScale(Vector3.one, .25f).SetEase(Ease.OutBack);
        t.DOAnchorPos(defaultPos + Vector2.up * 250, 2f).SetEase(Ease.InOutCubic);
        text.DOFade(0, 1f).SetDelay(1f).SetEase(Ease.OutSine);
    }
}
