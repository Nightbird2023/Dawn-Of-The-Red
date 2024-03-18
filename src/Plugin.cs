namespace DawnOfTheRed;

[BepInPlugin(GUID: AUTHORS, Name: MOD_NAME, Version: VERSION)]
class Plugin : BaseUnityPlugin
{
    public const string AUTHORS = "BensoneWhite";
    public const string MOD_NAME = "dawnofthered";
    public const string VERSION = "0.0.1";

    public bool IsInit;
    public bool IsPreInit;
    public bool IsPostInit;

    public void OnEnable()
    {
        On.RainWorld.PreModsInit += RainWorld_PreModsInit;
        On.RainWorld.OnModsInit += RainWorld_OnModsInit;
        On.RainWorld.PostModsInit += RainWorld_PostModsInit;

        Debug.LogWarning($"{MOD_NAME} is loading... {VERSION}");
    }

    private void RainWorld_PostModsInit(On.RainWorld.orig_PostModsInit orig, RainWorld self)
    {
        orig(self);

        try
        {
            if (IsPostInit) return;
            IsPostInit = true;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    private void RainWorld_PreModsInit(On.RainWorld.orig_PreModsInit orig, RainWorld self)
    {
        orig(self);

        try
        {
            if (IsPreInit) return;
            IsPreInit = true;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    private void RainWorld_OnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
        orig(self);

        try
        {
            if (IsInit) return;
            IsInit = true;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            Debug.LogError(e);
        }
    }
}
