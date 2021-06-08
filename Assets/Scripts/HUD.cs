using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public float hitPoints = 3f;
    public float maxHitPoints = 3f;
    public Image healthBar;
    public Image[] hearts = new Image[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = hitPoints / maxHitPoints;
        hearts[2].enabled = (hitPoints >= 3f);
        hearts[1].enabled = (hitPoints >= 2f);
        hearts[0].enabled = (hitPoints >= 1f);
    }
}
