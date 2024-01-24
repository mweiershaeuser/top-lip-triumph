using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBase
    {
        [SerializeField] private TextMeshProUGUI textHolder;

        [Header("Text")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private TMP_FontAsset font;

        [Header("Time")]
        [SerializeField] private float delay;

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textColor, font, delay));
        }
    }
}