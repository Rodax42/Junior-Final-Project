using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> players = new List<GameObject>();
    [SerializeField]
    GameObject toEnable, toDisable;
    public void Select(int index){
        players[index].SetActive(true);
        toEnable.SetActive(true);
        toDisable.SetActive(false);
    }
}
