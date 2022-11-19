using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeZumbis : MonoBehaviour
{
    public GameObject Zombie;
    float contadorTempo = 0;
    public float TempoGerarZombie = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contadorTempo += Time.deltaTime;

        if(contadorTempo >= TempoGerarZombie)
        {
            Instantiate(Zombie, transform.position, transform.rotation);
            contadorTempo = 0;
        }
    }
}
