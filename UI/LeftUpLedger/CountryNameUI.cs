using System;
using Entities.UI.TextFiles;
using UnityEngine;
using Features.Tooltip.PlayerLogic;
using TMPro;

namespace Entities.UI.LeftUpLedger
{
    public class CountryNameUI : MonoBehaviour
    {
        [SerializeField] private Vector3 CountryNameUIPosition = new Vector3(0, 3, 0); 
        public PlayerManager playerManager;
        [SerializeField] private GameObject countryNameUIPrefab;
        private GameObject countryNameUI;
        
        void Awake()
        {
            
        }

        void Start()
        {
            string countryName = playerManager.GetCurrentCountry().GetCountryName();
            Debug.Log(countryName);
            CountryNameUITextScript cNUIT = countryNameUIPrefab.GetComponentInChildren<CountryNameUITextScript>();
            cNUIT.SetCountryNameText(countryName);
            countryNameUI = Instantiate(countryNameUIPrefab);
            countryNameUI.transform.position = CountryNameUIPosition;
        }
    }
}