﻿// TODO: Villages

// TODO: Refactor -> IDE Style
// TODO: Refactor -> Documentation [///]
// TODO: Refactor -> Class Regions
// TODO [low priority]: Refactor code using LBS Style Guide ("my...", "a...")

/*
 * Player should get good reputation in a village to win.
 * He can gain reputation by buying stuff from the shop, fighting monsters to protect the village or
 * socializing.
 *
 * The better reputation the player has in a village the lower prices are in [a] village shop.
 *
 * Player can buy:
 *     Special Artifacts (Buffs, like potions in Minecraft)
 *     Books (to be able to gain more social points during the socializing process)
 *     Armor (to get more defense points, defense procent)
 *     Attack range (increases the attack wave range)
 *     Level upgrade (the health and walkingstamina increases)
 * Player can get money:
 *     By fighting monsters and bringing their heads to the shop.
 *     For every head the player gets [] points of reputation.
 *     Every head (every monster) has it's price. The harder monster to kill the bigger price is.
 *
 * Health represents both the energy and the health itself.
 * So when player's traveling the health decreases.
 * TODO: Declare Player.WalkingStamina, the bigger the value is the less health it takes per 1km
 *
 * Player can play fast, choose a village and just help them with everything,
 * or he can go from village to village and find new artifacts, stuff and monsters.
 * 
 */

using System;
using System.Collections.Generic;
using lbs_rpg.classes.gui.components;
using lbs_rpg.classes.gui.templates;
using lbs_rpg.classes.instances.player;
using lbs_rpg.contracts;

namespace lbs_rpg
{
    public static class Program
    {
        // Declare fast player instance reference, so that it can be accessed from any class in the program.
        public static Player Player = default;

        // Declare RenderPipeline that includes renderable items (such as player stats) that will
        // be redrawn after each console.clear invocation.
        public static IList<IRenderable> RenderPipeline = new List<IRenderable>();
        
        public static void Main(string[] args)
        {
            // Check if terminal container is not too small
            if (!ResolutionHandler.IsSupportedResolution())
            {
                throw new ApplicationException(
                    "The terminal window is too small. Please change window to the fullscreen mode.");
            }
            
            // Initialize player instance
            Player = new Player();
            
            // Initialize render pipeline
                // Player stats bar
            RenderPipeline.Add(new PlayerStatsBar(Player));
            
            // Display the welcome message (game introduction)
            WelcomeScreen.Display();
            
            ConstantProgress.Start("SLEEPING", 250,  () =>
            {
                // Update player's stats
                Player.ApplyDamage(-.1f);
            });
            
            // Display the stats (before the menu, since the menu method will block the thread)
            // TODO: Stats should also display the enemy damage (not in the Program.Main)
            // TODO: Stats should accept an argument [isAttackReloadShown] and replace the money field with the attack reload
                // * It would be super cool during the fights

                // Display the main menu
            ActionGroupsMenu.Display();
        }
    }
}
