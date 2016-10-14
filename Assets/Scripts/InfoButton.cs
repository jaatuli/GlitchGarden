using UnityEngine;
using System.Collections;

public class InfoButton : MonoBehaviour {

    private InfoPanel infoPanel;

    void Start() {
        infoPanel = GameObject.FindObjectOfType<InfoPanel>();
    }

    void OnMouseDown() {
        infoPanel.ShowInfoPanel();      
        
    }
}
