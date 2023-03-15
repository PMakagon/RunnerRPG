using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private Image sliderFill;
        [SerializeField] private TextMeshProUGUI valueText;

        public void UpdateHealthBar(int maxHp,int currentHP)
        {
            valueText.text = currentHP.ToString();
            slider.maxValue = maxHp;
            slider.value = currentHP;
        }
        
    }
}