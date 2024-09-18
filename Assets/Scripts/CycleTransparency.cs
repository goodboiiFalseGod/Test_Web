using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestAvi.UI
{
    public class CycleTransparency : MonoBehaviour
    {
        [SerializeField] private Image _buttonImage;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _animationSpeed;
        private bool _state;
        private bool _switch;

        private Color _buttonColor;
        private Color _textColor;
        
        public void Toggle(bool state)
        {
            _state = state;
            _buttonColor = _buttonImage.color;
            _textColor = _text.color;
            StartCoroutine(CycleColor());
        }

        private IEnumerator CycleColor()
        {
            while (_state)
            {
                float delta = Time.deltaTime * _animationSpeed * (_switch ? 1 : -1);

                _buttonColor.a += delta;
                _textColor.a += delta;

                _buttonImage.color = _buttonColor;
                _text.color = _textColor;

                if (_buttonColor.a <= 0f || _buttonColor.a >= 1f)
                    _switch = !_switch;

                yield return null;
            }
        }
    }
}