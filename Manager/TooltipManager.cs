using UnityEngine;
using Entities;
using Entities.Core.Input;

namespace Features.Tooltip
{
    public class TooltipManager : MonoBehaviour
    {
        [Header("Tooltip Settings")]
        [SerializeField] private GameObject tooltipPrefab;
        [SerializeField] private Vector3 tooltipPosition = new Vector3(0, 4, 0); // Ekranın üst ortası
        
        private GameObject currentTooltip;
        
        void OnEnable()
        {
            InputManager.OnProvinceMouseEnter += ShowTooltip;
            InputManager.OnProvinceMouseExit += HideTooltip;
        }
        
        void OnDisable()
        {
            InputManager.OnProvinceMouseEnter -= ShowTooltip;
            InputManager.OnProvinceMouseExit -= HideTooltip;
        }
        
        private void ShowTooltip(Province province)
        {
            if (province == null || currentTooltip != null) return;
            
            // Tooltip oluştur
            if (tooltipPrefab != null)
            {
                currentTooltip = Instantiate(tooltipPrefab);
                
                // Sabit pozisyona yerleştir (ekranın üst ortası)
                currentTooltip.transform.position = tooltipPosition;
                
                // İçeriği ayarla
                SetTooltipContent(province);
                
                Debug.Log($"[TooltipManager] Showing tooltip for {province.getProvinceName()}");
            }
        }
        
        private void HideTooltip(Province province)
        {
            if (currentTooltip != null)
            {
                Destroy(currentTooltip);
                currentTooltip = null;
                
                Debug.Log($"[TooltipManager] Hiding tooltip");
            }
        }
        
        private void SetTooltipContent(Province province)
        {
            if (currentTooltip == null) return;
            
            // Text componentini bul ve province ismini yaz
            var text = currentTooltip.GetComponentInChildren<UnityEngine.UI.Text>();
            if (text != null)
            {
                text.text = province.getProvinceName();
            }
            else
            {
                // TextMeshPro dene
                var tmpText = currentTooltip.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                if (tmpText != null)
                {
                    tmpText.text = province.getProvinceName();
                }
            }
        }
        
        // Tooltip pozisyonunu değiştirmek için
        public void SetTooltipPosition(Vector3 position)
        {
            tooltipPosition = position;
        }
    }
}