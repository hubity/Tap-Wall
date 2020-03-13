using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateMore : MonoBehaviour
{

    public void Rate(){
        Application.OpenURL("");
    }
    public void More(){
        Application.OpenURL("");
    }
    public void Feedback(){
        Application.OpenURL("mailto:felipdanylo@gmail.com");
    }

}
