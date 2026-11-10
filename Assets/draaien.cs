using UnityEngine;

public class draaien : MonoBehaviour
{
       [SerializeField] private float snelheid = 1000f;
       [SerializeField] private int HP = 500;
       Vector3 spawn = new Vector3(0, 5, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("HELP ME MAKE IT STOP");
        Debug.Log(snelheid);
        
    }

    // Update is called once per frame
    void Update()
    {
        spinning();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "kill" && other.gameObject != null)
        {
            if (HP == 0) {
               Destroy(gameObject);
                Debug.Log("OUCHIE!"); 
            } else
            {
                Revive();
                
            }
            
        }
    }
    void spinning()
    {
        transform.Rotate(new Vector3(0, snelheid* Time.deltaTime, 0));        
    }
    void Revive()
    {
        HP -= 1;
        transform.position = spawn;
    }
}
