using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    public string mainWord ="Slay";
    public int Livecount = 10;
    public TextMeshProUGUI mainWordText;
    public TextMeshProUGUI LivecountText;
    public TextMeshProUGUI messageText;
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        mainWordText.text = mainWord;
        LivecountText.text = $"You have {Livecount} tries";
    }

    public void onClick()
    {
        Debug.Log($"Guzik klikniety");
        Livecount = Livecount - 1;
        LivecountText.text = $"You have {Livecount} tries";

        if(mainWord == inputField.text)
        {
            messageText.text = $"you found the word";
            return;
        }
        if (mainWord.Length !=inputField.text.Length)
        {
            messageText.text = $"symbol count is not correct";
            return;
        }

        int bullsCount = CountBulls();
        int cowscount = CountCows();
        messageText.text =$"Bulls: {bullsCount} and cows: {cowscount}";
     }

    public int CountBulls()
    {
        int result = 0;

        for (int i = 0; i < mainWord.Length; i++)
        {
            if (mainWord[i] == inputField.text[i])
            {
                result++;
            }
        } return result;
    }
    public int CountCows()
        {
            int result = 0;

            for (int i = 0; i < mainWord.Length; i++)
            {
                if (mainWord[i] != inputField.text[i] && mainWord.Contains(inputField.text[i]) )
                {
                result++;
                  }
            }

            return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
