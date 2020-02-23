using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEditor;

public class ExtendedAudioSource : MonoBehaviour {

    [HideInInspector]
    public AudioSource source;
    private Coroutine inst;

    private bool usingPlaylist;
    public bool playIntroOnAwake;
    public bool playPlaylistOnAwake;
    public bool loopPlaylist;
    [Space(10)]
    public AudioClip introClip;
    public AudioClip loopingClip;

    [Space(10)]
    public PlaylistObject playlist;
    private int currentSong;

    public void Awake()
    {
        source = GetComponent<AudioSource>();

        if (playPlaylistOnAwake)
        {
            PlayFromPlaylist();
        }
        if (playIntroOnAwake)
        {
            PlayIntroFirst(introClip, loopingClip);
        }
    }

    [ExecuteInEditMode]
    public void Start () {

        if(source == null)
        {
            Debug.LogWarning("Warning! This gameobject does not have an Audio Source Component on it!\nAdd it for Extended Audio Source to work.");
        }
	}

    [ExecuteInEditMode]
    public void Update()
    {
        if(source == null)
        {
            source = GetComponent<AudioSource>();
        }

        if (usingPlaylist)
        {
            PlayNext();
        }
    }

    #region Play List
    /// <summary>
    /// Adds a song to the playlist.
    /// </summary>
    /// <param name="clipToAdd">The clip to add to the playlist.</param>
    public void AddToPlaylist(string nameOfSong, AudioClip clipToAdd)
    {
        playlist.list.Add(new PlaylistObject.Song(nameOfSong, clipToAdd));
    }

    /// <summary>
    /// Starts playing from the playlist.
    /// </summary>
    public void PlayFromPlaylist()
    {
        if (currentSong < playlist.list.Count)
        {
            currentSong++;
        }
        else if(loopPlaylist)
        {
            currentSong = 0;
        }
        else if (!loopPlaylist)
        {
            Debug.Log("Playlist has ended.");
            source.Stop();
            return;
        }

        source.clip = playlist.list[currentSong].song;
        Debug.Log("Now playing: <b>" + playlist.list[currentSong].name + "</b>");
        source.Play();
    }

    private void PlayNext()
    {
        if (source.isPlaying)
        {
            return;
        }
        else
        {
            PlayFromPlaylist();
        }
    }

    #endregion

    #region Intro Play
    /// <summary>
    /// Plays the current song first, then plays a song of your choice.
    /// Useful for looping songs that have an intro then loops.
    /// </summary>
    /// <param name="songToLoop">The audio clip that will play after the current one is finished.</param>
    public void PlayIntroFirst(AudioClip songToLoop)
    {
        source.Play();
        source.loop = false;
        StartCoroutine(PlayIntroFirstEnumerator(songToLoop));
    }

    private IEnumerator PlayIntroFirstEnumerator(AudioClip songToLoop)
    {

        yield return new WaitUntil(() => !source.isPlaying);
        source.clip = songToLoop;
        source.loop = true;
        source.Play();
    }
    /// <summary>
    /// Plays the current song first, then plays a song of your choice.
    /// Useful for looping songs that have an intro then loops.
    /// </summary>
    /// <param name="intro">The intro clip.</param>
    /// <param name="songToLoop">The audio clip that will play after the intro is finished.</param>
    public void PlayIntroFirst(AudioClip intro, AudioClip songToLoop)
    {
        source.clip = intro;
        source.loop = false;
        source.Play();
        StartCoroutine(PlayIntroFirstEnumerator(songToLoop));
    }

    #endregion

    #region CrossFade

    /// <summary>
    /// Fades this track out, while fading in another track from another source.
    /// </summary>
    /// <param name="otherSource">The other Extended Audio Source the new song will be played from.</param>
    /// <param name="clip">The new clip to be played.</param>
    public void CrossFade(ExtendedAudioSource otherSource, AudioClip clip)
    {
        StartCoroutine(CrossFadeNewSongEnumerator(otherSource, clip));
        StartCoroutine(CrossFadeOldSongEnumerator());
    }

    private IEnumerator CrossFadeNewSongEnumerator(ExtendedAudioSource otherSource, AudioClip clip)
    {
        var other = otherSource.source;

        float startVolume = other.volume;
        other.clip = clip;
        other.Play();

        while (other.volume < 1f)
        {
            other.volume += startVolume * Time.deltaTime / 1f;
            yield return new WaitForEndOfFrame();
        }
        other.volume = 1f;
    }

