using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour, ILumiObserver
{
    [Header("Referencias")]
    public LumiController lumi; 

    [Header("UI Elements")]
    public TMP_Text livesText;      
    public TMP_Text fragmentsText;  
    public TMP_Text powerUpMsg;    

    [Header("UI Elements")]
    public Image lifeBar;    
    public Sprite[] lifeBarSprites;

    void Start()
    {
        if(lumi != null)
        {
            lumi.AddObserver(this); // Patron observer

            // Estados iniciales de Lumi
            OnLifeChange(lumi.currentHealth);
            OnFragmentCount(0);
        }
    }

    void OnDestroy()
    {
        if (lumi != null) lumi.RemoveObserver(this);    // Patron observer
    }

    public void OnLifeChange(int value)
    {
        if (livesText != null)
            livesText.text = "Vidas: " + value;
        
        int spriteIndex = Mathf.CeilToInt((10 - value) / 2f);

        spriteIndex = Mathf.Clamp(spriteIndex, 0, lifeBarSprites.Length - 1);
        lifeBar.sprite = lifeBarSprites[spriteIndex];
    }

    public void OnFragmentCount(int value)
    {
        if (fragmentsText != null)
            fragmentsText.text = "Fragmentos: " + value;
    }

    public void OnPowerUp(string value)
    {
        if (powerUpMsg != null)
        {
            powerUpMsg.text = "¡Poder: " + value + "!";
            Invoke("ClearMessage", 2f);
        }
    }

    void ClearMessage()
    {
        if (powerUpMsg != null) powerUpMsg.text = "";
    }
}
