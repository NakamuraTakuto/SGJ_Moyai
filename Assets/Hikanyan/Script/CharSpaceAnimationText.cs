using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class CharSpaceAnimationText : MonoBehaviour
{
    TextMeshProUGUI _textMeshProUGUI;
    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        Initialize();
        Play(3.5f);
    }
    void Initialize()
    {
        _textMeshProUGUI.DOFade(0, 0);
        _textMeshProUGUI.characterSpacing = -50;
    }

    void Play(float duration)
    {
        // 文字間隔を開ける
        DOTween.To(() => _textMeshProUGUI.characterSpacing, value => _textMeshProUGUI.characterSpacing = value, 10, duration)
            .SetEase(Ease.OutQuart)
            .SetLoops(-1);

        // フェード
        DOTween.Sequence()
            .Append(_textMeshProUGUI.DOFade(1, duration / 4))
            .AppendInterval(duration / 2)
            .Append(_textMeshProUGUI.DOFade(0, duration / 4))
            .SetLoops(-1);
    }
}
