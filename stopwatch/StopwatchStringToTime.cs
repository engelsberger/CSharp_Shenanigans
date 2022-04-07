public float StopwatchStringToTime(string stopwatchString)
{
    /* RETURNS TIME IN SECONDS
     * Stopwatch string needs to be in the format 00:00:00 (m:s:ms) or 00:00:00:00 (h:m:s:ms)
     * Returns -1 if input does not work.
     */

    float[] inputs = stopwatchString.Split(':').Select(s => {
        float.TryParse(s, out float value);
        return value;
    }).ToArray();

    float timeInSeconds = 0;
    if (inputs.Length == 3 || inputs.Length == 4)
    {
        timeInSeconds += inputs[0] * 60 * (inputs.Length == 3 ? 1 : 60);
        timeInSeconds += inputs[1] * (inputs.Length == 3 ? 1 : 60);
        timeInSeconds += inputs[2] * (inputs.Length == 3 ? 0.01f : 1);
        if (inputs.Length == 4) timeInSeconds += inputs[3] * 0.01f;
    }
    else return -1f;
    
    return timeInSeconds;
}
