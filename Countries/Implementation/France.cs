using UnityEngine;

namespace Entities.Implementation
{
    public class France : AbstractCountry
    {
        [SerializeField] private string customRulerName = "Louis XIV";

        protected override void Awake()
        {
            
            base.Awake();
            
           
            id = 1;
            nameCountry = "France";
            rulerName = string.IsNullOrEmpty(customRulerName) ? "Louis XIV" : customRulerName;
            manpowerCountry = 50000f;
            moneyCountry = 1000f;
            diplomacyCountry = 8f;
            
            Debug.Log($"France initialized: {nameCountry} ruled by {rulerName}");
        }

        public override void DeclareWar(AbstractCountry target)
        {
            Debug.Log($"{rulerName} of {nameCountry} declares war on {target.NameCountry}!");
        }

        public override void SpecialAbility()
        {
            moneyCountry += 150f;
            Debug.Log($"Vive la France! Cultural influence bonus! Treasury: {moneyCountry}");
        }
    }
}