using Entities;
using UnityEngine;
using Entities;
using Entities.Core.Input;
using UnityEngine;

public class ProvinceCollider : MonoBehaviour
{
    [Header("Province Settings")]
    [SerializeField] private bool generateColliderOnStart = true;
    [SerializeField] private Province provinceData;
    
    [Header("Double Click Settings")]
    [SerializeField] private float doubleClickTimeWindow = 0.3f;
    
    private float lastClickTime = 0f;
    private bool waitingForDoubleClick = false;

    void Start()
    {
        // Auto-find Province component if not assigned
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
    
        // Remove existing collider if it exists
        PolygonCollider2D existingCollider = GetComponent<PolygonCollider2D>();
        if (existingCollider != null)
        {
            Debug.Log($"Removing existing collider for: {provinceData.getProvinceName()}");
            if (Application.isPlaying)
                Destroy(existingCollider);
            else
                DestroyImmediate(existingCollider);
        }
    
        // Always create a new collider
        PolygonCollider2D collider = gameObject.AddComponent<PolygonCollider2D>();
    
        Debug.Log($"Province collider created for: {provinceData.getProvinceName()}");
    }
    
    // === MOUSE EVENT HANDLERS - ONLY EVENT FIRING ===
    
    void OnMouseEnter()
    {
        // Only fire event - no logic here!
        InputManager.Instance?.FireProvinceMouseEnter(provinceData);
    }

    void OnMouseExit()
    {
        // Only fire event - no logic here!
        InputManager.Instance?.FireProvinceMouseExit(provinceData);
    }
    
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            HandleLeftClick();
        }
        else if (Input.GetMouseButtonDown(1)) // Right click
        {
            InputManager.Instance?.FireProvinceRightClick(provinceData);
        }
    }
    
    void OnMouseOver()
    {
        // Continuous hover event
        InputManager.Instance?.FireProvinceHover(provinceData);
    }
    
    // Handle double click detection
    private void HandleLeftClick()
    {
        float currentTime = Time.time;
        
        if (waitingForDoubleClick && (currentTime - lastClickTime) <= doubleClickTimeWindow)
        {
            // Double click detected
            waitingForDoubleClick = false;
            InputManager.Instance?.FireProvinceDoubleClick(provinceData);
        }
        else
        {
            // Single click (might become double)
            lastClickTime = currentTime;
            waitingForDoubleClick = true;
            
            // Start coroutine to handle single click after delay
            StartCoroutine(HandleSingleClickDelayed());
        }
    }
    
    private System.Collections.IEnumerator HandleSingleClickDelayed()
    {
        yield return new WaitForSeconds(doubleClickTimeWindow);
        
        if (waitingForDoubleClick)
        {
            // It was indeed a single click
            waitingForDoubleClick = false;
            InputManager.Instance?.FireProvinceLeftClick(provinceData);
        }
    }
    
    // === UTILITY METHODS ===
    
    public void ForceGenerateCollider()
    {
        GenerateProvinceCollider();
    }
    
    public Province GetProvinceData()
    {
        return provinceData;
    }
    
    public void SetProvinceData(Province newProvinceData)
    {
        provinceData = newProvinceData;
    }
    
    // For debugging
    void OnValidate()
    {
        if (provinceData == null)
            provinceData = GetComponent<Province>();
    }
}