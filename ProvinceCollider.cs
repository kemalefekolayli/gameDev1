using Entities;
using UnityEngine;

public class ProvinceCollider : MonoBehaviour
{
    [Header("Province Settings")]
    [SerializeField] private int provinceId;
    [SerializeField] private string provinceName;
    [SerializeField] private bool generateColliderOnStart = true;
    
   
    private GameObject tooltipPrefab => ProvinceInfo.Instance.TooltipPrefab;

    void Start()
    {
        if (generateColliderOnStart)
            GenerateProvinceCollider();
        
        
    }
    
    void GenerateProvinceCollider()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr?.sprite == null) return;
    
        // Remove existing collider if it exists
        PolygonCollider2D existingCollider = GetComponent<PolygonCollider2D>();
        if (existingCollider != null)
        {
            Debug.Log($"Removing existing collider for: {provinceName}");
            if (Application.isPlaying)
                Destroy(existingCollider);
            else
                DestroyImmediate(existingCollider); // For editor mode
        }
    
        // Always create a new collider
        PolygonCollider2D collider = gameObject.AddComponent<PolygonCollider2D>();
    
        // Debug collider info
        Debug.Log($"Province collider created for: {provinceName}");
        Debug.Log($"Collider bounds: {collider.bounds}");
        Debug.Log($"Collider enabled: {collider.enabled}");
        Debug.Log($"GameObject layer: {gameObject.layer}");
    }
    
    void OnMouseDown()
    {
        Debug.Log($"Clicked on province: ");
        // Province selection logic
    }
    
    private GameObject activeTooltip; // Aktif tooltip referansı

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
    
        // Tooltip oluştur
        if (ProvinceInfo.Instance != null && activeTooltip == null)
        {
            activeTooltip = Instantiate(ProvinceInfo.Instance.TooltipPrefab);
        
            // Mouse pozisyonuna yerleştir
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            activeTooltip.transform.position = mouseWorldPos + Vector3.up * 0.5f; // Biraz yukarıda
        }
        
        
        
        
        
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    
        // Tooltip'i yok et
        if (activeTooltip != null)
        {
            Destroy(activeTooltip);
            activeTooltip = null;
        }
    }
}