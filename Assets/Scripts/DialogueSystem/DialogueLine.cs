using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBase
    {

        [Header("Text")]
        [SerializeField] private string input;
        [SerializeField] private TextMeshProUGUI textHolder;
        [SerializeField] private Color textColor;
        [SerializeField] private TMP_FontAsset font;

        [Header("Time")]
        [SerializeField] private float delay;

        [Header("Avatar")]
        [SerializeField] private Sprite sprite;
        [SerializeField] private Image imgHolder;

        private void Awake()
        {
            textHolder.text = "";
            imgHolder.sprite = sprite;
            imgHolder.preserveAspect = true;
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textColor, font, delay));
        }
    }
}