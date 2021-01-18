using System;
using System.Collections.Generic;
using ServerGame.DataBase;
using ServerGame.Models;

namespace ServerGame.Services
{
    public class GameService
    {

        private MemoryDBGame memoryDB;

        public GameService()
        {
            memoryDB = MemoryDBGame.Instance;
        }

        public void Save(GameResultModel model)
        {
            memoryDB.AddGameResult(model);
        }
    }
}
