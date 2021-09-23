using System.Globalization;
using TMPro;
using UnityEngine;

namespace FG
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Updatetextwithintvalue : MonoBehaviour
    {
        private TextMeshProUGUI text;

        public void Settext(int val)
        {
            text.text = val.ToString(CultureInfo.InvariantCulture);
        }

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }
    }
}