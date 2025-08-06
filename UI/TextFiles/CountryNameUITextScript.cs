using UnityEngine;
using TMPro;

namespace Entities.UI.TextFiles
{
    public class CountryNameUITextScript : MonoBehaviour
    {
          
    public TMP_Text CountryNameText;


    public void SetCountryNameText(string CountryName)
    {
        CountryNameText.text = CountryName;
    }
    }
}