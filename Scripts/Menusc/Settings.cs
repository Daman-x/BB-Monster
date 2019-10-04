using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider slider;
    public AudioSource audi;
  

     void Update()
    {
        audi.volume = slider.value;
        
    }

}