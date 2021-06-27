using System.IO;

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace Program
{
    static class Database
    {
        private const string JSON_FILE = "database.json";
        private static List<Model> Models;

        async public static Task Load()
        {
            List<Model> models;

            using (FileStream fs = new FileStream(JSON_FILE, FileMode.Open))
            {
                models = await JsonSerializer.DeserializeAsync<List<Model>>(fs);
            }

            Models = models;
        }

        async public static void Create(Model model)
        {
            Models.Add(model);

            using (FileStream fs = new FileStream(JSON_FILE, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<Model>>(fs, Models);
            };

        }

        public static List<Model> All()
        {
            return Models;
        }

        public static Model Find(int id)
        {
            Model found = null;

            foreach (Model model in Models)
            {
                if (model.Id == id)
                    found = model;
            }

            return found;
        }

        public static List<Model> SearchByTitle(string title)
        {
            var foundModels = Models.Where(
                model => model.Title.ToLower().IndexOf(title.ToLower()) != -1
            );

            return foundModels.ToList();
        }

        public static Model Last()
        {
            if(Models.Count == 0)
                return null;

            return Models[Models.Count - 1];
        }

        public static int GetUniqueID()
        {
            Model lastModel = Last();

            return lastModel != null ? lastModel.Id + 1 : 1;
        }
    }
}
