﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News_Notice_Headlines
{
    public class headlines {
        List<properNoun> properNouns = new List<properNoun>();
        properNoun properNoun = null;
        verb verb = null;
        noun noun = null;
        adjective adjective = null;
        string[] headline = new string[4];
        public headlines() {
            Random choice = new Random();
            properNoun = properNouns[choice.Next(properNouns.Count)];
            verb = properNoun.verbChoice();
            noun = nounChoice();
            adjective = noun.adjectiveChoice();
        }
        private noun nounChoice() {
            List<noun> commonNouns = new List<noun>();
            foreach (noun properNoun in properNoun.nouns) {
                foreach(noun verbNoun in verb.nouns) {
                    if (verbNoun.Equals(properNoun))
                        commonNouns.Add(verbNoun);
                }
            }
            Random choice = new Random();
            return commonNouns[choice.Next(commonNouns.Count)];
        }
        public string getHeadline() {
            headline[0] = properNoun.word;
            headline[1] = verb.word;
            headline[2] = adjective.word;
            headline[3] = noun.word;

            return headline.ToString();
        }
    }
    class properNoun {
        public string word;
        List<verb> verbs = new List<verb>();
        public List<noun> nouns = new List<noun>();
        int good;
        int viewers;
        int chaos;
        public properNoun(string word, int good, int viwers, int chaos) {
            this.word = word ;
            this.good = good;
            this.viewers = viwers;
            this.chaos = chaos;
        }
       public verb verbChoice() {
            Random choice = new Random();
            return verbs[choice.Next(verbs.Count)];
        }
        public noun nounChoice() {
            Random choice = new Random();
            return nouns[choice.Next(nouns.Count)];
        }
        public void addVerb(verb verb) {
            verbs.Add(verb);
        }
        public void addNoun(noun noun) {
            nouns.Add(noun);
        }
    }
    class verb {
        public string word;
        public List<noun> nouns = new List<noun>();
        int good;
        int viewers;
        int chaos;
        public verb(string word, int good, int viewers, int chaos) {
            this.word = word;
            this.good = good;
            this.viewers = viewers;
            this.chaos = chaos;
        }
        public noun nounChoice() {
            Random choice = new Random();
            return nouns[choice.Next(nouns.Count)];
        }
        public void addNoun(noun noun) {
            nouns.Add(noun);
        }
    }
    class noun {
        public string word;
        List<adjective> adjectives = new List<adjective>();
        int good;
        int viewers;
        int chaos;
        public noun(string word, int good, int viewers, int chaos) {
            this.word = word;
            this.good = good;
            this.viewers = viewers;
            this.chaos = chaos;
        }
        public adjective adjectiveChoice() {
            Random choice = new Random();
            return adjectives[choice.Next(adjectives.Count)];
        }
        public void addAdjective(adjective adjective) {
            adjectives.Add(adjective);
        }
    }
    class adjective {
        public string word;
        int good;
        int viewers;
        int chaos;
        public adjective(string word, int good, int viewers, int chaos) {
            this.word = word;
            this.good = good;
            this.viewers = viewers;
            this.chaos = chaos;
        }
    }
     class initialize {
        public void verbs() {

        }
        public void nouns() {

        }
        public void adjectives() {

        }
        public void propernouns() {
            properNoun america = new properNoun("America", 1, 1000, -100);
        }
    }
}
