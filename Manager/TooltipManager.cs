using UnityEngine;
using Entities;
using Entities.Core.Input;

namespace Features.Tooltip
{
    public class TooltipManager : MonoBehaviour
    {
        [Header("Tooltip Settings")]
        [SerializeField] private GameObject tooltipPrefab;
        [SerializeField] private Vector3 tooltipPosition = new Vector3(0, 4, 0); 
        [SerializeField] private TooltipTextScript tooltipText;
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
                currentTooltip.transform.position = tooltipPosition;
                SetTooltipContent(province);
                
            }
        }
        
        private void HideTooltip(Province province)
        {
            if (currentTooltip != null)
            {
                Destroy(currentTooltip);
                currentTooltip = null;
                
            }
        }
        
        private void SetTooltipContent(Province province)
        {
            if (currentTooltip == null) return;
            tooltipText.SetProvinceText(province.getProvinceName());
            
        }

        public void SetTooltipPosition(Vector3 position)
        {
            tooltipPosition = position;
        }
    }
}