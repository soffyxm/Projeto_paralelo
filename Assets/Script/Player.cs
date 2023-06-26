using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float veloc ;

    public float entradaHorizontal;
    public float entradaVertical;

    public GameObject pfLaser;

    public float tempoDeDisparo = 0.3f;

    public float podeDisparar = 0.0f;
    // Start is called before the first frame update
    void Start()
    { 
       Debug.Log("Metodo Start ") ;
       transform.position = new Vector3(0,0,0) ;
    }

    // Update is called once per frame
    void Update()
    
    {
        this.Movimento();

        if (Input.GetKeyDown(KeyCode.Space)){

            if (Time.time > podeDisparar ){
            Instantiate(pfLaser,transform.position + new Vector3 (1,-2,0),Quaternion.identity);

            podeDisparar = Time.time + tempoDeDisparo ;
            }
        }
    }

    private void Disparo(){
        if ( Time.time > podeDisparar){
            Instantiate(pfLaser,transform.position + new Vector3 (0,1.1f,0),Quaternion.identity);
            podeDisparar = Time.time + tempoDeDisparo;
        }
    }
    
    private void Movimento()
    {
        float entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * entradaHorizontal *Time.deltaTime * veloc);
        if (transform.position.y > 0){
            transform.position = new Vector3(transform.position.x,0,0);
            }else if ( transform.position.y < -1.02f){
                transform.position = new Vector3(transform.position.x, -1.02f,0);
            }

        float entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * entradaVertical * Time.deltaTime * veloc);

        if (transform.position.x < -5.17f ){
            transform.position = new Vector3( -5.17f,transform.position.y,0);
        }else if ( transform.position.x < -5.17f ){
            transform.position = new Vector3(-5.17f,transform.position.y,0);
        }
    
    }
}
