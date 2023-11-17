namespace ClashRoyaleClanWarsAPI.API.Utils.Analytics;

public static class CardScore
{
    public static Dictionary<string, Dictionary<string, int>> GetCardScores()
    {
        var knightScores = new Dictionary<string, int>()
        {
            /*{ "Knight",  } ,
            { "Archers",  } ,
            { "Goblins",  } ,
            { "Giant",  } ,
            { "P.E.K.K.A",  } ,
            { "Minions",  } ,
            { "Ballon",  } ,
            { "Witch",  } ,
            { "Barbarians",  } ,
            { "Golem",  } ,
            { "Skeletons",  } ,
            { "Valkyrie",  } ,
            { "Skeleton Army",  } ,
            { "Bomber",  } ,
            { "Musketeer",  } ,
            { "Baby Dragon",  } ,
            { "Prince",  } ,
            { "Wizard",  } ,
            { "Mini P.E.K.K.A",  } ,
            { "Spear Goblins",  } ,
            { "Giant Skeleton",  } ,
            { "Hog Rider",  } ,
            { "Minion Horde",  } ,
            { "Ice Wizard",  } ,
            { "Royal Giant",  } ,
            { "Guards",  } ,
            { "Princess",  } ,
            { "Dark Prince",  } ,
            { "Three Musketeer",  } ,
            { "Lava Hound",  } ,
            { "Ice Spirit",  } ,
            { "Fire Spirit",  } ,
            { "Miner",  } ,
            { "Sparky",  } ,
            { "Bowler",  } ,
            { "Lumberjack",  } ,
            { "Battle Ram",  } ,
            { "Inferno Dragon",  } ,
            { "Ice Golem",  } ,
            { "Mega Minion",  } ,
            { "Dart Goblin",  } ,
            { "Goblin Gang",  } ,
            { "Electro Wizard",  } ,
            { "Elite Barbarians",  } ,
            { "Hunter",  } ,
            { "Executioner",  } ,
            { "Bandit",  } ,
            { "Royal Recruits",  } ,
            { "Night Witch",  } ,
            { "Bats",  } ,
            { "Royal Ghost",  } ,
            { "Ram Rider",  } ,
            { "Zappies",  } ,
            { "Rascals",  } ,
            { "Cannon Cart",  } ,
            { "Mega Knight",  } ,
            { "Skeleton Barrel",  } ,
            { "Flying Machine",  } ,
            { "Wall Breakers",  } ,
            { "Royal Hogs",  } ,
            { "Goblin Giant",  } ,
            { "Fisherman",  } ,
            { "Magic Archer",  } ,
            { "Electro Dragon",  } ,
            { "Firecracker",  } ,
            { "Mighty Miner",  } ,
            { "Elixir Golem",  } ,
            { "Battle Healer",  } ,
            { "Skeleton King",  } ,
            { "Archer Queen",  } ,
            { "Golden Knight",  } ,
            { "Monk",  } ,
            { "Skeleton Dragons",  } ,
            { "Mother Witch",  } ,
            { "Electro Spirit",  } ,
            { "Electro Giant",  } ,
            { "Phoenix",  } ,
            { "Heal Spirit",  } ,
            { "FireBall",  } ,
            { "Arrows",  } ,
            { "Rage",  } ,
            { "Rocket",  } ,
            { "Goblin Barrel",  } ,
            { "Freeze",  } ,
            { "Mirror",  } ,
            { "Lightning",  } ,
            { "Zap",  } ,
            { "Poison",  } ,
            { "Graveyard",  } ,
            { "The Log",  } ,
            { "Tornado",  } ,
            { "Clone",  } ,
            { "Earthquake",  } ,
            { "Barbarian Barrel",  } ,
            { "Giant Snowball",  } ,
            { "Royal Delivery",  } ,
            { "Cannon",  } ,
            { "Goblin Hut",  } ,
            { "Mortar",  } ,
            { "Inferno Tower",  } ,
            { "Bomb Tower",  } ,
            { "Barbarian Hut",  } ,
            { "Tesla",  } ,
            { "Elixir Collector",  } ,
            { "X-Bow",  } ,
            { "Tombstone",  } ,
            { "Furnace",  } ,
            { "Goblin Cage",  } ,
            { "Goblin Drill",  }*/
        };
        
        var archersScores = new Dictionary<string, int>();

        var goblinsScores = new Dictionary<string, int>();

        var giantScores = new Dictionary<string, int>();

        var pekkaScores = new Dictionary<string, int>();

        var minionsScores = new Dictionary<string, int>();

        var ballonScores = new Dictionary<string, int>();

        var witchScores = new Dictionary<string, int>();

        var barbariansScores = new Dictionary<string, int>();

        var golemScores = new Dictionary<string, int>();

        var skeletonsScores = new Dictionary<string, int>();

        var valkyrieScores = new Dictionary<string, int>();

        var skeleton_armyScores = new Dictionary<string, int>();

        var bomberScores = new Dictionary<string, int>();

        var musketeerScores = new Dictionary<string, int>();

        var baby_dragonScores = new Dictionary<string, int>();

        var princeScores = new Dictionary<string, int>();

        var wizardScores = new Dictionary<string, int>();

        var mini_pekkaScores = new Dictionary<string, int>();

        var spear_goblinsScores = new Dictionary<string, int>();

        var giant_skeletonScores = new Dictionary<string, int>();

        var hog_riderScores = new Dictionary<string, int>();

        var minion_hordeScores = new Dictionary<string, int>();

        var ice_wizardScores = new Dictionary<string, int>();

        var royal_giantScores = new Dictionary<string, int>();

        var guardsScores = new Dictionary<string, int>();

        var princessScores = new Dictionary<string, int>();

        var dark_princeScores = new Dictionary<string, int>();

        var three_musketeerScores = new Dictionary<string, int>();

        var lava_houndScores = new Dictionary<string, int>();

        var ice_spiritScores = new Dictionary<string, int>();

        var fire_spiritScores = new Dictionary<string, int>();

        var minerScores = new Dictionary<string, int>();

        var sparkyScores = new Dictionary<string, int>();

        var bowlerScores = new Dictionary<string, int>();

        var lumberjackScores = new Dictionary<string, int>();

        var battle_ramScores = new Dictionary<string, int>();

        var inferno_dragonScores = new Dictionary<string, int>();

        var ice_golemScores = new Dictionary<string, int>();

        var mega_minionScores = new Dictionary<string, int>();

        var dart_goblinScores = new Dictionary<string, int>();

        var goblin_gangScores = new Dictionary<string, int>();

        var electro_wizardScores = new Dictionary<string, int>();

        var elite_barbariansScores = new Dictionary<string, int>();

        var hunterScores = new Dictionary<string, int>();

        var executionerScores = new Dictionary<string, int>();

        var banditScores = new Dictionary<string, int>();

        var royal_recruitsScores = new Dictionary<string, int>();

        var night_witchScores = new Dictionary<string, int>();

        var batsScores = new Dictionary<string, int>();

        var royal_ghostScores = new Dictionary<string, int>();

        var ram_riderScores = new Dictionary<string, int>();

        var zappiesScores = new Dictionary<string, int>();

        var rascalsScores = new Dictionary<string, int>();

        var cannon_cartScores = new Dictionary<string, int>();

        var mega_knightScores = new Dictionary<string, int>();

        var skeleton_barrelScores = new Dictionary<string, int>();

        var flying_machineScores = new Dictionary<string, int>();

        var wall_breakersScores = new Dictionary<string, int>();

        var royal_hogsScores = new Dictionary<string, int>();

        var goblin_giantScores = new Dictionary<string, int>();

        var fishermanScores = new Dictionary<string, int>();

        var magic_archerScores = new Dictionary<string, int>();

        var electro_dragonScores = new Dictionary<string, int>();

        var firecrackerScores = new Dictionary<string, int>();

        var mighty_minerScores = new Dictionary<string, int>();

        var elixir_golemScores = new Dictionary<string, int>();

        var battle_healerScores = new Dictionary<string, int>();

        var skeleton_kingScores = new Dictionary<string, int>();

        var archer_queenScores = new Dictionary<string, int>();

        var golden_knightScores = new Dictionary<string, int>();

        var monkScores = new Dictionary<string, int>();

        var skeleton_dragonsScores = new Dictionary<string, int>();

        var mother_witchScores = new Dictionary<string, int>();

        var electro_spiritScores = new Dictionary<string, int>();

        var electro_giantScores = new Dictionary<string, int>();

        var phoenixScores = new Dictionary<string, int>();

        var heal_spiritScores = new Dictionary<string, int>();

        var fireballScores = new Dictionary<string, int>();

        var arrowsScores = new Dictionary<string, int>();

        var rageScores = new Dictionary<string, int>();

        var rocketScores = new Dictionary<string, int>();

        var goblin_barrelScores = new Dictionary<string, int>();

        var freezeScores = new Dictionary<string, int>();

        var mirrorScores = new Dictionary<string, int>();

        var lightningScores = new Dictionary<string, int>();

        var zapScores = new Dictionary<string, int>();

        var poisonScores = new Dictionary<string, int>();

        var graveyardScores = new Dictionary<string, int>();

        var the_logScores = new Dictionary<string, int>();

        var tornadoScores = new Dictionary<string, int>();

        var cloneScores = new Dictionary<string, int>();

        var earthquakeScores = new Dictionary<string, int>();

        var barbarian_barrelScores = new Dictionary<string, int>();

        var giant_snowballScores = new Dictionary<string, int>();

        var royal_deliveryScores = new Dictionary<string, int>();

        var cannon_Scores = new Dictionary<string, int>();

        var goblin_hutScores = new Dictionary<string, int>();

        var mortarScores = new Dictionary<string, int>();

        var inferno_towerScores = new Dictionary<string, int>();

        var bomb_towerScores = new Dictionary<string, int>();

        var barbarian_hutScores = new Dictionary<string, int>();

        var teslaScores = new Dictionary<string, int>();

        var elixir_collectorScores = new Dictionary<string, int>();

        var xbowScores = new Dictionary<string, int>();

        var tombstoneScores = new Dictionary<string, int>();

        var furnaceScores = new Dictionary<string, int>();

        var goblin_cageScores = new Dictionary<string, int>();

        var goblin_drillScores = new Dictionary<string, int>();


        var cardScores = new Dictionary<string, Dictionary<string, int>>()
        {
            { "Knight", knightScores } ,
            { "Archers", archersScores } ,
            { "Goblins", goblinsScores } ,
            { "Giant", giantScores } ,
            { "P.E.K.K.A", pekkaScores } ,
            { "Minions", minionsScores } ,
            { "Ballon", ballonScores } ,
            { "Witch", witchScores } ,
            { "Barbarians", barbariansScores } ,
            { "Golem", golemScores } ,
            { "Skeletons", skeletonsScores } ,
            { "Valkyrie", valkyrieScores } ,
            { "Skeleton Army", skeleton_armyScores } ,
            { "Bomber", bomberScores } ,
            { "Musketeer", musketeerScores } ,
            { "Baby Dragon", baby_dragonScores } ,
            { "Prince", princeScores } ,
            { "Wizard", wizardScores } ,
            { "Mini P.E.K.K.A", mini_pekkaScores } ,
            { "Spear Goblins", spear_goblinsScores } ,
            { "Giant Skeleton", giant_skeletonScores } ,
            { "Hog Rider", hog_riderScores } ,
            { "Minion Horde", minion_hordeScores } ,
            { "Ice Wizard", ice_wizardScores } ,
            { "Royal Giant", royal_giantScores } ,
            { "Guards", guardsScores } ,
            { "Princess", princessScores } ,
            { "Dark Prince", dark_princeScores } ,
            { "Three Musketeer", three_musketeerScores } ,
            { "Lava Hound", lava_houndScores } ,
            { "Ice Spirit", ice_spiritScores } ,
            { "Fire Spirit", fire_spiritScores } ,
            { "Miner", minerScores } ,
            { "Sparky", sparkyScores } ,
            { "Bowler", bowlerScores } ,
            { "Lumberjack", lumberjackScores } ,
            { "Battle Ram", battle_ramScores } ,
            { "Inferno Dragon", inferno_dragonScores } ,
            { "Ice Golem", ice_golemScores } ,
            { "Mega Minion", mega_minionScores } ,
            { "Dart Goblin", dart_goblinScores } ,
            { "Goblin Gang", goblin_gangScores } ,
            { "Electro Wizard", electro_wizardScores } ,
            { "Elite Barbarians", elite_barbariansScores } ,
            { "Hunter", hunterScores } ,
            { "Executioner", executionerScores } ,
            { "Bandit", banditScores } ,
            { "Royal Recruits", royal_recruitsScores } ,
            { "Night Witch", night_witchScores } ,
            { "Bats", batsScores } ,
            { "Royal Ghost", royal_ghostScores } ,
            { "Ram Rider", ram_riderScores } ,
            { "Zappies", zappiesScores } ,
            { "Rascals", rascalsScores } ,
            { "Cannon Cart", cannon_cartScores } ,
            { "Mega Knight", mega_knightScores } ,
            { "Skeleton Barrel", skeleton_barrelScores } ,
            { "Flying Machine", flying_machineScores } ,
            { "Wall Breakers", wall_breakersScores } ,
            { "Royal Hogs", royal_hogsScores } ,
            { "Goblin Giant", goblin_giantScores } ,
            { "Fisherman", fishermanScores } ,
            { "Magic Archer", magic_archerScores } ,
            { "Electro Dragon", electro_dragonScores } ,
            { "Firecracker", firecrackerScores } ,
            { "Mighty Miner", mighty_minerScores } ,
            { "Elixir Golem", elixir_golemScores } ,
            { "Battle Healer", battle_healerScores } ,
            { "Skeleton King", skeleton_kingScores } ,
            { "Archer Queen", archer_queenScores } ,
            { "Golden Knight", golden_knightScores } ,
            { "Monk", monkScores } ,
            { "Skeleton Dragons", skeleton_dragonsScores } ,
            { "Mother Witch", mother_witchScores } ,
            { "Electro Spirit", electro_spiritScores } ,
            { "Electro Giant", electro_giantScores } ,
            { "Phoenix", phoenixScores } ,
            { "Heal Spirit", heal_spiritScores } ,
            { "FireBall", fireballScores } ,
            { "Arrows", arrowsScores } ,
            { "Rage", rageScores } ,
            { "Rocket", rocketScores } ,
            { "Goblin Barrel", goblin_barrelScores } ,
            { "Freeze", freezeScores } ,
            { "Mirror", mirrorScores } ,
            { "Lightning", lightningScores } ,
            { "Zap", zapScores } ,
            { "Poison", poisonScores } ,
            { "Graveyard", graveyardScores } ,
            { "The Log", the_logScores } ,
            { "Tornado", tornadoScores } ,
            { "Clone", cloneScores } ,
            { "Earthquake", earthquakeScores } ,
            { "Barbarian Barrel", barbarian_barrelScores } ,
            { "Giant Snowball", giant_snowballScores } ,
            { "Royal Delivery", royal_deliveryScores } ,
            { "Cannon", cannon_Scores } ,
            { "Goblin Hut", goblin_hutScores } ,
            { "Mortar", mortarScores } ,
            { "Inferno Tower", inferno_towerScores } ,
            { "Bomb Tower", bomb_towerScores } ,
            { "Barbarian Hut", barbarian_hutScores } ,
            { "Tesla", teslaScores } ,
            { "Elixir Collector", elixir_collectorScores } ,
            { "X-Bow", xbowScores } ,
            { "Tombstone", tombstoneScores } ,
            { "Furnace", furnaceScores } ,
            { "Goblin Cage", goblin_cageScores } ,
            { "Goblin Drill", goblin_drillScores }
        };
        
        return cardScores;
    }
}