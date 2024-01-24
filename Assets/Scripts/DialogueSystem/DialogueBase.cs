using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueBase : MonoBehaviour
    {
        public bool finished { get; private set; }

        protected IEnumerator WriteText(string input, TextMeshProUGUI textHolder, Color textColor, TMP_FontAsset font, float delay)
        {
            textHolder.color = textColor;
            textHolder.font = font;

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                AudioManager.global.PlaySFX("typing");
                yield return new WaitForSeconds(delay);
            }

            finished = true;
        }
    }
}
