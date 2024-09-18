using UnityEngine;
using UnityEngine.UI;

namespace TestAvi.UI
{
    public class GameStartButton : MonoBehaviour
    {
        [SerializeField] private CycleTransparency _cycleTransparency;
        [SerializeField] private Button _button;
        [SerializeField] private LoadSprites _loadSprites;

        private void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _cycleTransparency.Toggle(true);
            _loadSprites.Load();

            _button.interactable = false;
        }
    }
}
