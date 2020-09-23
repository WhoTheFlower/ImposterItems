using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ItemAPI;
using Gungeon;
using DirectionType = DirectionalAnimation.DirectionType;
using AnimationType = ItemAPI.CompanionBuilder.AnimationType;
using MonoMod.RuntimeDetour;

namespace ImposterItems
{
    public class LilCrewmate
    {

        public static void Init()
        {
            string itemName = "Lil' Crewmate";
            string resourceName = "ImposterItems/Resources/lilcrewmate";
            GameObject obj = new GameObject(itemName);
            var item = obj.AddComponent<CompanionItem>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Just look at him!";
            string longDesc = "This little crewmate went with the impostor when they were both ejected off the ship.\n\nHe doesn’t talk, he doesn’t fight, he honestly doesn’t do much of anything aside from being cute. At least the company must be nice.";
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "spapi");
            item.quality = PickupObject.ItemQuality.SPECIAL;
            item.CompanionGuid = "lil_crewmate";
            item.Synergies = new CompanionTransformSynergy[0];
            BuildPrefab();
            Game.Items.Rename("spapi:lil'_crewmate", "spapi:lil_crewmate");
        }

        public static void BuildPrefab()
        {
            if (prefab == null && !CompanionBuilder.companionDictionary.ContainsKey("lil_crewmate"))
            {
                prefab = CompanionBuilder.BuildPrefab("Lil Crewmate", "lil_crewmate", "ImposterItems/Resources/Crewmate/IdleRight/lilguy_idle_right_001", new IntVector2(0, 0), new IntVector2(14, 16));
                var companion = prefab.AddComponent<CompanionController>();
                PixelCollider collider = new PixelCollider();
                collider.ColliderGenerationMode = PixelCollider.PixelColliderGeneration.Manual;
                collider.CollisionLayer = CollisionLayer.EnemyHitBox;
                collider.ManualWidth = 14;
                collider.ManualHeight = 16;
                collider.ManualOffsetX = 0;
                collider.ManualOffsetY = 0;
                companion.aiActor.HitByEnemyBullets = false;
                companion.aiActor.IsNormalEnemy = false;
                companion.CanInterceptBullets = true;
                companion.specRigidbody.PixelColliders.Add(collider);
                companion.specRigidbody.CollideWithOthers = true;
                companion.aiActor.CollisionDamage = 0f;
                companion.aiActor.MovementSpeed = 7.2f;
                companion.aiActor.HitByEnemyBullets = true;
                prefab.AddAnimation("idle_right", "ImposterItems/Resources/Crewmate/IdleRight",  5, AnimationType.Idle, DirectionType.TwoWayHorizontal);
                prefab.AddAnimation("idle_left", "ImposterItems/Resources/Crewmate/IdleLeft", 5, AnimationType.Idle, DirectionType.TwoWayHorizontal);
                prefab.AddAnimation("run_right", "ImposterItems/Resources/Crewmate/MoveRight",  16, AnimationType.Move, DirectionType.TwoWayHorizontal);
                prefab.AddAnimation("run_left", "ImposterItems/Resources/Crewmate/MoveLeft", 16, AnimationType.Move, DirectionType.TwoWayHorizontal);
                var bs = prefab.GetComponent<BehaviorSpeculator>();
                bs.MovementBehaviors.Add(new CompanionFollowPlayerBehavior() { IdleAnimations = new string[] { "idle" }, DisableInCombat = false });
            }
        }

        public static GameObject prefab;
    }
}
