using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClearWindow : MonoBehaviour
{
    RectTransform Rect;

    public int isGameClear;

    public int isTimer;

    public int isButton;

    Text text;

    public int a;

    public int minute;
    public int second;

    // Start is called before the first frame update
    void Start()
    {
        if (isTimer == 1)
        {
            text = GetComponent<Text>();
        }
        Rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimer == 0)
        {
            if (isButton == 0)
            {
                switch (isGameClear)
                {
                    case 0:
                        Rect.anchoredPosition = new Vector3(0, 1200, 0);
                        break;
                    case 1:
                        Time.timeScale = 0;
                        if (a == 0)
                        {
                            SoundManager.Instance.Play("Clear");
                            a++;
                        }
                        Rect.anchoredPosition = new Vector3(0, 0, 0);
                        break;
                }
            }
        }
        else if (isTimer == 1)
        {
            Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
            minute = timer.CurTime / 60;
            second = timer.CurTime % 60;
            text.text = "�ҿ� �ð�:" + minute.ToString() + ":" + second.ToString();
        }
    }

    public void ClearBack()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
}
