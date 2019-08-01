using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> characters;
        private List<Item> items;
        private int rounds;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }
       

        public string JoinParty(string[] args)
        {
            string faction = args[1];
            string characterType = args[2];
            string name = args[3];


            if (!Enum.TryParse(faction, out Faction factionResult))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            characterType = characterType.ToLower();

            Character character;

            if (characterType == "warrior")
            {
                character = new Warrior(name, factionResult);
            }
            else if (characterType == "cleric")
            {
                character = new Cleric(name, factionResult);
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            this.characters.Add(character);

            string result = $"{name} joined the party!";
            return result;
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[1];

            Item item;
            string itemNameTolower = itemName.ToLower();

            if (itemNameTolower == "healthpotion")
            {
                item = new HealthPotion();
            }
            else if (itemNameTolower == "armorrepairkit")
            {
                item = new ArmorRepairKit();
            }
            else if (itemNameTolower == "poisonpotion")
            {
                item = new PoisonPotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            this.items.Add(item);

            string result = $"{itemName} added to pool.";
            return result;
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[1];

            Character character = this.characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = this.items[this.items.Count - 1];
            this.items.RemoveAt(this.items.Count - 1);

            character.ReceiveItem(item);

            string result = $"{characterName} picked up {item.GetType().Name}!";
            return result;
        }

        public string UseItem(string[] args)
        {
            string characterName = args[1];
            string itemName = args[2];

            Character character = this.characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            character.UseItem(character.Bag.GetItem(itemName));

            string result = $"{characterName} used {itemName}.";
            return result;
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[1];
            string receiverName = args[2];
            string itemName = args[3];

            Character giverCharacter = this.characters.FirstOrDefault(x => x.Name == giverName);
            Character receiverCharacter = this.characters.FirstOrDefault(x => x.Name == receiverName);

            if (giverCharacter == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            else if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Item item = giverCharacter.Bag.GetItem(itemName);

            giverCharacter.UseItemOn(item, receiverCharacter);

            string result = $"{giverName} used {itemName} on {receiverName}.";
            return result;
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[1];
            string receiverName = args[2];
            string itemName = args[3];

            Character giverCharacter = this.characters.FirstOrDefault(x => x.Name == giverName);
            Character receiverCharacter = this.characters.FirstOrDefault(x => x.Name == receiverName);

            if (giverCharacter == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            else if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Item item = giverCharacter.Bag.GetItem(itemName);

            giverCharacter.GiveCharacterItem(item, receiverCharacter);

            string result = $"{giverName} gave {receiverName} {itemName}.";
            return result;
        }

        public string GetStats()
        {
            List<Character> sortedCharacters = this.characters
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health)
                .ToList();

            List<string> results = new List<string>();

            foreach (Character character in sortedCharacters)
            {
                string status = character.IsAlive ? "Alive" : "Dead";

                results.Add($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

            string result = string.Join(Environment.NewLine, results);
            return result;
        }

        public string Attack(string[] args)
        {
            string attackerName = args[1];
            string receiverName = args[2];

            Character attackerCharacter = this.characters.FirstOrDefault(x => x.Name == attackerName);
            Character receiverCharacter = this.characters.FirstOrDefault(x => x.Name == receiverName);

            if (attackerCharacter == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            else if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (attackerCharacter is Cleric)
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            ((Warrior)attackerCharacter).Attack(receiverCharacter);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{attackerName} attacks {receiverName} for {attackerCharacter.AbilityPoints} hit points! {receiverName} has {receiverCharacter.Health}/{receiverCharacter.BaseHealth} HP and {receiverCharacter.Armor}/{receiverCharacter.BaseArmor} AP left!");

            if (receiverCharacter.IsAlive == false)
            {
                sb.AppendLine($"{receiverName} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[1];
            string healingReceiverName = args[2];

            Character healerCharacter = this.characters.FirstOrDefault(x => x.Name == healerName);
            Character healerReceiverCharacter = this.characters.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healerCharacter == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            else if (healerReceiverCharacter == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (healerCharacter is Warrior)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            ((Cleric)healerCharacter).Heal(healerReceiverCharacter);

            string result = $"{healerName} heals {healingReceiverName} for {healerCharacter.AbilityPoints}! {healingReceiverName} has {healerReceiverCharacter.Health} health now!";
            return result;
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in this.characters.Where(x => x.IsAlive))
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (this.characters.Count(x => x.IsAlive) <= 1)
            {
                this.rounds++;
            }

            return sb.ToString().TrimEnd();

        }

        public bool IsGameOver()
        {
            if (this.rounds > 1)
            {
                return true;
            }

            return false;
        }

    }
}
