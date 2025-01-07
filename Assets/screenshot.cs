using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class screenshot : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject MenuUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DelayFunction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void DelayFunction(){
        
        text3.SetActive(true);
        await Task.Delay(1000);
        text3.SetActive(false);
        text2.SetActive(true);
        await Task.Delay(1000);
        text2.SetActive(false);
        text1.SetActive(true);
        await Task.Delay(1000);
        text1.SetActive(false);
        MenuUI.SetActive(false);
        Screenshot();
        await Task.Delay(500);
        MenuUI.SetActive(true);
    }
    void Screenshot(){
        string fileName = "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        ScreenCapture.CaptureScreenshot(fileName);
        Debug.Log("Screenshot saved as: " + fileName);
    }
    public void OnClick(){

        DelayFunction();
    }
}