    private IEnumerator CrossFadeOldSongEnumerator()
    {
        float startVolume = source.volume;

        while (source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / 1f;
            yield return new WaitForEndOfFrame();
        }

        source.Stop();
        source.volume = 1f;
    }

    /// <summary>
    /// Fades this track out, while fading in another track from another source.
    /// </summary>
    /// <param name="otherSource">The other Extended Audio Source the new song will be played from.</param>
    /// <param name="clip">The new clip to be played.</param>
    /// <param name="time">The fade transition time.</param>
    public void CrossFade(ExtendedAudioSource otherSource, AudioClip clip, float time)
    {
        StartCoroutine(CrossFadeNewSongEnumerator(otherSource, clip, time));
        StartCoroutine(CrossFadeOldSongEnumerator(time));
    }

    private IEnumerator CrossFadeNewSongEnumerator(ExtendedAudioSource otherSource, AudioClip clip, float time)
    {
        var other = otherSource.source;

        float startVolume = other.volume;
        other.clip = clip;
        other.Play();

        while (other.volume < 1f)
        {
            other.volume += startVolume * Time.deltaTime / time;
            yield return new WaitForEndOfFrame();
        }
        other.volume = 1f;
    }

    private IEnumerator CrossFadeOldSongEnumerator(float time)
    {
        float startVolume = source.volume;

        while (source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / time;
            yield return new WaitForEndOfFrame();
        }

        source.Stop();
        source.volume = 1f;
    }

    #endregion

    #region Play Pitch Vary
    /// <summary>
    /// Plays an source clip with a randomly generated pitch.
    /// Useful for sound effects like footsteps or voices.
    /// Pitch is reset after the length of the sound effect has been played.
    /// </summary>
    /// <param name="clip">The source clip to be played.</param>
    /// <param name="minPitch">The minimum pitch desired. Maximum is -3.</param>
    /// <param name="maxPitch">The maximum pitch desired. Maximum is 3.</param>
    public void PlayPitchVary(AudioClip clip, float minPitch, float maxPitch)
    {
        if(inst != null)
        {
            StopCoroutine(inst);
        }

        if(minPitch < (-3f) || maxPitch > 3f)
        {
            if (minPitch < (-3f))
            {
                Debug.LogError("Minimum pitch is too low! Maximum is <b>-3</b>");
            }
            if (maxPitch > 3f)
            {
                Debug.LogError("Maximum pitch it too high! Maximum is <b>3</b>");
            }
            return;
        }

        float rnd = Random.Range(minPitch, maxPitch);
        source.pitch = rnd;
        source.PlayOneShot(clip);
        float newLength = new float();

        if (0 < rnd)
        {
            newLength = clip.length / rnd;
        }

        if(rnd < 0)
        {
            float positiveRnd = -rnd;
            if (0 < positiveRnd)
            {
                newLength = clip.length / positiveRnd;
            }
        }

        inst = StartCoroutine(PlayPitchVaryEnumerator(newLength));
    }

    /// <summary>
    /// Plays an source clip with a randomly generated pitch.
    /// Useful for sound effects like footsteps or voices.
    /// </summary>
    /// <param name="clip">The source clip to be played.</param>
    /// <param name="minPitch">The minimum pitch desired. Maximum is -3.</param>
    /// <param name="maxPitch">The maximum pitch desired. Maximum is 3.</param>
    /// <param name="resetPitchTime">The time in seconds it should take before the pitch is reset back to normal.</param>
    public void PlayPitchVary(AudioClip clip, float minPitch, float maxPitch, float resetPitchTime)
    {
        if (inst != null)
        {
            StopCoroutine(inst);
        }

        if (minPitch < (-3f) || maxPitch > 3f)
        {
            if (minPitch < (-3f))
            {
                Debug.LogError("Minimum pitch is too low! Maximum is <b>-3</b>");
            }
            if (maxPitch > 3f)
            {
                Debug.LogError("Maximum pitch it too high! Maximum is <b>3</b>");
            }
            return;
        }

        float rnd = Random.Range(minPitch, maxPitch);
        source.pitch = rnd;
        source.PlayOneShot(clip);
        StartCoroutine(PlayPitchVaryEnumerator(resetPitchTime));
    }

    private IEnumerator PlayPitchVaryEnumerator(float resetPitchTime)
    {
        yield return new WaitForSecondsRealtime(resetPitchTime);
        source.pitch = 1f;
    }
    #endregion

