using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LevelText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Show();
    }

    private void Show(int value = 0)
    {
        _text.SetText($"Level {Manager.InGame.CurrentLevel + 1}");
    }
}