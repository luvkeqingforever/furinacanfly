using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textHP_scrupt : MonoBehaviour
{
    GameObject enemy;
    int hp;
   public Text hp_viewer;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Circle");
    }

    // Update is called once per frame
    void Update()
    {
        hp = enemy.GetComponent<Enemy_status>().HP;
        hp_viewer.text = "Enemy_HP:" + hp;
    }
}
