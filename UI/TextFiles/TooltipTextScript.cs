using Entities;
using UnityEngine;
using TMPro;

public class TooltipTextScript : MonoBehaviour
{

  
    public TMP_Text provinceText;
    
    public TMP_Text manpowerText;
    
    public TMP_Text incomeText;
    
    public TMP_Text tradeText;


    public void SetProvinceText(Province province)
    {
        provinceText.text = province.getProvinceName();
        manpowerText.text = province.GetProvinceManpower().ToString();
        incomeText.text = province.GetProvinceIncome().ToString();
        tradeText.text = province.GetProvinceTradePower().ToString();
    }
}
