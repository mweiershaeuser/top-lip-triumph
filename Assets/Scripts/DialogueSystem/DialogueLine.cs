using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBase
    {
        [Header("Name")]
        [SerializeField] private string characterName;
        [SerializeField] private TextMeshProUGUI nameHolder;

        [Header("Avatar")]
        [SerializeField] private Sprite sprite;
        [SerializeField] private Image imgHolder;

        [Header("Text")]
        [SerializeField] private string input;
        [SerializeField] private TextMeshProUGUI textHolder;
        [SerializeField] private Color textColor;
        [SerializeField] private TMP_FontAsset font;
        [SerializeField] private float fontSize;

        [Header("Time")]
        [SerializeField] private float delay;

        private void Awake()
        {
            textHolder.text = "";

            nameHolder.text = characterName;

            imgHolder.sprite = sprite;
            imgHolder.preserveAspect = true;
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textColor, font, fontSize, delay));
        }
    }
}