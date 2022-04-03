public string TimeToStopwatchString(float time)
{
    /* TIME IN SECONDS (corresponding to Time.deltaTime by Unity)
     * Returns given time in format 00:00:00 (min:sec:millisec) as string.
     */

    int minutes = Mathf.FloorToInt(time / 60F);
    int seconds = Mathf.FloorToInt(time % 60F);
    int milliseconds = Mathf.FloorToInt((time * 100F) % 100F);

    return minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
}
