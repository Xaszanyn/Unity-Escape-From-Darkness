using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject start;
    public GameObject levels;
    public bool state;
    public void ToggleMenu() {
        start.SetActive(state);
        levels.SetActive(!state);

        state = !state;
    }
}
