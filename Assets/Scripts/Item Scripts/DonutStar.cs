using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutStar : item
{
    //Rigidbody2D rb;

    // Start is called before the first frame update
    public override void giveEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().movementSpeed *= 3;
    }

    public override void removeEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().movementSpeed /= 3;
    }

    public override void giveSuperEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().movementSpeed *= 6;
    }

    public override void removeSuperEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().movementSpeed /= 6;
    }

    new void Throw(GameObject gb)
    {
        base.Throw(gb);
        isThrown = true;
        removeEffect(gb);
        StartCoroutine(returnHitbox());
    }
}
