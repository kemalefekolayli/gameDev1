using UnityEngine;

namespace Entities.Core.Input
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }
        
        [Header("Debug")]
        [SerializeField] private bool debugMode = false;
        
        // Basit events - sadece 3 tane
        public static event System.Action<Entities.Province> OnProvinceMouseEnter;
        public static event System.Action<Entities.Province> OnProvinceMouseExit;
        public static event System.Action<Entities.Province> OnProvinceLeftClick;
        
        void Awake()
        {
            // Singleton
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        // Event firing methods
        public void FireProvinceMouseEnter(Entities.Province province)
        {
            if (debugMode)
                Debug.Log($"[InputManager] Mouse Enter: {province?.getProvinceName()}");
                
            OnProvinceMouseEnter?.Invoke(province);
        }
        
        public void FireProvinceMouseExit(Entities.Province province)
        {
            if (debugMode)
                Debug.Log($"[InputManager] Mouse Exit: {province?.getProvinceName()}");
                
            OnProvinceMouseExit?.Invoke(province);
        }
        
        public void FireProvinceLeftClick(Entities.Province province)
        {
            if (debugMode)
                Debug.Log($"[InputManager] Left Click: {province?.getProvinceName()}");
                
            OnProvinceLeftClick?.Invoke(province);
        }
        
        // Mouse world position helper

        
        // Debug info
        public void SetDebugMode(bool enabled)
        {
            debugMode = enabled;
        }
    }
}