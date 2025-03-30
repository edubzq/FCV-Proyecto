using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarBate : StateMachineBehaviour
{
    GameObject bate;

    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bate = GameObject.FindWithTag("Bate");
        Collider bateC = bate.GetComponent<Collider>();
        Batazo bateB = bate.GetComponent<Batazo>();
        if (bateC != null)
        {
            bateB.StartAttack();
            bateC.enabled = true;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Collider bateC = bate.GetComponent<Collider>();
        Batazo bateB = bate.GetComponent<Batazo>();
        if (bateC != null)
        {
            bateB.EndAttack();
            bateC.enabled = false;
        }
    }
}
