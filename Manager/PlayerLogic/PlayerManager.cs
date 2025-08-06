using System;
using Entities;
using UnityEngine;

namespace Features.Tooltip.PlayerLogic
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance { get; private set; }
        [SerializeField] private AbstractCountry currentCountry;
        
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject); 
            }
            else
            {
                Destroy(gameObject); 
            }
        }
        
        public AbstractCountry GetCurrentCountry(){ return currentCountry; }

        public void SetCurrentCountry(AbstractCountry country)
        {
            currentCountry = country;
        }
        
        
    }
}