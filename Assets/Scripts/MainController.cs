using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public static MainController instance {get;private set;} // ENCAPSULATION 
    [SerializeField]
    private List<GameObject> players = new List<GameObject>(); // ENCAPSULATION
    [SerializeField]
    private GameObject toEnable, toDisable;  // ENCAPSULATION

    private void Start() {
        if(instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public IEnumerator Reload(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    public void Select(int index){
        players[index].SetActive(true);
        toEnable.SetActive(true);
        toDisable.SetActive(false);
    }
}
