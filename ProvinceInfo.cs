using UnityEngine;

namespace Entities
{
    public class ProvinceInfo : MonoBehaviour
    {
        public static ProvinceInfo Instance { get; private set; }
        
        [SerializeField] private GameObject tooltipPrefab;
        public GameObject TooltipPrefab => tooltipPrefab;
        
        void Awake()
        {
            Instance = this;
        }
    }
}