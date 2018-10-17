using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEndTutorial : MonoBehaviour
{

    private void Awake()
    {
        if (GetComponent<Button>())
            this.GetComponent<Button>().onClick.AddListener(delegate { TutorialManager.Instance.TutorialEnd(); });
        else
            Debug.LogWarning("Object is not a button: " + gameObject.name, gameObject);
                
    }
}
