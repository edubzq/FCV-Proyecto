using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giraCamara : MonoBehaviour
{
    public GameObject bola, dibujoFuerza;
    public float vg, vg2, g, factorFuerza;
    public controlJuego gestor;
    public Camera cam;
    public bool girando=false, moviendo=false, dandoFuerza=false;

    Rigidbody rb;  //el rigidbody de la bola
    float fDisparo = 5.0f;
    bool controlVel=false;
    Ray rayo;
    RaycastHit hit;
    float y,z, ang, ang2, t;
    Vector3 P, Q, dir, F,pos;
    // Start is called before the first frame update
    void Start()
    {
        rb=bola.GetComponent<Rigidbody>();
        cam=GetComponent<Camera>();
        y=transform.position.y;
        z=transform.position.z-bola.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        if(! moviendo & Input.GetMouseButtonDown(0)){
            rayo=cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(rayo,out hit)){
                if(! (hit.collider.gameObject.tag=="bola")){
                    girando=true;
                }
                else{
                    
                    dandoFuerza=true;
                    dibujoFuerza.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled=true;
                }
            }
            else{
                girando=true;
            }

        }
        // Si suelto el raton dejo de girar o de coger la fuerza
        if(Input.GetMouseButtonUp(0)){
            if(girando){
                girando=false;
            }
            if(dandoFuerza){
                rb.AddForce(F * fDisparo, ForceMode.Impulse);
                moviendo = true;
                dandoFuerza =false;
                dibujoFuerza.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled=false;
            }
        }

        // Si pulso escape cancelo dar fuerza
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(dandoFuerza){
                dandoFuerza=false;
                dibujoFuerza.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled=false;
            }
        }

        // Giro de la camara si estoy girando
        if(girando){
            ang=Input.GetAxis("Mouse X")*vg*Time.deltaTime;
            transform.RotateAround(bola.transform.position, Vector3.up, ang);
            ang2=Input.GetAxis("Mouse Y")*vg2*Time.deltaTime;
            Vector3 u=bola.transform.position-transform.position;
            u=new Vector3(-u.z,0,u.x);
            u=u.normalized;
            transform.RotateAround(bola.transform.position, u, ang2);
            transform.LookAt(bola.transform.position);
        }

        // Dibujar la flecha de fuerza entre la bola y donde estoy pulsando
        if(dandoFuerza){
            
            Q =bola.transform.position;
            rayo=cam.ScreenPointToRay(Input.mousePosition);
            P=rayo.origin;
            dir=rayo.direction;
            t=(Q.y-P.y)/dir.y;
            P=P+t*dir;
            P=new Vector3(P.x,0,P.z);
            Q=new Vector3(Q.x,0,Q.z);

            dibujoFuerza.transform.position=0.5f*(P+Q);
            dibujoFuerza.transform.LookAt(Q);
            dibujoFuerza.transform.localScale=new Vector3(g*(Q-P).magnitude,0.01f,(Q-P).magnitude);
            F=Q-P;
        }

       
    }

    // Algoritmo de camara para seguir a la bola
    void FixedUpdate(){
        if(moviendo){
            
            pos=bola.transform.position;
            pos-=z*(rb.velocity.normalized);
            pos=new Vector3(pos.x,y,pos.z);
            transform.position=Vector3.Lerp(transform.position,pos,0.02f);
            Quaternion q=Quaternion.LookRotation(bola.transform.position-transform.position,Vector3.up);
            transform.rotation=Quaternion.Lerp(transform.rotation,q,0.6f);
            if(controlVel & rb.velocity.magnitude<0.1f){
                rb.velocity=Vector3.zero;
                rb.angularVelocity=Vector3.zero;
                moviendo=false;
                controlVel=false;
            }
        }

    }

   

}
