using Android.App;
using Android.Content;

namespace EnMente.Platforms.Android;

[BroadcastReceiver(Enabled = true, Label = "Reboot complete receiver", Exported = false)]
[IntentFilter([Intent.ActionBootCompleted])]
public class BootReceiver : BroadcastReceiver
{
    public override void OnReceive(Context context, Intent intent)
    {
        if (intent.Action == "android.intent.action.BOOT_COMPLETED")
        {
            // Recreate alarms
        }
    }
}