    #region Play Random Volume
    /// <summary>
    /// Plays a sound effect with a randomly generated volume.
    /// </summary>
    /// <param name="clip">The source clip to be played.</param>
    /// <param name="minVolume">The minimum volume desired. Can not go lower than 0.</param>
    /// <param name="maxVolume">The maximum volume desired. Can not go higher than 1.</param>
    public void PlayRandomVolume(AudioClip clip, float minVolume, float maxVolume)
    {
        if(minVolume < 0 || maxVolume > 1)
        {
            if(minVolume < 0)
            {
                Debug.LogWarning("Minimum value can not be lower than 0.");
            }
            if(maxVolume > 1)
            {
                Debug.LogWarning("Maximum value can not be higher than 1.");
            }
            return;
        }

        float rnd = Random.Range(minVolume, maxVolume);

        source.volume = rnd;
        source.PlayOneShot(clip);
        StartCoroutine(PlayRandomVolumeEnumerator(clip.length));
    }

    private IEnumerator PlayRandomVolumeEnumerator(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        source.volume = 1f;
    }

    #endregion

    #region Play Focus

    /// <summary>
    /// Pauses every other source source, allowing this sourcesource to be in focus.
    /// The opposite of PlayUnfocus. Pauses every other source source, allowing this sourcesource to be in focus. The opposite of PlayUnfocus.
    /// </summary>
    public void PlayFocus()
    {
        AudioSource[] sourcesArray = FindObjectsOfType<AudioSource>();
        List<AudioSource> sources = new List<AudioSource>();
        foreach(AudioSource source in sourcesArray)
        {
            sources.Add(source);
        }

        sources.Remove(source);

        foreach(AudioSource source in sources)
        {
            source.Pause();
        }
    }
    /// <summary>
    /// Pauses every other source source, allowing this sourcesource to be in focus.
    /// The opposite of PlayUnfocus. Pauses every other source source, allowing this sourcesource to be in focus. The opposite of PlayUnfocus.
    /// </summary>
    /// <param name="unFocus">Set to true if you want to run PlayUnfocus() after this clip has been played.</param>
    /// <param name="clip">The clip to be played on this Audio Source.</param>
    public void PlayFocus(bool unFocus, AudioClip clip)
    {
        AudioSource[] sourcesArray = FindObjectsOfType<AudioSource>();
        List<AudioSource> sources = new List<AudioSource>();
        foreach (AudioSource source in sourcesArray)
        {
            sources.Add(source);
        }

        sources.Remove(source);

        foreach (AudioSource source in sources)
        {
            source.Pause();
        }
        source.clip = clip;
        source.Play();
        if(unFocus == true)
        {
            StartCoroutine(PlayFocusEnumerator(clip.length));
        }
    }

    private IEnumerator PlayFocusEnumerator(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        PlayUnFocus();
    }
    #endregion

    #region Play UnFocus

    /// <summary>
    /// Unpauses every source source in the scene except for this one.
    /// The opposite of PlayFocus
    /// </summary>
    public void PlayUnFocus()
    {
        AudioSource[] sourcesArray = FindObjectsOfType<AudioSource>();
        List<AudioSource> sources = new List<AudioSource>();
        foreach (AudioSource source in sourcesArray)
        {
            sources.Add(source);
        }

        sources.Remove(source);

        foreach (AudioSource source in sources)
        {
            source.UnPause();
        }
    }

    #endregion

    #region Fade Tracks
    /// <summary>
    /// Fades out the current track until the volume is zero, then fades in a new track.
    /// Different from crossfade in the sense that the volume must turn to zero before the new track is faded in.
    /// </summary>
    /// <param name="clip">The new source clip that will be faded in.</param>
    /// <param name="time">The fade transition time.</param>
    public void FadeTracks(AudioClip clip, float time)
    {
        if(source.volume == 1)
        {
            StartCoroutine(FadeTracksEnumerator(clip, time));
        }
        else
        {
            Debug.Log("Couldn't run FadeTracks() because this Audio Source is still fading. Wait until the volume is equal to 1 again.");
        }
    }

    private IEnumerator FadeTracksEnumerator(AudioClip clip, float time)
    {
        float startVolume = source.volume;

        while (source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / time;
            yield return new WaitForEndOfFrame();
        }

        source.Stop();
        source.clip = clip;
        source.Play();

        while (source.volume < 1f)
        {
            source.volume += startVolume * Time.deltaTime / time;
            yield return new WaitForEndOfFrame();
        }
    }
    #endregion

    #region Fade Out
    /// <summary>
    /// Fades the current clip out from it's current volume.
    /// </summary>
    /// <param name="time">The fade transition time.</param>
    /// <param name="stop">Whether the audio source should stop playing when fading out is complete.</param>
    public void FadeOut(float time, bool stop)
    {
        if(source.volume == 0)
        {
            Debug.LogWarning("Oops! Seems like you tried to fade out something while the volume was already zero.\nThe function ran but had no effect.");
            StartCoroutine(FadeOutEnumerator(time, stop));
        }
        else
        {
            StartCoroutine(FadeOutEnumerator(time, stop));
        }
    }

