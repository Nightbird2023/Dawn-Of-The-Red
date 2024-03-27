namespace DawnOfTheRed;

public class RueLizardHooks
{
    public static void Apply()
    {
        On.Lizard.ctor += Lizard_ctor;
        On.LizardBreeds.BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate += LizardBreeds_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate;

        Debug.LogWarning("Rue Lizard Loading DawnOFTheRed");
    }

    private static CreatureTemplate LizardBreeds_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate(On.LizardBreeds.orig_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate orig, CreatureType type, CreatureTemplate lizardAncestor, CreatureTemplate pinkTemplate, CreatureTemplate blueTemplate, CreatureTemplate greenTemplate)
    {
        if (type == DorEnums.CreatureType.RueLizard)
        {
            var temp = orig(CreatureType.BlueLizard, lizardAncestor, pinkTemplate, blueTemplate, greenTemplate);

            var lizardBreedParams = (LizardBreedParams)temp.breedParameters;

            temp.type = type;
            temp.name = "RueLizard";

            lizardBreedParams.bodyRadFac = 1f;
            lizardBreedParams.pullDownFac = 1f;

            lizardBreedParams.biteDelay = 1;
            lizardBreedParams.biteInFront = 22f;
            lizardBreedParams.biteHomingSpeed = 1.85f;
            lizardBreedParams.biteChance = 0.9f;
            lizardBreedParams.attemptBiteRadius = 94f;
            lizardBreedParams.getFreeBiteChance = 0.55f;
            lizardBreedParams.biteDamage = 1.45f;
            lizardBreedParams.biteDamageChance = 0.8f;
            lizardBreedParams.toughness = 2.45f;
            lizardBreedParams.stunToughness = 2.40f;

            lizardBreedParams.aggressionCurveExponent = 10f;
            lizardBreedParams.idleCounterSubtractWhenCloseToIdlePos = 0;

            lizardBreedParams.regainFootingCounter = 4;
            lizardBreedParams.floorLeverage = 1f;
            lizardBreedParams.maxMusclePower = 2.8f;
            lizardBreedParams.wiggleDelay = 15;
            lizardBreedParams.bodyStiffnes = 0.05f;
            lizardBreedParams.swimSpeed = 0.35f;
            lizardBreedParams.headShieldAngle = 100f;
            lizardBreedParams.canExitLounge = true;
            lizardBreedParams.canExitLoungeWarmUp = true;
            lizardBreedParams.findLoungeDirection = 1f;
            lizardBreedParams.loungeDistance = 80f;
            lizardBreedParams.preLoungeCrouch = 35;
            lizardBreedParams.preLoungeCrouchMovement = -0.3f;
            lizardBreedParams.loungeSpeed = 2.5f;
            lizardBreedParams.loungeMaximumFrames = 20;
            lizardBreedParams.loungePropulsionFrames = 8;
            lizardBreedParams.loungeJumpyness = 0.9f;
            lizardBreedParams.loungeDelay = 310;
            lizardBreedParams.riskOfDoubleLoungeDelay = 0.8f;
            lizardBreedParams.postLoungeStun = 20;
            lizardBreedParams.loungeTendensy = 0.2f;
            lizardBreedParams.perfectVisionAngle = 0.89f;
            lizardBreedParams.periferalVisionAngle = 0.08f;
            lizardBreedParams.biteDominance = 0.6f;
            lizardBreedParams.limbThickness = 1.05f;
            lizardBreedParams.stepLength = 0.4f;
            lizardBreedParams.liftFeet = 0f;
            lizardBreedParams.feetDown = 0f;
            lizardBreedParams.noGripSpeed = 0.2f;
            lizardBreedParams.limbSpeed = 6.5f;
            lizardBreedParams.limbGripDelay = 1;
            lizardBreedParams.smoothenLegMovement = true;
            lizardBreedParams.legPairDisplacement = 0f;
            lizardBreedParams.walkBob = 0.4f;
            lizardBreedParams.tailStiffness = 400f;
            lizardBreedParams.tailStiffnessDecline = 0.1f;
            lizardBreedParams.tailColorationStart = 0.1f;
            lizardBreedParams.tailColorationExponent = 1.2f;
            lizardBreedParams.neckStiffness = 0f;
            lizardBreedParams.jawOpenAngle = 109.1f;
            lizardBreedParams.jawOpenLowerJawFac = 0.55f;
            lizardBreedParams.jawOpenMoveJawsApart = 20f;
            lizardBreedParams.headGraphics = new int[5];
            lizardBreedParams.framesBetweenLookFocusChange = 20;
            lizardBreedParams.tongue = true;
            lizardBreedParams.tongueAttackRange = 140f;
            lizardBreedParams.tongueWarmUp = 10;
            lizardBreedParams.tongueSegments = 5;
            lizardBreedParams.tongueChance = 0.25f;
            lizardBreedParams.tamingDifficulty = 7.3f;
            lizardBreedParams.tailSegments = Random.Range(7, 9);
            lizardBreedParams.tailLengthFactor = 1.1f;
            lizardBreedParams.danger = 2f;
            lizardBreedParams.standardColor = Color.red;
            lizardBreedParams.headSize = 1f;
            lizardBreedParams.bodySizeFac = 1.1f;
            lizardBreedParams.limbSize = 0.95f;
            lizardBreedParams.bodyLengthFac = 1.05f;
            lizardBreedParams.bodyMass = 0.95f;
            lizardBreedParams.limbQuickness = 0.7f;
            lizardBreedParams.wiggleSpeed = 1f;
            lizardBreedParams.baseSpeed = 4.05f;
            lizardBreedParams.terrainSpeeds[1] = new(1.35f, 1.3f, 1.3f, 1.3f);
            lizardBreedParams.terrainSpeeds[2] = new(1f, 1f, 1f, 1f);
            lizardBreedParams.terrainSpeeds[3] = new(1.2f, 1.35f, 1.3f, 1.3f);
            lizardBreedParams.terrainSpeeds[4] = new(1.25f, 1.35f, 1.3f, 1.3f);
            lizardBreedParams.terrainSpeeds[5] = new(1.05f, 1f, 1f, 1f);

            temp.waterPathingResistance = 5f;
            temp.visualRadius = 950f;
            temp.waterVision = 0.4f;
            temp.throughSurfaceVision = 0.85f;
            temp.breedParameters = lizardBreedParams;
            temp.baseDamageResistance = lizardBreedParams.toughness * 2f;
            temp.baseStunResistance = lizardBreedParams.toughness;

            temp.damageRestistances[(int)Creature.DamageType.Bite, 0] = 2.5f;
            temp.damageRestistances[(int)Creature.DamageType.Bite, 1] = 3f;
            temp.meatPoints = 8;
            temp.doPreBakedPathing = false;
            temp.preBakedPathingAncestor = StaticWorld.GetCreatureTemplate(CreatureType.BlueLizard);
            temp.requireAImap = true;
            temp.virtualCreature = false;
            temp.pickupAction = "Bite";
            temp.jumpAction = "Call";
            temp.throwAction = "Launch";
            temp.wormGrassImmune = false;
            temp.canSwim = true;
            temp.dangerousToPlayer = 10f;

            return temp;
        }

        return orig(type, lizardAncestor, pinkTemplate, blueTemplate, greenTemplate);
    }

    private static void Lizard_ctor(On.Lizard.orig_ctor orig, Lizard self, AbstractCreature abstractCreature, World world)
    {
        orig(self, abstractCreature, world);
        if (self.Template.type == DorEnums.CreatureType.RueLizard)
        {
            self.effectColor = Custom.HSL2RGB(Custom.WrappedRandomVariation(0.0025f, 0.02f, 0.6f), 1f, Custom.ClampedRandomVariation(0.5f, 0.15f, 0.1f));
        }
    }
}