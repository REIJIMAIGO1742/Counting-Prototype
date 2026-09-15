using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool ispress = false;
    private float timeToHold;
    private Spring spring;

    public Slider slider;

    void Start()
    {
        spring = GameObject.Find("ShootPort").GetComponent<Spring>();
    
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Press");
        ispress = true;    
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Not Press");
        ispress = false;
        spring.Change(timeToHold);
        timeToHold = 0f;
        spring.Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        if (ispress)
        {
            Debug.Log("Change");
            spring.Relord();
            timeToHold += 10f;
            slider.value = timeToHold;
        }

    }
}
