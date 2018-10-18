using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCollision : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("lightningSpell"))
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag.Equals("waterSpell"))
        {
            Destroy(col.gameObject);

        }
    }
}
