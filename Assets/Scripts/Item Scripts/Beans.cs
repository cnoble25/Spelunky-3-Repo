using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beans : item
{
    public override void giveEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().jumpForce *= 2;
    }

    public override void removeEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().jumpForce /= 2;

    }

    public override void giveSuperEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().maxExtraJumps += 2;

    }
    public override void removeSuperEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().jumpForce -= 2;
    }

    new void Throw(GameObject gb)
    {
        base.Throw(gb);
        isThrown = true;
        removeEffect(gb);
        StartCoroutine(returnHitbox());
    }
}
