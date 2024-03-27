namespace DawnOfTheRed;

[BepInPlugin(GUID: MOD_ID, Name: MOD_NAME, Version: VERSION)]
class Plugin : BaseUnityPlugin
{
    public const string MOD_ID = "dawnofthered";
    public const string AUTHORS = "BensoneWhite";
    public const string MOD_NAME = "Dawn Of The Red";
    public const string VERSION = "1.02";

    public bool IsInit;
    public bool IsPreInit;
    public bool IsPostInit;

    public void OnEnable()
    {
        Debug.LogWarning($"{MOD_NAME} is loading... {VERSION}");
    
        ApplyLizards();

        try
        {
            On.RainWorld.PreModsInit += RainWorld_PreModsInit;
            On.RainWorld.OnModsInit += RainWorld_OnModsInit;
            On.RainWorld.PostModsInit += RainWorld_PostModsInit;

            On.RainWorld.OnModsDisabled += RainWorld_OnModsDisabled;
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
            Debug.LogException(ex);
        }
    }

    private void RainWorld_OnModsDisabled(On.RainWorld.orig_OnModsDisabled orig, RainWorld self, ModManager.Mod[] newlyDisabledMods)
    {
        orig(self, newlyDisabledMods);

        for (int i = 0; i < newlyDisabledMods.Length; i++)
        {
            if (newlyDisabledMods[i].id == "dawnofthered")
            {
                DorEnums.Unregister();
            }
            if (newlyDisabledMods[i].id == "moreslugcats")
            {
                DorEnums.Unregister();
            }
        }
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

            DorEnums.Init();

            Debug.LogWarning($"Loading Lizards.... {MOD_NAME}");
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            Debug.LogError(e);
        }
    }

    void ApplyLizards()
    {
        RueLizardHooks.Apply();

        Content.Register(
            new RueLizardCritob());
    }
}
