using UnityEngine;
using Entities;
using Entities.Core.Input;

public class ProvinceCollider : MonoBehaviour
{
    [Header("Province Settings")]
    [SerializeField] private bool generateColliderOnStart = true;
    [SerializeField] private Province provinceData;

    void Start()
    {
        // Auto-find Province component
        if (provinceData == null)
            provinceData = GetComponent<Province>();
            
        if (provinceData == null)
        {
            Debug.LogError($"ProvinceCollider on {gameObject.name} has no Province component!");
            return;
        }
        
        if (generateColliderOnStart)
            GenerateProvinceCollider();
    }
    
    void GenerateProvinceCollider()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr?.sprite == null) 
        {
            Debug.LogWarning($"No sprite found for province {provinceData.getProvinceName()}");
            return;
        }
    
        // Remove existing collider
        PolygonCollider2D existingCollider = GetComponent<PolygonCollider2D>();
        if (existingCollider != null)
        {
            Debug.Log($"Removing existing collider for: {provinceData.getProvinceName()}");
            if (Application.isPlaying)
                Destroy(existingCollider);
            else
                DestroyImmediate(existingCollider);
        }
    
        // Create new collider
        PolygonCollider2D collider = gameObject.AddComponent<PolygonCollider2D>();
        Debug.Log($"Province collider created for: {provinceData.getProvinceName()}");
    }
    
    // Mouse events - sadece event fire et
    void OnMouseEnter()
    {
        InputManager.Instance?.FireProvinceMouseEnter(provinceData);
    }

    void OnMouseExit()
    {
        InputManager.Instance?.FireProvinceMouseExit(provinceData);
    }
    
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            InputManager.Instance?.FireProvinceLeftClick(provinceData);
        }
    }
}