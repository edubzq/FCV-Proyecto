using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Falta hacer que la nieve "nazca" y apagar las luces al principio y al final

public class ManivelaStart : MonoBehaviour
{
    private Animator animator;
    public List<Animator> animatorsToSlowDown;
    public List<AudioSource> audioSourcesToFade;
    public List<ParticleSystem> particleSystemsToFade;
    public GameObject nieve;

    public List<Light> luces;

    public float duracionElementos = 15.0f;
    public float duracionDesaceleracion = 6.0f;
    public Animator ventana;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ventana.speed = 0;
        foreach (Animator animator in animatorsToSlowDown)
        {
            animator.enabled = false;
        }
        foreach (AudioSource audioSource in audioSourcesToFade)
        {
            audioSource.enabled = false;
        }
        foreach (ParticleSystem particleSystem in particleSystemsToFade)
        {
            particleSystem.Stop();
        }
        foreach (Light luz in luces){
            luz.enabled = false;
        }
    }

    // Update is called once per frame
    
    void Update(){

        if (animator != null){
            if(Input.GetKeyDown(KeyCode.Space)){
                 animator.SetTrigger("MouseClick");
                 activar();
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab)){
            ventana.SetTrigger("Cerrar");
        }
    }

    public void activar(){
        
        ventana.speed = 0.5f;
        nieve.SetActive(true);
        foreach (Light luz in luces){
            luz.enabled = true;
        }
        foreach (Animator animator in animatorsToSlowDown)
        {
            animator.enabled = true;
        }
         foreach (AudioSource audioSource in audioSourcesToFade)
        {
            audioSource.enabled = true;
        }
        foreach (ParticleSystem particleSystem in particleSystemsToFade)
        {
            particleSystem.Play();
        }
        
        StartCoroutine(DesacelerarYDetenerElementos());
    }


    IEnumerator DesacelerarYDetenerElementos()
    {
        // Esperar la duración total de los elementos
        yield return new WaitForSeconds(duracionElementos);

        // Desacelerar los animators
        foreach (Animator animator in animatorsToSlowDown)
        {
            StartCoroutine(DesacelerarAnimator(animator));
        }

        // Desacelerar los audio sources
        foreach (AudioSource audioSource in audioSourcesToFade)
        {
            StartCoroutine(DesacelerarAudioSource(audioSource));
        }

        // Desacelerar los sistemas de partículas
        foreach (ParticleSystem particleSystem in particleSystemsToFade)
        {
            StartCoroutine(DesacelerarParticleSystem(particleSystem));
        }
        ventana.SetTrigger("Cerrar");
        foreach (Light luz in luces){
            luz.enabled = false;
        }
    }
    IEnumerator DesacelerarAnimator(Animator animator)
    {
        float tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + duracionDesaceleracion)
        {
            float t = (Time.time - tiempoInicio) / duracionDesaceleracion;
            float nuevoFactorVelocidad = Mathf.SmoothStep(1.0f, 0.0f, t);
            foreach (Animator anim in animatorsToSlowDown)
            {
                anim.speed = nuevoFactorVelocidad;
            }
            yield return null;
        }
    }
    IEnumerator DesacelerarAudioSource(AudioSource audioSource)
    {
        float volumenInicial = audioSource.volume;
        float tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + duracionDesaceleracion)
        {
            float t = (Time.time - tiempoInicio) / duracionDesaceleracion;
            float nuevoVolumen = Mathf.Lerp(volumenInicial, 0f, t);
            audioSource.volume = nuevoVolumen;
            yield return null;
        }
    }
    IEnumerator DesacelerarParticleSystem(ParticleSystem particleSystem)
    {
        float intensidadInicial = particleSystem.emission.rateOverTimeMultiplier;
        float tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + duracionDesaceleracion)
        {
            float t = (Time.time - tiempoInicio) / duracionDesaceleracion;
            float nuevaIntensidad = Mathf.Lerp(intensidadInicial, 0f, t);
            var em = particleSystem.emission;
            em.rateOverTimeMultiplier = nuevaIntensidad;
            yield return null;
        }
    }
}
