using UnityEngine;

public class Tracker : MonoBehaviour
{
    public GameObject target;
    /*private float range = 10;*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*float this.transform.position.x;
        float this.transform.position.y;
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;


        if ((targetX - this.transform.position.x) > range)
        {
            x = targetX - range;

         else if ((targetY - this.transform.position.y) > range)
        {
            y = targetY - range;
        }


        this.transform.position = new Vector3(x, y, this.transform.position.z);*/

        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        }
}
