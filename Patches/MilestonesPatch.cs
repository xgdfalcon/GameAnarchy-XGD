using System.Collections.Generic;
using System.Linq;
using ICities;

namespace GameAnarchy.Patches {
    public class MilestonesPatch : MilestonesExtensionBase {
        public override void OnRefreshMilestones() {
            if (GAMod.IsUnlockAll) {
                milestonesManager.UnlockMilestone("Basic Road Created");
                milestonesManager.UnlockMilestone("Train Track Requirements");
                milestonesManager.UnlockMilestone("Metro Track Requirements");

                milestonesManager.UnlockMilestone("Space Elevator Requirements");
                milestonesManager.UnlockMilestone("Eden Project Requirements");
                milestonesManager.UnlockMilestone("Fusion Power Plant Requirements");
                milestonesManager.UnlockMilestone("Medical Center Requirements");
                milestonesManager.UnlockMilestone("Hadron Collider Requirements");
                milestonesManager.UnlockMilestone("Doomsday Vault Requirements");
                milestonesManager.UnlockMilestone("Ultimate Recycling Plant Requirements");
                milestonesManager.UnlockMilestone("Chirpwick Castle Requirements");

                managers.application.SupportsExpansion(Expansion.Campuses);
                milestonesManager.UnlockMilestone("Campus Main Building Requirements");
                milestonesManager.UnlockMilestone("TradeSchool Requirements 1");
                milestonesManager.UnlockMilestone("TradeSchool Requirements 2");
                milestonesManager.UnlockMilestone("TradeSchool Requirements 3");
                milestonesManager.UnlockMilestone("TradeSchool Requirements 4");
                milestonesManager.UnlockMilestone("TradeSchool Requirements 5");
                milestonesManager.UnlockMilestone("LiberalArts Requirements 1");
                milestonesManager.UnlockMilestone("LiberalArts Requirements 2");
                milestonesManager.UnlockMilestone("LiberalArts Requirements 3");
                milestonesManager.UnlockMilestone("LiberalArts Requirements 4");
                milestonesManager.UnlockMilestone("LiberalArts Requirements 5");
                milestonesManager.UnlockMilestone("University Requirements 1");
                milestonesManager.UnlockMilestone("University Requirements 2");
                milestonesManager.UnlockMilestone("University Requirements 3");
                milestonesManager.UnlockMilestone("University Requirements 4");
                milestonesManager.UnlockMilestone("University Requirements 5");

                managers.application.SupportsExpansion(Expansion.Parks);
                milestonesManager.UnlockMilestone("Park Gate Requirements");
                milestonesManager.UnlockMilestone("City Park Requirements 1");
                milestonesManager.UnlockMilestone("City Park Requirements 2");
                milestonesManager.UnlockMilestone("City Park Requirements 3");
                milestonesManager.UnlockMilestone("City Park Requirements 4");
                milestonesManager.UnlockMilestone("City Park Requirements 5");
                milestonesManager.UnlockMilestone("Amusement Park Requirements 1");
                milestonesManager.UnlockMilestone("Amusement Park Requirements 2");
                milestonesManager.UnlockMilestone("Amusement Park Requirements 3");
                milestonesManager.UnlockMilestone("Amusement Park Requirements 4");
                milestonesManager.UnlockMilestone("Amusement Park Requirements 5");
                milestonesManager.UnlockMilestone("Nature Reserve Requirements 1");
                milestonesManager.UnlockMilestone("Nature Reserve Requirements 2");
                milestonesManager.UnlockMilestone("Nature Reserve Requirements 3");
                milestonesManager.UnlockMilestone("Nature Reserve Requirements 4");
                milestonesManager.UnlockMilestone("Nature Reserve Requirements 5");
                milestonesManager.UnlockMilestone("Zoo Requirements 1");
                milestonesManager.UnlockMilestone("Zoo Requirements 2");
                milestonesManager.UnlockMilestone("Zoo Requirements 3");
                milestonesManager.UnlockMilestone("Zoo Requirements 4");
                milestonesManager.UnlockMilestone("Zoo Requirements 5");

                milestonesManager.UnlockMilestone("Main Building Requirements");
                milestonesManager.UnlockMilestone("Farming Requirements 1");
                milestonesManager.UnlockMilestone("Farming Requirements 2");
                milestonesManager.UnlockMilestone("Farming Requirements 3");
                milestonesManager.UnlockMilestone("Farming Requirements 4");
                milestonesManager.UnlockMilestone("Farming Requirements 5");
                milestonesManager.UnlockMilestone("Forestry Requirements 1");
                milestonesManager.UnlockMilestone("Forestry Requirements 2");
                milestonesManager.UnlockMilestone("Forestry Requirements 3");
                milestonesManager.UnlockMilestone("Forestry Requirements 4");
                milestonesManager.UnlockMilestone("Forestry Requirements 5");
                milestonesManager.UnlockMilestone("Oil Requirements 1");
                milestonesManager.UnlockMilestone("Oil Requirements 2");
                milestonesManager.UnlockMilestone("Oil Requirements 3");
                milestonesManager.UnlockMilestone("Oil Requirements 4");
                milestonesManager.UnlockMilestone("Oil Requirements 5");
                milestonesManager.UnlockMilestone("Ore Requirements 1");
                milestonesManager.UnlockMilestone("Ore Requirements 2");
                milestonesManager.UnlockMilestone("Ore Requirements 3");
                milestonesManager.UnlockMilestone("Ore Requirements 4");
                milestonesManager.UnlockMilestone("Ore Requirements 5");

                managers.application.SupportsExpansion(Expansion.Urban);
                milestonesManager.UnlockMilestone("Fishing Boat Harbor 02 Requirements");
                milestonesManager.UnlockMilestone("Fishing Boat Harbor 03 Requirements");
                milestonesManager.UnlockMilestone("Fishing Boat Harbor 04 Requirements");
                milestonesManager.UnlockMilestone("Fishing Boat Harbor 05 Requirements");
                milestonesManager.UnlockMilestone("Fish Farm 02 Requirements");
                milestonesManager.UnlockMilestone("Fish Farm 03 Requirements");

                managers.application.SupportsExpansion(Expansion.Airport);
                milestonesManager.UnlockMilestone("Airport Requirements 1");
                milestonesManager.UnlockMilestone("Airport Requirements 2");
                milestonesManager.UnlockMilestone("Airport Requirements 3");
                milestonesManager.UnlockMilestone("Airport Terminal Requirements");

                milestonesManager.UnlockMilestone("Milestone" + 13);
            }

            //if (GAMod.EnabledUnlockDeluxeLandmarks) {
            //    UnlockBuildingsSet("UnlockDeluxeLandmarks", new string[5]
            //     { "Eiffel Tower", "Statue of Liberty", "Grand Central Terminal", "Brandenburg Gate", "Arc de Triomphe", }, "Requirements");
            //}
            //if (GAMod.EnabledUnlockUniqueBuildings) {
            //    milestonesManager.UnlockMilestone("Basic Road Created");
            //    UnlockBuildingsSet("UnlockUniqueBuildings", new string[30] { 
            //        //UB-I
            //        "Statue of Industry", "Statue of Wealth", "Lazaret Plaza", "Statue of Shopping", "Plaza of the Dead",
            //        //UB-II
            //        "Fountain of LifeDeath", "Friendly Neighborhood", "Transport Tower", "Trash Mall", "Posh Mall",
            //        //UB-III
            //        "Colossal Offices", "Official Park", "CourtHouse", "Grand Mall", "Cityhall",
            //        //UB-IV
            //        "Business Park", "Library", "Observatory", "Opera House", "Oppression Office",
            //        //UB-V
            //        "ScienceCenter", "Servicing Services", "SeaWorld", "Expocenter", "High Interest Tower",
            //        //UB-VI
            //        "Cathedral of Plentitude", "Stadium", "Modern Art Museum", "SeaAndSky Scraper", "Theater of Wonders", 
            //     }, "Requirements");
            //    UnlockBuildingsSet("UnlockUniqueBuildings", new string[2] {
            //        "Academic Library", "Aviation Club", 
            //     }, "Prerequisites");
            //}
            //if (GAMod.EnabledUnlockWonders) {
            //    UnlockBuildingsSet("UnlockWonders", new string[5]
            //     { "Hadron Collider", "Medical Center", "Space Elevator", "Eden Project", "Fusion Power Plant", }, "Requirements");
            //}
            //if (GAMod.EnabledUnlockEuropeanLandmarks) {
            //    UnlockBuildingsSet("UnlockEuropeanLandmarks", new string[12]
            //     { "Arena", "Shopping Center", "Theatre", "London Eye", "Cinema", "City Hall", "Amsterdam Palace", "Cathedral", "Government Offices", "Hypermarket", "Department Store", "Gherkin", }, "Requirements");
            //}
            //if (GAMod.EnabledUnlockAfterDarkLandmarks) {
            //    managers.application.SupportsExpansion(Expansion.AfterDark);
            //    UnlockBuildingsSet("UnlockAfterDarkLandmarks", new string[5]
            //     { "Fancy Fountain", "Casino", "Driving Range", "Luxury Hotel", "Zoo", }, "Requirements");
            //}
            //if (GAMod.EnabledUnlockSnaowfallLandmarks) {
            //    managers.application.SupportsExpansion(Expansion.Snowfall);
            //    UnlockBuildingsSet("UnlockSnaowfallLandmarks", new string[10]
            //     { "Ice Hockey Arena", "Sleigh Ride", "Spa Hotel", "Snowcastle Restaurant", "Ski Resort", "Santa Claus Workshop", "Christmas Tree", "Arena",
            //      "Driving Range", "Igloo Hotel", }, "Requirements");
            //}
            //if (GAMod.EnabledUnlockNaturalDisastersLandmarks) {
            //    managers.application.SupportsExpansion(Expansion.NaturalDisasters);
            //    UnlockBuildingsSet("UnlockNaturalDisastersLandmarks", new string[7]
            //     { "Unicorn Park", "Sphinx Of Scenarios", "Pyramid Of Safety",  "Doomsday Vault", "Disaster Memorial", "Helicopter Park", "Meteor Park",}, "Requirements");
            //}
            //if (GAMod.EnabledUnlockMassTransitLandmarks) {
            //    managers.application.SupportsExpansion(Expansion.InMotion);
            //    UnlockBuildingsSet("UnlockMassTransitLandmarks", new string[3]
            //     { "Boat Museum", "Traffic Park", "Steam Train",}, "Requirements");
            //}
            //if (GAMod.EnabledUnlockGreenCitiesLandmarks) {
            //    managers.application.SupportsExpansion(Expansion.GreenCities);
            //    UnlockBuildingsSet("UnlockGreenCitiesLandmarks", new string[7]
            //     { "Bird And Bee Haven", "Floating Gardens", "Central Park", "Ziggurat Garden", "Climate Research Station", "Lungs of the City", "Ultimate Recycling Plant",}, "Requirements");
            //}
            //if (GAMod.EnabledUnlockConcertsLandmarks) {
            //    UnlockBuildingsSet("UnlockConcertsLandmarks", new string[4]
            //     { "Festival Fan Zone",  "Broadcasting Studios", "Live Music Venue", "Festival Area",}, "Requirements");
            //}
            //if (GAMod.EnabledUnlockParklifeLandmarks) {
            //    managers.application.SupportsExpansion(Expansion.Parks);
            //    milestonesManager.UnlockMilestone("Park Gate Requirements");
            //    milestonesManager.UnlockMilestone("City Park Requirements 1");
            //    milestonesManager.UnlockMilestone("City Park Requirements 2");
            //    milestonesManager.UnlockMilestone("City Park Requirements 3");
            //    milestonesManager.UnlockMilestone("City Park Requirements 4");
            //    milestonesManager.UnlockMilestone("City Park Requirements 5");
            //    milestonesManager.UnlockMilestone("Amusement Park Requirements 1");
            //    milestonesManager.UnlockMilestone("Amusement Park Requirements 2");
            //    milestonesManager.UnlockMilestone("Amusement Park Requirements 3");
            //    milestonesManager.UnlockMilestone("Amusement Park Requirements 4");
            //    milestonesManager.UnlockMilestone("Amusement Park Requirements 5");
            //    milestonesManager.UnlockMilestone("Nature Reserve Requirements 1");
            //    milestonesManager.UnlockMilestone("Nature Reserve Requirements 2");
            //    milestonesManager.UnlockMilestone("Nature Reserve Requirements 3");
            //    milestonesManager.UnlockMilestone("Nature Reserve Requirements 4");
            //    milestonesManager.UnlockMilestone("Nature Reserve Requirements 5");
            //    milestonesManager.UnlockMilestone("Zoo Requirements 1");
            //    milestonesManager.UnlockMilestone("Zoo Requirements 2");
            //    milestonesManager.UnlockMilestone("Zoo Requirements 3");
            //    milestonesManager.UnlockMilestone("Zoo Requirements 4");
            //    milestonesManager.UnlockMilestone("Zoo Requirements 5");
            //    UnlockBuildingsSet("UnlockParklifeLandmarks", new string[7]
            //        { "City Arch", "Clock Tower", "Old Market Street", "Sea Fortress", "Observation Tower", "Statue Of Colossalus", "",
            //        }, "Requirements");
            //}
            //if (GAMod.EnabledUnlockIndustriesLandmarks) {
            //    milestonesManager.UnlockMilestone("Main Building Requirements");
            //    milestonesManager.UnlockMilestone("Farming Requirements 1");
            //    milestonesManager.UnlockMilestone("Farming Requirements 2");
            //    milestonesManager.UnlockMilestone("Farming Requirements 3");
            //    milestonesManager.UnlockMilestone("Farming Requirements 4");
            //    milestonesManager.UnlockMilestone("Farming Requirements 5");
            //    milestonesManager.UnlockMilestone("Forestry Requirements 1");
            //    milestonesManager.UnlockMilestone("Forestry Requirements 2");
            //    milestonesManager.UnlockMilestone("Forestry Requirements 3");
            //    milestonesManager.UnlockMilestone("Forestry Requirements 4");
            //    milestonesManager.UnlockMilestone("Forestry Requirements 5");
            //    milestonesManager.UnlockMilestone("Oil Requirements 1");
            //    milestonesManager.UnlockMilestone("Oil Requirements 2");
            //    milestonesManager.UnlockMilestone("Oil Requirements 3");
            //    milestonesManager.UnlockMilestone("Oil Requirements 4");
            //    milestonesManager.UnlockMilestone("Oil Requirements 5");
            //    milestonesManager.UnlockMilestone("Ore Requirements 1");
            //    milestonesManager.UnlockMilestone("Ore Requirements 2");
            //    milestonesManager.UnlockMilestone("Ore Requirements 3");
            //    milestonesManager.UnlockMilestone("Ore Requirements 4");
            //    milestonesManager.UnlockMilestone("Ore Requirements 5");
            //}
            //if (GAMod.EnabledUnlockCampusLandmarks) {
            //    managers.application.SupportsExpansion(Expansion.Campuses);
            //    milestonesManager.UnlockMilestone("Campus Main Building Requirements");
            //    milestonesManager.UnlockMilestone("TradeSchool Requirements 1");
            //    milestonesManager.UnlockMilestone("TradeSchool Requirements 2");
            //    milestonesManager.UnlockMilestone("TradeSchool Requirements 3");
            //    milestonesManager.UnlockMilestone("TradeSchool Requirements 4");
            //    milestonesManager.UnlockMilestone("TradeSchool Requirements 5");
            //    milestonesManager.UnlockMilestone("LiberalArts Requirements 1");
            //    milestonesManager.UnlockMilestone("LiberalArts Requirements 2");
            //    milestonesManager.UnlockMilestone("LiberalArts Requirements 3");
            //    milestonesManager.UnlockMilestone("LiberalArts Requirements 4");
            //    milestonesManager.UnlockMilestone("LiberalArts Requirements 5");
            //    milestonesManager.UnlockMilestone("University Requirements 1");
            //    milestonesManager.UnlockMilestone("University Requirements 2");
            //    milestonesManager.UnlockMilestone("University Requirements 3");
            //    milestonesManager.UnlockMilestone("University Requirements 4");
            //    milestonesManager.UnlockMilestone("University Requirements 5");
            //}
            //if (GAMod.EnabledUnlockSunsetHarborLandmarks) {
            //    managers.application.SupportsExpansion(Expansion.Urban);
            //    milestonesManager.UnlockMilestone("Fishing Boat Harbor 02 Requirements");
            //    milestonesManager.UnlockMilestone("Fishing Boat Harbor 03 Requirements");
            //    milestonesManager.UnlockMilestone("Fishing Boat Harbor 04 Requirements");
            //    milestonesManager.UnlockMilestone("Fishing Boat Harbor 05 Requirements");
            //    milestonesManager.UnlockMilestone("Fish Farm 02 Requirements");
            //    milestonesManager.UnlockMilestone("Fish Farm 03 Requirements");
            //}
            //if (GAMod.EnabledUnlockAirportsLandmarks) {
            //    managers.application.SupportsExpansion(Expansion.Airport);
            //    milestonesManager.UnlockMilestone("Airport Requirements 1");
            //    milestonesManager.UnlockMilestone("Airport Requirements 2");
            //    milestonesManager.UnlockMilestone("Airport Requirements 3");
            //    milestonesManager.UnlockMilestone("Airport Terminal Requirements");
            //}

        }


        //public override int OnGetPopulationTarget(int originalTarget, int scaledTarget) {
        //    if (GAMod.EnabledUnlockUniqueBuildings) return 0;
        //    return base.OnGetPopulationTarget(originalTarget, scaledTarget);
        //}

        //private void UnlockBuildingsSet(string set, IEnumerable<string> buildingNames, string suffix = "Requirements") {
        //    foreach (string name in buildingNames) {
        //        UnlockBuilding(name, suffix);
        //    }
        //}

        //private void UnlockBuilding(string buildingName, string suffix) {
        //    string name = buildingName + " " + suffix;
        //    if (!((IEnumerable<string>)milestonesManager.EnumerateMilestones()).Contains<string>(name))
        //        return;
        //    milestonesManager.UnlockMilestone(name);
        //}





    }
}
