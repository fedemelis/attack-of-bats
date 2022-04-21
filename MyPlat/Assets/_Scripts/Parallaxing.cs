using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{

    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing = 1f;
    private Transform cam;
    private Vector3 lastCamPos;

    void Awake()
    {
        //inizializzazione camera
        cam = Camera.main.transform;
    }

    void Start()
    {
        //salvo la posizione della camera
        lastCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        //ogni background ha la sua parallaxScale
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            //l'array parallaxScales contiene valori con segno invertito
            float parallax = (lastCamPos.x - cam.position.x) * parallaxScales[i];

            //creo la nuova posizione del mio background nell'asse delle x
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //uso una variabile vector3 per settare la posizione del mio background
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //utilizzo il metodo lerp che aggiungie un effetto fade durante lo spostamento dello sfondo 
            //deltatime converte i frame del metodo update in secondi
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //esco dal ciclo che assegna la imposta i valori di posizione della mia camera e salvo ora la nuova posizione sovrascrivendo quella salvata in precedenza nel metodo start
        lastCamPos = cam.position;
    }
}
