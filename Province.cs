using System;
using UnityEngine;


namespace Entities
{
    public class Province : MonoBehaviour
    {
        private string provinceName { get; set; }
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