
using UnityEngine;
using UnityEngine.UI;

public class PanelEnable : MonoBehaviour {

    public Canvas canvas;
    public Canvas c;
    public Button S;

	void Start ()
    {
        canvas = canvas.GetComponent<Canvas>();
        c = c.GetComponent<Canvas>();
        S = S.GetComponent<Button>();
        canvas.enabled = false;
	}

    public void survival()
    {
        canvas.enabled = true;
        c.enabled = false;


    }
    public void backing()
    {
        canvas.enabled = false;
        c.enabled = true;
    }
}
