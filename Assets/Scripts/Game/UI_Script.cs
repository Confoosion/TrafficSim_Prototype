using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    public static UI_Script instance;
    void Awake()
    {
        instance = this;
    }
    public TMP_Text jumpsText;
    public Slider jumpsCooldown;
    public TMP_Text multiplier;
    public TMP_Text speed;
    public Slider shieldDuration;
}