    private IEnumerator FadeOutEnumerator(float time, bool stop)
    {

        float startVolume = source.volume;

        while (source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / time;
            yield return new WaitForEndOfFrame();
        }
        if (stop) {
            source.Stop();
        }
    }


    #endregion

    #region Fade In
    /// <summary>
    /// Fades the current clip in.
    /// </summary>
    /// <param name="time"></param>
    public void FadeIn(float time)
    {
        if(source.volume == 1)
        {
            Debug.LogWarning("Oops! Seems like you tried to fade in something while the volume was already full.\nThe function ran but had no effect.");
            StartCoroutine(FadeInEnumerator(time));
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(FadeInEnumerator(time));
        }
    }

    private IEnumerator FadeInEnumerator(float time)
    {
        float startVolume = 1f;

        while (source.volume < 1f)
        {
            source.volume += startVolume * Time.deltaTime / time;
            yield return new WaitForEndOfFrame();
        }

        source.volume = 1f;
    }


    /// <summary>
    /// Fades the current clip in.
    /// </summary>
    /// <param name="time">The time fade transition time.</param>
    /// <param name="startingVolume">The starting volume of the fade in.</param>
    public void FadeIn(float time, float startingVolume)
    {
        if(source.volume == 1)
        {
            Debug.LogWarning("Oops! Seems like you tried to fade in something while the volume was already full.\nThe function ran but had no effect.");
            StartCoroutine(FadeInEnumerator(time, startingVolume));
        }
        else
        {
            StartCoroutine(FadeInEnumerator(time, startingVolume));
        }
    }

    private IEnumerator FadeInEnumerator(float time, float startingVolume)
    {
        float startVolume = startingVolume;

        while (source.volume < 1f)
        {
            source.volume += startVolume * Time.deltaTime / time;
            yield return new WaitForEndOfFrame();
        }

        source.volume = 1f;
    }

    /// <summary>
    /// Fades a new clip in.
    /// </summary>
    /// <param name="time">The fade transition time.</param>
    /// <param name="clip">The new clip to be faded in.</param>
    public void FadeIn(float time, AudioClip clip)
    {
        if(source.volume == 1)
        {
            Debug.LogWarning("Oops! Seems like you tried to fade in something while the volume was already full.\nThe function ran but had no effect.");
            StartCoroutine(FadeInEnumerator(time, clip));
        }
        else
        {
            StartCoroutine(FadeInEnumerator(time, clip));
        }

    }

    private IEnumerator FadeInEnumerator(float time, AudioClip clip)
    {
        float startVolume = 0;
        source.clip = clip;

        while (source.volume < 1f)
        {
            source.volume += startVolume * Time.deltaTime / time;
            yield return new WaitForEndOfFrame();
        }

        source.volume = 1f;
    }

    /// <summary>
    /// Fades a new clip in.
    /// </summary>
    /// <param name="time">The fade transition time.</param>
    /// <param name="clip">The new clip to be faded in.</param>
    /// <param name="startingVolume">The starting volume of the fade in.</param>
    public void FadeIn(float time, AudioClip clip, float startingVolume)
    {
        if(source.volume == 1)
        {
            Debug.LogWarning("Oops! Seems like you tried to fade in something while the volume was already full.\nThe function ran but had no effect.");
            StartCoroutine(FadeInEnumerator(time, clip, startingVolume));
        }
        else
        {
            StartCoroutine(FadeInEnumerator(time, clip, startingVolume));
        }
    }

    private IEnumerator FadeInEnumerator(float time, AudioClip clip, float startingVolume)
    {
        float startVolume = startingVolume;
        source.clip = clip;

        while (source.volume < 1f)
        {
            source.volume += startVolume * Time.deltaTime / time;
            yield return new WaitForEndOfFrame();
        }

        source.volume = 1f;
    }
    #endregion
}

[CustomEditor(typeof(ExtendedAudioSource))]
public class ExtendedAudioSourceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ExtendedAudioSource myTarget = (ExtendedAudioSource)target;
        if(myTarget.source == null)
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("I should automatically find the AudioSource on this GameObject during runtime.");
            EditorGUILayout.LabelField("Confused on how to use me? Read the README.txt file");
            EditorGUILayout.EndVertical();
        }
        else
        {
            return;
        }
    }
}