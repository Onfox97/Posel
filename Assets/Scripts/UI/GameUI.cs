using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI text_laps;

    void Update()
    {
        text_laps.text = "Mail delivered: "+FlagManager.Laps;
    }
}
