using System;
using UnityEngine;


namespace Entities
{
    public class Province : MonoBehaviour
    { 
        [SerializeField] private string provinceName; 
        private string countryName { get; set; }
        private float provinceIncome { get; set; }
        private float provinceExpenses { get; set; }
        private float provinceManpower { get; set; }
        [SerializeField] SpriteRenderer provinceSprite;


        public string getProvinceName()
        {
            return provinceName;
        }

        
    
    }
}