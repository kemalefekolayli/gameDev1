using UnityEngine;
using System.Collections.Generic;

namespace Entities
{
    public abstract class AbstractCountry : MonoBehaviour
    {
        [Header("Country Info")]
        [SerializeField] protected int id;
        [SerializeField] protected string nameCountry;
        [SerializeField] protected string rulerName;
        
        [Header("Resources")]
        [SerializeField] protected float manpowerCountry;
        [SerializeField] protected float moneyCountry;
        [SerializeField] protected float diplomacyCountry;
        
        [Header("Visual")]
        [SerializeField] protected SpriteRenderer countrySprite;
        [SerializeField] protected Sprite countryFlag;
        
        [SerializeField] protected List<Province> provinces;

        // Properties
        public int Id => id;
        public string NameCountry => nameCountry;
        public string RulerName => rulerName;
        public float ManpowerCountry => manpowerCountry;
        public float MoneyCountry => moneyCountry;
        public float DiplomacyCountry => diplomacyCountry;

        // Base Awake - Ortak initialization
        protected virtual void Awake()
        {
            // Ortak initialization mantığı
            if (provinces == null)
                provinces = new List<Province>();
                
            // SpriteRenderer'ı otomatik bul
            if (countrySprite == null)
                countrySprite = GetComponent<SpriteRenderer>();
                
            Debug.Log($"Base Awake called for {nameCountry}");
        }

        protected virtual void Start()
        {
            // Sprite'ı ayarla
            if (countrySprite != null && countryFlag != null)
                countrySprite.sprite = countryFlag;
        }

        public abstract void DeclareWar(AbstractCountry target);
        public abstract void SpecialAbility();
        
        public string GetCountryName()
        {return this.nameCountry; }
    }
}