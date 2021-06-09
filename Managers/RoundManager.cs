using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Spymongus.Models;

namespace Spymongus.Managers
{
    class RoundManager
    {
        private static string _fileName = "round.xml";

        public List<Round> NewRound { get; set; }

        public List<Round> Round { get; set; }

        public RoundManager()
            : this(new List<Round>())
        {

        }

        public RoundManager(List<Round> rounds)
        {
            Round = rounds;

            AddNextRound();
        }

        public void Add(Round round)
        {
            Round.Add(round);

            Round = Round.OrderByDescending(c => c.Value).ToList();

            AddNextRound();
        }

        public static RoundManager Load()
        {
            if (!File.Exists(_fileName))
                return new RoundManager();

            using (var reader = new StreamReader(new FileStream(_fileName, FileMode.Open)))
            {
                var seriliser = new XmlSerializer(typeof(List<Round>));

                var rounds = (List<Round>)seriliser.Deserialize(reader);

                return new RoundManager(rounds);
            }
        }

        public void AddNextRound()
        {
            NewRound = Round.Take(5).ToList();
        }

        public static void save(RoundManager roundManager)
        {
            //Override the file if it already exists
            using (var writer = new StreamWriter(new FileStream(_fileName, FileMode.Create)))
            {
                //Version serilizer = new XmlSerializer(type);
            }
        }
    }
}
