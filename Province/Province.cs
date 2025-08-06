using System;
using UnityEngine;


namespace Entities
{
    public class Province : MonoBehaviour
    { 
        [SerializeField] private string provinceName; 
        private string countryName { get; set; }
        public float provinceIncome;
        public float provinceExpenses { get; set; }
        public float provinceManpower { get; set; }
        public float provinceTradePower { get; set; }
        [SerializeField] SpriteRenderer provinceSprite;


        public string getProvinceName()
        {
            return provinceName;
        }

        public float GetProvinceIncome()
        {
            return provinceIncome;
        }

        public float GetProvinceExpenses()
        {
            return provinceExpenses;
        }

        public float GetProvinceManpower()
        {
            return provinceManpower;
        }

        public float GetProvinceTradePower()
        {
            return provinceTradePower;
        }

        void Start()
        {
            provinceExpenses = 0;
            provinceManpower = 0;
            provinceTradePower = 7;
        }
    }
}