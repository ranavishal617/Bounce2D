using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            BollControler.SavePosition(transform.position);
            GameAudio.GameAudio_.PlayShot("CheckPoint");
            Instantiate(PefebStorage.Pefeb.PefebReturn("Point"), transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
