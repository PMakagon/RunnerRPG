using TMPro;
using UnityEngine;

namespace UI
{
    public class HitPopup : MonoBehaviour
    {
        [SerializeField] private Transform origin;
        [SerializeField] private TextMeshProUGUI hitPointsText;

        public void SetHitPoints(int points)
        {
            hitPointsText.text = points.ToString();
        }

        public void DestroyPopup()
        {
            Destroy(gameObject);
        }
    }
}