using UnityEngine;
using Entities;
using Entities.Core.Input;

namespace Features.Tooltip
{
    public class TooltipManager : MonoBehaviour
    {
        [Header("Tooltip Settings")]
        [SerializeField] private GameObject tooltipPrefab;
        [SerializeField] private Vector3 tooltipOffset = Vector3.up * 0.5f;
        [SerializeField] private bool followMouse = false;
        [SerializeField] private float followSpeed = 5f;
        
        [Header("Pool Settings")]
        [SerializeField] private int poolSize = 5;
        [SerializeField] private bool usePooling = true;
        
        private GameObject[] tooltipPool;
        private GameObject currentTooltip;
        private Province currentProvince;
        private bool tooltipActive = false;
        
        void Awake()
        {
            InitializeTooltipPool();
        }
        
        void OnEnable()
        {
            // Subscribe to input events
            InputManager.OnProvinceMouseEnter += ShowTooltip;
            InputManager.OnProvinceMouseExit += HideTooltip;
        }
        
        void OnDisable()
        {
            // Unsubscribe from input events
            InputManager.OnProvinceMouseEnter -= ShowTooltip;
            InputManager.OnProvinceMouseExit -= HideTooltip;
        }
        
        void Update()
        {
            if (followMouse && tooltipActive && currentTooltip != null)
            {
                UpdateTooltipPosition();
            }
        }
        
        void InitializeTooltipPool()
        {
            if (!usePooling || tooltipPrefab == null) return;
            
            tooltipPool = new GameObject[poolSize];
            
            for (int i = 0; i < poolSize; i++)
            {
                GameObject tooltip = Instantiate(tooltipPrefab);
                tooltip.SetActive(false);
                tooltipPool[i] = tooltip;
            }
            
            Debug.Log($"[TooltipManager] Initialized pool with {poolSize} tooltips");
        }
        
        private void ShowTooltip(Province province)
        {
            if (tooltipActive || province == null) return;
            
            currentProvince = province;
            
            if (usePooling)
            {
                currentTooltip = GetPooledTooltip();
            }
            else
            {
                if (tooltipPrefab != null)
                    currentTooltip = Instantiate(tooltipPrefab);
            }
            
            if (currentTooltip != null)
            {
                SetupTooltip(province);
                currentTooltip.SetActive(true);
                tooltipActive = true;
                
                Debug.Log($"[TooltipManager] Showing tooltip for {province.getProvinceName()}");
            }
        }
        
        private void HideTooltip(Province province)
        {
            if (!tooltipActive || currentTooltip == null) return;
            
            if (usePooling)
            {
                currentTooltip.SetActive(false);
            }
            else
            {
                Destroy(currentTooltip);
            }
            
            currentTooltip = null;
            currentProvince = null;
            tooltipActive = false;
            
            Debug.Log($"[TooltipManager] Hiding tooltip for {province.getProvinceName()}");
        }
        
        
        
        private GameObject GetPooledTooltip()
        {
            if (tooltipPool == null) return null;
            
            for (int i = 0; i < tooltipPool.Length; i++)
            {
                if (tooltipPool[i] != null && !tooltipPool[i].activeInHierarchy)
                {
                    return tooltipPool[i];
                }
            }
            
            // If no pooled tooltip available, create new one
            Debug.LogWarning("[TooltipManager] No pooled tooltip available, creating new one");
            return Instantiate(tooltipPrefab);
        }
        
        // === PUBLIC METHODS ===
        
        public void SetTooltipPrefab(GameObject newPrefab)
        {
            tooltipPrefab = newPrefab;
            if (usePooling)
                InitializeTooltipPool();
        }
        

        
        public void SetTooltipOffset(Vector3 offset)
        {
            tooltipOffset = offset;
        }
        
        public bool IsTooltipActive()
        {
            return tooltipActive;
        }
        
        public Province GetCurrentProvince()
        {
            return currentProvince;
        }
        
        // Force hide current tooltip
        public void ForceHideTooltip()
        {
            if (currentProvince != null)
                HideTooltip(currentProvince);
        }
        
        // === EDITOR METHODS ===
        
        void OnValidate()
        {
            if (poolSize <= 0)
                poolSize = 1;
                
            if (followSpeed < 0)
                followSpeed = 0;
        }
    }
}