using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CanvasManager : MonoBehaviour {
    public static event UnityAction pause;
    [SerializeField] private GameObject pauseMenu;
    
    private void Start() {
        GameManager.pauseGame += PauseMenuControl;
    }
    public void PauseMenuControl(bool val) {
        pauseMenu.SetActive(val);
    }

}
