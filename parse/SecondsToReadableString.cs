/* TAKES X SECONDS AS INTEGER AND CONVERTS IT TO A READABLE STRING
 * 
 * Ex. input is 65 - output is 1 minute, 5 seconds
 * Validates input, returns "0" for invalid input
 */

static string SecondsToReadableString(int seconds)
{
    // Validate input
    if (seconds == 0) return "0";
    if (seconds < 0) return "0";


    // Calculate years, days, hours, minutes and seconds
    int years = seconds / (60 * 60 * 24 * 365);
    seconds -= years * 60 * 60 * 24 * 365;
    int days = seconds / (60 * 60 * 24);
    seconds -= days * 60 * 60 * 24;
    int hours = seconds / (60 * 60);
    seconds -= hours * 60 * 60;
    int minutes = seconds / 60;
    seconds -= minutes * 60;

    // Convert everything into a readable string
    return (years > 1 ? (years.ToString() + " years") : years == 1 ? (years.ToString() + " year") : "")
         + (years > 0 && (days > 0 || hours > 0 || minutes > 0 || seconds > 0) ? ", " : "")
         + (days > 1 ? (days.ToString() + " days") : days == 1 ? (days.ToString() + " day") : "")
         + (days > 0 && (hours > 0 || minutes > 0 || seconds > 0) ? ", " : "")
         + (hours > 1 ? (hours.ToString() + " hours") : hours == 1 ? (hours.ToString() + " hour") : "")
         + (hours > 0 && (minutes > 0 || seconds > 0) ? ", " : "")
         + (minutes > 1 ? (minutes.ToString() + " minutes") : minutes == 1 ? (minutes.ToString() + " minute") : "")
         + (minutes > 0 && seconds > 0 ? ", " : "")
         + (seconds > 1 ? (seconds.ToString() + " seconds") : seconds == 1 ? (seconds.ToString() + " second") : "");
}
