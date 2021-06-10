﻿using TEDinc.MatchInvaders.GameLogic;
namespace TEDinc.MatchInvaders
{
    public static class GameConst
    {
        public static readonly IUnitModel MockUnit = new MockUnitModel();
        public const int MaxEnenmyGroupsCount = 4;
        // TODO : remove everything below from here to config file
        public static class Player
        {
            public static readonly int MaxHealth = 3;
            public static readonly int MoveSpeed = 200;
        }

        public static class Enemy
        {
            public static readonly int MaxHealth = 1;
            public static readonly int GroupCount = 4;
        }

        public static class Protector
        {
            public static readonly int MaxHealth = 5;
        }
    }
}