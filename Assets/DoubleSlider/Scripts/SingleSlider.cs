#region Includes
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
#endregion

namespace TS.DoubleSlider
{
    [RequireComponent(typeof(Slider))]
    public class SingleSlider : MonoBehaviour
    {
        #region Variables

        [Header("References")]
        [SerializeField] private Label _label;

        private Slider _slider;

        public bool IsEnabled
        {
            get { return _slider.interactable; }
            set { _slider.interactable = value; }

        }
        public float Value
        {
            get { return _slider.value; }
            set
            {
                _slider.value = value;
                _slider.onValueChanged.Invoke(_slider.value);

                UpdateLabel();
            }
        }
        public bool WholeNumbers
        {
            get { return _slider.wholeNumbers; }
            set { _slider.wholeNumbers = value; }
        }

        #endregion

        private void Awake()
        {
            if (!TryGetComponent<Slider>(out _slider))
            {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
                Debug.LogError("Missing Slider Component");
#endif
            }
        }

        public void Setup(float value, float minValue, float maxValue, UnityAction<float> valueChanged)
        {
            _slider.minValue = minValue;
            _slider.maxValue = maxValue;

            _slider.value = value;
            _slider.onValueChanged.AddListener(Slider_OnValueChanged);
            _slider.onValueChanged.AddListener(valueChanged);
        }

        private void Slider_OnValueChanged(float arg0)
        {
            UpdateLabel();
        }

        protected virtual void UpdateLabel()
        {
            if (_label == null) { return; }
            int numberValue = (int)Value;

            string numberStr = numberValue.ToString("D6");

            // ���ѥX�~�B��B��
            int year = 2000 + int.Parse(numberStr.Substring(0, 2)); // �e���O�~ (���]�O2000�~�H��)
            int month = int.Parse(numberStr.Substring(2, 2));       // �������O��
            int day = int.Parse(numberStr.Substring(4, 2));         // �̫���O��

            string date = $"{year}�~{month}��{day}��";


            _label.Text = date;
        }
    }
}