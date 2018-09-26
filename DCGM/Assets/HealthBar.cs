using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private float maxWidth;
    [Range(0,1)]
    public float normalizedCurrentWidth;
    public Image healthContentImage;

    private float currentWidth;

    private float normalizedPreviusWidth;

    public Color maxHealthColor;
    public Color minHealthColor;



    void Start () {
        RectTransform rectTransform = transform as RectTransform;
        maxWidth = rectTransform.sizeDelta.x;
        currentWidth = maxWidth;
        healthContentImage.rectTransform.sizeDelta = new Vector2(maxWidth, healthContentImage.rectTransform.sizeDelta.y);

        normalizedCurrentWidth = currentWidth / maxWidth;
        normalizedPreviusWidth = normalizedCurrentWidth;
       
           

    }
	
	// Update is called once per frame
	void Update () {
        
        if (normalizedPreviusWidth != normalizedCurrentWidth)
        {
            ChangeHealthBarWidth(normalizedCurrentWidth);
            Color interpolatedColor = InterpolateColor(normalizedCurrentWidth);
            ChangeHealthColor(interpolatedColor);

        }

            


    }

    private void ChangeHealthBarWidth(float normalizedWidth) {

        
        normalizedPreviusWidth = normalizedCurrentWidth;
        currentWidth = maxWidth* normalizedCurrentWidth;
        healthContentImage.rectTransform.sizeDelta = new Vector2(currentWidth, healthContentImage.rectTransform.sizeDelta.y);




    }
    private void ChangeHealthColor(Color color)
    {
        healthContentImage.color = color;
    }
    private Color InterpolateColor(float t )
    {
        return Color.Lerp(minHealthColor, maxHealthColor, t);
    }


}
