using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonTrigger: MonoBehaviour
    {
        public delegate void ButtonTriggerEvents();
        public event ButtonTriggerEvents onClicked;

        [SerializeField]
        private Button button;
        [SerializeField]
        private Image icon;

        private void Awake()
        {
            if (button)
                button.onClick.AddListener(() => onClicked?.Invoke());
        }

        public bool state;

        public Button GetButton() => button;
        public Image GetIcon() => icon;
    }
}